using System;
using System.Collections.Generic;

namespace exemploCrud {
    class Program {
        static void Main (string[] args) {
            RepCliente rc = new RepCliente();
            Cliente cliente = new Cliente();
            
            cliente.NomeCliente = "Kogake";
            cliente.EmailCliente = "roberto@gmail.com";
            cliente.CpfCliente = "1231231312";

            if (rc.Adicionar(cliente))
            {
                Console.WriteLine("Inserido com sucesso");
            }

            // Categoria cat = new Categoria ();
            // BancoDados bd = new BancoDados ();
            // int op = 0;
            // int table = 0;

            // while (table != 9) {
            //     Console.WriteLine("Escolha a tabela que deseja manipular");
            //     Console.WriteLine("1-Categoria\n2-Produto\n3-Cliente\n4-Estoque\n5-Funcionario\n6-Usuario\n7-Pedido\n8-Detalhe do Pedido\n9-Sair");
            //     switch (table) {
            //         case 1:
            //             while (op != 9) {
            //                 Console.WriteLine ("Escolha uma opção:");
            //                 Console.WriteLine ("1-Cadastrar Categoria\n2-Atualizar Categoria\n3-Deletar Categoria\n4-Consultar Categoria\n9-Sair");
            //                 op = Int32.Parse (Console.ReadLine ());
            //                 switch (op) {
            //                     case 1:
            //                         Console.Write ("Digite o título da categoria: ");
            //                         cat.Titulo = Console.ReadLine ();
            //                         Console.Clear ();
            //                         if (bd.Adicionar (cat)) {
            //                             Console.WriteLine ("Categoria cadastrada com sucesso");
            //                         }
            //                         break;

            //                     case 2:
            //                         Console.Write ("Digite o ID da categoria a ser atualizada: ");
            //                         cat.IdCategoria = Int32.Parse (Console.ReadLine ());
            //                         Console.Write ("Digite o novo titulo da categoria: ");
            //                         cat.Titulo = Console.ReadLine ();
            //                         Console.Clear ();
            //                         if (bd.Atualizar (cat)) {
            //                             Console.WriteLine ("Categoria atualizada com sucesso");
            //                         }
            //                         break;

            //                     case 3:
            //                         Console.Write ("Digite o ID da categoria a ser deletada: ");
            //                         cat.IdCategoria = Int32.Parse (Console.ReadLine ());
            //                         Console.Clear ();
            //                         if (bd.Apagar (cat)) {
            //                             Console.WriteLine ("Categoria deletada com sucesso");
            //                         }
            //                         break;

            //                     case 4:
            //                         List<Categoria> dados = new List<Categoria> ();

            //                         Console.Write ("Deseja pesquisar a categoria pelo 1-ID ou 2-Titulo: ");
            //                         int tipo = Int32.Parse (Console.ReadLine ());
            //                         switch (tipo) {
            //                             case 1:
            //                                 Console.Write ("Digite o ID da categoria para ser consultada: ");
            //                                 cat.IdCategoria = Int32.Parse (Console.ReadLine ());
            //                                 dados = bd.Consultar (cat.IdCategoria);
            //                                 if (dados.Count > 0) {
            //                                     Console.Clear ();
            //                                     foreach (var item in dados) {
            //                                         Console.WriteLine (item.IdCategoria + "\t" + item.Titulo);
            //                                     }
            //                                 } else {
            //                                     Console.Clear ();
            //                                     Console.WriteLine ("Categoria não encontrada.");
            //                                 }
            //                                 break;

            //                             case 2:
            //                                 Console.Write ("Digite o título da categoria a ser consultada: ");
            //                                 cat.Titulo = Console.ReadLine ();
            //                                 dados = bd.Consultar (cat.Titulo);
            //                                 if (dados.Count > 0) {
            //                                     Console.Clear ();
            //                                     foreach (var item in dados) {
            //                                         Console.WriteLine (item.IdCategoria + "\t" + item.Titulo);
            //                                     }
            //                                 } else {
            //                                     Console.Clear ();
            //                                     Console.WriteLine ("Categoria não encontrada.");
            //                                 }
            //                                 break;

            //                             default:
            //                                 break;
            //                         }
            //                         break;

            //                     default:
            //                         break;
            //                 }
            //             }
            //             break;
            //         default:
            //             break;
            //     }
            // }

        }
    }
}