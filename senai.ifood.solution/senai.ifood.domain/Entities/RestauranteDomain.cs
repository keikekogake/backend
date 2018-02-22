using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai.ifood.domain.Entities {
    public class RestauranteDomain {
        [Required]
        [StringLength (150, MinimumLength = 2)]
        public string Nome { get; set; }

        [Required]
        public string Responsavel { get; set; }

        [Required]
        [DataType (DataType.Url)]
        public string Site { get; set; }

        [Required]
        [DataType (DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Required]
        [DataType (DataType.EmailAddress)]
        public string Email { get; set; }

        [ForeignKey ("EspecialidadeId")]
        public EspecialidadeDomain Especialidade { get; set; }
        public int EspecialidadeId { get; set; }

        [ForeignKey ("UsuarioId")]
        public UsuarioDomain Usuario { get; set; }
        public int UsuarioId { get; set; }

        public ICollection<ProdutoRestauranteDomain> ProdutoRestaurante { get; set; }
    }
}