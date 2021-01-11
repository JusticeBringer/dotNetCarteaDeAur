using dotNetCarteaDeAur.Models;
using System;
using System.Collections.Generic;
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
    }
}