using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace senai.ifood.domain.Entities {
    public class UsuarioDomain : BaseDomain {
        [Required]
        [DataType (DataType.EmailAddress)]
        [StringLength (150, MinimumLength = 2)]
        public string Email { get; set; }

        [Required]
        [DataType (DataType.Password)]
        [StringLength (150, MinimumLength = 3)]
        public string Senha { get; set; }

        public ICollection<UsuarioPermissaoDomain> UsuarioPermissao { get; set; }
        public ICollection<RestauranteDomain> Restaurante { get; set; }
        public ICollection<ClienteDomain> Cliente { get; set; }

    }
}