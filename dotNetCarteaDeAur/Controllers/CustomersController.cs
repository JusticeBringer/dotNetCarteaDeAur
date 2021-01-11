using dotNetCarteaDeAur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dotNetCarteaDeAur.Controllers
{
    public class CustomersController : Controller
    {
        private DbCtx db = new DbCtx();
        // GET: Customers
        [HttpGet]
        public ActionResult Index()
        {
            List<Customer> customers = db.Customers.ToList();
            ViewBag.Customers = customers;

            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer != null)
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
                return RedirectToAction("Index", "Customers");
            }
            return HttpNotFound("Coulnd't find the customer with id " + id.ToString());
        }
    }
}