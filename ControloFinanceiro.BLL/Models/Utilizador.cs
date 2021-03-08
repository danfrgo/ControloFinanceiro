using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControloFinanceiro.BLL.Models
{
    public class Utilizador : IdentityUser<string>
    {
        public string CodigoPostal { get; set; }
        public string Profissao { get; set; }
        public byte[] Foto { get; set; }

        // relacionamentos
        public virtual ICollection<Cartao> Cartoes { get; set; }
        public virtual ICollection<Ganho> Ganhos { get; set; }
        public virtual ICollection<Despesa> Despesas { get; set; }

    }
}
