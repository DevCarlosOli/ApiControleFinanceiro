using ApiControleFinanceiro.Entities;
using ApiControleFinanceiro.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiControleFinanceiro.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class LancamentoController : ControllerBase
    {
        private readonly ILancamentoRepository _lancamentoRepository;

        public LancamentoController(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        /// <summary>
        /// Obter todas os lancamentos.
        /// </summary>
        /// <response code="200">A lista de lancamentos foi obtida com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao obter a lista de lancamentos.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<LancamentoEntity>), 200)]
        [ProducesResponseType(500)]
        public async Task<IEnumerable<LancamentoEntity>> GetSubCategoria()
        {
            return await _lancamentoRepository.Get();
        }

        /// <summary>
        /// Obter um lancamento específico por ID.
        /// </summary>
        /// <param name="id">ID do lancamento.</param>
        /// <response code="200">O lancamento foi obtido com sucesso.</response>
        /// <response code="404">Não foi encontrado lancamentos com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao obter o lancamento.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<LancamentoEntity>), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<LancamentoEntity>> GetSubCategoria(long id)
        {
            var pegarLancamento= await _lancamentoRepository.Get(id);

            if (pegarLancamento == null)
            {
                return BadRequest(new { code = "page_off", message = "Não foi encontrado a categoria com ID especificado." });
            }
            return Ok(pegarLancamento);
        }

        /// <summary>
        /// Cadastrar lancamentos.
        /// </summary>
        /// <param name="lancamento">Modelo de lancamento.</param>
        /// <response code="200">O lancamento foi obtido com sucesso.</response>
        /// <response code="400">O modelo de lancamento enviado é inválido.</response>
        /// <response code="500">Ocorreu um erro ao cadastrar o lancamento.</response>
        [HttpPost]
        [ProducesResponseType(typeof(List<LancamentoEntity>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<LancamentoEntity>> PostSubCategoria(LancamentoEntity lancamento)
        {
            var newlancamento = await _lancamentoRepository.Create(lancamento);

            return Ok();
        }

        /// <summary>
        /// Alterar lancamentos.
        /// </summary> 
        /// <param name="id">ID do lancamento.</param>
        /// <param name="lancamento">Modelo do lancamento.</param>
        /// <response code="201">O lancamento foi alterado com sucesso.</response>
        /// <response code="404">Não foi encontrado o lancamento com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao alterar o lancamento.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(List<LancamentoEntity>), 201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<LancamentoEntity>> PutSubCategoria([FromRoute] long id, LancamentoEntity lancamento)
        {
            if (id != lancamento.Id)
                return BadRequest(new { code = "page_off", message = "Não foi encontrado a categoria com ID especificado." });

            await _lancamentoRepository.Update(lancamento);

            return CreatedAtAction(nameof(GetSubCategoria), new { id = lancamento.Id }, lancamento);
        }

        /// <summary>
        /// Deletar lancamentos.
        /// </summary>
        /// <param name="id">ID do lancamento.</param>
        /// <response code="200">O lancamento foi deletado com sucesso.</response>
        /// <response code="404">Não foi encontrado lancamento com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao deletar o lancamento.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(List<LancamentoEntity>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<LancamentoEntity>> DeleteSubCategoria(long id)
        {
            var lancamentoDelete = await _lancamentoRepository.Get(id);

            if (lancamentoDelete == null)
                return BadRequest(new { code = "page_off", message = "Não foi encontrado a categoria com ID especificado." });

            await _lancamentoRepository.Delete(lancamentoDelete.Id);

            return Ok();
        }
    }
}
