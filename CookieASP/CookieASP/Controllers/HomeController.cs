using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookieASP.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 5, Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            HttpContext.Application.Add("numbervisited", 100);
            ViewBag.SessionId = HttpContext.Session.SessionID;
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.username = "Welcome: " + Session["username"];
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}