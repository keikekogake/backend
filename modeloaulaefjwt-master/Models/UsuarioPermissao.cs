using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace modelobasicoefjwt.Models
{
    public class UsuarioPermissao
    {
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuarioPermissao { get; set; }

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