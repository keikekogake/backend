using System;
using System.Threading;

namespace exemploEvento1 {
    public class Carro {
        public string Telefone { get; set; }
        int qtdTanque = 0;

        public Carro (int qtdeGasolina, string telefone) {
            this.qtdTanque = qtdeGasolina;
            this.Telefone = telefone;
        }

        public void Ligar () {
            int rs = (this.qtdTanque/2);
            while (true) {
                Console.WriteLine ("Tanque: " + this.qtdTanque);
                
                if (this.qtdTanque.Equals(rs)) {
                    this.chamando (Telefone);
                }
                if (this.qtdTanque.Equals (0)) {
                    this.TanqueVazio ();
                    break;
                }
                this.qtdTanque--;
                Thread.Sleep (1000);
            }
        }

        public delegate void EventoCarro ();

        public event EventoCarro TanqueVazio;

        public delegate void Chamar (string texto);
        public event Chamar chamando;
    }
}