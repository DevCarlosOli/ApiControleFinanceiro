using ApiControleFinanceiro.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiControleFinanceiro.Repositories
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<CategoriaEntity>> Get();

        Task<CategoriaEntity> Get(string nome);

        Task<CategoriaEntity> Create(CategoriaEntity categoria);

        Task Update(CategoriaEntity categoria);

        Task Delete(string nome);
    }
}
