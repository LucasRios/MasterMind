﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterMind.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           // return RedirectToAction("List", "Temas");
            return RedirectToAction("Login", "Account");
           // return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
