using System;

namespace exemploEvento1 {
    class Program {
        static void Main (string[] args) {
            Console.Write("Digite a quantidade de litros: ");
            int lts = Int16.Parse(Console.ReadLine());
            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();
            Carro carro = new Carro (lts, telefone);

            carro.TanqueVazio += new Carro.EventoCarro (tanque_vazio);
            carro.TanqueVazio += new Carro.EventoCarro (pedir_uber);
            carro.chamando += new Carro.Chamar (ligar_casa);
            carro.Ligar ();
        }

        static void tanque_vazio () {
            Console.WriteLine ("Tanque vazio");
        }
        static void pedir_uber () {
            Console.WriteLine ("Peça um Uber");
        }
        static void ligar_casa (string telefone){
            Console.WriteLine("Ligar para o número: " + telefone);
        }
    }
}