namespace ApiControleFinanceiro.Entities
{
    public class SubcategoriaEntity
    {        
        public int Id { get; set; }
        public string Nome { get; set; }
        public CategoriaEntity Categoria { get; set; }
    }
}
