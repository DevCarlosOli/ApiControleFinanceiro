using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiControleFinanceiro.Entities
{
    [Table("categoria")]
    public class CategoriaEntity
    {
        [Key()]
        [Column("idcategoria")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }
    }
}
