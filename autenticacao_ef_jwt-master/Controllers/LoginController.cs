using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using Autenticacao_EF_JWT.Dados;
using Autenticacao_EF_JWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Autenticacao_EF_JWT.Controllers
{
    /*
        O método Post receberá requisições HTTP do tipo POST, tendo sido marcado com o atributo AllowAnonymous para assim possibilitar o acesso de usuários não-autenticados;
    As instâncias dos tipos UsersDAO, SigningConfigurations e TokenConfigurations foram marcadas com o atributo FromServices no método Post, o que indica que as mesmas serão resolvidas via mecanismo de injeção de dependências do ASP.NET Core;
    O parâmetro usuario foi marcado com o atributo FromBody, correspondendo às credenciais (ID do usuário + chave de acesso) que serão enviadas no corpo de uma requisição. As informações desta referência (usuario) serão então comparadas com o retorno produzido pela instância do tipo UsersDAO, determinando assim a validade do usuário e da chave de acesso em questão;
    Em se tratando de credenciais de um usuário existente claims serão geradas, o período de expiração calculado e um token criado por meio de uma instância do tipo JwtSecurityTokenHandler (namespace System.IdentityModel.Tokens.Jwt). Este último elemento é então transformado em uma string por meio do método WriteToken e, finalmente, devolvido como retorno da Action Post (juntamente com outras informações como horário de geração e expiração do token);
    Se o usuário for inválido um objeto então será devolvido, indicando que a autenticação falhou.
     */
     
    [Route("api/login")]
    public class LoginController : Controller
    {
        readonly AutenticacaoContexto _contexto;

        public LoginController(AutenticacaoContexto contexto)
        {
            _contexto = contexto;   
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post(
            [FromBody]Usuario usuario,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations)
        {
            
            Usuario user = _contexto.Usuarios.Include("UsuariosPermissoes")
                                                .Include("UsuariosPermissoes.Permissao")
                                                .FirstOrDefault(c => c.Email == usuario.Email && 
                                                                    c.Senha == usuario.Senha );

            
            
            if (user != null)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.IdUsuario.ToString(), "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.IdUsuario.ToString()),
                        new Claim("Nome", user.Nome),
                        new Claim(ClaimTypes.Email, user.Email)
                    }
                );

                foreach (var item in user.UsuariosPermissoes)
                {
                        identity.AddClaim(new Claim(ClaimTypes.Role, item.Permissao.Nome));
                }

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                var retorno = new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };

                return Ok(retorno);
            }
            else
            {
                var retorno = new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };

                return BadRequest(retorno);
            }
        }
    }
}