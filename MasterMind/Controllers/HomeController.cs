using System;
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
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Principal", "Game");
            }
            else 
            {
               /* Random random = new Random();
                int i = random.Next(1, 2);

                if (i==1) return RedirectToAction("Login", "Account");
                else*/
                return RedirectToAction("Login", "Account");
            }            
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
