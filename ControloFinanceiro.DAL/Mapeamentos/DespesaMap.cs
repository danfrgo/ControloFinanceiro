using ControloFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControloFinanceiro.DAL.Mapeamentos
{
    public class DespesaMap : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder.HasKey(d => d.DespesaId);

            builder.Property(d => d.Descricao).IsRequired().HasMaxLength(50);

            builder.Property(d => d.Valor).IsRequired();

            builder.Property(d => d.Dia).IsRequired();

            builder.Property(d => d.Ano).IsRequired();

            // uma despesa está associada a um cartao, mas um cartao está associado a n despesas
            builder.HasOne(d => d.Cartao).WithMany(d => d.Despesas).HasForeignKey(d => d.CartaoId).IsRequired();

            // uma despesa está associada a uma categoria, mas uma categoria está associada a n despesas
            builder.HasOne(d => d.Categoria).WithMany(d => d.Despesas).HasForeignKey(d => d.CategoriaId).IsRequired();

            // uma despesa está associada a um mes, mas um mes está associada a n despesas
            builder.HasOne(d => d.Mes).WithMany(d => d.Despesas).HasForeignKey(d => d.MesId).IsRequired();

            // uma despesa está associada a um utilizador, mas um utilizador está associada a n despesas
            builder.HasOne(d => d.Utilizador).WithMany(d => d.Despesas).HasForeignKey(d => d.Utilizadorid).IsRequired();

            builder.ToTable("Despesas");
        }
    }
}

