using GestionDeAulas.Models.IModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GestionDeAulas.Models.ViewModels.Reserves
{
    public class ReserveCreateVM
    {
        public IEnumerable<GestionDeAulas.Models.Classes>? ClassesList { get; set; }
        public IEnumerable<GestionDeAulas.Models.DTOs.NamedEntity>? UsersList { get; set; }
        public ICollection<GestionDeAulas.Models.ClassRoom> Rooms { get; set; } = new List<ClassRoom>();
        public GestionDeAulas.Models.Classes? Class { get; set; }
        [Range(0,100)]
        public int Students{ get; set; }
       virtual public string? Id { get; set; } = Guid.NewGuid().ToString();
     
            [Required(ErrorMessage = "Ingresa una fecha para inicio de reserva")]
            [DisplayName("Fecha de Reserva")]
            public DateOnly Date { get; set; }
     
            [DisplayName("Materia")]

            public string? ClassId { get; set; }
            
            public string? UserId { get; set; }
            public User? Teacher { get; set; }
            [Required(ErrorMessage = "Debes ingresar una hora para la reserva")]
            [DisplayName("Hora de la reserva")]
            public int Hour { get; set; } 
            
            [DisplayName("Numero de Salon")]
            [Required(ErrorMessage = "Debes ingresar un numero de Aula")]
            public string RoomId { get; set; } = string.Empty;
            public ClassRoom? Room { get; set; }
            public string Description { get; set; } = string.Empty;
            [Required(ErrorMessage = "Debes definir el numero de horas de la reserva")]
            [DisplayName("Horas de la reserva")]
            public int TotalHours { get; set; } 
            [Required(ErrorMessage = "Debes definir la fecha de fin de reserva")]
            [DisplayName("Fecha de Fin de Reserva")]
            public DateOnly EndDate { get; set; }
            public bool? IsActive { get; set; }

        
    }
}
