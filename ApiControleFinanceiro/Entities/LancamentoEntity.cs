using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiControleFinanceiro.Entities
{
    [Table("lancamento")]
    public class LancamentoEntity
    {
        [Key]
        [Column("idlancamento")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Range(1, double.MaxValue, ErrorMessage = "Campo obrigatório")]
        [Column("valor")]
        public decimal Valor { get; set; }

        [Column("data", TypeName = "date")]
        public DateTime Data { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Range(1, int.MaxValue, ErrorMessage = "Campo obrigatório")]
        public long SubcategoriaId { get; set; }
        public SubcategoriaEntity Subcategoria { get; set; }

        [NotMapped]
        public CategoriaEntity Categoria { get; set; }

        [Column("comentario")]
        [MaxLength(1024, ErrorMessage = "Este campo deve conter 1024 caracteres no máximo")]
        public string Comentario { get; set; }        
    }
}
