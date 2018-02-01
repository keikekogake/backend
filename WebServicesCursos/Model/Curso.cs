using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebServicesCursos.Model {
    public class Curso {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int IdCurso { get; set; }

        [Required (ErrorMessage = "Campo não pode ser vazio")]
        [StringLength (150, MinimumLength=2)]
        public string Nome { get; set; }

        [Required (ErrorMessage = "Campo não pode ser vazio")]
        public int IdArea { get; set; }

        public ICollection<DataHora> DataHora { get; set; }
        public Area Area { get; set; }

    }
}