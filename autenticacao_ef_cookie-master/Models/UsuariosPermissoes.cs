using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autenticacao_EF_Cookie.Models

{
    public class UsuariosPermissoes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuariosPermissoes { get; set; }
        
        [Required]
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        
        [Required]
        public int IdPermissao { get; set; }

        [ForeignKey("IdPermissao")]
        public Permissao Permissao { get; set; }
    }
}