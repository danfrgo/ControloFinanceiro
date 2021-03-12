using ControloFinanceiro.BLL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControloFinanceiro.DAL.Interfaces
{
    public interface IUtilizadorRepositorio: IRepositorioGenerico<Utilizador>
    {
        Task<int> ObterTotalDeUtilizadoresRegistados();
        Task<IdentityResult> CriarUtilizador(Utilizador utilizador, string palpassword); // resultado do registo do utilizador
        Task AdicionarUtilizadorEmFuncao(Utilizador utilizador, string funcao);  // adiconar funcao/role a utilizador
        Task LoginUtilizador(Utilizador utilizador, bool lembrarUtilizador); // funcao para login do utilizado

    }
}
