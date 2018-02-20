namespace modeloaulaefjwt_master.Models {
    public class TokenConfigurations {

        // CAMPO PARA LIMITAR SITES QUE PODERÃO FAZER REQUISIÇÕES PARA A API
        public string Audience { get; set; }

        // CAMPO PARA LIMITAR SITES QUE PODERÃO FAZER REQUISIÇÕES PARA A API
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}