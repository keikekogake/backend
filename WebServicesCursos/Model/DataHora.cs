using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebServicesCursos.Model {
    public class DataHora {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int IdDataHora { get; set; }

        [Required (ErrorMessage = "Campo não pode ser vazio")]
        [DataType (DataType.Date)]
        public string DataInicio { get; set; }

        [Required (ErrorMessage = "Campo não pode ser vazio")]
        [DataType (DataType.Date)]
        public string DataFim { get; set; }
        public string DiaSemana { get; set; }

        [Required (ErrorMessage = "Campo não pode ser vazio")]
        [DataType (DataType.Time)]
        public string HoraInicio { get; set; }

        [Required (ErrorMessage = "Campo não pode ser vazio")]
        [DataType (DataType.Time)]
        public string HoraFim { get; set; }

        [Required (ErrorMessage = "Campo não pode ser vazio")]
        public int IdCurso { get; set; }

        public Curso Curso { get; set; }

    }
}