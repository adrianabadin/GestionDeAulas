using GestionDeAulas.Models.IModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeAulas.Models
{
    [PrimaryKey(nameof(Date),nameof(RoomId),nameof(Hour))]
    public class Reserve :IActivable
    {
        
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        [Column("0")]
        [Required(ErrorMessage = "Ingresa una fecha para inicio de reserva")]
        [DisplayName("Fecha de Reserva")]
        public DateOnly Date {  get; set; }
        [ForeignKey("Classes")]
        [DisplayName("Materia")]
        
        public string? ClassId {  get; set; }
        public Classes? Class { get; set; } 
        [ForeignKey("User")]
        public string? UserId {  get; set; }
        public User? Teacher { get; set; } 
        [Column("1")]
        [Required(ErrorMessage = "Debes ingresar una hora para la reserva")]
        [DisplayName("Hora de la reserva")]
        public int  Hour { get; set; } 
        
        [Column("2")]
        [ForeignKey("ClassRoom")]
        [DisplayName("Numero de Salon")]
        [Required(ErrorMessage = "Debes ingresar un numero de Aula")]
        public string RoomId { get; set; } = string.Empty;
        public ClassRoom? Room { get; set; } 
        
        public string Description {  get; set; } = string.Empty;
        [Required(ErrorMessage = "Debes definir el numero de horas de la reserva")]
        [DisplayName("Horas de la reserva")]
        public int TotalHours { get; set; } 
        [Required(ErrorMessage = "Debes definir la fecha de fin de reserva")]
        [DisplayName("Fecha de Fin de Reserva")]
        public DateOnly EndDate { get; set; }
        public bool? IsActive { get; set; }
        
    }
}
