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

        /// <summary>
        /// Obter todas as categorias.
        /// </summary>
        /// <response code="200">A lista de categorias foi obtida com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao obter a lista de categorias.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<CategoriaEntity>), 200)]
        [ProducesResponseType(500)]
        public async Task<IEnumerable<CategoriaEntity>> GetCategoria()
        {
            return await _categoriaRepository.Get();
        }

        /// <summary>
        /// Obter uma categoria específica por NOME.
        /// </summary>
        /// <param name="nome">Nome da categoria.</param>
        /// <response code="200">A categoria foi obtido com sucesso.</response>
        /// <response code="404">Não foi encontrada categoria com NOME especificado.</response>
        /// <response code="500">Ocorreu um erro ao obter a categoria.</response>
        [HttpGet("{string}")]
        public async Task<ActionResult<CategoriaEntity>> GetCategoria(string nome)
        {
            return await _categoriaRepository.Get(nome);
        }

        /// <summary>
        /// Cadastrar categoria.
        /// </summary>
        /// <param name="categoria">Modelo de categoria.</param>
        /// <response code="200">A categoria foi obtido com sucesso.</response>
        /// <response code="400">O modelo de categoria enviado é inválido.</response>
        /// <response code="500">Ocorreu um erro ao cadastrar a categoria.</response>
        [HttpPost]
        public async Task<ActionResult<CategoriaEntity>> PostCategoria([FromBody] CategoriaEntity categoria)
        {
            var newCategoria = await _categoriaRepository.Create(categoria);

            return CreatedAtAction(nameof(GetCategoria), new { nome = newCategoria.Nome }, newCategoria);
        }

        /// <summary>
        /// Deletar categoria.
        /// </summary>
        /// <param name="nome">NOME da categoria.</param>
        /// <response code="200">A categoria foi deletada com sucesso.</response>
        /// <response code="404">Não foi encontrado categoria com NOME especificado.</response>
        /// <response code="500">Ocorreu um erro ao deletar a categoria.</response>
        [HttpDelete("{string}")]
        public async Task<ActionResult<CategoriaEntity>> DeleteCategoria(string nome)
        {
            var categoriaDelete = await _categoriaRepository.Get(nome);

            if(categoriaDelete == null)
                return NotFound();

            await _categoriaRepository.Delete(categoriaDelete.Nome);

            return NoContent();
        }

        /// <summary>
        /// Alterar categoria.
        /// </summary> 
        /// <param name="nome">Nome da categoria.</param>
        /// <param name="categoria">Modelo da categoria.</param>
        /// <response code="200">A categoria foi alterada com sucesso.</response>
        /// <response code="400">O modelo da categoria enviado é inválido.</response>
        /// <response code="404">Não foi encontrado a categoria com NOME especificado.</response>
        /// <response code="500">Ocorreu um erro ao alterar a categoria.</response>
        [HttpPut]
        public async Task<ActionResult<CategoriaEntity>> PutCategoria(string nome, [FromBody] CategoriaEntity categoria)
        {
            if(nome != categoria.Nome)
                return BadRequest();

            await _categoriaRepository.Update(categoria);

            return NoContent();
        }
    }
}
