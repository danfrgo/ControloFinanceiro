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

namespace ControloFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriasController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _categoriaRepositorio.ObterTodos().ToListAsync();
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _categoriaRepositorio.ObterPeloId(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // PUT: api/Categorias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            // verificar se os dados estao validos
            if (ModelState.IsValid)
            {
                await _categoriaRepositorio.Atualizar(categoria);
                return Ok(new
                {
                    mensagem = $"Categoria {categoria.Nome} atualizada com sucesso"
                });
            }
            return BadRequest(ModelState);
        }

        // POST: api/Categorias
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaRepositorio.Inserir(categoria);

                return Ok(new
                {
                    mensagem = $"Categoria {categoria.Nome} registada com sucesso"
                });
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _categoriaRepositorio.ObterPeloId(id);

            // se categoria for nula retorn notfound
            if (categoria == null)
            {
                return NotFound();
            }

            await _categoriaRepositorio.Remover(id);

            return Ok(new
            {
                mensagem = $"Categoria {categoria.Nome} removida com sucesso"
            });
        }

        [HttpGet("FiltrarCategoria/{nomeCategoria}")]
        public async Task<ActionResult<IEnumerable<Categoria>>> FiltrarCategorias(string nomeCategoria)
        {
            return await _categoriaRepositorio.FiltrarCategorias(nomeCategoria).ToListAsync();
        }

    


    }
}
