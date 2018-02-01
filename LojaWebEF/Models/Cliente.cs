using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaWebEF.Models {
    public class Cliente {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }

        [Required (ErrorMessage = "Campo não pode ser vazio")]
        [StringLength (100, MinimumLength = 2)]
        public string Nome { get; set; }

        [Required (ErrorMessage = "Campo não pode ser vazio")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required (ErrorMessage = "Campo não pode ser vazio")]
        [Range(1,150)]
        public int Idade { get; set; }

        public ICollection<Pedido> Pedido { get; set; }
    }
}