using Autenticacao_EF_Cookie.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao_EF_Cookie.Controllers
{
    [Authorize(Roles="Recursos Humanos")]
    public class RecursosHumanosController : Controller
    {
        readonly AutenticacaoContexto _contexto;

        public RecursosHumanosController(AutenticacaoContexto contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index(){
            return View();
        }
    }
}