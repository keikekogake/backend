using Microsoft.AspNetCore.Mvc;
using projetoCidades.Models;

namespace projetoCidades.Controllers {
    public class CidadesController : Controller {
        Cidade cidade = new Cidade();
        public IActionResult Index () {
            // Execução do método LISTARCIDADES, para trazer a lista de cidades.
            var list = cidade.ListarCidades();
            return View (list);
        }
        public IActionResult CidadesEstados () {
            var list = cidade.ListarCidades();
            return View (list);
        }
        public IActionResult TodosOsDados () {
            var list = cidade.ListarCidades();
            return View (list);
        }
    }
}