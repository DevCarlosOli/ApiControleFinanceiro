using ApiControleFinanceiro.Context;
using ApiControleFinanceiro.Entities;
using ApiControleFinanceiro.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiControleFinanceiro.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriaEntity>> GetCategoria()
        {
            return await _categoriaRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaEntity>> GetCategoria(int id)
        {
            return await _categoriaRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaEntity>> PostCategoria([FromBody] CategoriaEntity categoria)
        {
            var newCategoria = await _categoriaRepository.Create(categoria);
            return CreatedAtAction(nameof(GetCategoria), new { id = newCategoria.Id }, newCategoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoriaEntity>> DeleteCategoria(int id)
        {
            var categoriaDelete = await _categoriaRepository.Get(id);

            if(categoriaDelete == null)
                return NotFound();

            await _categoriaRepository.Delete(categoriaDelete.Id);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<CategoriaEntity>> PutCategoria(int id, [FromBody] CategoriaEntity categoria)
        {
            if(id != categoria.Id)
                return BadRequest();

            await _categoriaRepository.Update(categoria);

            return NoContent();
        }
    }
}
