using GestionDeAulas.Models;
using GestionDeAulas.Models.ViewModels.Courses;
using GestionDeAulas.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeAulas.Controllers
{
    public class CoursesController : Controller
    {
        public UnidadContenedora _container;
        public CoursesController(UnidadContenedora Container)
        {
            _container = Container;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _container._courses.List(null,null,"Institution");
            return View(response);
        }
        public async Task<IActionResult> Create() {
            var datos = new CoursesCreateVM()
            {
                Institutions = await _container._institutions.List()

            };
            return View(datos); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CoursesCreateVM entity) {
            if (ModelState.IsValid)
            {

                _container._courses.Add(entity);
                await _container.Save();
            }
            else {
                entity.Institutions = await _container._institutions.List();
                return View(entity); }

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id) {
            try {
                var course = await _container._courses.GetByID(id);
                if (course == null) throw new Exception("No se encuentra una carrera con es ID");
                var entity = new CoursesCreateVM()
                {
                    Description = course.Description,
                    Institutions = await _container._institutions.List(),
                    InstitutionId = course.InstitutionId,
                    IsActive = course.IsActive,
                    Id = id,
                    Name = course.Name,
                    StartingYear = course.StartingYear
                };
                return View(entity);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CoursesCreateVM entity) {
            try {
                await _container._courses.Update(entity);
                await _container.Save();
                return RedirectToAction(nameof(Index));
            } catch (Exception ex) { Console.WriteLine(ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _container._courses.Remove(id);
                await _container.Save();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                var course = await _container._courses.GetByID(id);
                return View(course);
            }
            
        }
        public async Task<IActionResult> UnDelete(string id) {
            try
            {
                await _container._courses.UnDelete(id);
                await _container.Save();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                var course = await _container._courses.GetByID(id);
                return View(course);
            }
        }
    }
}
