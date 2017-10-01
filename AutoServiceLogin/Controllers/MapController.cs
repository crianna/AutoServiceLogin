using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoServiceLogin.Models;

namespace AutoServiceLogin.Controllers
{
    public class MapController : Controller
    {
        //
        // GET: /Map/
        public ActionResult Index()
        {
            AutoServiceEntities GE = new AutoServiceEntities();
            return View(GE.Services.ToList());
        }
	}
}