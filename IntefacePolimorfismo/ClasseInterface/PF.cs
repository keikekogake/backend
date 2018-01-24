namespace ClasseInterface {
    public class PF : Cliente, IAcao {
        public string Nome { get; set; }
        public string CPF { get; set; }

        public PF () {

        }
        public PF (int id, string email, string telefone, Endereco endereco, string nome, string cpf) {
            base.Id = id;
            base.Email = email;
            base.Telefone = telefone;
            base.Endereco = endereco;
            this.Nome = nome;
            this.CPF = cpf;
        }

        public string Cadastro () {
            string composicao =
                "ID: " + Id +
                "\nEmail: " + Email +
                "\nTelefone: " + Telefone +
                "\nEndereço: " + Endereco.Logradouro + "," + Endereco.Numero + " - " + Endereco.Bairro +
                "\nNome: " + Nome +
                "\nCPF: " + CPF;
            return "\n\nCliente cadastrado:\n" + composicao;
        }

        public string Consulta () {
            throw new System.NotImplementedException ();
        }
    }
}