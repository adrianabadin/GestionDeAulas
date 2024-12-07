using Microsoft.AspNetCore.Mvc;

namespace GestionDeAulas.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult ListReserves()
        {
            return View();
        }
    }
}
