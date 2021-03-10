using ControloFinanceiro.BLL.Models;
using ControloFinanceiro.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControloFinanceiro.DAL.Repositorios
{
    public class TipoRepositorio : RepositorioGenerico<Tipo>, ITipoRepositorio
    {
        public TipoRepositorio(Contexto contexto) : base(contexto)
        {
        }
    }
}
