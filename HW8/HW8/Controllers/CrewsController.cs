using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW8.Models;

namespace HW8.Controllers
{
    public class CrewsController : Controller
    {
        private HW8Context db = new HW8Context();

        // GET: Crews
        public ActionResult Index()
        {
            var crews = db.Crews.Include(c => c.Pirates).Include(c => c.Ships);
            return View(crews.ToList());
        }

        // GET: Crews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crews crews = db.Crews.Find(id);
            if (crews == null)
            {
                return HttpNotFound();
            }
            return View(crews);
        }

        // GET: Crews/Create
        public ActionResult Create()
        {
            ViewBag.PirateID = new SelectList(db.Pirates, "ID", "Name");
            ViewBag.ShipID = new SelectList(db.Ships, "ID", "Name");
            return View();
        }

        // POST: Crews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Booty,PirateID,ShipID")] Crews crews)
        {
            if (ModelState.IsValid)
            {
                db.Crews.Add(crews);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PirateID = new SelectList(db.Pirates, "ID", "Name", crews.PirateID);
            ViewBag.ShipID = new SelectList(db.Ships, "ID", "Name", crews.ShipID);
            return View(crews);
        }

        // GET: Crews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crews crews = db.Crews.Find(id);
            if (crews == null)
            {
                return HttpNotFound();
            }
            ViewBag.PirateID = new SelectList(db.Pirates, "ID", "Name", crews.PirateID);
            ViewBag.ShipID = new SelectList(db.Ships, "ID", "Name", crews.ShipID);
            return View(crews);
        }

        // POST: Crews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Booty,PirateID,ShipID")] Crews crews)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crews).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PirateID = new SelectList(db.Pirates, "ID", "Name", crews.PirateID);
            ViewBag.ShipID = new SelectList(db.Ships, "ID", "Name", crews.ShipID);
            return View(crews);
        }

        // GET: Crews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crews crews = db.Crews.Find(id);
            if (crews == null)
            {
                return HttpNotFound();
            }
            return View(crews);
        }

        // POST: Crews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Crews crews = db.Crews.Find(id);
            db.Crews.Remove(crews);
            db.SaveChanges();
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
