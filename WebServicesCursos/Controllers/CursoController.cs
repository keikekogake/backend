using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServicesCursos.Dados;
using WebServicesCursos.Model;

namespace WebServicesCursos.Controllers {
    [Route ("api/[controller]")]
    public class CursoController : Controller {
        readonly CursosContexto contexto;
        Curso area = new Curso ();

        public CursoController (CursosContexto contexto) {
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Curso> Listar () {
            return contexto.Curso.ToList ();
        }

        [HttpPost]
        public IActionResult Cadastrar ([FromBody] Curso curso) {
            JsonResult rs;
            contexto.Curso.Add (curso);
            rs = new JsonResult (contexto.SaveChanges ());
            rs.ContentType = "application/json";

            try {
                if (!ModelState.IsValid) {
                    return BadRequest (ModelState);
                }
                if (!Convert.ToBoolean (rs.Value)) {
                    rs.StatusCode = 404;
                    rs.Value = "Ocorreu um erro";
                } else {
                    rs.Value = "Curso cadastrado";
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
        public IActionResult Atualizar (int id, [FromBody] Curso curso) {
            JsonResult rs;
            if (curso == null || curso.IdCurso != id) {
                return BadRequest ();
            }
            var conCurso = contexto.Curso.FirstOrDefault (x => x.IdCurso == id);
            if (conCurso == null) {
                return NotFound ();
            } else {
                conCurso.IdCurso = curso.IdCurso;
                conCurso.Nome = curso.Nome;
                conCurso.IdArea = curso.IdArea;

                contexto.Curso.Update (conCurso);
                rs = new JsonResult (contexto.SaveChanges ());
                rs.ContentType = "application/json";

                try {
                    if (!ModelState.IsValid) {
                        return BadRequest (ModelState);
                    }
                    if (!Convert.ToBoolean (rs.Value)) {
                        rs.StatusCode = 404;
                        rs.Value = "Ocorreu um erro";
                    } else {
                        rs.Value = "Curso atualizado";
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
        }

        [HttpDelete ("{id}")]
        public IActionResult Deletar (int id) {
            JsonResult rs;
            if (id == null) {
                return BadRequest ();
            }
            var conCurso = contexto.Curso.FirstOrDefault (x => x.IdCurso == id);
            if (conCurso == null) {
                return NotFound ();
            } else {
                contexto.Curso.Remove (conCurso);
                rs = new JsonResult (contexto.SaveChanges ());
                rs.ContentType = "application/json";

                try {
                    if (!ModelState.IsValid) {
                        return BadRequest (ModelState);
                    }
                    if (!Convert.ToBoolean (rs.Value)) {
                        rs.StatusCode = 404;
                        rs.Value = "Ocorreu um erro";
                    } else {
                        rs.Value = "Curso removido";
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
        }
    }
}