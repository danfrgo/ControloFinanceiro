using ControloFinanceiro.BLL.Models;
using ControloFinanceiro.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControloFinanceiro.DAL.Repositorios
{
    public class FuncaoRepositorio : RepositorioGenerico<Funcao>, IFuncaoRepositorio
    {
        private readonly Contexto _contexto;
        private readonly RoleManager<Funcao> _gestaoFuncoes;

        public FuncaoRepositorio(Contexto contexto, RoleManager<Funcao> gestaoFuncoes) : base(contexto)
        {
            _contexto = contexto;
            _gestaoFuncoes = gestaoFuncoes;
        }

        public async Task AdicionarFuncao(Funcao funcao)
        {
            try
            {
                await _gestaoFuncoes.CreateAsync(funcao);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task AtualizarFuncao(Funcao funcao)
        {
            try
            {
                Funcao f = await ObterPeloId(funcao.Id);
                f.Name = funcao.Name;
                f.NormalizedName = funcao.NormalizedName;
                f.Descricao = funcao.Descricao;

                await _gestaoFuncoes.UpdateAsync(f);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    
    }
}
