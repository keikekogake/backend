using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autenticacao_EF_JWT.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Email { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public ICollection<UsuarioPermissao> UsuariosPermissoes  { get; set; }
        
    }
}