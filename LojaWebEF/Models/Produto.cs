using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaWebEF.Models {
    public class Produto {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int IdProduto { get; set; }

        [Required (ErrorMessage = "Campo não pode ser vazio")]
        [StringLength (100, MinimumLength = 2)]
        public string Nome { get; set; }

        [Required (ErrorMessage = "Campo não pode ser vazio")]
        [DataType (DataType.Text)]
        public string Descricao { get; set; }

        [Required (ErrorMessage = "Campo não pode ser vazio")]
        [DataType (DataType.Currency)]
        public double Preco { get; set; }

        [Required (ErrorMessage = "Campo não pode ser vazio")]
        public int Quantidade { get; set; }

        public ICollection<Pedido> Pedido { get; set; }
    }
}