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
            ViewBag.ListaTemas = TemasDTO.Lista();

            GenericoRep<Jogos> repositorio = new GenericoRep<Jogos>();
            IEnumerable<Jogos> Jogos = new List<Jogos>();

            Jogos = repositorio.ObterTodos().Where(x => x.Sala.Id_Sala == Id);



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

            if (list.Count() >= 9)
            {
                ModelState.AddModelError("", "Esta sala já está completa! Por favor escolha outra sala!");
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
                    return RedirectToAction("Partida", "Game");
                }

                ViewBag.ListaTemas = TemasDTO.Lista();

                ModelState.AddModelError("", "A senha para acesso à sala está incorreta");
                return View(model);
            }
            ViewBag.ListaTemas = TemasDTO.Lista();
            ModelState.AddModelError("", "Dados incorretos");
            return View(model);
        }

    }
}
