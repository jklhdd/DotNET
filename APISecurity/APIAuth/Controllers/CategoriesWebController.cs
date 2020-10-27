using APIAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace APIAuth.Controllers
{
    [Authorize]
    public class CategoriesWebController : Controller
    {
        // GET: CategoriesWeb
        private string path = "https://localhost:44387/api/";
        public ActionResult Index()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(path);
                var responseTask = client.GetAsync("Categories");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Category[]>();
                    readTask.Wait();
                    var categories = readTask.Result;

                    return View(categories);
                }
            }
            return View();
        }
    }
}