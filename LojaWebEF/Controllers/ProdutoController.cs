using System.Collections.Generic;
using System.Linq;
using LojaWebEF.Dados;
using LojaWebEF.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaWebEF.Controllers {
    [Route ("api/[controller]")]
    public class ProdutoController : Controller {
        Produto produto = new Produto ();
        readonly LojaContexto contexto;

        public ProdutoController (LojaContexto contexto) {
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Produto> Listar () {
            return contexto.Produto.ToList ();
        }

        [HttpGet ("{id}")]
        public Produto Listar (int id) {
            return contexto.Produto.Where (x => x.IdProduto == id).FirstOrDefault ();
        }

        [HttpPost]
        public void Cadastrar ([FromBody] Produto pr) {
            contexto.Produto.Add (pr);
            contexto.SaveChanges ();
        }

        [HttpPut ("{id}")]
        public IActionResult Atualizar (int id, [FromBody] Produto pr) {
            if (pr == null || pr.IdProduto != id) {
                return BadRequest ();
            }
            var prod = contexto.Produto.FirstOrDefault (x => x.IdProduto == id);
            if (prod == null) {
                return NotFound ();
            }
            prod.IdProduto = pr.IdProduto;
            prod.Nome = pr.Nome;
            prod.Descricao = pr.Descricao;
            prod.Preco = pr.Preco;
            prod.Quantidade = pr.Quantidade;

            contexto.Produto.Update (prod);
            int rs = contexto.SaveChanges ();

            if (rs > 0) {
                return Ok ();
            } else {
                return BadRequest ();
            }
        }

        [HttpDelete ("{id}")]
        public IActionResult Deletar (int id) {
            var cli = contexto.Produto.Where (x => x.IdProduto == id).FirstOrDefault ();
            if (cli == null) {
                return NotFound ();
            }
            contexto.Produto.Remove (cli);
            int rs = contexto.SaveChanges ();

            if (rs > 0) {
                return Ok ();
            } else {
                return BadRequest ();
            }
        }
    }
}