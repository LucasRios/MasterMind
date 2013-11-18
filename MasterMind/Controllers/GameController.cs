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
    public class GameController : Controller
    {
        //
        // GET: /Game/

        public ActionResult Principal()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Partida()
        {            
            GenericoRep<Perguntas> perguntasRep = new GenericoRep<Perguntas>();
            ViewBag.PerguntaInicial = perguntasRep.ObterPorId(5);

            return View(@"~/Views/Game/Partida.cshtml");
        }

        public ActionResult Ranking_top()
        {
            GenericoRep<Ranking> repositorio = new GenericoRep<Ranking>();
            IEnumerable<Ranking> ranking = repositorio.ObterTodos();

            ranking = ranking.OrderByDescending(c => c.qtde_certas).ThenBy(c => c.qtde_erradas).ToList();

            List<Ranking> aux = new List<Ranking>();

            if (ranking != null && ranking.Count() >= 3)
            {
                for (var i = 0; i <= 2; i++)
                {
                    aux.Add(ranking.ElementAt(i));
                }
            }
            for (var i = 0; i <= ranking.Count()-1; i++)
            {
                ranking.ElementAt(i).Id_Ranking = i+1;

                if (ranking.ElementAt(i).Id_User.Id_user == WebSecurity.GetUserId(User.Identity.Name))
                aux.Add(ranking.ElementAt(i));
            }

            return View(aux);
        }

        public ActionResult Ranking()
        {
            GenericoRep<Ranking> repositorio = new GenericoRep<Ranking>();
            IEnumerable<Ranking> ranking = repositorio.ObterTodos();
            ranking = ranking.OrderByDescending(c => c.qtde_certas).ThenBy(c => c.qtde_erradas).ToList();
            return View(ranking);
        }


        public JsonResult ObterPergunta(Int32 IdTema, Int32 IdNivel)
        {
            JsonResult json = new JsonResult();

            PerguntasRep repositorio = new PerguntasRep();

            var vm = new { perguntas = repositorio.ObterPerguntas(IdTema, IdNivel) } ;

            json.Data = vm;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return json;
        }

        public JsonResult Responder(Int32 IdResposta)
        {
            JsonResult json = new JsonResult();

            GenericoRep<Respostas> respostaRep = new GenericoRep<Respostas>();
            Respostas resposta = respostaRep.ObterPorId(IdResposta);
            Boolean opcaoCerta = resposta.OpcaoCerta;

            var vm = new { opcaoCerta = opcaoCerta };

            json.Data = vm;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return json;
        }
    
        [HttpGet]
        public ActionResult Personagem()
        {
            ViewBag.ListaPerson = PersonagemDTO.ListaPerson();

            Usuario usuario = new Usuario();
            GenericoRep<Usuario> usu = new GenericoRep<Usuario>();

            usuario = usu.ObterPorId(WebSecurity.GetUserId(User.Identity.Name));

            return View(usuario);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Personagem(Usuario model)
        {

            if (model.Personagem.Id_person != 0)
            {
                Usuario usuario = new Usuario();
                GenericoRep<Usuario> usu = new GenericoRep<Usuario>();

                usuario = usu.ObterPorId(WebSecurity.GetUserId(User.Identity.Name));
                usuario.Personagem = model.Personagem;

                GenericoRep<Usuario> repositorio = new GenericoRep<Usuario>();

                repositorio.Salvar(usuario);               

                return RedirectToAction("Principal", "Game" );
            }

            ViewBag.ListaPerson = PersonagemDTO.ListaPerson();
            return View(model);
        }

    }
}
