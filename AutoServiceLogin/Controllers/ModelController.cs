using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoServiceLogin.Models;
using AutoServiceLogin;

namespace AutoService.Controllers
{
    public class ModelController : Controller
    {
        private AutoServiceLogin.AutoServiceEntities db = new AutoServiceLogin.AutoServiceEntities();

        // GET: /Model/
        public ActionResult Index()
        {

            string selectie = this.Request.QueryString["option"];
            string cautare = this.Request.QueryString["cautare"];

            Model modelMasina = new Model();
            ViewBag.producatorSelected = selectie == "Producator";

            if (selectie == "Producator")
            {

                //  return View(db.Producators.Where(s=>s.Nume.ToLower() == cautare.ToLower() || cautare == null).ToList());
                List<Model> result;
                result = db.Models.Where(s => s.Producator.Nume.ToLower() == cautare.ToLower() || cautare == null).ToList();
                return View(result);
            }
            else if (selectie == "Model")
            {

                return View(db.Models.Where(s => s.Nume == cautare || cautare == null).ToList());
            }
            else
            {

                return View(db.Models.Where(s => s.Nume.StartsWith(cautare) || cautare == null));
            }



        }

        // GET: /Model/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: /Model/Create
        public ActionResult Create()
        {
            ViewBag.ProducatorID = new SelectList(db.Producators, "ProducatorID", "Nume");
            return View();
        }

        // POST: /Model/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModelID,Nume,ProducatorID")] Model model)
        {
            if (ModelState.IsValid)
            {
                db.Models.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProducatorID = new SelectList(db.Producators, "ProducatorID", "Nume", model.ProducatorID);
            return View(model);
        }

        // GET: /Model/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProducatorID = new SelectList(db.Producators, "ProducatorID", "Nume", model.ProducatorID);
            return View(model);
        }

        // POST: /Model/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModelID,Nume,ProducatorID")] Model model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProducatorID = new SelectList(db.Producators, "ProducatorID", "Nume", model.ProducatorID);
            return View(model);
        }

        // GET: /Model/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: /Model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Model model = db.Models.Find(id);
            db.Models.Remove(model);
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
