﻿using System;
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
    public class ShipsController : Controller
    {
        private HW8Context db = new HW8Context();

        // GET: Ships
        public ActionResult Index()
        {
            return View(db.Ships.ToList());
        }

        // GET: Ships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ships ships = db.Ships.Find(id);
            if (ships == null)
            {
                return HttpNotFound();
            }
            return View(ships);
        }

        // GET: Ships/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Type,Tonnage")] Ships ships)
        {
            if (ModelState.IsValid)
            {
                db.Ships.Add(ships);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ships);
        }

        // GET: Ships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ships ships = db.Ships.Find(id);
            if (ships == null)
            {
                return HttpNotFound();
            }
            return View(ships);
        }

        // POST: Ships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Type,Tonnage")] Ships ships)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ships).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ships);
        }

        // GET: Ships/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError= false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Ships ships = db.Ships.Find(id);
            if (ships == null)
            {
                return HttpNotFound();
            }
            return View(ships);
        }

        // POST: Ships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Ships ships = db.Ships.Find(id);
                db.Ships.Remove(ships);
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
