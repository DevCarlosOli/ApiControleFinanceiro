using ApiControleFinanceiro.Entities;
using ApiControleFinanceiro.Repositories;
using Microsoft.AspNetCore.Mvc;
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
        /// Obter uma categoria específica por ID.
        /// </summary>
        /// <param name="nome">Nome da categoria.</param>
        /// <response code="200">A categoria foi obtido com sucesso.</response>
        /// <response code="404">Não foi encontrada categoria com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao obter a categoria.</response>
        [HttpGet("{nome}")]
        [ProducesResponseType(typeof(List<CategoriaEntity>), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CategoriaEntity>> GetCategoria(string nome)
        {
            var pegarCategoria = await _categoriaRepository.Get(nome);

            if (pegarCategoria == null)
            {
                return NotFound(new { code = "page_off", message = "Não foi encontrado a categoria com ID especificado." });
            }
            return Ok(pegarCategoria);
        }

        /// <summary>
        /// Cadastrar categoria.
        /// </summary>
        /// <param name="categoria">Modelo de categoria.</param>
        /// <response code="200">A categoria foi obtida com sucesso.</response>
        /// <response code="400">O modelo de categoria enviado é inválido.</response>
        /// <response code="500">Ocorreu um erro ao cadastrar a categoria.</response>
        [HttpPost]
        [ProducesResponseType(typeof(List<CategoriaEntity>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CategoriaEntity>> PostCategoria(CategoriaEntity categoria)
        {
            var newCategoria = await _categoriaRepository.Create(categoria);

            if (categoria == newCategoria)
                return BadRequest(new { code = "invalid_requisition", message = "O modelo de categoria enviado é inválido." });

            return Ok(newCategoria);
        }

        /// <summary>
        /// Alterar categoria.
        /// </summary> 
        /// <param name="id">ID da categoria.</param>
        /// <param name="categoria">Modelo da categoria.</param>
        /// <response code="201">A categoria foi alterada com sucesso.</response>
        /// <response code="404">Não foi encontrado a categoria com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao alterar a categoria.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(List<SubcategoriaEntity>), 201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CategoriaEntity>> PutCategoria([FromRoute] long id, CategoriaEntity categoria)
        {
            if (id != categoria.Id)
                return NotFound(new { code = "page_off", message = "Não foi encontrado a categoria com ID especificado." });

            await _categoriaRepository.Update(categoria);

            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.Id }, categoria);
        }

        /// <summary>
        /// Deletar categoria.
        /// </summary>
        /// <param name="nome">Nome da categoria.</param>
        /// <response code="200">A categoria foi deletada com sucesso.</response>
        /// <response code="404">Não foi encontrado categoria com nome especificado.</response>
        /// <response code="500">Ocorreu um erro ao deletar a categoria.</response>
        [HttpDelete("{nome}")]
        [ProducesResponseType(typeof(List<CategoriaEntity>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CategoriaEntity>> DeleteCategoria(string nome)
        {
            var categoriaDelete = await _categoriaRepository.Get(nome);

            if (categoriaDelete == null)
                return NotFound(new { code = "page_off", message = "Não foi encontrado a categoria com ID especificado." });

            await _categoriaRepository.Delete(categoriaDelete.Nome);

            return Ok();
        }
        
    }
}
