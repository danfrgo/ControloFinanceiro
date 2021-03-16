using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControloFinanceiro.API.ViewModels
{
    public class RegistoViewModel
    {
        public string NomeUtilizador { get; set; }
        public string CodigoPostal { get; set; }
        public string Pofissao { get; set; }
        public byte[] Foto { get; set; }
        public string Email { get; set; }
        public string PasswordUtl { get; set; }
    }
}
