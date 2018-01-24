using System;
using System.Collections.Generic;

namespace exemploLista {
    class Program {
        static void Main (string[] args) {
            // List<String> cidades = new List<String> ();
            // cidades.Add ("São Paulo");
            // cidades.Add ("Rio de Janeiro");
            // Console.WriteLine (cidades[0].ToUpper());
            // Console.WriteLine (cidades[1].ToUpper());

            // Usuarios keike1 = new Usuarios ();
            // Usuarios keike2 = new Usuarios ();
            // List<Usuarios> us = new List<Usuarios> ();

            // keike1.Id = 1;
            // keike1.Login = "keike1";
            // keike1.Senha = "1234";

            // keike2.Id = 2;
            // keike2.Login = "keike2";
            // keike2.Senha = "1234";

            // us.Add (keike1);
            // us.Add (keike2);

            // Console.WriteLine (us[1].Id);
            // Console.WriteLine (us[1].Login);
            // Console.WriteLine (us[1].Senha);

            List<Produto> sacola = new List<Produto> ();
            HigienePessoal sabonete = new HigienePessoal ();
            Bebidas cerveja = new Bebidas ();

            sabonete.Id = 1;
            sabonete.Marca = "Dove";
            sabonete.Nome = "sabonete";
            sabonete.NumeroMS = "321";
            sabonete.Preco = 50;

            cerveja.Id = 2;
            cerveja.Nome = "Pilsen";
            cerveja.Preco = 3.50;
            cerveja.TeorAlcolico = 10;
            cerveja.Tipo = "bla";

            sacola.Add (sabonete);
            sacola.Add (cerveja);

            foreach (var item in sacola) {

                // Pega o tipo do objeto e atribui a variável classe
                string classe = item.GetType ().ToString ();

                switch (classe) {
                    case "exemploLista.HigienePessoal":
                        {
                            // converte o "item" que era do tipo Produto para o tipo HigienePessoal
                            HigienePessoal hp = (HigienePessoal) item;
                            Console.WriteLine ("Higiene Pessoal: " + hp.Nome + " - " + hp.NumeroMS + " - " + hp.Marca);
                            break;
                        }
                    case "exemploLista.Bebidas":
                        {
                            // converte o "item" que era do tipo Produto para o tipo Bebidas
                            Bebidas bebida = (Bebidas) item;
                            Console.WriteLine ("Bebida: " + bebida.Nome + " - " + bebida.TeorAlcolico + " - " + bebida.Tipo);
                            break;
                        }

                    default:
                        break;
                }
            }
        }
    }
}