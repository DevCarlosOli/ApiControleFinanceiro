using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiControleFinanceiro.Entities
{
    [Table("subcategoria")]
    public class SubcategoriaEntity
    {
        [Key]
        [Column("idsubcategoria")]
        public long Id { get; set; }

        [Required]
        [Column("nome")]
        [MaxLength(30, ErrorMessage = "Este campo deve ter de 3 a 30 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter de 3 a 30 caracteres")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Range(1, int.MaxValue, ErrorMessage = "Campo obrigatório")]
        [ForeignKey("Id")]
        public long CategoriaId { get; set; }

        public CategoriaEntity Categoria { get; set; }
    }
}
