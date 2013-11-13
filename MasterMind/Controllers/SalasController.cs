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

            GenericoRep<Usuario> usu = new GenericoRep<Usuario>();
            GenericoRep<Perfil> perfil = new GenericoRep<Perfil>();

            sala = repositorio.ObterTodos();

            foreach (var i in sala)
            {
                if (i.Id_Usuario !=0) { i.Usuario = usu.ObterPorId(i.Id_Usuario); }
                if (i.Perfil == 1) { i.Desc_perfil = "Pública"; }
                else { i.Desc_perfil = "Privada"; }
            }

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
            model.Id_Usuario = WebSecurity.GetUserId(User.Identity.Name);
            repositorio.Salvar(model);
           
            return RedirectToAction("Acesso", "Jogos", new { Id = model.Id_Sala, senha = model.Senha });
        }

    }
}
