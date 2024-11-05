using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestionDeAulas.Models
{
    public class ReserveSeek
    {
        [Required(ErrorMessage ="Debes definir el numero de alumnos")]
        [DisplayName("Numero de Estudiantes")]
        public int Students {  get; set; }
        [Required(ErrorMessage ="Debes definir la fecha")]
        [DisplayName("Fecha de reserva")]
        public DateOnly Date { get; set; }
        [Required(ErrorMessage = "Hora de inicio")]
        [DisplayName("Hora de inicio de la clase")]
        public string Hour { get; set; } = string.Empty;
        [Required( ErrorMessage ="Debes definir el numero de horas de la reserva")]
        [DisplayName("Horas de la reserva")]
        public string TotalHours { get; set; } = string.Empty;
        [Required(ErrorMessage = "Debes definir la fecha de fin de reserva")]
        [DisplayName("Fecha de Fin de Reserva")]
        public DateOnly EndDate {  get; set; }
    }
}
