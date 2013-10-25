using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infraestrutura.Repositorios.Entidades;
using Infraestrutura.Repositorios.Implementacao;

namespace MasterMind.Controllers.BackOffice
{
    public class PerguntasController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Details(Int32 Id)
        {
            GenericoRep<Perguntas> repositorio = new GenericoRep<Perguntas>();
            Perguntas pergunta = repositorio.ObterPorId(Id);
            return View(pergunta);
        }

        [HttpGet]
        public ActionResult Edit(Int32 Id)
        {
            GenericoRep<Perguntas> repositorio = new GenericoRep<Perguntas>();
            Perguntas pergunta = repositorio.ObterPorId(Id);
            return View(pergunta);
        }

        [HttpPost]
        public ActionResult Edit(Perguntas pergunta)
        {
            GenericoRep<Perguntas> repositorio = new GenericoRep<Perguntas>();
            repositorio.Salvar(pergunta);
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            GenericoRep<Perguntas> repositorio = new GenericoRep<Perguntas>();
            IEnumerable<Perguntas> Perguntas = repositorio.ObterTodos();
            return View(Perguntas);
        }

        [HttpGet]
        public ActionResult Delete(Int32 Id)
        {
            GenericoRep<Perguntas> repositorio = new GenericoRep<Perguntas>();
            Perguntas pergunta = repositorio.ObterPorId(Id);
            return View(pergunta);
        }
        [HttpPost]
        public ActionResult Delete(Perguntas pergunta)
        {
            GenericoRep<Perguntas> repositorio = new GenericoRep<Perguntas>();
            repositorio.Excluir(pergunta);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Perguntas pergunta)
        {
            GenericoRep<Perguntas> repositorio = new GenericoRep<Perguntas>();
            repositorio.Salvar(pergunta);
            return RedirectToAction("List");
        }
    }
}
