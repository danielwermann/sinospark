//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SinosPark.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pagamento
    {
        public int Id { get; set; }
        public Nullable<System.TimeSpan> Tempo { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public Nullable<System.DateTime> DataHoraPagamento { get; set; }
        public short EventoId { get; set; }
        public byte PagamentoTipoId { get; set; }
    
        public virtual Evento Evento { get; set; }
        public virtual PagamentoTipo PagamentoTipo { get; set; }
    }
}
