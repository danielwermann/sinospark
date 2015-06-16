using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SinosPark.Models;
using SinosPark.ViewModels;

namespace SinosPark.Controllers
{
    public class EventoesController : Controller
    {
        private SinosParkEntities db = new SinosParkEntities();

        // GET: Eventoes
        public ActionResult Index()
        {
            var evento = db.Evento.Include(e => e.Aluno).Include(e => e.Estacionamento).Include(e => e.Veiculo);
            return View(evento.ToList());
        }

        // GET: Eventoes/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Evento.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // GET: Eventoes/Create
        public ActionResult Create()
        {
            ViewBag.AlunoId = new SelectList(db.Aluno, "Id", "CPF");
            ViewBag.EstacionamentoId = new SelectList(db.Estacionamento, "Id", "Nome");
            ViewBag.VeiculoId = new SelectList(db.Veiculo, "Id", "Placa");
            return View();
        }

        public ActionResult Entrada()
        {
            var viewModel = new EventoViewModel();
            using (var db = new SinosParkEntities())
            {
                viewModel.Alunos = db.Aluno.Select(x => new SelectListItem
                {
                    Text = x.Nome, 
                    Value = x.Id.ToString()
                })
                .OrderBy(x => x.Text)
                .ToList();

                viewModel.Veiculos = db.Veiculo.Select(x => new SelectListItem
                {
                    Text = x.Placa,
                    Value = x.Id.ToString()
                })
                .OrderBy(x => x.Text)
                .ToList();

                viewModel.Estacionamentos = db.Estacionamento.Select(x => new SelectListItem
                {
                    Text = x.Nome,
                    Value = x.Id.ToString()
                })
                .OrderBy(x => x.Text)
                .ToList();

                viewModel.Entrada = DateTime.Now;
            }
            
            return View(viewModel);
        }

        public ActionResult SaveEntrada(EventoViewModel viewModel)
        {
            return RedirectToAction("Entrada", viewModel);
        }

        public ActionResult Saida()
        {
            return Index();
        }

        // POST: Eventoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Entrada,Saida,CodigoBarras,VeiculoId,AlunoId,EstacionamentoId")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Evento.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlunoId = new SelectList(db.Aluno, "Id", "CPF", evento.AlunoId);
            ViewBag.EstacionamentoId = new SelectList(db.Estacionamento, "Id", "Nome", evento.EstacionamentoId);
            ViewBag.VeiculoId = new SelectList(db.Veiculo, "Id", "Placa", evento.VeiculoId);
            return View(evento);
        }

        // GET: Eventoes/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Evento.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlunoId = new SelectList(db.Aluno, "Id", "CPF", evento.AlunoId);
            ViewBag.EstacionamentoId = new SelectList(db.Estacionamento, "Id", "Nome", evento.EstacionamentoId);
            ViewBag.VeiculoId = new SelectList(db.Veiculo, "Id", "Placa", evento.VeiculoId);
            return View(evento);
        }

        // POST: Eventoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Entrada,Saida,CodigoBarras,VeiculoId,AlunoId,EstacionamentoId")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlunoId = new SelectList(db.Aluno, "Id", "CPF", evento.AlunoId);
            ViewBag.EstacionamentoId = new SelectList(db.Estacionamento, "Id", "Nome", evento.EstacionamentoId);
            ViewBag.VeiculoId = new SelectList(db.Veiculo, "Id", "Placa", evento.VeiculoId);
            return View(evento);
        }

        // GET: Eventoes/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Evento.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: Eventoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            Evento evento = db.Evento.Find(id);
            db.Evento.Remove(evento);
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
