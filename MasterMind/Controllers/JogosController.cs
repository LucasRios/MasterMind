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
            return RedirectToAction("List","Salas");
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
                return RedirectToAction("Partida", "Game", new { Id_Sala = list.ElementAt(0).Sala.Id_Sala });
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

            if (senha != "") { model.Senha=senha; }


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

            if (list.Count() >= 8)
            {
                ModelState.AddModelError("", "Esta sala já está completa! Por favor escolha outra sala!");
                ViewBag.ListaTemas = TemasDTO.Lista();
                return View(model);
            }

            list = list.Where(x => x.Tema.Id_tema == model.Tema.Id_tema);
            if(list.Count() > 0)
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

                    servidor_cria_sala(model);//o servidor verifica se a sala encheu, e se a mesma for pública ele cria uma nova

                    return RedirectToAction("Partida", "Game", new { Id_Sala = model.Sala.Id_Sala });
                }

                ViewBag.ListaTemas = TemasDTO.Lista();

                ModelState.AddModelError("", "A senha para acesso à sala está incorreta");
                return View(model);
            }
            ViewBag.ListaTemas = TemasDTO.Lista();
            ModelState.AddModelError("", "Dados incorretos");
            return View(model);
        }

        private void servidor_cria_sala(Jogos model)
        {
            if (model.Sala.Perfil == 1)
            {
                GenericoRep<Jogos> repJogos = new GenericoRep<Jogos>();
                IEnumerable<Jogos> lJogos = repJogos.ObterTodos().Where(x => x.Sala.Id_Sala == model.Sala.Id_Sala);

                if (lJogos.Count() >= 8) 
                {
                    Salas sala_new = new Salas();
                    
                    sala_new.Desc_perfil = model.Sala.Desc_perfil;
                    sala_new.Id_Usuario = model.Sala.Id_Usuario;
                    sala_new.Niveis = model.Sala.Niveis;
                    sala_new.Perfil = model.Sala.Perfil;
                    sala_new.qtde_usu = model.Sala.qtde_usu;
                    sala_new.Sala = model.Sala.Sala;
                    sala_new.Senha = model.Sala.Senha;
                    sala_new.Usuario = model.Sala.Usuario;

                    GenericoRep<Salas> repSalas = new GenericoRep<Salas>();
                    repSalas.Salvar(sala_new);
                }

            }

        }

    }
}
