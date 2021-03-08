using ControloFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControloFinanceiro.DAL.Mapeamentos
{
    class FuncaoMap : IEntityTypeConfiguration<Funcao>
    {
        public void Configure(EntityTypeBuilder<Funcao> builder)
        {
            builder.Property(f => f.Id).ValueGeneratedOnAdd(); // ValueGeneratedOnAdd -> para ID ser autoincremental
            builder.Property(f => f.Descricao).IsRequired().HasMaxLength(50);

            // popular BD
            builder.HasData(
                new Funcao
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Administrador",
                    NormalizedName = "ADMINISTRADOR", // NormalizedName -> para comparar valores
                    Descricao = "Administrador da plataforma"
                },


                new Funcao
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Utilizador",
                    NormalizedName = "UTILIZADOR", // NormalizedName -> para comparar valores
                    Descricao = "Utilizador da plataforma"
                });

            // definir nome da tabela na BD
            builder.ToTable("Funcoes");
        }
    }
}