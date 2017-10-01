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
    public class VehiculController : Controller
    {
        private AutoServiceEntities db = new AutoServiceEntities();

        // GET: /Vehicul/
        public ActionResult Index()
        {
            var vehiculs = db.Vehiculs.Include(v => v.An1).Include(v => v.Model).Include(v => v.Motorizare);
            return View(vehiculs.ToList());
        }

        // GET: /Vehicul/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicul vehicul = db.Vehiculs.Find(id);
            if (vehicul == null)
            {
                return HttpNotFound();
            }
            return View(vehicul);
        }

        // GET: /Vehicul/Create
        public ActionResult Create()
        {
            ViewBag.An = new SelectList(db.Ans, "AnID", "AnID");
            ViewBag.ModelID = new SelectList(db.Models, "ModelID", "Nume");
            ViewBag.MotorizareID = new SelectList(db.Motorizares, "MotorizareID", "Nume");
            return View();
        }

        // POST: /Vehicul/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="VehiculID,ModelID,MotorizareID,An")] Vehicul vehicul)
        {
            if (ModelState.IsValid)
            {
                db.Vehiculs.Add(vehicul);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.An = new SelectList(db.Ans, "AnID", "AnID", vehicul.An);
            ViewBag.ModelID = new SelectList(db.Models, "ModelID", "Nume", vehicul.ModelID);
            ViewBag.MotorizareID = new SelectList(db.Motorizares, "MotorizareID", "Nume", vehicul.MotorizareID);
            return View(vehicul);
        }

        // GET: /Vehicul/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicul vehicul = db.Vehiculs.Find(id);
            if (vehicul == null)
            {
                return HttpNotFound();
            }
            ViewBag.An = new SelectList(db.Ans, "AnID", "AnID", vehicul.An);
            ViewBag.ModelID = new SelectList(db.Models, "ModelID", "Nume", vehicul.ModelID);
            ViewBag.MotorizareID = new SelectList(db.Motorizares, "MotorizareID", "Nume", vehicul.MotorizareID);
            return View(vehicul);
        }

        // POST: /Vehicul/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="VehiculID,ModelID,MotorizareID,An")] Vehicul vehicul)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicul).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.An = new SelectList(db.Ans, "AnID", "AnID", vehicul.An);
            ViewBag.ModelID = new SelectList(db.Models, "ModelID", "Nume", vehicul.ModelID);
            ViewBag.MotorizareID = new SelectList(db.Motorizares, "MotorizareID", "Nume", vehicul.MotorizareID);
            return View(vehicul);
        }

        // GET: /Vehicul/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicul vehicul = db.Vehiculs.Find(id);
            if (vehicul == null)
            {
                return HttpNotFound();
            }
            return View(vehicul);
        }

        // POST: /Vehicul/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicul vehicul = db.Vehiculs.Find(id);
            db.Vehiculs.Remove(vehicul);
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
