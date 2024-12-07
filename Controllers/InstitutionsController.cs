using GestionDeAulas.Models;
using GestionDeAulas.Repository;
using GestionDeAulas.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeAulas.Controllers
{
    public class InstitutionsController : Controller
    {
        protected UnidadContenedora _container {  get; set; }
        public InstitutionsController(UnidadContenedora Container)
        {
            _container = Container;
        }
        public async Task<IActionResult> Index()
        {
            var institutions = await _container._institutions.List(); 
            return View(institutions);
        }
        public IActionResult Crear() { return View(); }
        [HttpPost]
        public async Task<IActionResult> Create(Institutions entity) 
        {
            //entity.Id = new Guid().ToString();
            _container._institutions.Add(entity);
           await _container.Save();
            return RedirectToAction(nameof(Index));
        }
        public async  Task<IActionResult> Edit(string id) {
            var institution= await _container._institutions.GetByID(id);
            return View(institution); }

        [HttpPost]
        public async Task<IActionResult> Edit(Institutions entity) {
            var response = await _container._institutions.Update(entity);
            if (response == null) return View(entity);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(string id) {
            await _container._institutions.Remove(id);
            await _container.Save();
            return RedirectToAction(nameof(Index)); }
        public async Task<IActionResult> UnDelete(string id)
        {
            await _container._institutions.UnDelete(id);
            await _container.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
