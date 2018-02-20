using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Autenticacao_EF_Cookie.Models;
using Autenticacao_EF_Cookie.Repositorio;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Autenticacao_EF_Cookie.Controllers
{
    [AllowAnonymous]
    public class ContaController : Controller
    {
        readonly AutenticacaoContexto _contexto;

        public ContaController(AutenticacaoContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            try
            {

                /*
insert into Usuarios values('colte12@gmail.com', 'Ligia', '123456')
insert into Permissoes values('Contabilidade')
insert Into UsuariosPermissoes values((select max(IdPermissao) from Permissoes), (select max(idusuario) from Usuarios))
insert Into UsuariosPermissoes values((select max(IdPermissao) from Permissoes),(select IdUsuario from Usuarios where Email = 'fernando.guerra@corujasdev.com.br'))

                 */
                Usuario user = _contexto.Usuarios.Include("UsuariosPermissoes")
                                                .Include("UsuariosPermissoes.Permissao")
                                                .FirstOrDefault(c => c.Email == usuario.Email && 
                                                                    c.Senha == usuario.Senha );

                if (user != null)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Email, user.Email));
                    claims.Add(new Claim(ClaimTypes.Name, user.Nome));
                    claims.Add(new Claim("FullName", user.Nome));

                    foreach (var item in user.UsuariosPermissoes)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, item.Permissao.Nome));
                    }
                    
                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme
                    );

                    HttpContext.SignInAsync( CookieAuthenticationDefaults.AuthenticationScheme, 
                        new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Financeiro");
                }

                TempData["Mensagem"] = "Usuário ou senha inválidos";

                return View();
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(usuario);
            }
        }

        private List<Claim> GetClaims(Usuario usuario)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, usuario.Email));
            claims.Add(new Claim("Nome", usuario.Nome));

            foreach (var item in usuario.UsuariosPermissoes)
            {
                claims.Add(new Claim(ClaimTypes.Role, item.Permissao.Nome));
            }

            return claims;
        }

        [HttpGet]
        public IActionResult Sair(){
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
    }
}