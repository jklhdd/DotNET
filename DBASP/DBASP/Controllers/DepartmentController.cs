using DBASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBASP.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        private SchoolContext db = new SchoolContext();
        public ActionResult Index()
        {

            return View(db.Departments.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            var departmentExist = db.Departments.FirstOrDefault(x => x.Id == id.Value);
            if (departmentExist != null)
            {
                return View(departmentExist);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int? id, Department department)
        {
            if (id.HasValue)
            {
                var departmentExist = db.Departments.FirstOrDefault(x => x.Id == id.Value);
                if (departmentExist != null)
                {
                    departmentExist.Name = department.Name;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            var departmentExist = db.Departments.FirstOrDefault(x => x.Id == id.Value);
            if (departmentExist != null)
            {
                return View(departmentExist);
            }
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var departmentExist = db.Departments.FirstOrDefault(x => x.Id == id.Value);
                if (departmentExist != null)
                {
                    return View(departmentExist);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int? id, Department department)
        {
            if (id.HasValue)
            {
                var departmentExist = db.Departments.FirstOrDefault(x => x.Id == id.Value);
                db.Departments.Remove(departmentExist);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}