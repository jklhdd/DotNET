using ASP_S2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_S2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            ViewData["student1"] = new Student() { ID = 3, Name = "Batman", DateOfJoin = new DateTime(2019, 6, 20) };
            ViewBag.student = new Student() { ID = 2, Name = "James", DateOfJoin = new DateTime(2019, 6, 20) };
            TempData["student1"] = new Student() { ID = 1, Name = "Long", DateOfJoin = new DateTime(2019, 6, 20) };
            return View();
        }

        public ActionResult ViewDataSample()
        {
            ViewData["student1"] = new Student() { ID = 1, Name = "Long", DateOfJoin = new DateTime(2019, 6, 20) };
            return View();
        }

        public ActionResult ViewBagSample()
        {
            ViewBag.student = new Student() { ID = 1, Name = "Long", DateOfJoin = new DateTime(2019, 6, 20) };
            return View();
        }

        public ActionResult TempDataSample()
        {
            TempData["student1"] = new Student() { ID = 1, Name = "Long", DateOfJoin = new DateTime(2019, 6, 20) };
            return View();
        }

        public ActionResult CompareObject()
        {
            ViewData["student1"] = new Student() { ID = 3, Name = "Batman", DateOfJoin = new DateTime(2019, 6, 20) };
            ViewBag.student = new Student() { ID = 2, Name = "James", DateOfJoin = new DateTime(2019, 6, 20) };
            TempData["student1"] = new Student() { ID = 1, Name = "Long", DateOfJoin = new DateTime(2019, 6, 20) };
            return RedirectToAction("AnotherMethod");
        }
        public ActionResult AnotherMethod()
        {
            return View();
        }

        public ActionResult RazorSample()
        {
            return View();
        }

        public ActionResult HtmlHelper()
        {
            return View();
        }
    }
}