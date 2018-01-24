using System;

namespace WebServicesForum.Models {
    public class PostagemModel {
        public int Id { get; set; }
        public int IdTopico { get; set; }
        public int IdUsuario { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataPublicacao { get; set; }
    }
}