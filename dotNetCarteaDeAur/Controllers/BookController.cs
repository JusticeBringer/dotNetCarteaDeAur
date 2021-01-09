using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dotNetCarteaDeAur.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace dotNetCarteaDeAur.Controllers
{
    public class BookController : Controller
    {
        private DbCtx db = new DbCtx();

        [HttpGet]
        public ActionResult Index()
        {
            List<Book> books = db.Books.ToList();
            ViewBag.Books = books;

            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            Book book = new Book();
            book.Orders = new List<Order>();

            return View(book);
        }

        [HttpPost]
        public ActionResult New(Book bookRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bookRequest.Publisher = db.Publishers.FirstOrDefault(p => p.Pub_id.Equals(1));
                    db.Books.Add(bookRequest);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(bookRequest);
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex); 
                string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors)
                                                                                  .Select(x => x.PropertyName + ": " + x.ErrorMessage));
                return View(errorMessages);
            }
        }


        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Book book = db.Books.Find(id);
                if (book != null)
                {
                    return View(book);
                }
                return HttpNotFound("Couldn't find the book with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing book id parameter!");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Book book = db.Books.Find(id);
                if (book == null)
                {
                    return HttpNotFound("Couldn't find the book with id " + id.ToString());
                }
                return View(book);
            }
            return HttpNotFound("Missing book id parameter!");
        }
        [HttpPut]
        public ActionResult Edit(int id, Book bookRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Book book = db.Books
                   .Include("Publisher")
                    .SingleOrDefault(b => b.Book_id.Equals(id));
                    if (TryUpdateModel(book))
                    {
                        book.Title = bookRequest.Title;
                        book.Author = bookRequest.Author;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(bookRequest);
            }
            catch (DbEntityValidationException ex)
            {
                string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors)
                                                                                  .Select(x => x.PropertyName + ": " + x.ErrorMessage));
                Console.WriteLine(ex);
                return View(errorMessages);
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return HttpNotFound("Couldn't find the book with id " + id.ToString());
        }
    }
}