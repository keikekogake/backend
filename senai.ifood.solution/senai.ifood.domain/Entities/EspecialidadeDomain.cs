using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace senai.ifood.domain.Entities {
    public class EspecialidadeDomain : BaseDomain {
        [Required]
        [StringLength (150, MinimumLength = 2)]
        public string Nome { get; set; }

        public ICollection<RestauranteDomain> Restaurante { get; set; }
    }
}