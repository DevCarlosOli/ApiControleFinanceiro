using ApiControleFinanceiro.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiControleFinanceiro.Repositories
{
    public interface ISubcategoriaRepository
    {
        Task<IEnumerable<SubcategoriaEntity>> Get();

        Task<SubcategoriaEntity> Get(long id);

        Task<SubcategoriaEntity> Create(SubcategoriaEntity subCategoria);

        Task Update(SubcategoriaEntity subCategoria);

        Task Delete(long id);
    }
}
