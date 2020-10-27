using AuthenticationWithWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationWithWebApi.Controllers
{
    
    public class HomeController : Controller
    {
        private string baseAddress = "https://authenticationwithwebapi20200921191707.azurewebsites.net/";
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email,string password)
        {
            using(var client = new HttpClient())
            {

                var form = new Dictionary<string, string>()
                {
                    {"grant_type","password" },
                    {"username",email },
                    {"password",password }
                };
                var tokenResponse = client.PostAsync(baseAddress + "token", new FormUrlEncodedContent(form)).Result;
                var token = tokenResponse.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;
                Session["Token"] = token;
                return RedirectToAction("Index");
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterBindingModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://authenticationwithwebapi20200921191707.azurewebsites.net/api/Account/Register");
                var postTask = client.PostAsJsonAsync<RegisterBindingModel>("Register", model);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    RedirectToAction("Login");
                }
            }
            return View();
        }
    }
}
