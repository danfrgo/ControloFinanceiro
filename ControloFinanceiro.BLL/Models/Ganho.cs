using System;
using System.Collections.Generic;
using System.Text;

namespace ControloFinanceiro.BLL.Models
{
    public class Ganho
    {
        public int GanhoId { get; set; }
        public string Descricao { get; set; }

        // chave estrangeira
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public double Valor { get; set; }
        public int Dia { get; set; }

        // chave estrangeira
        public int MesId { get; set; }
        public Mes Mes { get; set; }
        public int Ano { get; set; }

        // chave estrangeira
        public string UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }

    }
}
