using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServicesCursos.Dados;
using WebServicesCursos.Model;

namespace WebServicesCursos.Controllers {
    [Route ("api/[controller]")]
    public class AreaController : Controller {
        readonly CursosContexto contexto;
        Area area = new Area ();

        public AreaController (CursosContexto contexto) {
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Area> Listar () {
            return contexto.Area.ToList ();
        }

        [HttpPost]
        public IActionResult Cadastrar ([FromBody] Area area) {
            JsonResult rs;
            contexto.Area.Add (area);
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
                    rs.Value = "Area cadastrada";
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
        public IActionResult Atualizar (int id, [FromBody] Area area) {
            JsonResult rs;
            if (area == null || area.IdArea != id) {
                return BadRequest ();
            }
            var conArea = contexto.Area.FirstOrDefault (x => x.IdArea == id);
            if (conArea == null) {
                return NotFound ();
            } else {
                conArea.IdArea = area.IdArea;
                conArea.Nome = area.Nome;

                contexto.Area.Update (conArea);
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
        }

        [HttpDelete ("{id}")]
        public IActionResult Deletar (int id) {
            JsonResult rs;
            if (id == null) {
                return BadRequest ();
            }
            var conArea = contexto.Area.FirstOrDefault (x => x.IdArea == id);
            if (conArea == null) {
                return NotFound ();
            } else {
                contexto.Area.Remove (conArea);
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
                        rs.Value = "Area removida";
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