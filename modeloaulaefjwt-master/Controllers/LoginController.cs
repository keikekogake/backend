using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using modeloaulaefjwt_master.Models;
using modeloaulaefjwt_master.Repositorio;
using modelobasicoefjwt.Models;
using modelobasicoefjwt.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.IdentityModel.Tokens;

namespace modeloaulaefjwt_master.Controllers {
    [Route ("api/[controller]")]
    public class LoginController : Controller {
        readonly AutenticacaoContext _contexto;
        public LoginController (AutenticacaoContext contexto) {
            _contexto = contexto;
        }

        [HttpPost]
        public IActionResult Validar ([FromBody] Usuario usuario, [FromServices] SigningConfigurations signingConfigurations, [FromServices] TokenConfigurations tokenConfigurations) {
            Usuario user = _contexto.Usuarios.FirstOrDefault (c => c.Email == usuario.Email && c.Senha == usuario.Senha);

            if (user != null) {
                ClaimsIdentity identity = new ClaimsIdentity (
                    new GenericIdentity (user.IdUsuario.ToString (), "Login"),
                    new [] {
                        new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ("N")),
                        new Claim (JwtRegisteredClaimNames.Jti, user.IdUsuario.ToString()),
                        new Claim (JwtRegisteredClaimNames.Jti, user.Nome),
                        new Claim (ClaimTypes.Email, user.Email)
                    }
                );

                var handler = new JwtSecurityTokenHandler ();
                var securiryToken = handler.CreateToken (new SecurityTokenDescriptor {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity
                });

                var token = handler.WriteToken(securiryToken);

                var retorno = new {
                    autenticacao = true,
                    accessToken = token,
                    message = "Ok"
                };

                return Ok (retorno);
            }
            var retornoErro = new {
                autenticacao = false,
                message = "Falha na autenticação"
            };

            return BadRequest (retornoErro);
        }
    }
}