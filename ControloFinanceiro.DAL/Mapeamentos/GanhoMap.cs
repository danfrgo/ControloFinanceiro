using ControloFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControloFinanceiro.DAL.Mapeamentos
{
    public class GanhoMap : IEntityTypeConfiguration<Ganho>
    {
        public void Configure(EntityTypeBuilder<Ganho> builder)
        {
            builder.HasKey(g => g.GanhoId);

            builder.Property(g => g.Descricao).IsRequired().HasMaxLength(50);

            builder.Property(g => g.Valor).IsRequired();

            builder.Property(g => g.Dia).IsRequired();

            builder.Property(g => g.Ano).IsRequired();

            // um ganho está associado a uma categoria, mas uma categoria está associado a n ganhos
            builder.HasOne(g => g.Categoria).WithMany(g => g.Ganhos).HasForeignKey(g => g.CategoriaId).IsRequired();

            // um ganho está associada a um mes, mas um mes está associado a n ganhos
            builder.HasOne(g => g.Mes).WithMany(g => g.Ganhos).HasForeignKey(g => g.MesId).IsRequired();

            // um ganho está associado a um utilizador, mas um utilizador está associado a n ganhos
            builder.HasOne(g => g.Utilizador).WithMany(g => g.Ganhos).HasForeignKey(g => g.UtilizadorId).IsRequired();

            builder.ToTable("Ganhos");
        }
    }
}

