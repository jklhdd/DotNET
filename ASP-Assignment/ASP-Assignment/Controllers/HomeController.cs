using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using ASP_Assignment.Models;
using PagedList;

namespace ASP_Assignment.Controllers
{
    public class HomeController : Controller
    {
        private BookStoreContext db = new BookStoreContext();
        public ActionResult Index(int? page)
        {
            var books = db.Books.Where(b => b.IsActive == 1 ).Include(b => b.Author).Include(b => b.Category).Include(b => b.Publisher);
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            books = books.OrderBy(x => x.Id);
            return View(books.ToPagedList(pageNumber, pageSize));
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            
            if (book == null || book.IsActive == 0)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Comment(int bookId, string content)
        {
            Comment comment = new Comment() { BookId = bookId, Content = content, CreateDate = DateTime.Now, IsActive = 1 };
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Details",new { id = bookId });
        }
    }
}