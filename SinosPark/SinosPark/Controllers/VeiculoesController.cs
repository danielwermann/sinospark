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
    public class VeiculoesController : Controller
    {
        private SinosParkEntities db = new SinosParkEntities();

        // GET: Veiculoes
        public ActionResult Index()
        {
            var veiculo = db.Veiculo.Include(v => v.VeiculoModelo);
            return View(veiculo.ToList());
        }

        // GET: Veiculoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculo.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // GET: Veiculoes/Create
        public ActionResult Create()
        {
            ViewBag.VeiculoModeloId = new SelectList(db.VeiculoModelo, "Id", "Descricao");
            return View();
        }

        // POST: Veiculoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Placa,Cor,VeiculoModeloId,isBloqueado")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Veiculo.Add(veiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VeiculoModeloId = new SelectList(db.VeiculoModelo, "Id", "Descricao", veiculo.VeiculoModeloId);
            return View(veiculo);
        }

        // GET: Veiculoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculo.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.VeiculoModeloId = new SelectList(db.VeiculoModelo, "Id", "Descricao", veiculo.VeiculoModeloId);
            return View(veiculo);
        }

        // POST: Veiculoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Placa,Cor,VeiculoModeloId,isBloqueado")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VeiculoModeloId = new SelectList(db.VeiculoModelo, "Id", "Descricao", veiculo.VeiculoModeloId);
            return View(veiculo);
        }

        // GET: Veiculoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculo.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // POST: Veiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Veiculo veiculo = db.Veiculo.Find(id);
            db.Veiculo.Remove(veiculo);
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
