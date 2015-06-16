using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using SinosPark.Models;

namespace SinosPark.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Sinos Park";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetEstacionamentos()
        {
            IEnumerable<Estacionamento> t = new List<Estacionamento>();
            using (var db = new SinosParkEntities())
            {
                t = db.Estacionamento.Where(p => p.isAtivo).ToList();
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }
    }
}