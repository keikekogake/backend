using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace autenticacaoEfCookie.Models {
    public class UsuarioPermissao {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public int IdPermissao { get; set; }

        // DENIFI QUE O CAMPO IdUsuario é a ForeignKey referenciando a classe Usuario
        [ForeignKey ("IdUsuario")]
        public Usuario Usuario { get; set; }

        // DENIFI QUE O CAMPO IdPermissao é a ForeignKey referenciando a classe Permissao
        [ForeignKey ("IdPermissao")]
        public Permissao Permissao { get; set; }
    }
}