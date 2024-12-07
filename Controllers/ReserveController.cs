using GestionDeAulas.Models;
using GestionDeAulas.Models.ViewModels.Reserves;
using GestionDeAulas.Repository;
using GestionDeAulas.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDeAulas.Controllers
{
    public class ReserveController : Controller
    {
        protected readonly UnidadContenedora _container;
        public ReserveController(UnidadContenedora container)
        {
            _container = container;
        }
        public async Task< IActionResult> Index()
        {
            var response = await _container._reserve.List(null,null,"Teacher,Room,Class");
            return View(response);
        }
        public async Task<IActionResult> Crear() {
            //var materias = await _container._classes.List();
            var listas = new ReserveCreateVM() {
                
            };
            listas.Date =  DateOnly.FromDateTime(DateTime.Now);
            listas.EndDate = DateOnly.FromDateTime(DateTime.Now);
     


            return View(listas); }
        [HttpPost]
        public async Task<IActionResult> Create(ReserveCreateVM entity) {
            
            var reserve = new Reserve() { Description = entity.Description, Date = entity.Date, ClassId = entity.ClassId, EndDate = entity.EndDate, Hour = entity.Hour, IsActive = true, RoomId = entity.RoomId, TotalHours = entity.TotalHours, UserId = entity.UserId };
            _container._reserve.Add(reserve);
            await _container.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Seeker(ReserveCreateVM data) 
        {
            var response =await  _container._reserve.Seek(data);
            data.Rooms = response;
            data.ClassesList= await _container._classes.List();
            var roles = await _container._roles.GetFirst(e => e.NormalizedName == "DOCENTE");
            if (roles != null) {
                data.UsersList = await _container._classes.GetTeachers();
            }
            return View(nameof(Crear),data);
        }
        public IActionResult Edit() { return View(); }
        public IActionResult Delete() { return View(); }
    }
}
