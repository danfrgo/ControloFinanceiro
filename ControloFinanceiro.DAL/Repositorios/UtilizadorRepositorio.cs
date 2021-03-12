using ControloFinanceiro.BLL.Models;
using ControloFinanceiro.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControloFinanceiro.DAL.Repositorios
{
    public class UtilizadorRepositorio : RepositorioGenerico<Utilizador>, IUtilizadorRepositorio
    {
        private readonly Contexto _contexto;
        private readonly UserManager<Utilizador> _gerirUtilizadores; // responsavel pela gestao dos utilizadores
        private readonly SignInManager<Utilizador> _gerirLogin; // responsavel pelo login dos utilizadores
        public UtilizadorRepositorio(Contexto contexto, UserManager<Utilizador> gerirUtilizadores, SignInManager<Utilizador> gerirLogin) : base(contexto)
        {
            _contexto = contexto;
            _gerirUtilizadores = gerirUtilizadores;
            _gerirLogin = gerirLogin;
        }

        public async Task<IdentityResult> CriarUtilizador(Utilizador utilizador, string palpassword)
        {
            try
            {
                return await _gerirUtilizadores.CreateAsync(utilizador, palpassword);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task AdicionarUtilizadorEmFuncao(Utilizador utilizador, string funcao)
        {
            try
            {
               await _gerirUtilizadores.AddToRoleAsync(utilizador, funcao);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task LoginUtilizador(Utilizador utilizador, bool lembrarUtilizador)
        {
            try
            {
                await _gerirLogin.SignInAsync(utilizador, false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> ObterTotalDeUtilizadoresRegistados()
        {
            try
            {
                return await _contexto.Utilizadores.CountAsync(); 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
