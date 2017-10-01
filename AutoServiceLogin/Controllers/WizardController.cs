using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoServiceLogin.Controllers
{

    [Authorize]
    public class WizardController : Controller
    {
        private AutoServiceEntities db = new AutoServiceEntities();

        //
        // GET: /Wizard/
        public ActionResult Index()
        {
            return View();
        }



        public JsonResult GetProducatori(string q)
        {
            var producatori = db.Producators.Where(p => p.Nume.ToLower().Contains(q.ToLower())).ToList();
            Dictionary<int, String> toSerialize = new Dictionary<int, String>();

            foreach (Producator prod in producatori)
            {
                toSerialize.Add(prod.ProducatorID, prod.Nume);
            }

            return Json(toSerialize.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMotorizare(int ProdId,string q)
        {
            var motorizari = db.Motorizares
                .Where(p=> p.ProducatorID == ProdId)
                .Where(p => p.Nume.ToLower().Contains(q.ToLower())).ToList();
            Dictionary<int, String> toSerialize = new Dictionary<int, String>();

            foreach (Motorizare mot in motorizari)
            {
                toSerialize.Add(mot.MotorizareID, mot.Nume);
            }

            return Json(toSerialize.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAn(int ProdId, string q)
        {
            var motorizari = db.Motorizares
                .Where(p => p.ProducatorID == ProdId)
                .Where(p => p.An.ToLower().Contains(q.ToLower())).ToList();
            Dictionary<int, String> toSerialize = new Dictionary<int, String>();

            foreach (Motorizare mot in motorizari)
            {
                toSerialize.Add(mot.MotorizareID, mot.An);
            }

            return Json(toSerialize.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetModele(int ProdId, string q)
        {
            var modele = db.Models
                .Where(m => m.ProducatorID == (int)ProdId).Distinct()
                .Where(p => p.Nume.ToLower().Contains(q.ToLower()))
                .ToList();

            Dictionary<int, String> toSerialize = new Dictionary<int, String>();

            foreach (Model m in modele)
            {
                toSerialize.Add(m.ModelID, m.Nume);
            }
            return Json(toSerialize.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMartori(int p, int m,int mot)
        {
            Producator producator = db.Producators.Where(_p => _p.ProducatorID == p).First();
            Model model = db.Models.Where(_m => _m.ModelID == m).First();
            Motorizare motorizare = db.Motorizares.Where(_mot => _mot.MotorizareID == mot).First();
           
            ViewBag.Model = model.Nume;
            ViewBag.Producator = producator.Nume;
            ViewBag.Motorizare = motorizare.Nume;
            ViewBag.An = motorizare.An;

            ViewBag.m = model.ModelID;
            ViewBag.p = producator.ProducatorID;
            ViewBag.mot = motorizare.MotorizareID;


            var martori = db.MartoriBords.ToList();

            return View(martori);
        }

        protected bool inArray(string[] ar, int toCheck)
        {
            foreach (string s in ar)
            {
                if( Int32.Parse(s) == toCheck){
                    return true;
                }
            }

            return false;
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Finish(string[] martorSelectat, int p, int m)
        {
            List<int> l = new List<int>();
            
            if (martorSelectat != null)
            {

                foreach (var s in martorSelectat)
                {
                    l.Add(Int32.Parse(s));
                }

            }

            ViewBag.p = p;

            var martori = db.MartoriBords.Where(_m => l.Contains(_m.MartorID)).ToList();
            return View(martori);

           
           
        }

        public ActionResult Map(int p)
        {
            ViewBag.p = p;
            return View();
        }


        public JsonResult GetMapMarkers(int p)
        {
            var markers = db.Services.Where(s => s.ProducatorID==p);

            return Json(markers.ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}