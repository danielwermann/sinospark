using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinosPark.ViewModels
{
    public class CreditoViewModel
    {
        public int AlunoId { get; set; }
        public string AlunoNome { get; set; }
        public string AlunoMatricula { get; set; }
        public int PagamentoTipoId { get; set; }
        public string PagamentoTipoNome { get; set; }
        public DateTime DataCompra { get; set; }
        public List<SelectListItem> Alunos { get; set; }
        public List<SelectListItem> PagamentoTipos { get; set; }
        public decimal Valor { get; set; }
    }
}