﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SinosParkEntities : DbContext
    {
        public SinosParkEntities()
            : base("name=SinosParkEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Aluno> Aluno { get; set; }
        public virtual DbSet<Estacionamento> Estacionamento { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<Pagamento> Pagamento { get; set; }
        public virtual DbSet<PagamentoTipo> PagamentoTipo { get; set; }
        public virtual DbSet<Preco> Preco { get; set; }
        public virtual DbSet<Veiculo> Veiculo { get; set; }
        public virtual DbSet<VeiculoModelo> VeiculoModelo { get; set; }
    }
}
