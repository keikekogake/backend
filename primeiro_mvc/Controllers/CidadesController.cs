using Microsoft.AspNetCore.Mvc;

namespace primeiro_mvc.Controllers {
    public class CidadesController : Controller {
        public IActionResult Index () {
            return View ();
        }
    }
}