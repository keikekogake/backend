using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace autenticacaoEfCookie.Models {
    public class Permissao {

        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength (150, MinimumLength = 2)]
        public string Nome { get; set; }

        public ICollection<UsuarioPermissao> UsuariosPermissoes { get; set; }
    }
}