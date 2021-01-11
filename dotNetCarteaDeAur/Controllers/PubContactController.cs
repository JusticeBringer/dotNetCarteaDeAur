using dotNetCarteaDeAur.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                PubContact pubContact = db.PubContacts.Find(id);

                if (pubContact == null)
                {
                    return HttpNotFound("Couldn't find the publisher contact with id " + id.ToString());
                }
                return View(pubContact);
            }
            return HttpNotFound("Missing id parameter of publisher contact!");
        }

        [HttpPut]
        public ActionResult Edit(int id, PubContact pubContactRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PubContact pubContact = db.PubContacts.Find(id);

                    if (TryUpdateModel(pubContact))
                    {
                        pubContact.Pub_email = pubContactRequest.Pub_email;
                        pubContact.Pub_phone = pubContactRequest.Pub_phone;
                        pubContact.Pub_city = pubContactRequest.Pub_city;
                        pubContact.Pub_street = pubContactRequest.Pub_street;

                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(pubContactRequest);
            }
            catch (DbEntityValidationException ex)
            {
                // for debugging
                string err = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors)
                                    .Select(x => x.PropertyName + " " + x.ErrorMessage));
                return View(err);
            }
        }
    }
}