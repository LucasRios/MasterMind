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
        public ActionResult Acesso(Int32 Id)
        {
            ViewBag.ListaTemas = TemasDTO.Lista();

            GenericoRep<Jogos> repositorio = new GenericoRep<Jogos>();
            IEnumerable<Jogos> Jogos = new List<Jogos>();

            Jogos = repositorio.ObterTodos().Where(x => x.Sala.Id_Sala == Id);



            Jogos jogo = new Jogos();
            GenericoRep<Usuario> usuario = new GenericoRep<Usuario>();
            GenericoRep<Salas> sala = new GenericoRep<Salas>();
            
            jogo.Usuario = usuario.ObterPorId(WebSecurity.GetUserId(User.Identity.Name));
            jogo.Sala = sala.ObterPorId(Id);

            jogo.Id_jogo = 0;


            return View(jogo);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Acesso(Jogos model)
        {
            GenericoRep<Salas> sala = new GenericoRep<Salas>();
            Salas auxSala = sala.ObterPorId(model.Sala.Id_Sala);

            if (auxSala.Senha == model.Sala.Senha) 
            {
                GenericoRep<Jogos> repositorio = new GenericoRep<Jogos>();

                repositorio.Salvar(model);
                return RedirectToAction("Partida", "Game");
            }

            return View();
        }

    }
}
