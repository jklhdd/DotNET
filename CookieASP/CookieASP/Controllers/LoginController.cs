using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookieASP.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, string password)
        {
            if (name == "admin" && password == "123456")
            {
                Session["username"] = name;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}