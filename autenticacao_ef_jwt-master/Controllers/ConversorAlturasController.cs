using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao_EF_JWT.Controllers
{
    [Route("api/[controller]")]
    public class ConversorAlturasController : Controller
    {
        [Authorize("Bearer", Roles="Recursos Humanos")]
        [HttpGet("PesMetros/{alturaPes}")]
        public IActionResult Get(double alturaPes)
        {
            var retorno = new
            {
                AlturaPes = alturaPes,
                AlturaMetros = Math.Round(alturaPes * 0.3048, 4)
            };

            return Ok(retorno);
        }
    }
}