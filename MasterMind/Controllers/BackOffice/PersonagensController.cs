using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infraestrutura.Repositorios.Entidades;
using Infraestrutura.Repositorios.Entidades.DTO;
using Infraestrutura.Repositorios.Implementacao;

namespace MasterMind.Controllers.BackOffice
{
    public class PersonagensController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Details(Int32 Id)
        {
            GenericoRep<Personagens> repositorio = new GenericoRep<Personagens>();
            Personagens personagem = repositorio.ObterPorId(Id);
            return View(personagem);
        }

        [HttpGet]
        public ActionResult Edit(Int32 Id)
        {
            ViewBag.ListaTemas = TemasDTO.Lista();

            GenericoRep<Personagens> repositorio = new GenericoRep<Personagens>();
            Personagens personagem = repositorio.ObterPorId(Id);
            return View(personagem);
        }

        [HttpPost]
        public ActionResult Edit(Personagens personagem)
        {
            GenericoRep<Personagens> repositorio = new GenericoRep<Personagens>();
            repositorio.Salvar(personagem);
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            GenericoRep<Personagens> repositorio = new GenericoRep<Personagens>();
            IEnumerable<Personagens> Personagens = repositorio.ObterTodos();
            return View(Personagens);
        }

        [HttpGet]
        public ActionResult Delete(Int32 Id)
        {
            GenericoRep<Personagens> repositorio = new GenericoRep<Personagens>();
            Personagens personagem = repositorio.ObterPorId(Id);
            return View(personagem);
        }
        [HttpPost]
        public ActionResult Delete(Personagens personagem)
        {
            GenericoRep<Personagens> repositorio = new GenericoRep<Personagens>();
            repositorio.Excluir(personagem);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ListaTemas = TemasDTO.Lista();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Personagens personagem)
        {
            GenericoRep<Personagens> repositorio = new GenericoRep<Personagens>();
            repositorio.Salvar(personagem);
            return RedirectToAction("List");
        }
    }
}
