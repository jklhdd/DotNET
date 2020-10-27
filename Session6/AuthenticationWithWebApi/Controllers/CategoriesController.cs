using AuthenticationWithWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationWithWebApi.Controllers
{
    public class CategoriesController : Controller
    {
        string baseAddress = "https://authenticationwithwebapi20200921191707.azurewebsites.net/";
        // GET: Categories
        public ActionResult Index()
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                var token = Session["token"] as Token;
                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token.AccessToken);
                    var response = client.GetAsync("api/CategoriesApi").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var categories = response.Content.ReadAsAsync<List<Category>>().Result;
                        if (categories!=null)
                        {
                            return View(categories);
                        }
                    }
                }

            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress + "api/CategoriesApi");
                var token = Session["token"] as Token;
                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token.AccessToken);
                    var postTask = client.PostAsJsonAsync<Category>("CategoriesApi", category);
                    postTask.Wait();

                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else RedirectToAction("Login", "Home");
                }

            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                var token = Session["token"] as Token;
                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token.AccessToken);
                    var response = client.GetAsync("api/CategoriesApi/?id=" + id.Value).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var category = response.Content.ReadAsAsync<Category>().Result;
                        if (category != null)
                        {
                            return View(category);
                        }
                    }
                }

            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int? id, Category category)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress + "api/CategoriesApi");
                var token = Session["token"] as Token;
                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token.AccessToken);
                    var postTask = client.PutAsJsonAsync<Category>("CategoriesApi?id="+id.Value, category);
                    postTask.Wait();

                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else RedirectToAction("Login", "Home");
                }

            }
            return View();
        }

        public ActionResult Delete(int? id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                var token = Session["token"] as Token;
                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token.AccessToken);
                    var response = client.GetAsync("api/CategoriesApi/?id=" + id.Value).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var category = response.Content.ReadAsAsync<Category>().Result;
                        if (category != null)
                        {
                            return View(category);
                        }
                    }
                }

            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int? id, Category category)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress + "api/CategoriesApi");
                var token = Session["token"] as Token;
                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token.AccessToken);
                    var postTask = client.DeleteAsync("CategoriesApi?id=" + id.Value);
                    postTask.Wait();

                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else RedirectToAction("Login", "Home");
                }

            }
            return View();
        }
    }
}