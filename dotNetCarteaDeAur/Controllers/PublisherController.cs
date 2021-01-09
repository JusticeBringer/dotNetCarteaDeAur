using dotNetCarteaDeAur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dotNetCarteaDeAur.Controllers
{
    public class PublisherController : Controller
    {
        private DbCtx db = new DbCtx();
        // GET: Publisher
        public ActionResult Index()
        {
            List<Publisher> publishers = db.Publishers.ToList();
            ViewBag.Publishers = publishers;

            return View();
        }
    }
}