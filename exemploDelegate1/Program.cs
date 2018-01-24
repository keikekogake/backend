using System;

namespace exemploDelegate1 {
    class Program {
        static void Main (string[] args) {
            // Data("Sabe que dia é hoje? ");
            // Console.WriteLine(DataCompleta("Keike"));
            Cortador vera = new Cortador(Data);
            vera("Olá, eu sou um delegate ");

            Cortador filha = new Cortador(DataCompleta);
            filha("Keike");
        }

        // Criação do tipo DELEGATE
        public delegate void Cortador (string queijo);

        static void Data (string texto) {
            Console.WriteLine (texto + "Hoje é " + DateTime.Now.ToShortDateString ());
        }

        static void DataCompleta (string nome) {
            Console.WriteLine("Olá " + nome + " hoje é " + DateTime.Now.ToLongDateString ());
        }
    }
}