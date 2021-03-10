using ControloFinanceiro.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControloFinanceiro.DAL.Interfaces
{
    public interface ICategoriaRepositorio : IRepositorioGenerico<Categoria>
    {
        new IQueryable<Categoria> ObterTodos();
        new Task<Categoria> ObterPeloId(int id);
        IQueryable<Categoria> FiltrarCategorias(string nomeCategoria);
    }
}
