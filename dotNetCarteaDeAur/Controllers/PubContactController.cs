using dotNetCarteaDeAur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dotNetCarteaDeAur.Controllers
{
    public class PubContactController : Controller
    {
        private DbCtx db = new DbCtx();
        // GET: PubContact
        public ActionResult Index()
        {
            List<PubContact> pubContacts = db.PubContacts.ToList();
            ViewBag.PubContacts = pubContacts;

            return View();
        }
    }
}