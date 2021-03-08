using ControloFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControloFinanceiro.DAL.Mapeamentos
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {

            builder.HasKey(c => c.CategoriaId);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Icone).IsRequired().HasMaxLength(15);

            // relacionamentos e chave estrangeira
            // uma categoria pode ter apenas um tipo, mas um tipo pode ter n categorias
            builder.HasOne(c => c.Tipo).WithMany(c => c.Categorias).HasForeignKey(c => c.TipoId).IsRequired();

            // uma categoria pode ter n ganhos e os ganhos so podem ter uma categoria
            builder.HasMany(c => c.Ganhos).WithOne(c => c.Categoria);

            // uma categoria pode ter n despesas e uma despesa so pode ter uma categoria
            builder.HasMany(c => c.Despesas).WithOne(c => c.Categoria);


            // definir nome da tabela na BD
            builder.ToTable("Categorias");

        }
    }
}
