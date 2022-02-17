using ApiControleFinanceiro.Entities;
using System;

namespace ApiControleFinanceiro.DTO
{
    public class LancamentoDTO
    {
        public int IdLancamento { get; set; }        
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public SubcategoriaEntity IdSubcategoria { get; set; }
        public string Comentario { get; set; }
    }
}
