using Microsoft.AspNetCore.Mvc;

namespace papelaria_mvc.Controllers {
    public class CategoriasController : Controller {
        public IActionResult Cadastrar () {
            ViewData["msg"] = "Cadastro de Categorias";
            return View ();
        }
        public IActionResult Consultar () {
            return View ();
        }
    }
}