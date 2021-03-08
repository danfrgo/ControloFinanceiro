using ControloFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControloFinanceiro.DAL.Mapeamentos
{
    class CartaoMap : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.HasKey(c => c.CartaoId);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(20);
            builder.HasIndex(c => c.Nome).IsUnique(); // evita nomes repetidos

            builder.Property(c => c.Bandeira).IsRequired().HasMaxLength(15);

            builder.Property(c => c.Numero).IsRequired().HasMaxLength(20);
            builder.HasIndex(c => c.Numero).IsUnique();

            builder.Property(c => c.Limite).IsRequired().HasMaxLength(20);

            // um cartao pertence apenas a um utilizador, mas um utilizador pode ter n cartoes
            builder.HasOne(c => c.Utilizador).WithMany(c => c.Cartoes).HasForeignKey(c => c.UtilizadorId).IsRequired().OnDelete(DeleteBehavior.NoAction);

            // um cartao pode ter varias despesas, mas uma despesa está relacionada apenas a um cartao
            builder.HasMany(c => c.Despesas).WithOne(c => c.Cartao);

            // definir nome da tabela na BD
            builder.ToTable("Cartoes");

        }
    }
}
