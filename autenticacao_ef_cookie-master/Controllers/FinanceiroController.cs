using System.Linq;
using System.Security.Claims;
using Autenticacao_EF_Cookie.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao_EF_Cookie.Controllers
{
    [Authorize(Roles="Financeiro")]
    public class FinanceiroController : Controller
    {

        readonly AutenticacaoContexto _contexto;

        public FinanceiroController(AutenticacaoContexto contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index(){
            

            return View();
        }
        
    }
}