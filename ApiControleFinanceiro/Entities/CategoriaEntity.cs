using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiControleFinanceiro.Entities
{
    [Table("categoria")]
    public class CategoriaEntity
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idcategoria")]
        public long Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }
    }
}
