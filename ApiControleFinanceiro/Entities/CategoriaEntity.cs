using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiControleFinanceiro.Entities
{
    [Table("categoria")]
    public class CategoriaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idcategoria")]
        public long IdCategoria { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Este campo deve ter de 3 a 30 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter de 3 a 30 caracteres")]
        [Column("nome")]
        public string Nome { get; set; }
    }
}
