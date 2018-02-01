using System.Linq;
using LojaWebEF.Models;

namespace LojaWebEF.Dados {
    public class IniciarBanco {
        public static void Inicializar (LojaContexto contexto) {
            // contexto.Database.EnsureCreated(); É UTILIZADO PARA GARANTIR QUE O BANCO DE DADOS FOI CRIADO
            contexto.Database.EnsureCreated ();

            if (contexto.Cliente.Any ()) {
                return;
            }
            var cliente = new Cliente () {
                Nome = "João",
                Email = "joao@terra.com.br",
                Idade = 23
            };
            contexto.Cliente.Add(cliente);

            var produto = new Produto () {
                Nome = "Mouse",
                Descricao = "Mouse Microsoft",
                Preco = 25.30,
                Quantidade = 10
            };
            contexto.Produto.Add(produto);

            var pedido = new Pedido () {
                IdCliente = cliente.IdCliente,
                IdProduto = produto.IdProduto,
                Quantidade = 5
            };
            contexto.Pedido.Add(pedido);
            
            contexto.SaveChanges();
        }
    }
}