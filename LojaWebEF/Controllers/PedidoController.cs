using System.Collections.Generic;
using System.Linq;
using LojaWebEF.Dados;
using LojaWebEF.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaWebEF.Controllers {
    [Route ("api/[controller]")]
    public class PedidoController : Controller {
        Pedido pedido = new Pedido ();
        readonly LojaContexto contexto;

        public PedidoController (LojaContexto contexto) {
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Pedido> Listar () {
            return contexto.Pedido.ToList ();
        }

        [HttpGet ("{id}")]
        public Pedido Listar (int id) {
            return contexto.Pedido.Where (x => x.IdPedido == id).FirstOrDefault ();
        }

        [HttpPost]
        public void Cadastrar ([FromBody] Pedido pd) {
            contexto.Pedido.Add (pd);
            contexto.SaveChanges ();
        }

        [HttpPut ("{id}")]
        public IActionResult Atualizar (int id, [FromBody] Pedido pd) {
            if (pd == null || pd.IdPedido != id) {
                return BadRequest ();
            }
            var ped = contexto.Pedido.FirstOrDefault (x => x.IdPedido == id);
            if (ped == null) {
                return NotFound ();
            }
            ped.IdPedido = pd.IdPedido;
            ped.Quantidade = pd.Quantidade;

            contexto.Pedido.Update (ped);
            int rs = contexto.SaveChanges ();

            if (rs > 0) {
                return Ok ();
            } else {
                return BadRequest ();
            }
        }

        [HttpDelete ("{id}")]
        public IActionResult Deletar (int id) {
            var ped = contexto.Pedido.Where (x => x.IdPedido == id).FirstOrDefault ();
            if (ped == null) {
                return NotFound ();
            }
            contexto.Pedido.Remove (ped);
            int rs = contexto.SaveChanges ();

            if (rs > 0) {
                return Ok ();
            } else {
                return BadRequest ();
            }
        }
    }
}