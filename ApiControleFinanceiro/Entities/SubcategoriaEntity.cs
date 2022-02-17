using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiControleFinanceiro.Entities
{
    [Table("subcategoria")]
    public class SubcategoriaEntity
    {
        [Key]
        [Column("idsubcategoria")]
        public long IdSubcategoria { get; set; }

        [Required]
        [Column("nome")]
        [MaxLength(30, ErrorMessage = "Este campo deve ter de 3 a 30 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter de 3 a 30 caracteres")]
        public string Nome { get; set; }

        [ForeignKey("CategoriaEntity")]
        public long IdCategoria { get; set; }
    }
}
