using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoASP.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string id)
        {
            ViewBag.id = id;
            return View();
        }
    }
}