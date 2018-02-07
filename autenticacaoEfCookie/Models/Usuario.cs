using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace autenticacaoEfCookie.Models {
    public class Usuario {
        [Key]
        [Required]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength (150, MinimumLength = 2)]
        public string Nome { get; set; }

        [Required]
        [DataType (DataType.EmailAddress)]
        [StringLength (150, MinimumLength = 2)]
        public string Email { get; set; }

        [Required]
        [DataType (DataType.Password)]
        [StringLength (50, MinimumLength = 4)]
        public string Senha { get; set; }

        public ICollection<UsuarioPermissao> UsuariosPermissoes { get; set; }
    }
}