using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using SinosPark.Models;
using SinosPark.Utility;
using SinosPark.ViewModels;

namespace SinosPark.Controllers
{
    public class EventoesController : Controller
    {
        private SinosParkEntities db = new SinosParkEntities();

        // GET: Eventoes
        public ActionResult Index()
        {
            return RedirectToAction("Lista");
        }

        public ViewResult RelatorioMovimentacao()
        {
            var evento = db.Evento
               .Include(e => e.Aluno)
               .Include(e => e.Estacionamento)
               .Include(e => e.Veiculo)
               .OrderByDescending(e=>e.Entrada);

            var result = (from e in evento
                          let aluno = e.Aluno
                          let veiculo = e.Veiculo
                          let estacionamento = e.Estacionamento
                          let veiculoModelo = e.Veiculo != null ? e.Veiculo.VeiculoModelo.Descricao : ""
                          let pagamento = e.Pagamento.FirstOrDefault()
                          select new EventoViewModel
                          {
                              AlunoMatricula = aluno == null ? "" : aluno.Matricula,
                              AlunoNome = aluno == null ? "" : aluno.Nome,
                              VeiculoCor = veiculo == null ? "" : veiculo.Cor,
                              VeiculoPlaca = veiculo == null ? "" : veiculo.Placa,
                              VeiculoModelo = veiculoModelo,
                              EstacionamentoNome = estacionamento.Nome,
                              EventoId = e.Id,
                              Entrada = e.Entrada,
                              Saida = e.Saida,
                              PagamentoId = pagamento != null ? pagamento.Id : 0
                          }).ToList();

            return View(result);
        }

        public ActionResult Lista(string matricula, string placa)
        {
            var evento = db.Evento
                .Include(e => e.Aluno)
                .Include(e => e.Estacionamento)
                .Include(e => e.Veiculo);

            if (!string.IsNullOrEmpty(matricula))
            {
                ViewBag.SearchMatricula = matricula;
                evento = evento.Where(x => (x.Aluno != null && x.Aluno.Matricula.Contains(matricula)));
            }
            if (!string.IsNullOrEmpty(placa))
            {
                ViewBag.SearchPlaca = placa;
                evento = evento.Where(x => (x.Veiculo != null && x.Veiculo.Placa.Contains(placa)));
            }

            var result = (from e in evento
                let aluno = e.Aluno
                let veiculo = e.Veiculo
                let estacionamento = e.Estacionamento
                let veiculoModelo = e.Veiculo != null ? e.Veiculo.VeiculoModelo.Descricao : ""
                let pagamento = e.Pagamento.FirstOrDefault()
                select new EventoViewModel
                {
                    AlunoMatricula = aluno == null ? "" : aluno.Matricula,
                    AlunoNome = aluno == null ? "" : aluno.Nome,
                    VeiculoCor = veiculo == null ? "" : veiculo.Cor,
                    VeiculoPlaca = veiculo == null ? "" : veiculo.Placa,
                    VeiculoModelo = veiculoModelo,
                    EstacionamentoNome = estacionamento.Nome,
                    EventoId = e.Id,
                    Entrada = e.Entrada,
                    Saida = e.Saida,
                    PagamentoId = pagamento != null ? pagamento.Id : 0
                }).ToList();

            return View(result);
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

        [HttpPost]
        public ActionResult ComprovantePagamento(EventoPagamentoViewModel viewModel)
        {
            var evento = db.Evento.Find(viewModel.EventoId);
            if (evento == null)
            {
                return HttpNotFound();
            }
            
            PagamentoTipo pagamentoTipo = db.PagamentoTipo.First(x => x.Id == viewModel.PagamentoId);
            viewModel = new EventoPagamentoViewModel
            {
                PagamentoNome = pagamentoTipo.Descricao,
                DataEntrada = evento.Entrada,
                DataSaida = DateTime.Now
            };

            var tempo = viewModel.DataSaida - viewModel.DataEntrada;

            var hora = tempo.Hours;
            var minutos = tempo.Minutes;

            if (minutos >= 30)
            {
                hora += 1;
            }

            viewModel.Tempo = new TimeSpan(0, hora, minutos, 0);

            var tempoFilter = new TimeSpan(0, hora, 0, 0);

            var preco = db.Preco.FirstOrDefault(x => x.Tempo == tempoFilter);

            viewModel.Valor = (preco != null) ? preco.Valor : 10;

            if (evento.Aluno != null)
            {
                viewModel.AlunoMatricula = evento.Aluno.Matricula;
                viewModel.AlunoNome = evento.Aluno.Nome;
            }

            if (evento.Veiculo != null)
            {
                viewModel.VeiculoPlaca = evento.Veiculo.Placa;
                viewModel.VeiculoCor = evento.Veiculo.Cor;
                viewModel.VeiculoModelo = evento.Veiculo.VeiculoModelo.Descricao;
            }

            var pagamento = new Pagamento
            {
                DataHoraPagamento = DateTime.Now,
                Evento = evento,
                PagamentoTipo = pagamentoTipo,
                Tempo = viewModel.Tempo,
                Valor = viewModel.Valor
            };

            db.Pagamento.Add(pagamento);
            db.SaveChanges();

            evento.Saida = viewModel.DataSaida;
            db.Entry(evento).State = EntityState.Modified;
            db.SaveChanges();
            
            return View(viewModel);
        }

        public ViewResult ComprovantePagamento(int pagamentoId)
        {
            var pagamento = db.Pagamento.Find(pagamentoId);


            var viewModel = new EventoPagamentoViewModel
            {
                PagamentoNome = pagamento.PagamentoTipo.Descricao,
                DataEntrada = pagamento.Evento.Entrada,
                DataSaida = pagamento.Evento.Saida.GetValueOrDefault(),
                Valor = (decimal) pagamento.Valor,
                DataPagamento = (DateTime) pagamento.DataHoraPagamento,
                Tempo = (TimeSpan) pagamento.Tempo
            };

            
            if (pagamento.Evento.Aluno != null)
            {
                viewModel.AlunoMatricula = pagamento.Evento.Aluno.Matricula;
                viewModel.AlunoNome = pagamento.Evento.Aluno.Nome;
            }

            if (pagamento.Evento.Veiculo != null)
            {
                viewModel.VeiculoPlaca = pagamento.Evento.Veiculo.Placa;
                viewModel.VeiculoCor = pagamento.Evento.Veiculo.Cor;
                viewModel.VeiculoModelo = pagamento.Evento.Veiculo.VeiculoModelo.Descricao;
            }

            return View(viewModel);
        }

        public ActionResult Saida(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var evento = db.Evento.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }

            var viewModel = new EventoPagamentoViewModel
            {
                Pagamentos = db.PagamentoTipo.Where(x => x.isAtivo).Select(x => new SelectListItem
                {
                    Text = x.Descricao,
                    Value = x.Id.ToString()
                })
                    .OrderBy(x => x.Text)
                    .ToList(),
                DataEntrada = evento.Entrada,
            };
            viewModel.DataSaida = DateTime.Now;
            var tempo = viewModel.DataSaida - viewModel.DataEntrada;

            var hora = tempo.Hours;
            var minutos = tempo.Minutes;

            if (minutos >= 30)
            {
                hora += 1;
            }

            viewModel.Tempo = new TimeSpan(0, hora, minutos, 0);

            var tempoFilter = new TimeSpan(0, hora, 0, 0);

            var preco = db.Preco.FirstOrDefault(x => x.Tempo == tempoFilter);

            viewModel.Valor = (preco != null) ? preco.Valor : 10;

            viewModel.EventoId = evento.Id;

            return View(viewModel);
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
            var viewModel = GetEventoViewModel();

            return View(viewModel);
        }

        private EventoViewModel GetEventoViewModel()
        {
            var viewModel = new EventoViewModel
            {
                Alunos = db.Aluno.Select(x => new SelectListItem
                {
                    Text = x.Nome,
                    Value = x.Id.ToString()
                })
                    .OrderBy(x => x.Text)
                    .ToList()
            };


            viewModel.Alunos.Insert(0, new SelectListItem
            {
                Text = "",
                Value = "-1"
            });

            viewModel.Veiculos = db.Veiculo.Select(x => new SelectListItem
            {
                Text = x.Placa,
                Value = x.Id.ToString()
            })
                .OrderBy(x => x.Text)
                .ToList();

            viewModel.Veiculos.Insert(0, new SelectListItem
            {
                Text = "",
                Value = "-1"
            });

            viewModel.Estacionamentos = db.Estacionamento.Select(x => new SelectListItem
            {
                Text = x.Nome,
                Value = x.Id.ToString()
            })
                .OrderBy(x => x.Text)
                .ToList();

            viewModel.Entrada = DateTime.Now;

            return viewModel;
        }

        public ViewResult RelatorioFinanceiro()
        {
            var vm = db.Pagamento
                .GroupBy(x => new
                {
                    x.DataHoraPagamento.Value.Month, 
                    x.Evento.Estacionamento
                })
                .Select(y => new RelatorioFinanceiroViewModel
                {
                    EstacionamentoNome = y.Key.Estacionamento.Nome,
                    MesId= y.Key.Month,
                    Valor = y.Sum(v => v.Valor.Value)
                })
                .ToList();
            vm.ForEach(x=>x.MesNome = x.MesId.GetMonthName());
            return View(vm);
        }

        [HttpPost]
        public ActionResult Ticket(EventoViewModel viewModel)
        {
            if (viewModel.VeiculoId == -1 && viewModel.AlunoId == -1)
            {
                return RedirectToAction("Entrada");
            }

            Aluno aluno = null;
            Veiculo veiculo = null;

            if (viewModel.AlunoId > -1)
            {
                aluno = db.Aluno.Find(viewModel.AlunoId);
                viewModel.AlunoMatricula = aluno.Matricula;
                viewModel.AlunoNome = aluno.Nome;
            }

            var estacionamento = db.Estacionamento.Find(viewModel.EstacionamentoId);
            viewModel.EstacionamentoNome = estacionamento.Nome;

            if (viewModel.VeiculoId > -1)
            {
                veiculo = db.Veiculo.Find(viewModel.VeiculoId);
                viewModel.VeiculoPlaca = veiculo.Placa;
                viewModel.VeiculoCor = veiculo.Cor;
            }
            var evento = new Evento
            {
                Estacionamento = estacionamento,
                Veiculo = veiculo,
                Aluno = aluno,
                Entrada = viewModel.Entrada.GetValueOrDefault(),
                CodigoBarras = ""
            };
            db.Evento.Add(evento);
            db.SaveChanges();

            return View(viewModel);
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
