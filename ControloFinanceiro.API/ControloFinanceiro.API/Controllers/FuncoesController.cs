using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControloFinanceiro.BLL.Models;
using ControloFinanceiro.DAL;
using ControloFinanceiro.DAL.Interfaces;
using ControloFinanceiro.API.ViewModels;

namespace ControloFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncoesController : ControllerBase
    {
        private readonly IFuncaoRepositorio _funcaoRepositorio;

        public FuncoesController(IFuncaoRepositorio funcaoRepositorio)
        {
            _funcaoRepositorio = funcaoRepositorio;
        }

        // GET: api/Funcoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcao>>> GetFuncoes()
        {
            return await _funcaoRepositorio.ObterTodos().ToListAsync();
        }

        // GET: api/Funcoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funcao>> GetFuncao(string id)
        {
            var funcao = await _funcaoRepositorio.ObterPeloId(id);

            if (funcao == null)
            {
                return NotFound();
            }

            return funcao;
        }

        // PUT: api/Funcoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncao(string id, FuncoesViewModel funcoes)
        {
            if (id != funcoes.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                Funcao funcao = new Funcao()
                {
                    Id = funcoes.Id,
                    Name = funcoes.Name,
                    Descricao = funcoes.Descricao
                };
            
            await _funcaoRepositorio.AtualizarFuncao(funcao);

            // enviar mensagem para o angular
            return Ok(new
            {
                mensagem = $"Funcao {funcao.Name} atualizada com sucesso"
            });

        }
        return BadRequest(ModelState);
    }

        // POST: api/Funcoes
        [HttpPost]
        public async Task<ActionResult<Funcao>> PostFuncao(FuncoesViewModel funcoes)
        {
            if (ModelState.IsValid)
            {
                Funcao funcao = new Funcao()
                {
                    Name = funcoes.Name,
                    Descricao = funcoes.Descricao,
                };
                await _funcaoRepositorio.AdicionarFuncao(funcao);

                // enviar mensagem para o angular
                return Ok(new
                {
                    mensagem = $"Funcao {funcao.Name} adicionada com sucesso"
                });
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Funcoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncao(string id)
        {
            var funcao = await _funcaoRepositorio.ObterPeloId(id);
            if (funcao == null)
            {
                return NotFound();
            }

            await _funcaoRepositorio.Remover(funcao);

            // enviar mensagem para o angular
            return Ok(new
            {
                mensagem = $"Funcao {funcao.Name} removida com sucesso"
            });
        }
    }
}

