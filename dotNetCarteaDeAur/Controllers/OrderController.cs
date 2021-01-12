using dotNetCarteaDeAur.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dotNetCarteaDeAur.Controllers
{
    public class OrderController : Controller
    {
        private DbCtx db = new DbCtx();
        // GET: Order
        public ActionResult Index()
        {
            List<Order> orders = db.Orders.ToList();
            ViewBag.Orders = orders;

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Order order = db.Orders.Find(id);
                if (order == null)
                {
                    return HttpNotFound("Couldn't find the order with id " + id.ToString());
                }
                return View(order);
            }
            return HttpNotFound("Missing book id parameter!");
        }
        [HttpPut]
        public ActionResult Edit(int id, Order orderRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Order order = db.Orders.Find(id);

                    if (TryUpdateModel(order))
                    {
                        order.Ord_price = orderRequest.Ord_price;
                        order.Ord_placed = new DateTime(2013, 12, 31);
                        order.Ord_arrived = new DateTime(2013, 12, 31);
                        order.Status = orderRequest.Status;
                        order.Customer = orderRequest.Customer;

                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(orderRequest);
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
            Order order = db.Orders.Find(id);
            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
                return RedirectToAction("Index", "Order");
            }
            return HttpNotFound("Couldn't find the order with id " + id.ToString());
        }
    }
}