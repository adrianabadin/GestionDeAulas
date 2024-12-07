using GestionDeAulas.Models;
using GestionDeAulas.Models.ViewModels;
using GestionDeAulas.Models.ViewModels.Classes;
using GestionDeAulas.Repository;
using GestionDeAulas.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDeAulas.Controllers
{
    public class ClassesController : Controller
    {
        private readonly UnidadContenedora _Container;
        public ClassesController(UnidadContenedora Container)
        {
            _Container= Container;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _Container._classes.List(null,null,"User,Course");

            return View(response);
        }
        public async  Task<IActionResult> Create() {
            var data = new ClassesVMCreate();
            var roles = await _Container._roles.List();
            if (roles == null) throw new Exception("No Roles Asigned");
            string TeacherRolId = "";
            foreach (var role in roles) { 
            if (role.NormalizedName=="DOCENTE") TeacherRolId = role.Id;
            }
            if (TeacherRolId == null) throw new Exception("No Teachers Asigned");
            var teachers = await _Container._classes.GetTeachers();
            var courses = await _Container._classes.GetCourses();
            var classesVM = new ClassessCreateVM() { CoursesList = courses, TeachersList = teachers };
            return View(classesVM); 
        }
        [HttpPost]
        public async Task<IActionResult> Create(Classes entity) {
             _Container._classes.Add(entity);
            await _Container.Save();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(string id) {
            var data = await _Container._classes.GetFirst(e=>e.Id==id,"User,Course");
            if (data == null) throw new Exception("No se enccontro la materia");
            ClassessCreateVM response = new ClassessCreateVM() {
            Description=data.Description,
            Id=id,
            IsActive=data.IsActive,
            Name=data.Name,
            CourseId=data.CourseId,
            UserId=data.UserId,
            TeachersList=await _Container._classes.GetTeachers(),
            CoursesList= await _Container._classes.GetCourses()
            };
            return View(response); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClassessCreateVM entity) {
            var response = await  _Container._classes.GetByID(entity.Id);
            if (response == null) throw new Exception("Materia no encontrada");
            response.Description= entity.Description ?? response.Description;
            response.Name= entity.Name ?? response.Name;
            response.CourseId = entity.CourseId ?? response.CourseId;
            response.UserId = entity.UserId ?? response.UserId;
            response.IsActive = entity.IsActive ?? response.IsActive;
            await _Container.Save();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _Container._classes.Remove(id);
                await _Container.Save();
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
            try
            {
                await _Container._classes.UnDelete(id);
                await _Container.Save();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}
