using Infraestrutura.Repositorios.Entidades;
using Infraestrutura.Repositorios.Entidades.DTO;
using Infraestrutura.Repositorios.Implementacao;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebMatrix.WebData;
using System.Linq;
using System.Web;



namespace MasterMind.Controllers
{
    public class SalasController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List(Int32? Id_nivel, Int32? Id_perfil)
        {
            GenericoRep<Salas> repositorio = new GenericoRep<Salas>();
            IEnumerable<Salas> sala = new List<Salas>();
            
            GenericoRep<Usuario> usu = new GenericoRep<Usuario>();
            GenericoRep<Jogos> jogos = new GenericoRep<Jogos>();
            GenericoRep<Perfil> perfil = new GenericoRep<Perfil>();
            IEnumerable<Jogos> list = new List<Jogos>();

            ViewBag.ListaNivel = NivelDTO.ListaNivel();
            ViewBag.ListaTPSala = TipoSalaDTO.ListaTipoSala();

            sala = repositorio.ObterTodos();

            if (Id_nivel != null && Id_nivel > 0)
            {
                sala = repositorio.ObterTodos().Where(x => x.Niveis.Id_Nivel == Id_nivel);
            }
            else sala = repositorio.ObterTodos();

            if (Id_perfil != null && Id_perfil > 0)
            {
                sala = sala.Where(x => x.Perfil == Id_perfil);
            }   

            foreach (var i in sala)
            {
                list = jogos.ObterTodos().Where(x => x.Sala.Id_Sala == i.Id_Sala);
                i.qtde_usu = list.Count();

                if (i.Id_Usuario !=0) { i.Usuario = usu.ObterPorId(i.Id_Usuario); }
                if (i.Perfil == 1) { i.Desc_perfil = "Pública"; }
                else { i.Desc_perfil = "Privada"; }
            }

            sala = sala.Where(u => u.qtde_usu < 9 ).ToList();

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
            ViewBag.ListaNiveis = NivelDTO.ListaNivel();

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Salas model)
        {
            GenericoRep<Usuario> usu = new GenericoRep<Usuario>();
            model.Perfil = 2;

            model.Usuario = usu.ObterPorId(WebSecurity.GetUserId(User.Identity.Name));
            model.Id_Usuario = model.Usuario.Id_user;

            if (ModelState.IsValid)
            {
                GenericoRep<Salas> repositorio = new GenericoRep<Salas>();

                repositorio.Salvar(model);

                return RedirectToAction("Acesso", "Jogos", new { Id = model.Id_Sala, senha = model.Senha });
            }
            ViewBag.ListaNiveis = NivelDTO.ListaNivel();
            ModelState.AddModelError("", "Campos inválidos");
            return View(model);
        }

    }
}
