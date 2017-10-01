using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoServiceLogin;

namespace AutoServiceLogin.Controllers
{
    public class ModRezolvareController : Controller
    {
        private AutoServiceEntities db = new AutoServiceEntities();

        // GET: /ModRezolvare/
        public ActionResult Index()
        {
            var modrezolvares = db.ModRezolvares.Include(m => m.MartoriBord);
            return View(modrezolvares.ToList());
        }

        // GET: /ModRezolvare/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModRezolvare modrezolvare = db.ModRezolvares.Find(id);
            if (modrezolvare == null)
            {
                return HttpNotFound();
            }
            return View(modrezolvare);
        }

        // GET: /ModRezolvare/Create
        public ActionResult Create()
        {
            ViewBag.MartorID = new SelectList(db.MartoriBords, "MartorID", "Nume");
            return View();
        }

        // POST: /ModRezolvare/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="RezolvareID,ModeRezolvare,MartorID")] ModRezolvare modrezolvare)
        {
            if (ModelState.IsValid)
            {
                db.ModRezolvares.Add(modrezolvare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MartorID = new SelectList(db.MartoriBords, "MartorID", "Nume", modrezolvare.MartorID);
            return View(modrezolvare);
        }

        // GET: /ModRezolvare/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModRezolvare modrezolvare = db.ModRezolvares.Find(id);
            if (modrezolvare == null)
            {
                return HttpNotFound();
            }
            ViewBag.MartorID = new SelectList(db.MartoriBords, "MartorID", "Nume", modrezolvare.MartorID);
            return View(modrezolvare);
        }

        // POST: /ModRezolvare/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="RezolvareID,ModeRezolvare,MartorID")] ModRezolvare modrezolvare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modrezolvare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MartorID = new SelectList(db.MartoriBords, "MartorID", "Nume", modrezolvare.MartorID);
            return View(modrezolvare);
        }

        // GET: /ModRezolvare/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModRezolvare modrezolvare = db.ModRezolvares.Find(id);
            if (modrezolvare == null)
            {
                return HttpNotFound();
            }
            return View(modrezolvare);
        }

        // POST: /ModRezolvare/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModRezolvare modrezolvare = db.ModRezolvares.Find(id);
            db.ModRezolvares.Remove(modrezolvare);
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
