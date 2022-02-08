using ApiControleFinanceiro.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApiControleFinanceiro.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CategoriaController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IActionResult> Get()
        {
            return Ok
                (new
                {
                    success = true,
                    data = await _dataContext.Categorias.ToListAsync()
                });
        }
    }
}
