using Infraestrutura.Repositorios.Entidades;
using Infraestrutura.Repositorios.Entidades.DTO;
using Infraestrutura.Repositorios.Implementacao;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebMatrix.WebData;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;


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
            servidor_cria_sala(); //servido cria salas se não houverem salas públicas

            GenericoRep<Salas> repositorio = new GenericoRep<Salas>();
            IEnumerable<Salas> sala = new List<Salas>();

            GenericoRep<Usuario> usu = new GenericoRep<Usuario>();
            GenericoRep<Jogos> jogos = new GenericoRep<Jogos>();
            GenericoRep<Perfil> perfil = new GenericoRep<Perfil>();
            IEnumerable<Jogos> list = new List<Jogos>();

            ViewBag.ListaNivel = NivelDTO.ListaNivel().OrderBy(p => p.Id_Nivel);
            ViewBag.ListaTPSala = TipoSalaDTO.ListaTipoSala().OrderBy(p => p.Id_TPSala);


            sala = repositorio.ObterTodos().Where(x => x.Fechada != 1);

            if (Id_nivel != null && Id_nivel > 0)
            {
                sala = repositorio.ObterTodos().Where(x => x.Niveis.Id_Nivel == Id_nivel);
                sala = sala.Where(x => x.Fechada != 1);
            }
            else
            {
                sala = repositorio.ObterTodos().Where(x => x.Fechada != 1);
            }

            if (Id_perfil != null && Id_perfil > 0)
            {
                sala = sala.Where(x => x.Perfil == Id_perfil);
                sala = sala.Where(x => x.Fechada != 1);
            }

            foreach (var i in sala)
            {
                list = jogos.ObterTodos().Where(x => x.Sala.Id_Sala == i.Id_Sala);
                i.qtde_usu = list.Count();

                if (i.Id_Usuario != 0) { i.Usuario = usu.ObterPorId(i.Id_Usuario); }
                if (i.Perfil == 1) { i.Desc_perfil = "Pública"; }
                else { i.Desc_perfil = "Privada"; }
            }

            //sala = sala.Where(u => u.qtde_usu < 12 ).ToList();

            return View(sala);
        }
        [HttpPost]
        public string ListarSalas(Int32? Id_nivel, Int32? Id_perfil)
        {
            GenericoRep<Salas> repositorio = new GenericoRep<Salas>();
            IEnumerable<Salas> sala = new List<Salas>();

            GenericoRep<Usuario> usu = new GenericoRep<Usuario>();
            GenericoRep<Jogos> jogos = new GenericoRep<Jogos>();
            GenericoRep<Perfil> perfil = new GenericoRep<Perfil>();
            IEnumerable<Jogos> list = new List<Jogos>();

            ViewBag.ListaNivel = NivelDTO.ListaNivel().OrderBy(p => p.Id_Nivel);
            ViewBag.ListaTPSala = TipoSalaDTO.ListaTipoSala().OrderBy(p => p.Id_TPSala);

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

                if (i.Id_Usuario != 0) { i.Usuario = usu.ObterPorId(i.Id_Usuario); }
                if (i.Perfil == 1) { i.Desc_perfil = "Pública"; }
                else { i.Desc_perfil = "Privada"; }
            }

            //sala = sala.Where(u => u.qtde_usu < 12 ).ToList();
            JavaScriptSerializer jss = new JavaScriptSerializer();



            return jss.Serialize(sala);
        }



        private void servidor_cria_sala()
        {
            GenericoRep<Salas> repJogos = new GenericoRep<Salas>();
            IEnumerable<Salas> lJogos = repJogos.ObterTodos().Where(x => x.Perfil == 1);
            lJogos = lJogos.Where(x => x.Fechada == 0);
            IEnumerable<Salas> auxSalas = new List<Salas>();

            GenericoRep<Nivel> repnivel = new GenericoRep<Nivel>();

            //verifica se tem salas de nível fácil
            auxSalas = lJogos.Where(x => x.Niveis.Id_Nivel == 1);
            if (auxSalas.Count() == 0)
            {
                Nivel nivel = repnivel.ObterPorId(1);
                Salas sala_new = new Salas();

                sala_new.Desc_perfil = "Pública";
                sala_new.Niveis = nivel;
                sala_new.Perfil = 1;
                sala_new.qtde_usu = 8;
                sala_new.Sala = "Pública Fácil";
                repJogos.Salvar(sala_new);

            }
            //verifica se tem salas de nível médio
            auxSalas = lJogos.Where(x => x.Niveis.Id_Nivel == 1);
            if (auxSalas.Count() == 0)
            {
                Nivel nivel = repnivel.ObterPorId(2);
                Salas sala_new = new Salas();

                sala_new.Desc_perfil = "Pública";
                sala_new.Niveis = nivel;
                sala_new.Perfil = 1;
                sala_new.qtde_usu = 8;
                sala_new.Sala = "Pública Média";
                repJogos.Salvar(sala_new);

            }
            //verifica se tem salas de nível difícil
            auxSalas = lJogos.Where(x => x.Niveis.Id_Nivel == 1);
            if (auxSalas.Count() == 0)
            {
                Nivel nivel = repnivel.ObterPorId(3);
                Salas sala_new = new Salas();

                sala_new.Desc_perfil = "Pública";
                sala_new.Niveis = nivel;
                sala_new.Perfil = 1;
                sala_new.qtde_usu = 8;
                sala_new.Sala = "Pública Difícil";
                repJogos.Salvar(sala_new);

            }

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

        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Salas model)
        {
            GenericoRep<Usuario> usu = new GenericoRep<Usuario>();
            GenericoRep<Nivel> nivelRep = new GenericoRep<Nivel>();

            model.Niveis = nivelRep.ObterPorId(Convert.ToInt32(Request.Form["cd-dropdown"])); 
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
