using System;
using System.Collections.Generic;
using System.Text;

namespace ControloFinanceiro.BLL.Models
{
    public class Tipo
    {
        public int TipoId { get; set; }
        public int Nome { get; set; }

        //o Tipo terá n categorias logo preciso de uma coleçao de categorias
        public virtual ICollection<Categoria> Categorias { get; set; }

    }
}
