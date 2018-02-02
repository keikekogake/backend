using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServicesForum.DAO;
using WebServicesForum.Models;

namespace WebServicesForum.Controllers {
    [Route ("api/v1/[controller]")]
    public class UsuarioController : Controller {
        Usuario user = new Usuario ();
        public IActionResult Get (int id) {
            var rs = new JsonResult (user.BuscarDados ().Where (x => x.Id == id).FirstOrDefault ());
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
        public IEnumerable<UsuarioModel> Get () {
            return user.BuscarDados ();
        }

        [HttpPost]
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

        [HttpPut ("{id}")]
        public IActionResult Atualizar (int id, [FromBody] UsuarioModel usuario) {
            JsonResult rs;
            if (user.Atualizar (usuario)) {
                return Ok ();
            } else {
                return BadRequest ();
            }
            if (usuario == null || usuario.Id != id) {
                return BadRequest ();
            }
            rs = new JsonResult (user.Atualizar (usuario));
            rs.ContentType = "application/json";

            try {
                if (!ModelState.IsValid) {
                    return BadRequest (ModelState);
                }
                if (!Convert.ToBoolean (rs.Value)) {
                    rs.StatusCode = 404;
                    rs.Value = "Ocorreu um erro";
                } else {
                    rs.Value = "Area atualizada";
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

        [HttpDelete]
        public string Deletar ([FromBody] UsuarioModel usuario) {
            string msg = "Usuário não encontrado";
            if (user.Deletar (usuario)) {
                msg = "Usuario excluido";
            }
            return msg;
        }
    }
}