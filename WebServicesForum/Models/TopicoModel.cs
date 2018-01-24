using System;

namespace WebServicesForum.Models {
    public class TopicoModel {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}