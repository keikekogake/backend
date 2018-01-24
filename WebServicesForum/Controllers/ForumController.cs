using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServicesForum.DAO;
using WebServicesForum.Models;

namespace WebServicesForum.Controllers {

    public class ForumController : Controller {
        Usuario user = new Usuario ();
        Topico topic = new Topico ();
        Postagem posta = new Postagem ();

        [HttpGet ("api/listartodos/usuario/{id}", Name = "LoginAtual")]
        // public UsuarioModel Get (int id) {
        //     return user.Listar ().Where (x => x.Id == id).FirstOrDefault ();
        // }
        public IActionResult Get (int id) {
            var rs = new JsonResult (user.Listar ().Where (x => x.Id == id).FirstOrDefault ());
            if (rs.Value == null) {
                rs.StatusCode = 204;
                rs.Value = $"o ID: {id} não foi encontrado";
                rs.ContentType = "application/json";
            } else {
                rs.ContentType = "application/json";
                rs.StatusCode = 200;
            }
            return Json (rs);
        }

        [HttpGet]
        [Route ("api/listartodos/usuario")]
        public IEnumerable<UsuarioModel> Get () {
            return user.Listar ();
        }

        [HttpPost]
        [Route ("api/cadastrar/usuario")]
        public IActionResult Cadastrar ([FromBody] UsuarioModel usuario) {
            JsonResult rs;

            try {
                if (!ModelState.IsValid) {
                    return BadRequest (ModelState);
                }
                rs = new JsonResult (user.Cadastrar (usuario));
                rs.ContentType = "application/json";
                if (!Convert.ToBoolean (rs.Value)) {
                    rs.StatusCode = 404;
                    rs.Value = "Ocorreu um erro";
                } else {
                    rs.StatusCode = 200;
                }
            } catch (Exception ex) {
                rs = new JsonResult ("");
                rs.StatusCode = 204;
                rs.ContentType = "application/json";
                rs.Value = ex.Message;
            }
            return Json (rs);
        }

        [HttpPost]
        [Route ("api/logar/usuario")]
        public string Logar ([FromBody] UsuarioModel usuario) {
            string msg = "Usuário não encontrado";
            if (user.Logar (usuario)) {
                msg = "Usuario encontrado";
            }
            return msg;
        }

        [HttpPost]
        [Route ("api/atualizar/usuario")]
        public string Atualizar ([FromBody] UsuarioModel usuario) {
            string msg = "Tópico não encontrado";
            if (user.Atualizar (usuario)) {
                msg = "Tópico atualizado";
            }
            return msg;
        }

        [HttpPost]
        [Route ("api/deletar/usuario")]
        public string Deletar ([FromBody] UsuarioModel usuario) {
            string msg = "Usuário não encontrado";
            if (user.Deletar (usuario)) {
                msg = "Usuario excluido";
            }
            return msg;
        }

        //ROTAS PARA OS TÓPICOS
        [HttpPost]
        [Route ("api/cadastrar/topico")]
        public string Cadastrar ([FromBody] TopicoModel topico) {
            topic.Cadastrar (topico);
            return "Tópico cadastrado";
            // return CreatedAtRoute ("TopicoAtual", new { id = topico.Id }, topico);
        }

        [HttpPost]
        [Route ("api/atualizar/topico")]
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

        [HttpPost]
        [Route ("api/deletar/topico")]
        public string Deletar ([FromBody] TopicoModel topico) {
            string msg = "Tópico não encontrado";
            if (topic.Deletar (topico)) {
                msg = "Tópico excluido";
            }
            return msg;
        }

        // ROTAS PARA POSTAGEM
        [HttpPost]
        [Route ("api/cadastrar/postagem")]
        public string Cadastrar ([FromBody] PostagemModel postagem) {
            posta.Cadastrar (postagem);
            return "Tópico cadastrado";
            // return CreatedAtRoute ("TopicoAtual", new { id = topico.Id }, topico);
        }

        [HttpPost]
        [Route ("api/atualizar/postagem")]
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

        [HttpPost]
        [Route ("api/deletar/postagem")]
        public string Deletar ([FromBody] PostagemModel postagem) {
            string msg = "Tópico não encontrado";
            if (posta.Deletar (postagem)) {
                msg = "Tópico excluido";
            }
            return msg;
        }
    }
}