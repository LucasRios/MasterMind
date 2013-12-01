using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Infraestrutura.Repositorios.Entidades;
using Infraestrutura.Repositorios.Entidades.DTO;
using Infraestrutura.Repositorios.Implementacao;
using WebMatrix.WebData;

namespace MasterMind.Controllers.BackOffice
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Details(Int32 Id)
        {
            GenericoRep<Usuario> repositorio = new GenericoRep<Usuario>();
            Usuario usuario = repositorio.ObterPorId(Id);
            return View(usuario);
        }

        [HttpGet]
        public ActionResult Edit(Int32 Id)
        {
            ViewBag.ListaSexo = SexoDTO.ListaSexo();
            ViewBag.ListaPerfil = PerfilDTO.ListaPerfil();
            GenericoRep<Usuario> repositorio = new GenericoRep<Usuario>();
            Usuario usuario = repositorio.ObterPorId(Id);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            GenericoRep<Usuario> repositorio = new GenericoRep<Usuario>();
            repositorio.Salvar(usuario);                       
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            GenericoRep<Usuario> repositorio = new GenericoRep<Usuario>();
            IEnumerable<Usuario> Usuario = repositorio.ObterTodos();
            return View(Usuario);
        }

        [HttpGet]
        public ActionResult Delete(Int32 Id)
        {
            GenericoRep<Usuario> repositorio = new GenericoRep<Usuario>();
            Usuario usuario = repositorio.ObterPorId(Id);
            return View(usuario);
        }
        [HttpPost]
        public ActionResult Delete(Usuario usuario)
        {
            GenericoRep<Usuario> repositorio = new GenericoRep<Usuario>();
            repositorio.Excluir(usuario);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ListaSexo = SexoDTO.ListaSexo();
            ViewBag.ListaPerfil = PerfilDTO.ListaPerfil();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            CultureInfo culturaAtual = Thread.CurrentThread.CurrentCulture;
            CultureInfo culturaUS = CultureInfo.GetCultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = culturaUS;

            GenericoRep<Usuario> repositorio = new GenericoRep<Usuario>();
            repositorio.Salvar(usuario);
            WebSecurity.CreateAccount(usuario.Email, usuario.Senha);

            Thread.CurrentThread.CurrentCulture = culturaAtual;

            return RedirectToAction("List");
        }

        public ActionResult partialPerfil(Usuario user)
        {

            GenericoRep<Usuario> repositorio = new GenericoRep<Usuario>();
            Usuario Usuario = repositorio.ObterPorId(WebSecurity.GetUserId(User.Identity.Name));



            return PartialView(Usuario);

        }

    }
}
