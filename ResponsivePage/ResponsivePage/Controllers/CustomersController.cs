using ResponsivePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResponsivePage.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCustomerByRegion(string region)
        {
            using (var db = new CompanyContext())
            {
                return PartialView("_CustomerByRegion", db.Customers.Where(x => x.Region == region).ToList());
            }
        }

        public ActionResult SearchCustomer(string name)
        {
            using(var db = new CompanyContext())
            {
                return PartialView("_CustomerByRegion", db.Customers.Where(x => x.Name.Contains(name)).ToList());
            }
        }
    }
}