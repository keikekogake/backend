using System.Collections.Generic;

namespace projetoCidades.Models {
    public class Cidade {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public int Habitantes { get; set; }
        public List<Cidade> ListarCidades () {
            List<Cidade> cidade = new List<Cidade> () {
                new Cidade { Id = 1, Nome = "São Paulo", Estado = "SP", Habitantes = 123412 },
                new Cidade { Id = 2, Nome = "Rio de Janeiro", Estado = "RJ", Habitantes = 123412 },
                new Cidade { Id = 3, Nome = "Porto Alegre", Estado = "RS", Habitantes = 346554 },
                new Cidade { Id = 4, Nome = "Campinas", Estado = "SP", Habitantes = 234565 },
                new Cidade { Id = 5, Nome = "Vitória", Estado = "ES", Habitantes = 1235476 },
                new Cidade { Id = 6, Nome = "Londrina", Estado = "PR", Habitantes = 1234987 }
            };
            return cidade;
        }
    }
}