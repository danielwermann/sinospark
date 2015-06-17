using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SinosPark.ViewModels
{
    public class EventoPagamentoViewModel
    {
        public List<SelectListItem> Pagamentos { get; set; }
        public int PagamentoId { get; set; }
        public int EventoId { get; set; }
        public string PagamentoNome { get; set; }
        public string AlunoNome { get; set; }
        public string AlunoMatricula { get; set; }
        public string VeiculoPlaca { get; set; }
        public string VeiculoCor { get; set; }
        public string VeiculoModelo { get; set; }
        public DateTime DataSaida { get; set; }

        public DateTime DataEntrada { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal Valor { get; set; }

        public TimeSpan Tempo { get; set; }
    }
}