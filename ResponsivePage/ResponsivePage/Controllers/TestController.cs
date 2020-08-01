using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ResponsivePage.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestSync()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TestSync(string msg)
        {
            Thread.Sleep(5000);
            ViewBag.msg = "dữ liệu trả về";
            return View();
        }
    }
}