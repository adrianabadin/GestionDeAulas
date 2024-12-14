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
        public  IActionResult Crear() {
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
            var response =await  _container._reserve.Seek(data,false);
            data.Rooms = response;
            data.ClassesList= await _container._classes.List();
            var roles = await _container._roles.GetFirst(e => e.NormalizedName == "DOCENTE");
            if (roles != null) {
                data.UsersList = await _container._classes.GetTeachers();
            }
            return View(nameof(Crear),data);
        }

        public async Task<IActionResult> Edit(string id, ReserveUpdateVM? entity) {
            try {             
                if (entity.ClassId == null && id !=null) { 
            var data =await  _container._context.Reserves.FindAsync(id);
                //if para validar data
            var classes=  await _container._classes.List();
            var teachers = await _container._classes.GetTeachers();
                    if (data == null) throw new Exception("Id Not Found");
            var roomAsigned = await _container._classRoom.GetByID(data.RoomId);
                    if (classes == null || teachers == null || roomAsigned == null) throw new Exception("SOmething went wrong");
            if (data != null && classes !=null && teachers!=null && roomAsigned !=null)  {             
                var response = new ReserveUpdateVM() {
                ClassId=data.ClassId,Date=data.Date,Description=data.Description,EndDate=data.EndDate,IsActive=data.IsActive,Hour=data.Hour,RoomId=data.RoomId,
                Students=roomAsigned.Seats,TotalHours=data.TotalHours,UserId=data.UserId,UsersList=teachers,ClassesList=classes,Id=data.Id
                  };
                var availableRooms = await _container._reserve.Seek(response,true);

                var lista = new List<ClassRoom>() { };
                if (availableRooms != null)
                {
                    lista.AddRange(availableRooms);
                }
               
                response.Rooms = lista;
                        response.MainId = id; 



            return View(response); }
            else { return RedirectToAction(nameof(Index)); }
            }else { return View(entity); }
            }catch(Exception err)
            {
                Console.WriteLine(err.Message);
                return View(nameof(Index));
            }

            }




        [HttpPost]
        public async Task<IActionResult> SeekEdit(ReserveUpdateVM entity) {
            entity.UsersList = await _container._classes.GetTeachers();
            entity.Rooms = await _container._reserve.Seek(entity, true);
            entity.ClassesList=await _container._classes.List();
            return View(nameof(Edit),entity);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(ReserveUpdateVM data) {
            var reserva = new Reserve()
            
            {
            ClassId=data.ClassId,
            Date=data.Date,Description=data.Description,EndDate = data.EndDate,Hour = data.Hour,IsActive = data.IsActive,
            RoomId= data.RoomId,TotalHours=data.TotalHours,UserId=data.UserId,Class=data.Class,Id=data.MainId
            };
            await _container._reserve.Update(reserva,data.MainId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete() { return View(); }
    }
}
