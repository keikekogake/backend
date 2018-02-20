using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao_EF_JWT.Controllers
{
    
        [Route("api/[controller]")]
        public class RetornaIdadeController : Controller
        {
            [Authorize("Bearer", Roles="Recursos Humanos")]
            [HttpGet("Idade/{anonascimento}")]
            public IActionResult Get(int anonascimento)
            {
                var retorno = new
                {
                    AnoNascimento = anonascimento,
                    Idade = DateTime.Now.Year - anonascimento,
                    Nome = User.Claims.Where(c => c.Type == "Nome").Select(c => c.Value).SingleOrDefault(),
                    Email = User.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value).SingleOrDefault()
                };

                return Ok(retorno);
            }
        }
    }
