using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Session3.Models;

namespace Session3.Controllers
{
    public class EmployeesController : Controller
    {
        public static List<Employee> employees = new List<Employee>() {
            new Employee(){ Id=1,Name="A",Address="Ha Noi"},
            new Employee(){ Id=2,Name="B",Address="Ha Nam"},
            new Employee(){ Id=3,Name="C",Address="Ha Tinh"}
        };
        // GET: Employees
        public ActionResult Index()
        {
            return View(employees);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            var employeeId = employees.OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();

            employees.Add(new Employee
            {
                Id = employeeId + 1,
                Name = employee.Name,
                Address = employee.Address
            });

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var employee = employees.FirstOrDefault(x => x.Id == id.Value);
                if (employee != null)
                {
                    return View(employee);
                }

            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var employee = employees.FirstOrDefault(x => x.Id == id.Value);
                if (employee != null)
                {
                    return View(employee);
                }

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int? id, Employee emp)
        {
            if (id.HasValue)
            {
                var employee = employees.FirstOrDefault(x => x.Id == id.Value);
                if (employee != null)
                {
                    employees.Remove(employee);

                }

            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var employee = employees.FirstOrDefault(x => x.Id == id.Value);
                if (employee != null)
                {
                    return View(employee);
                }

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(int? id,Employee employee)
        {
            if (id.HasValue)
            {
                //Get Employee from list Employees has id parameter
                var employeeExist = employees.FirstOrDefault(x => x.Id == id.Value);

                if (employeeExist != null)
                {
                    //get index of employee need to update
                    var index = employees.IndexOf(employeeExist);
                    employees[index] = employee;
                }

            }
            return RedirectToAction("Index");
        }
    }
}