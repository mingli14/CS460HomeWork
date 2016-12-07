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
    public class ClassificationsController : Controller
    {
        private FinalContext db = new FinalContext();

        // GET: Classifications
        public ActionResult Index()
        {
            var classifications = db.Classifications.Include(c => c.ArtWorks).Include(c => c.Genres);
            return View(classifications.ToList());
        }

        // GET: Classifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classifications classifications = db.Classifications.Find(id);
            if (classifications == null)
            {
                return HttpNotFound();
            }
            return View(classifications);
        }

        // GET: Classifications/Create
        public ActionResult Create()
        {
            ViewBag.ArtWorkID = new SelectList(db.ArtWorks, "ID", "Title");
            ViewBag.GenreID = new SelectList(db.Genres, "ID", "Name");
            return View();
        }

        // POST: Classifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ArtWorkID,GenreID")] Classifications classifications)
        {
            if (ModelState.IsValid)
            {
                db.Classifications.Add(classifications);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtWorkID = new SelectList(db.ArtWorks, "ID", "Title", classifications.ArtWorkID);
            ViewBag.GenreID = new SelectList(db.Genres, "ID", "Name", classifications.GenreID);
            return View(classifications);
        }

        // GET: Classifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classifications classifications = db.Classifications.Find(id);
            if (classifications == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtWorkID = new SelectList(db.ArtWorks, "ID", "Title", classifications.ArtWorkID);
            ViewBag.GenreID = new SelectList(db.Genres, "ID", "Name", classifications.GenreID);
            return View(classifications);
        }

        // POST: Classifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ArtWorkID,GenreID")] Classifications classifications)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(classifications).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            ViewBag.ArtWorkID = new SelectList(db.ArtWorks, "ID", "Title", classifications.ArtWorkID);
            ViewBag.GenreID = new SelectList(db.Genres, "ID", "Name", classifications.GenreID);
            return View(classifications);
        }

        // GET: Classifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classifications classifications = db.Classifications.Find(id);
            if (classifications == null)
            {
                return HttpNotFound();
            }
            return View(classifications);
        }

        // POST: Classifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Classifications classifications = db.Classifications.Find(id);
                db.Classifications.Remove(classifications);
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
