using ApiControleFinanceiro.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiControleFinanceiro.Repositories
{
    public interface ILancamentoRepository
    {
        Task<IEnumerable<LancamentoEntity>> Get();

        Task<LancamentoEntity> Get(long id);

        Task<LancamentoEntity> Create(LancamentoEntity lancamento);

        Task Update(LancamentoEntity lancamento);

        Task Delete(long id);
    }
}
