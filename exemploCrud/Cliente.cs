using System;

namespace exemploCrud
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public string CpfCliente { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}