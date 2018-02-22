using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace senai.ifood.domain.Entities {
    public class PermissaoDomain : BaseDomain {
        [Required]
        [StringLength (100, MinimumLength = 2)]
        public string Nome { get; set; }
        public ICollection<UsuarioPermissaoDomain> UsuarioPermissao { get; set; }
    }
}