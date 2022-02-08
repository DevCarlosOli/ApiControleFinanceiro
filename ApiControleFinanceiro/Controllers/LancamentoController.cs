using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiControleFinanceiro.Controllers
{
    public class LancamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
