using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APIAuth.Controllers
{
    public class LoginController : Controller
    {
        private string path = "https://localhost:44387/api/";
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterBindingModel)
        {
            return View();
        }

    }
}