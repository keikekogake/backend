using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebServicesCursos.Model {
    public class Area {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int IdArea { get; set; }

        [Required (ErrorMessage = "Campo não pode ser vazio")]
        [StringLength (150, MinimumLength = 2)]
        public string Nome { get; set; }

        public ICollection<Curso> Curso { get; set; }
    }
}