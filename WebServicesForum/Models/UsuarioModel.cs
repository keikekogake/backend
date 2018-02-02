using System;
using System.ComponentModel.DataAnnotations;

namespace WebServicesForum.Models {
    public class UsuarioModel {
        public int Id { get; set; }

        [Display (Name = "Nome do usuário")]
        [Required (ErrorMessage = "Este campo não pode ser vazio")]
        [MinLength (2, ErrorMessage = "Este campo deve ter no mínimo 2 caracteres")]
        [MaxLength (150, ErrorMessage = "Este campo deve ter no máximo 10 caracteres")]
        public string Nome { get; set; }

        [Required (ErrorMessage = "Este campo não pode ser vazio")]
        [MinLength (2, ErrorMessage = "Este campo deve ter no mínimo 2 caracteres")]
        [MaxLength (150, ErrorMessage = "Este campo deve ter no máximo 10 caracteres")]
        public string Login { get; set; }

        [Required (ErrorMessage = "Este campo não pode ser vazio")]
        [MinLength (6, ErrorMessage = "Este campo deve ter no mínimo 8 caracteres")]
        [MaxLength (150, ErrorMessage = "Este campo deve ter no máximo 12 caracteres")]
        public string Senha { get; set; }
        
        public DateTime DataCadastro { get; set; }
    }
}