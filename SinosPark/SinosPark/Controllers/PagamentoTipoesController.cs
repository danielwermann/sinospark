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
    public class PagamentoTipoesController : Controller
    {
        private SinosParkEntities db = new SinosParkEntities();

        // GET: PagamentoTipoes
        public ActionResult Index()
        {
            return View(db.PagamentoTipo.ToList());
        }

        // GET: PagamentoTipoes/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagamentoTipo pagamentoTipo = db.PagamentoTipo.Find(id);
            if (pagamentoTipo == null)
            {
                return HttpNotFound();
            }
            return View(pagamentoTipo);
        }

        // GET: PagamentoTipoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PagamentoTipoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,isAtivo")] PagamentoTipo pagamentoTipo)
        {
            if (ModelState.IsValid)
            {
                db.PagamentoTipo.Add(pagamentoTipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pagamentoTipo);
        }

        // GET: PagamentoTipoes/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagamentoTipo pagamentoTipo = db.PagamentoTipo.Find(id);
            if (pagamentoTipo == null)
            {
                return HttpNotFound();
            }
            return View(pagamentoTipo);
        }

        // POST: PagamentoTipoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,isAtivo")] PagamentoTipo pagamentoTipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagamentoTipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pagamentoTipo);
        }

        // GET: PagamentoTipoes/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagamentoTipo pagamentoTipo = db.PagamentoTipo.Find(id);
            if (pagamentoTipo == null)
            {
                return HttpNotFound();
            }
            return View(pagamentoTipo);
        }

        // POST: PagamentoTipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            PagamentoTipo pagamentoTipo = db.PagamentoTipo.Find(id);
            db.PagamentoTipo.Remove(pagamentoTipo);
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
