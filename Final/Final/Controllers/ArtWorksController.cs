using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final.Views.Shared;

namespace Final.Controllers
{
    public class ArtWorksController : Controller
    {
        private FinalContext db = new FinalContext();

        // GET: ArtWorks
        public ActionResult Index()
        {
            var artWorks = db.ArtWorks.Include(a => a.Artists);
            return View(artWorks.ToList());
        }

        // GET: ArtWorks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtWorks artWorks = db.ArtWorks.Find(id);
            if (artWorks == null)
            {
                return HttpNotFound();
            }
            return View(artWorks);
        }

        // GET: ArtWorks/Create
        public ActionResult Create()
        {
            ViewBag.ArtistID = new SelectList(db.Artists, "ID", "Name");
            return View();
        }

        // POST: ArtWorks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ArtistID")] ArtWorks artWorks)
        {
            if (ModelState.IsValid)
            {
                db.ArtWorks.Add(artWorks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.ArtistID = new SelectList(db.Artists, "ID", "Name", artWorks.ArtistID);
            return View(artWorks);
        }

        // GET: ArtWorks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtWorks artWorks = db.ArtWorks.Find(id);
            if (artWorks == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "ID", "Name", artWorks.ArtistID);
            return View(artWorks);
        }

        // POST: ArtWorks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ArtistID")] ArtWorks artWorks)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(artWorks).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "ID", "Name", artWorks.ArtistID);
            return View(artWorks);
        }

        // GET: ArtWorks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtWorks artWorks = db.ArtWorks.Find(id);
            if (artWorks == null)
            {
                return HttpNotFound();
            }
            return View(artWorks);
        }

        // POST: ArtWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ArtWorks artWorks = db.ArtWorks.Find(id);
                db.ArtWorks.Remove(artWorks);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
