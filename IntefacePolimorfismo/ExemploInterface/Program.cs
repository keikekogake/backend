using System;
using ClasseInterface;

namespace ExemploInterface {
    class Program {
        static void Main (string[] args) {
            Endereco end = new Endereco();
            end.Logradouro = "Rua Nova Esperança";
            end.Numero = "123";
            end.Bairro = "Centro";

            PF pf = new PF(10, "keike.kogake@gmail.com","11940359890",end,"Keike","40314256865");

            Console.WriteLine(pf.Cadastro());
        }
    }
}