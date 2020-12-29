using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dotNetCarteaDeAur.Models;

namespace dotNetCarteaDeAur.Controllers
{
    public class BookController : Controller
    {
        private DbCtx db = new DbCtx();

        // GET: Book
        public ActionResult Index()
        {
            List<Book> books = db.Books.ToList();
            ViewBag.Books = books;

            return View();
        }
    }
}