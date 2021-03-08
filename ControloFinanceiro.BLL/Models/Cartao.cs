using System;
using System.Collections.Generic;
using System.Text;

namespace ControloFinanceiro.BLL.Models
{
    public class Cartao
    {
        public int CartaoId { get; set; }
        public string Nome { get; set; }
        public string Bandeira { get; set; }
        public string Numero { get; set; }
        public double Limite { get; set; }

        // relacionamentos
        public string UtilizadorId { get; set; } //  string e nao ID por causa do Identity, que tem o ID pre definido como string
        public Utilizador Utilizador { get; set; }

        // relacionamentos
        public virtual ICollection<Despesa> Despesas { get; set; }
        public virtual ICollection<Ganho> Ganhos { get; set; }


    }
}
