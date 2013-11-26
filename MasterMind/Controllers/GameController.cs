using Infraestrutura.Repositorios.Entidades;
using Infraestrutura.Repositorios.Entidades.DTO;
using Infraestrutura.Repositorios.Implementacao;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebMatrix.WebData;
using System.Linq;
using System.Web;

namespace MasterMind.Controllers
{
    public class GameController : Controller
    {
        //
        // GET: /Game/

        public ActionResult Principal()
        {
            Usuario usuario = new Usuario();
            GenericoRep<Usuario> usu = new GenericoRep<Usuario>();

            usuario = usu.ObterPorId(WebSecurity.GetUserId(User.Identity.Name));

            return View(usuario);
        }

        [HttpGet]
        public ActionResult Prototipo()
        {
            return View(@"~/Views/Game/Partida.aspx");
        }

        [HttpGet]
        public ActionResult Partida(Int32 Id_Sala)
        {
            ///
            /// Partida - GAMES
            ///
            JogosRep jogoRep = new JogosRep();
            IList<Jogos> partida = jogoRep.ObterPorIdSala(Id_Sala);
            ViewBag.Partida = partida;

            ///
            /// SALA 
            ///
            GenericoRep<Salas> salasRep = new GenericoRep<Salas>();
            Salas sala = salasRep.ObterPorId(Id_Sala);

            ///
            /// Pergunta Inicial
            /// 
            PerguntasRep perguntasRep = new PerguntasRep();

            IList<Perguntas> perguntas = perguntasRep.ObterPerguntas(partida[0].Tema.Id_tema);

            Random indicePergunta = new Random();

            ViewBag.PerguntaInicial = perguntas[indicePergunta.Next(0, perguntas.Count - 1)];

            ///
            /// Atualiza hora da pergunta atual do jogador
            /// 
            Jogos Jogador = partida.Where(x => x.Usuario.Id_user == WebSecurity.GetUserId(User.Identity.Name)).ElementAt(0);
            Jogador.PerguntaAtualFeitaEm = DateTime.Now;
            jogoRep.Salvar(Jogador);


            ViewBag.Jogador = partida.Where(x => x.Usuario.Id_user == WebSecurity.GetUserId(User.Identity.Name)).ElementAt(0);

            return View(@"~/Views/Game/Partida.cshtml");
        }

        public ActionResult Ranking_top()
        {
            GenericoRep<Ranking> repositorio = new GenericoRep<Ranking>();
            IEnumerable<Ranking> ranking = repositorio.ObterTodos();

            ranking = ranking.OrderByDescending(c => c.qtde_partidas_ganhas).ThenByDescending(c => c.qtde_certas).ThenBy(c => c.qtde_erradas).ToList();

            List<Ranking> aux = new List<Ranking>();

            if (ranking != null)
            {
                for (var i = 0; i <= 2 && i<=ranking.Count()-1; i++)
                {
                   aux.Add(ranking.ElementAt(i));
                }
                ViewBag.achouRanking = false;
                for (var i = 0; i <= ranking.Count() - 1; i++)
                {
                    if (ranking.ElementAt(i).Id_User.Id_user == WebSecurity.GetUserId(User.Identity.Name))
                    {
                        ViewBag.achouRanking = true;
                        ranking.ElementAt(i).Id_Ranking = i + 1;
                        aux.Add(ranking.ElementAt(i));
                    }
                }
            }
            return View(aux);
        }

        public ActionResult Ranking()
        {
            GenericoRep<Ranking> repositorio = new GenericoRep<Ranking>();
            IEnumerable<Ranking> ranking = repositorio.ObterTodos();
            ranking = ranking.OrderByDescending(c => c.qtde_partidas_ganhas).ThenByDescending(c => c.qtde_certas).ThenBy(c => c.qtde_erradas).ToList();
            return View(ranking);
        }

        public JsonResult ObterPergunta(Int32 IdTema, Int32 IdNivel)
        {
            JsonResult json = new JsonResult();

            PerguntasRep repositorio = new PerguntasRep();

            var vm = new { perguntas = repositorio.ObterPerguntas(IdTema, IdNivel) };

            json.Data = vm;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return json;
        }

        public JsonResult Responder(Int32 IdResposta)
        {
            JsonResult json = new JsonResult();

            GenericoRep<Respostas> respostaRep = new GenericoRep<Respostas>();
            Respostas resposta = respostaRep.ObterPorId(IdResposta);
            Boolean opcaoCerta = resposta.OpcaoCerta;

            atualiza_ranking(opcaoCerta);
            //atualiza_acerto_erro(opcaoCerta);

            var vm = new { opcaoCerta = opcaoCerta };

            json.Data = vm;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return json;
        }

        private void atualiza_ranking(Boolean opcaoCerta, Boolean partidaGanha = false)
        {
            GenericoRep<Ranking> rankingRep = new GenericoRep<Ranking>();
            IEnumerable<Ranking> rList = rankingRep.ObterTodos().Where(x => x.Id_User.Id_user == WebSecurity.GetUserId(User.Identity.Name));

            Ranking ranking = new Ranking();

            if (rList.Count() > 0)
                ranking = rList.ElementAt(0);
            else
            {
                GenericoRep<Usuario> UsuRep = new GenericoRep<Usuario>();
                Usuario usu = new Usuario();
                usu = UsuRep.ObterPorId(WebSecurity.GetUserId(User.Identity.Name));
                ranking.Id_User = usu;
            }

            if (opcaoCerta) ranking.qtde_certas = (ranking.qtde_certas + 1);
            else ranking.qtde_erradas = (ranking.qtde_erradas + 1);

            ranking.qtde_respostas = ranking.qtde_respostas + 1;

            if (partidaGanha) ranking.qtde_partidas_ganhas = ranking.qtde_partidas_ganhas + 1;

            rankingRep.Salvar(ranking);

        }           
        private void atualiza_acerto_erro(Boolean opcaoCerta)
        {
            int id_sala = Convert.ToInt32(Request.Params["Id_Sala"]);
            JogosRep JogoRep = new JogosRep();
            Jogos jogador = JogoRep.ObterPorIdSala(id_sala).Where(x => x.Usuario.Id_user == WebSecurity.GetUserId(User.Identity.Name)).ElementAt(0);

            if (opcaoCerta)
                jogador.Acertos = jogador.Acertos + 1;
            else jogador.Erros = jogador.Erros + 1;

            jogador.DataUltimaResposta = DateTime.Now;

            JogoRep.Salvar(jogador);
        }
        private void atualiza_nivel_personagem()
        {
            GenericoRep<Ranking> rankingRep = new GenericoRep<Ranking>();
            Ranking ranking = rankingRep.ObterTodos().Where(x => x.Id_User.Id_user == WebSecurity.GetUserId(User.Identity.Name)).ElementAt(0);

            GenericoRep<Usuario> UsuRep = new GenericoRep<Usuario>();
            Usuario usuario = UsuRep.ObterTodos().Where(x => x.Id_user == WebSecurity.GetUserId(User.Identity.Name)).ElementAt(0);

            if (usuario.Personagem.Nivel < (int)(ranking.qtde_partidas_ganhas / 2))
            {
                GenericoRep<Personagens> PerRep = new GenericoRep<Personagens>();
                IEnumerable<Personagens> lPersonagem = PerRep.ObterTodos().Where(x => x.Tema.Id_tema == usuario.Personagem.Tema.Id_tema);
                Personagens Personagem = lPersonagem.Where(x => x.Nivel == (int)(ranking.qtde_partidas_ganhas / 2)).ElementAt(0);
                usuario.Personagem = Personagem;

                UsuRep.Salvar(usuario);
            }

              
        }
    }
}
