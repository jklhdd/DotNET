using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookieASP.Controllers
{
    public class ApplicationSampleController : Controller
    {
        // GET: ApplicationSample
        public ActionResult Index()
        {
            if (HttpContext.Application)
            {

            }
            return View();
        }
    }
}