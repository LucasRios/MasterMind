using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterMind.Controllers
{
    public class GameController : Controller
    {
        //
        // GET: /Game/

        public ActionResult Principal()
        {
            return RedirectToAction("Partida", "Game");
            return View();
        }

        public ActionResult Partida()
        {            
            return View();
        }

    }
}
