using ApiControleFinanceiro.Context;
using ApiControleFinanceiro.Entities;
using ApiControleFinanceiro.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiControleFinanceiro.Service
{
    public class CategoriaService : ICategoriaRepository
    {
        private readonly DataContext _dataContext;

        public CategoriaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<CategoriaEntity>> Get()
        {
            return await _dataContext.Categorias.ToListAsync();
        }

        public async Task<CategoriaEntity> Get(long id)
        {
            return await _dataContext.Categorias.FindAsync(id);
        }

        public async Task<CategoriaEntity> Create(CategoriaEntity categoria)
        {
            _dataContext.Categorias.Add(categoria);
            await _dataContext.SaveChangesAsync();

            return categoria;
        }

        public async Task Update(CategoriaEntity categoria)
        {
            _dataContext.Entry(categoria).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var categoriaDelete = await _dataContext.Categorias.FindAsync(id);
            _dataContext.Categorias.Remove(categoriaDelete);
            await _dataContext.SaveChangesAsync();
        }
    }
}
