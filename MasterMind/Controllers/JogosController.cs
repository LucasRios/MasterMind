using Infraestrutura.Repositorios.Entidades;
using Infraestrutura.Repositorios.Entidades.DTO;
using Infraestrutura.Repositorios.Implementacao;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
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
        public ActionResult Acesso()
        {
            ViewBag.ListaTemas = TemasDTO.Lista();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Jogos model)
        {
            GenericoRep<Usuario> usuario = new GenericoRep<Usuario>();
            model.Usuario = usuario.ObterPorId(WebSecurity.GetUserId(User.Identity.Name));

            GenericoRep<Jogos> repositorio = new GenericoRep<Jogos>();
            model.Id_jogo = 0;


            repositorio.Salvar(model);

            return RedirectToAction("List","Salas");
        }

    }
}
