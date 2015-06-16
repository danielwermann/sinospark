using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SinosPark.Models;

namespace SinosPark.ViewModels
{
    public class EventoViewModel
    {
        public int AlunoId { get; set; }
        public int EstacionamentoId { get; set; }
        public int VeiculoId { get; set; }
        public DateTime? Entrada { get; set; }
        public DateTime? Saida { get; set; }
        public string CodigoBarras { get; set; }

        public List<SelectListItem> Estacionamentos { get; set; }
        public List<SelectListItem> Veiculos { get; set; }
        public List<SelectListItem> Alunos { get; set; }

    }
}