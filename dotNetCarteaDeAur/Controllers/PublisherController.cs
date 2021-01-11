using dotNetCarteaDeAur.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Publisher publisher = db.Publishers.Find(id);

                if (publisher == null)
                {
                    return HttpNotFound("Couldn't find publisher with id " + id.ToString());
                }

                return View(publisher);
            }

            return HttpNotFound("Missing publisher id parameter");
        }

        [HttpPut]
        public ActionResult Edit(int id, Publisher publisherRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Publisher publisher = db.Publishers.Find(id);

                    if (TryUpdateModel(publisher))
                    {
                        publisher.Pub_name = publisherRequest.Pub_name;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(publisherRequest);
            }
            catch (DbEntityValidationException ex)
            {
                string err = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors)
                                   .Select(x => x.PropertyName + " " + x.ErrorMessage));
                return View(err);
            }

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Publisher publisher = db.Publishers.Find(id);

            if (publisher != null)
            {
                db.Publishers.Remove(publisher);
                db.SaveChanges();

                return RedirectToAction("Index", "Publisher");
            }

            return HttpNotFound("Couldn't find the publisher with the id " + id.ToString());
        }
    }
}