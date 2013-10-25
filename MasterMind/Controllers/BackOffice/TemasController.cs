using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infraestrutura.Repositorios.Entidades;
using Infraestrutura.Repositorios.Implementacao;

namespace MasterMind.Controllers.BackOffice
{
    public class TemasController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Details(Int32 Id)
        {
            GenericoRep<Temas> repositorio = new GenericoRep<Temas>();
            Temas tema = repositorio.ObterPorId(Id);
            return View(tema);
        }

        [HttpGet]
        public ActionResult Edit(Int32 Id)
        {
            GenericoRep<Temas> repositorio = new GenericoRep<Temas>();
            Temas tema = repositorio.ObterPorId(Id);
            return View(tema);
        }

        [HttpPost]
        public ActionResult Edit(Temas tema)
        {
            GenericoRep<Temas> repositorio = new GenericoRep<Temas>();
            repositorio.Salvar(tema);
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            GenericoRep<Temas> repositorio = new GenericoRep<Temas>();
            IEnumerable<Temas> temas = repositorio.ObterTodos();
            return View(temas);
        }

        [HttpGet]
        public ActionResult Delete(Int32 Id)
        {
            GenericoRep<Temas> repositorio = new GenericoRep<Temas>();
            Temas tema = repositorio.ObterPorId(Id);
            return View(tema);
        }
        [HttpPost]
        public ActionResult Delete(Temas tema)
        {
            GenericoRep<Temas> repositorio = new GenericoRep<Temas>();
            repositorio.Excluir(tema);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Temas tema)
        {
            GenericoRep<Temas> repositorio = new GenericoRep<Temas>();
            repositorio.Salvar(tema);
            return RedirectToAction("List");
        }
    }
}
