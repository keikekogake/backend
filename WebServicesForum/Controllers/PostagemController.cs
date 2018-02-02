using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServicesForum.DAO;
using WebServicesForum.Models;

namespace WebServicesForum.Controllers {
    public class PostagemController : Controller {
        Postagem posta = new Postagem ();

        [HttpPost]
        public string Cadastrar ([FromBody] PostagemModel postagem) {
            posta.Cadastrar (postagem);
            return "Tópico cadastrado";
            // return CreatedAtRoute ("TopicoAtual", new { id = topico.Id }, topico);
        }

        [HttpPut]
        public string Atualizar ([FromBody] PostagemModel postagem) {
            string msg = "Tópico não encontrado";
            if (posta.Atualizar (postagem)) {
                msg = "Tópico atualizado";
            }
            return msg;
        }

        [HttpGet ("{id}", Name = "PostagemAtual")]
        public PostagemModel GetPostagem (int id) {
            return posta.Listar ().Where (x => x.Id == id).FirstOrDefault ();
        }

        [HttpGet]
        [Route ("api/listartodos/postagem")]
        public IEnumerable<PostagemModel> GetPostagem () {
            return posta.Listar ();
        }

        [HttpDelete]
        public string Deletar ([FromBody] PostagemModel postagem) {
            string msg = "Tópico não encontrado";
            if (posta.Deletar (postagem)) {
                msg = "Tópico excluido";
            }
            return msg;
        }
    }
}