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
    public class SalasController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            GenericoRep<Salas> repositorio = new GenericoRep<Salas>();
            IEnumerable<Salas> sala = new List<Salas>();
            sala = repositorio.ObterTodos();
            return View(sala);
        }

        [HttpGet]
        public ActionResult Delete(Int32 Id)
        {
            GenericoRep<Salas> repositorio = new GenericoRep<Salas>();
            Salas sala = repositorio.ObterPorId(Id);
            return View(sala);
        }
        [HttpPost]
        public ActionResult Delete(Salas sala)
        {
            GenericoRep<Salas> repositorio = new GenericoRep<Salas>();
            repositorio.Excluir(sala);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Salas model)
        {
            GenericoRep<Salas> repositorio = new GenericoRep<Salas>();
            repositorio.Salvar(model);

            return RedirectToAction("List","Salas");
        }

    }
}
