using GestionDeAulas.Models;
using GestionDeAulas.Repository;
using GestionDeAulas.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeAulas.Controllers
{
    public class ClassRoomController : Controller
    {
        public UnidadContenedora _container;
        public ClassRoomController(UnidadContenedora container)
        {
            _container= container;
        }
        public async Task<IActionResult> Index()
        {
            var response = await  _container._classRoom.List();
            return View(response);
        }
        
        
        public IActionResult Create() { return View(); }
        [HttpPost]
        public async Task<IActionResult> Create(ClassRoom data) 
        {
            try {
                data.IsActive = true;
                 _container._classRoom.Add(data);
                await _container.Save();
                return RedirectToAction(nameof(Index));
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        
            public async Task<IActionResult> Edit(string id) {
            try {
                var response = await _container._classRoom.GetByID(id);
                if (response == null) throw new Exception("No se encontro el salon");
                
                return View(response);

            } catch (Exception ex) { Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
 }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClassRoom entity) {
            try {
                await _container._classRoom.Update(entity);
                return RedirectToAction(nameof(Index));
            }catch(Exception ex) { Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        public async  Task<IActionResult> Delete(string id) {
            try
            {
                var entidad = await _container._context.Classrooms.FindAsync(id);
                if (entidad == null) throw new Exception("No se encontro el aula...");
                entidad.IsActive = false;
                await _container.Save();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }




 }
        public async Task<IActionResult> UnDelete(string id)
        {
            try {
                var entidad =await  _container._context.Classrooms.FindAsync(id);
                if (entidad == null) throw new Exception("No se encontro el aula...");
                entidad.IsActive = true;
                await _container.Save();
                return RedirectToAction(nameof(Index));
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}
