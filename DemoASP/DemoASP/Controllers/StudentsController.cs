using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoASP.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index(int? id,string name,int? age)
        {
            if (id.HasValue)
            {
                ViewBag.id = id;
                ViewBag.name = name;
                ViewBag.age = age;

            }
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }
    }
}