using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServicesCursos.Dados;
using WebServicesCursos.Model;

namespace WebServicesCursos.Controllers {
    [Route ("api/[controller]")]
    public class DataHoraController : Controller {
        readonly CursosContexto contexto;
        DataHora dataHora = new DataHora ();

        public DataHoraController (CursosContexto contexto) {
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<DataHora> Listar () {
            return contexto.DataHora.ToList ();
            
        }

        [HttpPost]
        public IActionResult Cadastrar ([FromBody] DataHora dataHora) {
            JsonResult rs;
            contexto.DataHora.Add (dataHora);
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
        public IActionResult Atualizar (int id, [FromBody] DataHora dataHora) {
            JsonResult rs;
            if (dataHora == null || dataHora.IdDataHora != id) {
                return BadRequest ();
            }
            var conDataHora = contexto.DataHora.FirstOrDefault (x => x.IdDataHora == id);
            if (conDataHora == null) {
                return NotFound ();
            } else {
                conDataHora.DataInicio = dataHora.DataInicio;
                conDataHora.DataFim = dataHora.DataFim;
                conDataHora.HoraInicio = dataHora.HoraFim;
                conDataHora.HoraFim = dataHora.HoraFim;
                conDataHora.IdDataHora = dataHora.IdDataHora;
                conDataHora.IdCurso = dataHora.IdCurso;
                conDataHora.DiaSemana = dataHora.DiaSemana;

                contexto.DataHora.Update (conDataHora);
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
            var conDataHora = contexto.DataHora.FirstOrDefault (x => x.IdDataHora == id);
            if (conDataHora == null) {
                return NotFound ();
            } else {
                contexto.DataHora.Remove (conDataHora);
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