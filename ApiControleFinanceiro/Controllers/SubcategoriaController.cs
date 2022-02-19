using ApiControleFinanceiro.Entities;
using ApiControleFinanceiro.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiControleFinanceiro.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class SubcategoriaController : ControllerBase
    {
        private readonly ISubcategoriaRepository _subCategoriaRepository;

        private readonly IMapper _mapeamento;

        public SubcategoriaController(ISubcategoriaRepository subCategoriaRepository, IMapper mapeamento)
        {
            _subCategoriaRepository = subCategoriaRepository;
            _mapeamento = mapeamento;
        }

        /// <summary>
        /// Obter todas as sub-categorias.
        /// </summary>
        /// <response code="200">A lista de sub-categorias foi obtida com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao obter a lista de sub-categorias.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<SubcategoriaEntity>), 200)]
        [ProducesResponseType(500)]
        public async Task<IEnumerable<SubcategoriaEntity>> GetSubCategoria()
        {
            return await _subCategoriaRepository.Get();
        }

        /// <summary>
        /// Obter uma sub-categoria específica por ID.
        /// </summary>
        /// <param name="id">ID da sub-categoria.</param>
        /// <response code="200">A sub-categoria foi obtido com sucesso.</response>
        /// <response code="404">Não foi encontrada sub-categoria com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao obter a sub-categoria.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<SubcategoriaEntity>), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<SubcategoriaEntity>> GetSubCategoria(long id)
        {
            var pegarSubcategoria = await _subCategoriaRepository.Get(id);

            if (pegarSubcategoria == null)
            {
                return NotFound(new { code = "page_off", message = "Não foi encontrado a categoria com ID especificado." });
            }
            return Ok(pegarSubcategoria);
        }

        /// <summary>
        /// Cadastrar sub-categoria.
        /// </summary>
        /// <param name="subCategoria">Modelo de sub-categoria.</param>
        /// <response code="200">A sub-categoria foi obtida com sucesso.</response>
        /// <response code="400">O modelo de sub-categoria enviado é inválido.</response>
        /// <response code="500">Ocorreu um erro ao cadastrar a sub-categoria.</response>
        [HttpPost]
        [ProducesResponseType(typeof(List<SubcategoriaEntity>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<SubcategoriaEntity>> PostSubCategoria(SubcategoriaEntity subCategoria)
        {
            var newSubcategoria = await _subCategoriaRepository.Create(subCategoria);

            return Ok(newSubcategoria);
        }

        /// <summary>
        /// Alterar sub-categoria.
        /// </summary> 
        /// <param name="id">ID da sub-categoria.</param>
        /// <param name="subCategoria">Modelo da sub-categoria.</param>
        /// <response code="201">A sub-categoria foi alterada com sucesso.</response>
        /// <response code="404">Não foi encontrado a sub-categoria com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao alterar a sub-categoria.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(List<SubcategoriaEntity>), 201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<SubcategoriaEntity>> PutSubCategoria([FromRoute] long id, SubcategoriaEntity subCategoria)
        {
            if (id != subCategoria.Id)
                return BadRequest(new { code = "page_off", message = "Não foi encontrado a categoria com ID especificado." });

            await _subCategoriaRepository.Update(subCategoria);

            return CreatedAtAction(nameof(GetSubCategoria), new { id = subCategoria.Id }, subCategoria);
        }

        /// <summary>
        /// Deletar sub-categoria.
        /// </summary>
        /// <param name="id">ID da sub-categoria.</param>
        /// <response code="200">A sub-categoria foi deletada com sucesso.</response>
        /// <response code="404">Não foi encontrado sub-categoria com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao deletar a sub-categoria.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(List<SubcategoriaEntity>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<SubcategoriaEntity>> DeleteSubCategoria(long id)
        {
            var subCategoriaDelete = await _subCategoriaRepository.Get(id);

            if (subCategoriaDelete == null)
                return BadRequest(new { code = "page_off", message = "Não foi encontrado a categoria com ID especificado." });

            await _subCategoriaRepository.Delete(subCategoriaDelete.Id);

            return Ok();
        }
    }
}
