using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dotNetCarteaDeAur.Models;



namespace dotNetCarteaDeAur.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SeePayment()
        {
            Payment p = new Payment
            {
                Pay_id = 1,
                Bank_name = "BRD",
                Pay_method = "Card"
            };

            return View(p);
        }
    }
}