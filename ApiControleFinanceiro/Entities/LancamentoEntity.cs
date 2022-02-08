using System;

namespace ApiControleFinanceiro.Entities
{
    public class LancamentoEntity
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public string Comentario { get; set; }
        public SubcategoriaEntity Subcategoria { get; set; }
    }
}
