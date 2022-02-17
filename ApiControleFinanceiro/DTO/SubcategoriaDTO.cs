using ApiControleFinanceiro.Entities;

namespace ApiControleFinanceiro.DTO
{
    public class SubcategoriaDTO
    {
        public int IdSubcategoria { get; set; }
        public string Nome { get; set; }
        public CategoriaEntity IdCategoria { get; set; }
    }
}
