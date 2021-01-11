using dotNetCarteaDeAur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dotNetCarteaDeAur.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        private DbCtx db = new DbCtx();

        [HttpGet]
        public ActionResult Index()
        {
            List<Book> books = db.Books.ToList();
            ViewBag.Books = books;

            List<Publisher> publishers = db.Publishers.ToList();
            ViewBag.Publishers = publishers;

            return View();
        }
    }
}