using ApiControleFinanceiro.Context;
using ApiControleFinanceiro.Entities;
using ApiControleFinanceiro.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiControleFinanceiro.Service
{
    public class SubcategoriaService : ISubcategoriaRepository
    {
        private readonly DataContext _dataContext;

        public SubcategoriaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<SubcategoriaEntity>> Get()
        {
            return await _dataContext.Subcategorias.ToListAsync();
        }

        public async Task<SubcategoriaEntity> Get(long id)
        {
            return await _dataContext.Subcategorias.FindAsync(id);
        }

        public async Task<SubcategoriaEntity> Create(SubcategoriaEntity subCategoria)
        {
            _dataContext.Subcategorias.Add(subCategoria);
            await _dataContext.SaveChangesAsync();

            return subCategoria;
        }       

        public async Task Update(SubcategoriaEntity subCategoria)
        {
            _dataContext.Entry(subCategoria).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var subCategoriaDelete = await _dataContext.Subcategorias.FindAsync(id);
            _dataContext.Subcategorias.Remove(subCategoriaDelete);
            await _dataContext.SaveChangesAsync();
        }
    }
}
