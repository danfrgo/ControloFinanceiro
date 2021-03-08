using ControloFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControloFinanceiro.DAL.Mapeamentos
{
    class UtilizadorMap : IEntityTypeConfiguration<Utilizador>
    {
        public void Configure(EntityTypeBuilder<Utilizador> builder)
        {
            builder.Property(u => u.Id).ValueGeneratedOnAdd(); // ValueGeneratedOnAdd -> para ID ser autoincremental

            builder.Property(u => u.CodigoPostal).IsRequired().HasMaxLength(20);
            builder.HasIndex(u => u.CodigoPostal).IsUnique();

            builder.Property(u => u.Profissao).IsRequired().HasMaxLength(30);

            // um utilizador pode ter n cartoes e os cartoes so podem ter um utilizador
            builder.HasMany(u => u.Cartoes).WithOne(u => u.Utilizador).OnDelete(DeleteBehavior.NoAction);

            // um utilizador pode ter n despesas e os despesas so podem ter um utilizador
            builder.HasMany(u => u.Despesas).WithOne(u => u.Utilizador).OnDelete(DeleteBehavior.NoAction);

            // um utilizador pode ter n ganhos e esses ganhos so podem ter um utilizador
            builder.HasMany(u => u.Ganhos).WithOne(u => u.Utilizador).OnDelete(DeleteBehavior.NoAction);

            // definir nome da tabela na BD
            builder.ToTable("Utilizadores");
        }
    }
}