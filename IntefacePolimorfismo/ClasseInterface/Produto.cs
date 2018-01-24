namespace ClasseInterface {
    public class Produto : IAcao {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }

        public Produto () { }
        public Produto (int id, string nome, string descricao, double preco) {
            Id = id;
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
        }

        public string Cadastro () {
            string composicao = "Id do produto: " + Id + "\nNome do produto: " + Nome.ToUpper () + "\nDescricao do produto: " + Descricao.ToUpper () + "\nPreco do produto: " + string.Format ("{0:C2}", Preco);
            return "Produto cadastrado: \n" + composicao;
        }

        public string Consulta () {
            return null;
        }
    }
}