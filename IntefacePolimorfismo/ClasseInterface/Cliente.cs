namespace ClasseInterface {
    public abstract class Cliente {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
    }
}