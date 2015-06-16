using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SinosPark.Models;

namespace SinosPark.Controllers
{
    public class EstacionamentoesController : Controller
    {
        private SinosParkEntities db = new SinosParkEntities();

        // GET: Estacionamentoes
        public ActionResult Index()
        {
            return View(db.Estacionamento.ToList());
        }

        // GET: Estacionamentoes/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estacionamento estacionamento = db.Estacionamento.Find(id);
            if (estacionamento == null)
            {
                return HttpNotFound();
            }
            return View(estacionamento);
        }

        // GET: Estacionamentoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estacionamentoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,isAtivo,QuantidadeMaxima")] Estacionamento estacionamento)
        {
            if (ModelState.IsValid)
            {
                db.Estacionamento.Add(estacionamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estacionamento);
        }

        // GET: Estacionamentoes/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estacionamento estacionamento = db.Estacionamento.Find(id);
            if (estacionamento == null)
            {
                return HttpNotFound();
            }
            return View(estacionamento);
        }

        // POST: Estacionamentoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,isAtivo,QuantidadeMaxima")] Estacionamento estacionamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estacionamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estacionamento);
        }

        // GET: Estacionamentoes/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estacionamento estacionamento = db.Estacionamento.Find(id);
            if (estacionamento == null)
            {
                return HttpNotFound();
            }
            return View(estacionamento);
        }

        // POST: Estacionamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            Estacionamento estacionamento = db.Estacionamento.Find(id);
            db.Estacionamento.Remove(estacionamento);
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
