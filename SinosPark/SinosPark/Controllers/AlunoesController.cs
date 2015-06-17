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
    public class AlunoesController : Controller
    {
        private SinosParkEntities db = new SinosParkEntities();

        // GET: Alunoes
        public ActionResult Index()
        {
            return View(db.Aluno.ToList());
        }

        // GET: Alunoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Aluno.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: Alunoes/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ComprarCreditos()
        {
            var viewModel = new CreditoViewModel();
            using (var db = new SinosParkEntities())
            {
                viewModel.Alunos = db.Aluno.Select(x => new SelectListItem
                {
                    Text = x.Nome,
                    Value = x.Id.ToString()
                })
                .OrderBy(x => x.Text)
                .ToList();

                viewModel.PagamentoTipos = db.PagamentoTipo.Select(x => new SelectListItem
                {
                    Text = x.Descricao,
                    Value = x.Id.ToString()
                })
                .OrderBy(x => x.Text)
                .ToList();
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ComprovanteVenda(CreditoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("ComprarCreditos");
            }

            using (var db = new SinosParkEntities())
            {
                var aluno = db.Aluno.Find(viewModel.AlunoId);
                var saldoAtual = aluno.ValorSaldo;
                saldoAtual += viewModel.Valor;
                aluno.ValorSaldo = saldoAtual;
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();

                var pagamentoTipo = db.PagamentoTipo.Find(viewModel.PagamentoTipoId);

                viewModel.AlunoNome = aluno.Nome;
                viewModel.PagamentoTipoNome = pagamentoTipo.Descricao;
                viewModel.AlunoMatricula = aluno.Matricula;
            }

            viewModel.DataCompra = DateTime.Now;

            return View(viewModel);
        }

        // POST: Alunoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CPF,Matricula,Nome,ValorSaldo")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Aluno.Add(aluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        // GET: Alunoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Aluno.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CPF,Matricula,Nome,ValorSaldo")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        // GET: Alunoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Aluno.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluno aluno = db.Aluno.Find(id);
            db.Aluno.Remove(aluno);
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
