using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LojaWebEF.Dados;
using LojaWebEF.Models;

namespace LojaWebEF.Controllers {
    [Route("api/[controller]")]
    public class ClienteController : Controller {
        
        Cliente cliente = new Cliente();
        readonly LojaContexto contexto;

        public ClienteController(LojaContexto contexto){
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Cliente> Listar(){
            return contexto.Cliente.ToList();
        }

        [HttpGet ("{id}")]
        public Cliente Listar (int id) {
            return contexto.Cliente.Where (x => x.IdCliente == id).FirstOrDefault ();
        }

        [HttpPost]
        public void Cadastrar ([FromBody] Cliente cl) {
            contexto.Cliente.Add (cl);
            contexto.SaveChanges ();
        }

        [HttpPut ("{id}")]
        public IActionResult Atualizar (int id, [FromBody] Cliente cl) {
            if (cl == null || cl.IdCliente != id) {
                return BadRequest ();
            }
            var cli = contexto.Cliente.FirstOrDefault (x => x.IdCliente == id);
            if (cli == null) {
                return NotFound ();
            }
            cli.IdCliente = cl.IdCliente;
            cli.Nome = cl.Nome;
            cli.Email = cl.Email;
            cli.Idade = cl.Idade;

            contexto.Cliente.Update (cli);
            int rs = contexto.SaveChanges ();

            if (rs > 0) {
                return Ok ();
            } else {
                return BadRequest ();
            }
        }

        [HttpDelete ("{id}")]
        public IActionResult Deletar (int id) {
            var cli = contexto.Cliente.Where (x => x.IdCliente == id).FirstOrDefault ();
            if (cli == null) {
                return NotFound ();
            }
            contexto.Cliente.Remove (cli);
            int rs = contexto.SaveChanges ();

            if (rs > 0) {
                return Ok ();
            } else {
                return BadRequest ();
            }
        }
    }
}