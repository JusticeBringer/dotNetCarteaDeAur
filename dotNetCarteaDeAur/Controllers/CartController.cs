using dotNetCarteaDeAur.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dotNetCarteaDeAur.Controllers
{
    public class CartController : Controller
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


            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            List<PubContact> pubContacts = db.PubContacts.ToList();
            ViewBag.PubContacts = pubContacts;

            List<Publisher> publishers = db.Publishers.ToList();
            ViewBag.Publishers = publishers;

            List<Book> books = db.Books.ToList();
            ViewBag.Books = books;

            List<Customer> customers = db.Customers.ToList();
            ViewBag.Customers = customers;

            Order order = new Order();

            return View(order);
        }

        [HttpPost]
        public ActionResult New(Order orderRequest)
        {
            List<PubContact> pubContacts = db.PubContacts.ToList();
            ViewBag.PubContacts = pubContacts;

            List<Publisher> publishers = db.Publishers.ToList();
            ViewBag.Publishers = publishers;

            List<Customer> customers = db.Customers.ToList();
            ViewBag.Customers = customers;

            List<Book> books = db.Books.ToList();
            ViewBag.Books = books;

            try
            {
                int sum = 0;
                foreach(int v in orderRequest.Quantity_bought)
                {
                    sum += v; 
                }

                orderRequest.Ord_price = sum;
                orderRequest.Ord_placed = new DateTime(2013, 10, 24);
                orderRequest.Status = "Placed";
                orderRequest.Cust_id = 1;

                if (ModelState.IsValid)
                {
                    db.Orders.Add(orderRequest);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(orderRequest);
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex);
                string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors)
                                                                                  .Select(x => x.PropertyName + ": " + x.ErrorMessage));
                return View(errorMessages);
            }
        }
    }
}