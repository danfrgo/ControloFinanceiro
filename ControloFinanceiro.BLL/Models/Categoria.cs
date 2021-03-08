using System;
using System.Collections.Generic;
using System.Text;

namespace ControloFinanceiro.BLL.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Icone { get; set; }

        // chave estrangeira para relacionar com a model Tipo
        public int TipoId { get; set; }
        public string Tipo{ get; set; }

        // relacionamentos
        public virtual ICollection<Despesa> Despesas { get; set; }
        public virtual ICollection<Ganho> Ganhos { get; set; }
    }
}
