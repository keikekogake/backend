using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai.ifood.domain.Entities {
    public class ProdutoRestauranteDomain {
        [Required]
        [StringLength (150, MinimumLength = 2)]
        public string Nome { get; set; }

        [Required]
        [StringLength (300)]
        public string Descricao { get; set; }

        [Required]
        public bool Ativo { get; set; }

        [Required]
        [DataType (DataType.Currency)]
        public decimal Valor { get; set; }

        [ForeignKey ("RestauranteId")]
        public RestauranteDomain Restaurante { get; set; }
        public int RestauranteId { get; set; }
    }
}