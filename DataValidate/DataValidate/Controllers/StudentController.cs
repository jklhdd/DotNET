using DataValidate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataValidate.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        static List<Student> students = new List<Student>();

        public ActionResult Index()
        {
            return View(students);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                students.Add(student);
            }
            return RedirectToAction("Index");
        }
    }
}