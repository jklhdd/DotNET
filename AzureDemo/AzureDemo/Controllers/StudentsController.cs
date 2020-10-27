using AzureDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzureDemo.Controllers
{
    public class StudentsController : Controller
    {
        StudentRepository db = new StudentRepository();
        // GET: Students
        public ActionResult Index()
        {
            List<Student> students = db.GetAllStudent();
            return View(students);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            db.Insert(student);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Student student = db.GetStudent(id);
            return View(student);
        }
    }
}