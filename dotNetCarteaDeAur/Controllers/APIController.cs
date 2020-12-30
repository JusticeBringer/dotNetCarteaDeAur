using dotNetCarteaDeAur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dotNetCarteaDeAur.Controllers
{
    public class APIController : Controller
    {
        private DbCtx db = new DbCtx();

        [HttpGet]
        public ActionResult Index()
        {
            List<PubContact> pubContacts = db.PubContacts.ToList();
            ViewBag.PubContacts = pubContacts;

            List<Publisher> publishers = db.Publishers.ToList();
            ViewBag.Publishers = publishers;

            List<Book> books = db.Books.ToList();
            ViewBag.Books = books;

            List<Customer> customers = db.Customers.ToList();
            ViewBag.Customers = customers;

            List<Order> orders = db.Orders.ToList();
            ViewBag.Orders = orders;

            List<Orders_items> orders_Items = db.Orders_Items.ToList();
            ViewBag.Orders_items = orders_Items;

            return View();
        }
    }
}