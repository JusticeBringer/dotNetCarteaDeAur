using dotNetCarteaDeAur.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Customer customer = db.Customers.Find(id);

                if (customer == null)
                {
                    return HttpNotFound("Couldn't find the customer with id " + id.ToString());
                }
                return View(customer);
            }
            return HttpNotFound("Missing customer id parameter!");
        }

        [HttpPut]
        public ActionResult Edit(int id, Customer customerRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Customer customer = db.Customers.Find(id);

                    if (TryUpdateModel(customer))
                    {
                        customer.Cust_id = customerRequest.Cust_id;
                        customer.First_name = customerRequest.First_name;
                        customer.Last_name = customerRequest.Last_name;
                        customer.City = customerRequest.City;
                        customer.Street = customerRequest.Street;
                        customer.P_code = customerRequest.P_code;
                        customer.Phone = customerRequest.Phone;

                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(customerRequest);
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex);
                string err = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors)
                                                                        .Select(x => x.PropertyName + ": " + x.ErrorMessage));
                return View(err);
            }
        }
    }
}