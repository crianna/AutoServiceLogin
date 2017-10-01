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
    public class MotorizareController : Controller
    {
        private AutoServiceEntities db = new AutoServiceEntities();

        // GET: /Motorizare/
        public ActionResult Index()
        {
            return View(db.Motorizares.ToList());
        }

        // GET: /Motorizare/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorizare motorizare = db.Motorizares.Find(id);
            if (motorizare == null)
            {
                return HttpNotFound();
            }
            return View(motorizare);
        }

        // GET: /Motorizare/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Motorizare/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MotorizareID,Nume,ProducatorID")] Motorizare motorizare)
        {
            if (ModelState.IsValid)
            {
                db.Motorizares.Add(motorizare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(motorizare);
        }

        // GET: /Motorizare/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorizare motorizare = db.Motorizares.Find(id);
            if (motorizare == null)
            {
                return HttpNotFound();
            }
            return View(motorizare);
        }

        // POST: /Motorizare/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MotorizareID,Nume,ProducatorID")] Motorizare motorizare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motorizare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(motorizare);
        }

        // GET: /Motorizare/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorizare motorizare = db.Motorizares.Find(id);
            if (motorizare == null)
            {
                return HttpNotFound();
            }
            return View(motorizare);
        }

        // POST: /Motorizare/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Motorizare motorizare = db.Motorizares.Find(id);
            db.Motorizares.Remove(motorizare);
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
