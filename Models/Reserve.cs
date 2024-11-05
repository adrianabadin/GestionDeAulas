using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeAulas.Models
{
    [PrimaryKey(nameof(Date),nameof(RoomId),nameof(Hour))]
    public class Reserve
    {
        [Column("0")]
        [Required(ErrorMessage = "Ingresa una fecha para inicio de reserva")]
        [DisplayName("Fecha de Reserva")]
        public DateOnly Date {  get; set; }
        [ForeignKey("Classes")]
        [DisplayName("Materia")]
        
        public Guid? ClassId {  get; set; }
        public Classes? Class { get; set; } = new Classes();
        [ForeignKey("User")]
        public Guid? UserId {  get; set; }
        public User? Teacher { get; set; } = new User();
        [Column("1")]
        [Required(ErrorMessage = "Debes ingresar una hora para la reserva")]
        [DisplayName("Hora de la reserva")]
        public string Hour { get; set; } = string.Empty;
        
        [Column("2")]
        [ForeignKey("ClassRoom")]
        [DisplayName("Numero de Salon")]
        [Required(ErrorMessage = "Debes ingresar un numero de Aula")]
        public string RoomId { get; set; } = string.Empty;
        public ClassRoom Room { get; set; } = new ClassRoom();
        
        public string Description {  get; set; } = string.Empty;
        [Required(ErrorMessage = "Debes definir el numero de horas de la reserva")]
        [DisplayName("Horas de la reserva")]
        public string TotalHours { get; set; } = string.Empty;
        [Required(ErrorMessage = "Debes definir la fecha de fin de reserva")]
        [DisplayName("Fecha de Fin de Reserva")]
        public DateOnly EndDate { get; set; }
        
    }
}
