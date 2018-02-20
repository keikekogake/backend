using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace modelobasicoefjwt.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        [StringLength(100, MinimumLength=4)]
        [Required]
        public string Nome { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(12, MinimumLength=4)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(14)]
        public string Cpf { get; set; }

        public ICollection<UsuarioPermissao> UsuariosPermissoes { get; set; }
    }
}