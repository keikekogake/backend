using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServicesCidades.Models;

namespace WebServicesCidades.Controllers {
    // VAMOS DEFINIR A ROTA PARA A REQUISIÇÃO DO SERVIÇO

    [Route ("api/[controller]")]
    public class PrimeiraController : Controller {
        DAOCidades dao = new DAOCidades ();

        // ANOTAÇÃO DO MÉTODO, DESCREVE A FUNÇÃO E OS PARAMETROS QUE DEVEM SER PASSADOS (SE NECESSÁRIO);
        [HttpGet]
        public IEnumerable<Cidades> Get () {
            return dao.Listar ();
        }

        [HttpGet ("{id}", Name = "CidadeAtual")]
        public Cidades Get (int id) {
            return dao.Listar ().Where (x => x.Id == id).FirstOrDefault ();
        }

        [HttpPost]
        public IActionResult Post ([FromBody] Cidades cidades) {
            dao.Cadastrar (cidades);
            return CreatedAtRoute ("CidadeAtual", new { id = cidades.Id }, cidades);
        }

        [HttpPut]
        public IActionResult Put ([FromBody] Cidades cidades) {
            dao.Atualizar (cidades);
            return CreatedAtRoute ("CidadeAtual", new { id = cidades.Id }, cidades);
        }

        [HttpDelete]
        public string Delete ([FromBody] Cidades cidades) {
            string msg = "Erro";
            if (dao.Deletar (cidades)) {
                msg = "Cidade com ID " + cidades.Id + " excluida";
            }
            return msg;
        }
    }
}