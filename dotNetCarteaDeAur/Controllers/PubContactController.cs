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

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            PubContact pubContact = db.PubContacts.Find(id);

            // first delete publishers
            while (true)
            {
                Publisher publisher = db.Publishers.Find(id);

                if (publisher != null)
                {
                    db.Publishers.Remove(publisher);
                    db.SaveChanges();
                }
                else
                {
                    break;
                }
            }

            // then delete publisher contact
            if (pubContact != null)
            {
                db.PubContacts.Remove(pubContact);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return HttpNotFound("Couldn't find the publisher contact with the id " + id.ToString());
        }
    }
}