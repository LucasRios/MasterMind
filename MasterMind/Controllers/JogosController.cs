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
            ViewBag.ListaNiveis = NivelDTO.ListaNivel();

            GenericoRep<Jogos> repositorio = new GenericoRep<Jogos>();
            IEnumerable<Jogos> Jogos = new List<Jogos>();

            Jogos = repositorio.ObterTodos().Where(x => x.Sala.Id_Sala == Id);



            Jogos model = new Jogos();
            model.Id_sala = Id;
            GenericoRep<Salas> sala = new GenericoRep<Salas>();

            model.Sala = sala.ObterPorId(model.Id_sala);
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
            GenericoRep<Salas> sala = new GenericoRep<Salas>();
            GenericoRep<Temas> tema = new GenericoRep<Temas>();
            GenericoRep<Nivel> nivel = new GenericoRep<Nivel>();

            model.Usuario = usuario.ObterPorId(WebSecurity.GetUserId(User.Identity.Name));
            model.Sala = sala.ObterPorId(model.Id_sala);
            model.Tema = tema.ObterPorId(model.Id_tema);
            model.Niveis = nivel.ObterPorId(model.Id_nivel);

            if (model.Senha == model.Sala.Senha) 
            {
                GenericoRep<Jogos> repositorio = new GenericoRep<Jogos>();

                repositorio.Salvar(model);
                return RedirectToAction("Partida", "Game");
            }

            ViewBag.ListaTemas = TemasDTO.Lista();
            ViewBag.ListaNiveis = NivelDTO.ListaNivel();

            ModelState.AddModelError("", "A senha para acesso à sala está incorreta");
            return View(model);
        }

    }
}
