using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP_Assignment.Models;
using PagedList;

namespace ASP_Assignment.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private BookStoreContext db = new BookStoreContext();

        // GET: Books
        public ActionResult Index(int? page)
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Category).Include(b => b.Publisher);
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
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "AuthorName");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CateName");
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,CategoryId,AuthorId,PublisherId,Summary,ImgUrl,Price,Quantity,CreateDate,ModifiedDate,IsActive")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.CreateDate = DateTime.Now;
                book.ModifiedDate = DateTime.Now;
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "AuthorName", book.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CateName", book.CategoryId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name", book.PublisherId);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "AuthorName", book.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CateName", book.CategoryId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name", book.PublisherId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,CategoryId,AuthorId,PublisherId,Summary,ImgUrl,Price,Quantity,CreateDate,ModifiedDate,IsActive")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.ModifiedDate = DateTime.Now;
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "AuthorName", book.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CateName", book.CategoryId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name", book.PublisherId);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
