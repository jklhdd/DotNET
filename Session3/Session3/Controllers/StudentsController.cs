using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Session3.Models;

namespace Session3.Controllers
{
    public class StudentsController : Controller
    {
        public static List<Student> students = new List<Student>()
        {
            new Student(){ Id=1,Name="A",DateOfJoin=new DateTime(2020,4,20)},
            new Student(){ Id=2,Name="B",DateOfJoin=new DateTime(2020,2,20)},
            new Student(){ Id=3,Name="C",DateOfJoin=new DateTime(2020,3,20)},
            new Student(){ Id=4,Name="D",DateOfJoin=new DateTime(2020,1,20)},
            new Student(){ Id=5,Name="E",DateOfJoin=new DateTime(2020,7,20)}
        };
        // GET: Students
        public ActionResult Index()
        {
            //ViewBag.students = students;
            return View(students);
        }

        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var student = students.FirstOrDefault(x => x.Id == id.Value);
                if (student != null)
                {
                    ViewBag.student = student;
                    return View();
                }
            }

            return RedirectToAction("Index");
        }
        public ActionResult Chitiet(int? id)
        {
            if (id.HasValue)
            {
                var student = students.FirstOrDefault(x => x.Id == id.Value);
                if (student != null)
                {
                    return View(student);//Model Data
                }
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        //lay gia tri primitive
        //[HttpPost]
        //public ActionResult Insert(string name, DateTime dateOfJoin)
        //{
        //    var studentId = students.OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();
        //    var student = new Student()
        //    {
        //        Id = studentId + 1,
        //        Name = name,
        //        DateOfJoin=dateOfJoin
        //    };
        //    students.Add(student);
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        
        //public ActionResult Insert(FormCollection s)
        //{
        //    var studentId = students.OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();
        //    var student = new Student()
        //    {
        //        Id = studentId + 1,
        //        Name = s["Name"],
        //        DateOfJoin =DateTime.Parse( s["DateOfJoin"])
        //    };

        //    students.Add(student);

        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        //object
        public ActionResult Insert(Student s)
        {
            var studentId = students.OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();
            var student = new Student()
            {
                Id = studentId + 1,
                Name = s.Name,
                DateOfJoin = s.DateOfJoin
            };
            
            students.Add(student);

            return RedirectToAction("Index");
        }
    }
}