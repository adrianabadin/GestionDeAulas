using Microsoft.AspNetCore.Mvc;

namespace GestionDeAulas.Controllers
{
    public class ReserveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Crear() { return View(); }
        public IActionResult Edit() { return View(); }
        public IActionResult Delete() { return View(); }
    }
}
