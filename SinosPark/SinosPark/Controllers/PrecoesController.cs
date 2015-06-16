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
    public class PrecoesController : Controller
    {
        private SinosParkEntities db = new SinosParkEntities();

        // GET: Precoes
        public ActionResult Index()
        {
            return View(db.Preco.ToList());
        }

        // GET: Precoes/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preco preco = db.Preco.Find(id);
            if (preco == null)
            {
                return HttpNotFound();
            }
            return View(preco);
        }

        // GET: Precoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Precoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tempo,Valor,isMoto,isAtivo")] Preco preco)
        {
            if (ModelState.IsValid)
            {
                db.Preco.Add(preco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(preco);
        }

        // GET: Precoes/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preco preco = db.Preco.Find(id);
            if (preco == null)
            {
                return HttpNotFound();
            }
            return View(preco);
        }

        // POST: Precoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tempo,Valor,isMoto,isAtivo")] Preco preco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(preco);
        }

        // GET: Precoes/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preco preco = db.Preco.Find(id);
            if (preco == null)
            {
                return HttpNotFound();
            }
            return View(preco);
        }

        // POST: Precoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            Preco preco = db.Preco.Find(id);
            db.Preco.Remove(preco);
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
