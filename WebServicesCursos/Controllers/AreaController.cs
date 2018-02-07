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

        /// <summary>
        /// Lista todas as Áreas cadastradas no sistema.
        /// </summary>
        /// <returns>Lista de áreas</returns>
        /// <response code="200"> Retorna uma lista de áreas </response>
        /// <response code="400"> Ocorreu um erro </response>
        [HttpGet]
        [ProducesResponseType (typeof (List<Area>), 200)]
        [ProducesResponseType (typeof (string), 400)]
        public IActionResult Listar () {
            try {
                return Ok (contexto.Area.ToList ());
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        /// <summary>
        /// Lista todas as Áreas cadastradas no sistema.
        /// </summary>
        /// <returns>Lista de áreas</returns>
        /// <response code="200"> Retorna uma lista de áreas </response>
        /// <response code="400"> Ocorreu um erro </response>
        /// /// <response code="404"> Área não encontrada </response>
        [HttpGet ("{id}")]
        [ProducesResponseType (typeof (List<Area>), 200)]
        [ProducesResponseType (typeof (string), 400)]
        [ProducesResponseType (typeof (string), 404)]
        public IActionResult Listar (int id) {

            try {
                var area = Ok (contexto.Area.ToList ().Where (x => x.IdArea == id).FirstOrDefault ());
                if (area.Value == null) {
                    return NotFound ("Area não encontrada");
                }
                return Ok (area);
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        /// <summary>
        /// Cadastra uma nova área
        /// </summary>
        /// <param name="area">Objeto AREA</param>
        /// <remarks>
        /// Modelo de dados que deve ser enviado para cadastrar a area request:
        /// 
        ///     POST /area
        ///     {
        ///         "nome" : "nome da área"
        ///     }
        /// </remarks>
        /// <response code="200"> Retorna a área cadastrada </response>
        /// <response code="400"> Ocorreu um erro </response>
        [HttpPost]
        [ProducesResponseType (typeof (Area), 200)]
        [ProducesResponseType (typeof (string), 400)]
        public IActionResult Cadastrar ([FromBody] Area area) {
            try {
                contexto.Area.Add (area);
                contexto.SaveChanges ();
                return Ok (area);
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        /// <summary>
        /// Atualiza uma área
        /// </summary>
        /// <param name="id"> ID da área que será atualizada </param>
        /// <param name="area"> Novo nome da área </param>
        /// <returns> Retorna a área atualizada </returns>
        /// <remarks>
        /// Modelo de dados que deve ser enviado para atualizar a area:
        /// 
        ///     POST /area
        ///     {
        ///         "idarea" : id da área    
        ///         "nome" : "nome da área"
        ///     }
        /// </remarks>
        /// <response code="200"> Retorna a área atualizada </response>
        /// <response code="400"> Ocorreu um erro </response>
        [HttpPut ("{id}")]
        [ProducesResponseType (typeof (Area), 200)]
        [ProducesResponseType (typeof (string), 400)]
        [ProducesResponseType (typeof (string), 404)]
        public IActionResult Atualizar (int id, [FromBody] Area area) {

            try {
                if (area == null || area.IdArea != id) {
                    return BadRequest ("Parametros inválidos");
                }
                var conArea = contexto.Area.FirstOrDefault (x => x.IdArea == id);
                if (conArea == null) {
                    return NotFound ("Área não encontrada");
                } else {
                    conArea.IdArea = area.IdArea;
                    conArea.Nome = area.Nome;

                    contexto.Area.Update (conArea);
                    return Ok (area);
                }
            } catch (Exception ex) {
                return BadRequest (ex.Message);
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