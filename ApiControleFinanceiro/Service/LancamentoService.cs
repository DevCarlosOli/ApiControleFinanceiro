using ApiControleFinanceiro.Context;
using ApiControleFinanceiro.Entities;
using ApiControleFinanceiro.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiControleFinanceiro.Service
{
    public class LancamentoService : ILancamentoRepository
    {
        private readonly DataContext _dataContext;

        public LancamentoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<LancamentoEntity>> Get()
        {
            return await _dataContext.Lancamentos.ToListAsync();
        }

        public async Task<LancamentoEntity> Get(long id)
        {
            return await _dataContext.Lancamentos.FindAsync();
        }

        public async Task<LancamentoEntity> Create(LancamentoEntity lancamento)
        {
            _dataContext.Lancamentos.Add(lancamento);
            await _dataContext.SaveChangesAsync();

            return lancamento;
        }

        public async Task Update(LancamentoEntity lancamento)
        {
            _dataContext.Entry(lancamento).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var lancamentoDelete = await _dataContext.Lancamentos.FindAsync(id);
            _dataContext.Lancamentos.Remove(lancamentoDelete);
            await _dataContext.SaveChangesAsync();
        }
    }
}
