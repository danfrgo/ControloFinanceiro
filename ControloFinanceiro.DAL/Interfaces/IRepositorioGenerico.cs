using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControloFinanceiro.DAL.Interfaces
{
    public interface IRepositorioGenerico<TEntity> where TEntity : class
    {
        IQueryable<TEntity> ObterTodos();
        Task<TEntity> ObterPeloId(int id);
        Task<TEntity> ObterPeloId(string id);
        Task Inserir(TEntity entity);
        Task Inserir(List<TEntity> entity);
        Task Atualizar(TEntity entity);
        Task Remover(string id);
        Task Remover(int id);
    }
}
