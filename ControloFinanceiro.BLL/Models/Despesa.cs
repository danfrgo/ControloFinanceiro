using System;
using System.Collections.Generic;
using System.Text;

namespace ControloFinanceiro.BLL.Models
{
    public class Despesa
    {
        public int DespesaId { get; set; }

        // chave estrangeira para cartao
        public int CartaoId { get; set; }
        public Cartao Cartao { get; set; }
        public string Descricao { get; set; }

        // chave estrangeira Categoria
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public double Valor { get; set; }
        public int Dia { get; set; }

        // chave estrangeira Mes
        public int MesId { get; set; }
        public Mes Mes { get; set; }
        public int Ano { get; set; }

        // chave estrangeira
        public string Utilizadorid { get; set; }
        public Utilizador Utilizador { get; set; }



    }
}
