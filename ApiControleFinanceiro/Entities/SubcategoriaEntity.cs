using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiControleFinanceiro.Entities
{
    [Table("subcategoria")]
    public class SubcategoriaEntity
    {
        [Key()]
        [Column("idsubcategoria")]
        public long Id { get; set; }

        [Column("nome")]
        [StringLength(100)]
        [MinLength(5)]
        public string Nome { get; set; }
        
        [ForeignKey(nameof(Id))]
        public virtual CategoriaEntity CategoriaEntity { get; set; }
    }
}
