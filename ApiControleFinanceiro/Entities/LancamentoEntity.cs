using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiControleFinanceiro.Entities
{
    [Table("lancamento")]
    public class LancamentoEntity
    {
        [Key()]
        [Column("idlancamento")]
        public long IdLancamento { get; set; }

        [Column("valor")]
        public double Valor { get; set; }

        [Column("data", TypeName = "date")]
        public DateTime Data { get; set; }

        [ForeignKey("SubcategoriaEntity")]
        public long IdSubcategoria { get; set; }
        public virtual SubcategoriaEntity Subcategoria { get; set; }

        [Column("comentario")]
        [StringLength(500)]
        public string Comentario { get; set; }        
    }
}
