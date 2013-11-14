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
            ViewBag.ListaTemas = TemasDTO.Lista();
            ViewBag.ListaNivel = NivelDTO.ListaNivel();
            GenericoRep<Perguntas> repositorio = new GenericoRep<Perguntas>();
            Perguntas pergunta = repositorio.ObterPorId(Id);
            return View(pergunta);
        }

        [HttpPost]
        public ActionResult Edit(Perguntas pergunta, String RespostaCerta)
        {
            Int32 respostaCerta = 0;
            Int32.TryParse(RespostaCerta, out respostaCerta);

            switch (respostaCerta)
            {
                case 1:
                    pergunta.Resposta1.OpcaoCerta = true;
                    break;
                case 2:
                    pergunta.Resposta2.OpcaoCerta = true;
                    break;
                case 3:
                    pergunta.Resposta3.OpcaoCerta = true;
                    break;
            }

            GenericoRep<Perguntas> repositorio = new GenericoRep<Perguntas>();
            repositorio.Salvar(pergunta);
            return RedirectToAction("List");
        }

        public ActionResult List(Int32? Id_tema)
        {
            ViewBag.ListaTemas = TemasDTO.Lista();
            ViewBag.ListaNivel = NivelDTO.ListaNivel();

            GenericoRep<Perguntas> repositorio = new GenericoRep<Perguntas>();
            IEnumerable<Perguntas> Perguntas = new List<Perguntas>();

            if (Id_tema != null && Id_tema > 0)
                Perguntas = repositorio.ObterTodos().Where(x => x.Tema.Id_tema == Id_tema);

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
            ViewBag.ListaTemas = TemasDTO.Lista();
            ViewBag.ListaNivel = NivelDTO.ListaNivel();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Perguntas pergunta, String RespostaCerta)
        {
            Int32 respostaCerta = 0;
            Int32.TryParse(RespostaCerta, out respostaCerta);

            switch (respostaCerta)
            {
                case 1:
                    pergunta.Resposta1.OpcaoCerta = true;
                    break;
                case 2:
                    pergunta.Resposta2.OpcaoCerta = true;
                    break;
                case 3:
                    pergunta.Resposta3.OpcaoCerta = true;
                    break;
            }

            GenericoRep<Perguntas> repositorio = new GenericoRep<Perguntas>();
            repositorio.Salvar(pergunta);
            return RedirectToAction("List");
        }
    }
}
