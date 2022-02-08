using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiControleFinanceiro.Entities
{
    [Table("lancamento")]
    public class LancamentoEntity
    {
        [Key()]
        [Column("id")]
        public int Id { get; set; }

        [Column("valor")]
        public double Valor { get; set; }

        [Column("data", TypeName = "date")]
        public DateTime Data { get; set; }

        [Column("comentario")]
        [StringLength(500)]
        public string Comentario { get; set; }

        [ForeignKey(nameof(Id))]
        public virtual SubcategoriaEntity SubcategoriaEntity { get; set; }
    }
}
