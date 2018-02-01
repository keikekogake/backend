using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PrimeiroEF.Dados;
using PrimeiroEF.Models;

namespace PrimeiroEF.Controllers {

    [Route ("api/[controller]")]
    public class ClienteController : Controller {

        Cliente cliente = new Cliente ();

        // READONLY É USADO PARA QUE NENHUMA PROPRIEDADE SEJA ALTERADA
        readonly ClienteContexto contexto;

        public ClienteController (ClienteContexto contexto) {
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Cliente> Listar () {
            return contexto.ClienteBase.ToList ();
        }

        [HttpGet ("{id}")]
        public Cliente Listar (int id) {
            return contexto.ClienteBase.Where (x => x.Id == id).FirstOrDefault ();
        }

        [HttpPost]
        public void Cadastrar ([FromBody] Cliente cl) {
            contexto.ClienteBase.Add (cl);
            contexto.SaveChanges ();
        }

        [HttpPut ("{id}")]
        public IActionResult Atualizar (int id, [FromBody] Cliente cl) {
            if (cl == null || cl.Id != id) {
                return BadRequest ();
            }
            var cli = contexto.ClienteBase.FirstOrDefault (x => x.Id == id);
            if (cli == null) {
                return NotFound ();
            }
            cli.Id = cl.Id;
            cli.Nome = cl.Nome;
            cli.Email = cl.Email;
            cli.Idade = cl.Idade;
            cli.DataCadastro = cl.DataCadastro;

            contexto.ClienteBase.Update (cli);
            int rs = contexto.SaveChanges ();

            if (rs > 0) {
                return Ok ();
            } else {
                return BadRequest ();
            }
        }

        [HttpDelete ("{id}")]
        public IActionResult Deletar (int id) {
            var cli = contexto.ClienteBase.Where (x => x.Id == id).FirstOrDefault ();
            if (cli == null) {
                return NotFound ();
            }
            contexto.ClienteBase.Remove (cli);
            int rs = contexto.SaveChanges ();

            if (rs > 0) {
                return Ok ();
            } else {
                return BadRequest ();
            }
        }
    }
}