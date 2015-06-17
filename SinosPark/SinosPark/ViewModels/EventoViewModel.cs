using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SinosPark.ViewModels
{
    public class EventoViewModel
    {
        public int AlunoId { get; set; }
        public int EstacionamentoId { get; set; }
        public int VeiculoId { get; set; }
        public string AlunoNome { get; set; }
        public string AlunoMatricula { get; set; }
        public string VeiculoPlaca { get; set; }
        public string VeiculoCor { get; set; }
        public string VeiculoModelo { get; set; }
        public string  EstacionamentoNome { get; set; }
        public int PagamentoId { get; set; }
        public DateTime? Entrada { get; set; }
        public DateTime? Saida { get; set; }
        public string CodigoBarras { get; set; }

        public List<SelectListItem> Estacionamentos { get; set; }
        public List<SelectListItem> Veiculos { get; set; }
        public List<SelectListItem> Alunos { get; set; }
        public int EventoId { get; set; }
    }
}