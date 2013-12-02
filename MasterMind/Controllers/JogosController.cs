using Infraestrutura.Repositorios.Entidades;
using Infraestrutura.Repositorios.Entidades.DTO;
using Infraestrutura.Repositorios.Implementacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;


namespace MasterMind.Controllers
{
    public class JogosController : Controller
    {
        public ActionResult List()
        {
            GenericoRep<Jogos> repositorio = new GenericoRep<Jogos>();
            IEnumerable<Jogos> jogos = new List<Jogos>();
            jogos = repositorio.ObterTodos();
            return View(jogos);
        }

        [HttpGet]
        public ActionResult Delete(Int32 Id)
        {
            GenericoRep<Jogos> repositorio = new GenericoRep<Jogos>();
            Jogos jogos = repositorio.ObterPorId(Id);
            return View(jogos);
        }
        [HttpPost]
        public ActionResult Delete(Jogos jogos)
        {
            GenericoRep<Jogos> repositorio = new GenericoRep<Jogos>();
            repositorio.Excluir(jogos);
            return RedirectToAction("List", "Salas");
        }

        [HttpGet]
        public ActionResult Sala_Espera(Int32 Id_Sala, Int32? id_selecionado)
        {
            int TempoRestante = 100;

            JogosRep jogoRep = new JogosRep();
            IEnumerable<Jogos> partida = jogoRep.ObterPorIdSala(Id_Sala);
            ViewBag.Partida = partida;
            Jogos jogador = partida.Where(x => x.Usuario.Id_user == WebSecurity.GetUserId(User.Identity.Name)).ElementAt(0);
            ViewBag.jogador = jogador;

            if ((id_selecionado != 0) && (id_selecionado != null)) ViewBag.selecionado = id_selecionado; //Verifica se o usuário clicou no div para ver detalhes de um jogador
            else ViewBag.selecionado = null;

            if (partida.Count() >= 2) // se existem mais de dois jogadores na sala de espera
            {
                IEnumerable<Jogos> prontos = partida.Where(x => x.DataEntradaSala != null).OrderBy(x => x.DataEntradaSala);

                if (prontos.Count() >= 2) // se pelo menos 2 deles selecionou "estou pronto" e tem mais que um na sala
                {                         //evita que o primeiro dê como pronto e o segundo só vá entrar na sala de espera 10min depois, aí ele estava sendo jogado direto para o tabuleiro
                                          //mudei para que a contagem necessite de dois jogadores prontos, assim pelo menos 2 vão passar pela tela de espera.
                    TempoRestante = 1 - DateTime.Now.Subtract(DateTime.Parse(prontos.ElementAt(1).DataEntradaSala.ToString())).Minutes;
                    ViewBag.TempoRestante = "Tempo restante para iniciar a partida " + TempoRestante.ToString() + " minutos";
                }
                else ViewBag.TempoRestante = "Não há um mínimo de jogadores confirmados para iniciar a partida";

                //Se 8 deles selecionaram "estou pronto" ou se o tempo acabou
                if ((prontos.Count() >= 8) || (TempoRestante <= 0))
                {
                    servidor_cria_sala(Id_Sala);//o servidor verifica se a sala encheu, e se a mesma for pública ele cria uma nova
                    return RedirectToAction("Partida", "Game", new { Id_Sala = Id_Sala });
                }
            }
            else ViewBag.TempoRestante = "Não há jogadores suficientes para iniciar a partida";

            Response.AddHeader("Refresh", "5");

            return View(jogador);
        }

        [HttpPost]
        public ActionResult Sala_Espera(Jogos jogo)
        {
            JogosRep jogoRep = new JogosRep();
            Jogos modelo = jogoRep.ObterPorId(jogo.Id_jogo);

            if (modelo.DataEntradaSala == null)
            {
                modelo.DataEntradaSala = DateTime.Now;
                jogoRep.Salvar(modelo);
            }
            else
            {
                modelo.DataEntradaSala = null;
                jogoRep.Salvar(modelo);
            }

            return RedirectToAction("Sala_Espera", "Jogos", new { Id_Sala = modelo.Sala.Id_Sala });
        }

        [HttpGet]
        public ActionResult _AcessoPartial(Int32 Id_jogo)
        {
            GenericoRep<Jogos> repjogo = new GenericoRep<Jogos>();
            Jogos jogos = repjogo.ObterPorId(Id_jogo);
            Temas tema = jogos.Tema;
            ViewBag.tema = tema;

            GenericoRep<Ranking> repRanking = new GenericoRep<Ranking>();
            Ranking ranking = repRanking.ObterTodos().Where(x => x.Id_User.Id_user == jogos.Usuario.Id_user).ElementAt(0);
            ViewBag.rank = ranking;

            return View();
        }

        [HttpGet]
        public ActionResult Acesso(Int32 Id, String senha)
        {

            /*Verifica se o usuário já está nesta sala e está tentando entrar de novo */
            IEnumerable<Jogos> list = new List<Jogos>();
            GenericoRep<Jogos> jogos = new GenericoRep<Jogos>();
            list = jogos.ObterTodos().Where(x => x.Sala.Id_Sala == Id);
            list = list.Where(x => x.Usuario.Id_user == WebSecurity.GetUserId(User.Identity.Name));

            if (list.Count() > 0)
            {
                ModelState.AddModelError("", "Esta sala já está completa! Por favor escolha outra sala!");
                ViewBag.ListaTemas = TemasDTO.Lista();
                return RedirectToAction("Sala_Espera", "Jogos", new { Id_Sala = list.ElementAt(0).Sala.Id_Sala });
            }
            /*-------*/

            GenericoRep<Temas> temasrep = new GenericoRep<Temas>();
            IEnumerable<Temas> ltemas = new List<Temas>();

            ltemas = temasrep.ObterTodos();

            GenericoRep<Jogos> repositorio = new GenericoRep<Jogos>();
            IEnumerable<Jogos> Jogos = new List<Jogos>();

            Jogos = repositorio.ObterTodos().Where(x => x.Sala.Id_Sala == Id);

            foreach (var i in Jogos)
            {
                ltemas = ltemas.Where(x => x.Id_tema != i.Tema.Id_tema);
            }

            ViewBag.ListaTemas = ltemas;

            Jogos model = new Jogos();
            GenericoRep<Salas> sala = new GenericoRep<Salas>();

            model.Sala = sala.ObterPorId(Id);
            model.Id_jogo = 0;

            if (senha != "") { model.Senha = senha; }


            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Acesso(Jogos model)
        {
            GenericoRep<Usuario> usuario = new GenericoRep<Usuario>();
            GenericoRep<Temas> tema = new GenericoRep<Temas>();
            GenericoRep<Salas> sala = new GenericoRep<Salas>();


            /*Verifica se no meio tempo a sala foi completada */
            IEnumerable<Jogos> list = new List<Jogos>();
            GenericoRep<Jogos> jogos = new GenericoRep<Jogos>();
            list = jogos.ObterTodos().Where(x => x.Sala.Id_Sala == model.Sala.Id_Sala);
            model.SequenciaEntradaUsuarioSala = list.Count() + 1;

            if (list.Count() > 0)
            {
                if (list.ElementAt(0).Sala.Fechada == 1)
                {
                    ModelState.AddModelError("", "Esta sala já está completa! Por favor escolha outra sala!");
                    ViewBag.ListaTemas = TemasDTO.Lista();
                    return View(model);
                }
            }

            list = list.Where(x => x.Tema.Id_tema == model.Tema.Id_tema);
            if (list.Count() > 0)
            {
                ModelState.AddModelError("", "Este tema acabou de ser escolhido. Por favor escolha outro!");
                ViewBag.ListaTemas = TemasDTO.Lista();
                return View(model);
            }
            /*-------*/

            model.Usuario = usuario.ObterPorId(WebSecurity.GetUserId(User.Identity.Name));
            model.Sala = sala.ObterPorId(model.Sala.Id_Sala);
            model.Sala.Usuario = usuario.ObterPorId(model.Sala.Id_Usuario);

            if (model.Tema.Id_tema != 0)
            {
                model.Tema = tema.ObterPorId(model.Tema.Id_tema);
                ModelState.Remove("Tema.Desc_tema");
            }
            if (ModelState.IsValid)
            {
                if (model.Senha == model.Sala.Senha)
                {
                    GenericoRep<Jogos> repositorio = new GenericoRep<Jogos>();

                    repositorio.Salvar(model);

                    return RedirectToAction("Sala_Espera", "Jogos", new { Id_Sala = model.Sala.Id_Sala });
                }

                ViewBag.ListaTemas = TemasDTO.Lista();

                ModelState.AddModelError("", "A senha para acesso à sala está incorreta");
                return View(model);
            }
            ViewBag.ListaTemas = TemasDTO.Lista();
            ModelState.AddModelError("", "Dados incorretos");
            return View(model);
        }

        private void servidor_cria_sala(Int32 id_sala)
        {
            GenericoRep<Salas> repJogos = new GenericoRep<Salas>();
            Salas lJogos = repJogos.ObterTodos().Where(x => x.Id_Sala == id_sala).ElementAt(0);

            if (lJogos.Perfil == 1)
            {
                lJogos.Fechada = 1;
                repJogos.Salvar(lJogos);

                Salas sala_new = new Salas();

                sala_new.Desc_perfil = lJogos.Desc_perfil;
                sala_new.Id_Usuario = lJogos.Id_Usuario;
                sala_new.Niveis = lJogos.Niveis;
                sala_new.Perfil = lJogos.Perfil;
                sala_new.qtde_usu = lJogos.qtde_usu;
                sala_new.Sala = lJogos.Sala;
                sala_new.Senha = lJogos.Senha;
                sala_new.Usuario = lJogos.Usuario;
                repJogos.Salvar(sala_new);

            }

        }

    }
}
