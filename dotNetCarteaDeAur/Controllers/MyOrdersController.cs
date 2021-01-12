using dotNetCarteaDeAur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dotNetCarteaDeAur.Controllers
{
    public class MyOrdersController : Controller
    {
        private DbCtx db = new DbCtx();
        private ApplicationDbContext ctx = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            List<Book> books = db.Books.ToList();
            ViewBag.Books = books;

            List<Publisher> publishers = db.Publishers.ToList();
            ViewBag.Publishers = publishers;

            List<Order> orders = db.Orders.ToList();
            ViewBag.Orders = orders;

            ViewBag.UsersList = ctx.Users
            .OrderBy(u => u.UserName)
            .ToList();

            return View();
        }
    }
}