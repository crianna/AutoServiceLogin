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
    public class ProducatorController : Controller
    {
        private AutoServiceEntities db = new AutoServiceEntities();

        // GET: /Producator/
        public ActionResult Index()
        {
            return View(db.Producators.ToList());
        }

        // GET: /Producator/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producator producator = db.Producators.Find(id);
            if (producator == null)
            {
                return HttpNotFound();
            }
            return View(producator);
        }

        // GET: /Producator/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Producator/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ProducatorID,Nume")] Producator producator)
        {
            if (ModelState.IsValid)
            {
                db.Producators.Add(producator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producator);
        }

        // GET: /Producator/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producator producator = db.Producators.Find(id);
            if (producator == null)
            {
                return HttpNotFound();
            }
            return View(producator);
        }

        // POST: /Producator/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ProducatorID,Nume")] Producator producator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producator);
        }

        // GET: /Producator/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producator producator = db.Producators.Find(id);
            if (producator == null)
            {
                return HttpNotFound();
            }
            return View(producator);
        }

        // POST: /Producator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producator producator = db.Producators.Find(id);
            db.Producators.Remove(producator);
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
