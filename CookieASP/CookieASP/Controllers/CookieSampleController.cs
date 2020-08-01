using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookieASP.Controllers
{
    public class CookieSampleController : Controller
    {
        // GET: CookieSample
        public ActionResult Index()
        {
            if(Request.Cookies["login"] != null)
            {
                ViewBag.msg = "Value in cookie:" + Request.Cookies["login"]["username"];
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name)
        {
            HttpCookie cookie = new HttpCookie("login");
            cookie.Values.Add("username", name);
            cookie.Expires = DateTime.Now.AddDays(10);
            Response.Cookies.Add(cookie);

            ViewBag.msg = "Save cookie!";
            return View();
        }


    }
}