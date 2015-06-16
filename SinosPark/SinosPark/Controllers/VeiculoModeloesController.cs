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
    public class VeiculoModeloesController : Controller
    {
        private SinosParkEntities db = new SinosParkEntities();

        // GET: VeiculoModeloes
        public ActionResult Index()
        {
            return View(db.VeiculoModelo.ToList());
        }

        // GET: VeiculoModeloes/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VeiculoModelo veiculoModelo = db.VeiculoModelo.Find(id);
            if (veiculoModelo == null)
            {
                return HttpNotFound();
            }
            return View(veiculoModelo);
        }

        // GET: VeiculoModeloes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VeiculoModeloes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,isAtivo,isMoto")] VeiculoModelo veiculoModelo)
        {
            if (ModelState.IsValid)
            {
                db.VeiculoModelo.Add(veiculoModelo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(veiculoModelo);
        }

        // GET: VeiculoModeloes/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VeiculoModelo veiculoModelo = db.VeiculoModelo.Find(id);
            if (veiculoModelo == null)
            {
                return HttpNotFound();
            }
            return View(veiculoModelo);
        }

        // POST: VeiculoModeloes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,isAtivo,isMoto")] VeiculoModelo veiculoModelo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veiculoModelo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(veiculoModelo);
        }

        // GET: VeiculoModeloes/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VeiculoModelo veiculoModelo = db.VeiculoModelo.Find(id);
            if (veiculoModelo == null)
            {
                return HttpNotFound();
            }
            return View(veiculoModelo);
        }

        // POST: VeiculoModeloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            VeiculoModelo veiculoModelo = db.VeiculoModelo.Find(id);
            db.VeiculoModelo.Remove(veiculoModelo);
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
