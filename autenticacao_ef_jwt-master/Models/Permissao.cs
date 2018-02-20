using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autenticacao_EF_JWT.Models
{
    public class Permissao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPermissao { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Nome { get; set; }

        public ICollection<UsuarioPermissao> UsuariosPermissoes  { get; set; }   
    }
}