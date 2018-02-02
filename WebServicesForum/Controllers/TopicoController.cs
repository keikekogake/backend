using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServicesForum.DAO;
using WebServicesForum.Models;

namespace WebServicesForum.Controllers {
    public class TopicoController : Controller {
        Topico topic = new Topico ();

        [HttpPost]
        public string Cadastrar ([FromBody] TopicoModel topico) {
            topic.Cadastrar (topico);
            return "Tópico cadastrado";
            // return CreatedAtRoute ("TopicoAtual", new { id = topico.Id }, topico);
        }

        [HttpPut]
        public string Atualizar ([FromBody] TopicoModel topico) {
            string msg = "Tópico não encontrado";
            if (topic.Atualizar (topico)) {
                msg = "Tópico atualizado";
            }
            return msg;
        }

        [HttpGet ("{id}", Name = "TopicoAtual")]
        public TopicoModel GetTopico (int id) {
            return topic.Listar ().Where (x => x.Id == id).FirstOrDefault ();
        }

        [HttpGet]
        [Route ("api/listartodos/topico")]
        public IEnumerable<TopicoModel> GetTopico () {
            return topic.Listar ();
        }

        [HttpDelete]
        public string Deletar ([FromBody] TopicoModel topico) {
            string msg = "Tópico não encontrado";
            if (topic.Deletar (topico)) {
                msg = "Tópico excluido";
            }
            return msg;
        }
    }
}