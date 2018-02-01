using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaWebEF.Models {
    public class Pedido {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int IdPedido { get; set; }

        [Required (ErrorMessage = "Campo não pode ser vazio")]
        public int IdProduto { get; set; }

        [Required (ErrorMessage = "Campo não pode ser vazio")]
        public int IdCliente { get; set; }

        [Required (ErrorMessage = "Campo não pode ser vazio")]
        public int Quantidade { get; set; }

        public Produto Produto { get; set; }
        public Cliente Cliente { get; set; }
    }
}