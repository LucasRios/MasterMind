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
            ViewBag.ListaTemas = TemasDTO.Lista();
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Details(Int32 Id)
        {
            ViewBag.ListaTemas = TemasDTO.Lista();
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
            ViewBag.ListaTemas = TemasDTO.Lista();
            HttpPostedFileBase imagem = Request.Files["photo"];

            if ((imagem != null) && (imagem.FileName != ""))
            {
                if (imagem.ContentLength > 100240)
                {
                    ModelState.AddModelError("photo", "O tamanho da foto não pode exceder 100 KB");
                    return View(personagem);
                }

                var supportedTypes = new[] { "jpg", "jpeg", "png" };

                var fileExt = System.IO.Path.GetExtension(imagem.FileName).Substring(1);

                if (!supportedTypes.Contains(fileExt))
                {
                    ModelState.AddModelError("photo", "Tipo inválido. Somente os tipos (jpg, jpeg, png) são suportados.");
                    return View(personagem);
                }

                string arquivo = System.IO.Path.Combine(
                                           Server.MapPath("../../img/personagens"), personagem.Id_person + "." + fileExt);

                imagem.SaveAs(arquivo);
                personagem.Imagem = "../img/personagens/" + personagem.Id_person + "." + fileExt;
            }


            ViewBag.ListaTemas = TemasDTO.Lista();
            GenericoRep<Personagens> repositorio = new GenericoRep<Personagens>();
            repositorio.Salvar(personagem);
            return RedirectToAction("List");
        }

        public ActionResult List(Int32? Id_tema)
        {
            ViewBag.ListaTemas = TemasDTO.Lista();

            GenericoRep<Personagens> repositorio = new GenericoRep<Personagens>();
            IEnumerable<Personagens> Personagens = repositorio.ObterTodos();

            if (Id_tema != null && Id_tema > 0)
                Personagens = repositorio.ObterTodos().Where(x => x.Tema.Id_tema == Id_tema);

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

            IEnumerable<Personagens> iper = repositorio.ObterTodos().Where(x => x.Desc_person.Trim().ToUpper() == personagem.Desc_person.Trim().ToUpper());

            personagem = iper.ElementAt(0);

            HttpPostedFileBase imagem = Request.Files["photo"];

            if ((imagem != null) && (imagem.FileName != ""))
            {
                if (imagem.ContentLength > 100240)
                {
                    ModelState.AddModelError("photo", "O tamanho da foto não pode exceder 100 KB");
                    return View(personagem);
                }

                var supportedTypes = new[] { "jpg", "jpeg", "png" };

                var fileExt = System.IO.Path.GetExtension(imagem.FileName).Substring(1);

                if (!supportedTypes.Contains(fileExt))
                {
                    ModelState.AddModelError("photo", "Tipo inválido. Somente os tipos (jpg, jpeg, png) são suportados.");
                    return View(personagem);
                }

                string arquivo = System.IO.Path.Combine(
                                           Server.MapPath("../../img/personagens"), personagem.Id_person + "." + fileExt);

                imagem.SaveAs(arquivo);
                personagem.Imagem = "../img/personagens/" + personagem.Id_person + "." + fileExt;
            }

            repositorio.Salvar(personagem);
            return RedirectToAction("List");
        }
    }
}
