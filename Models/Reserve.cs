using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeAulas.Models
{
    public class Reserve
    {
        [Key]
        [Column("0")]
        [Required]
        [DisplayName("Fecha de Reserva")]
        public DateOnly Date {  get; set; }
        [ForeignKey("Classes")]
        [DisplayName("Materia")]
        public Guid ClassId {  get; set; }
        public Classes Class { get; set; } = new Classes();
        [ForeignKey("User")]
        public Guid UserId {  get; set; }
        public User Teacher { get; set; } = new Teacher();
        [Key]
        [Column("1")]
        [Required]
        [DisplayName("Hora de la reserva")]
        public string Hour { get; set; } = string.Empty;
        [Key]
        [Column("2")]
        [ForeignKey("ClassRoom")]
        [DisplayName("Numero de Salon")]
        public string RoomId { get; set; } = string.Empty;
        public ClassRoom Room { get; set; } = new ClassRoom();
        [Required]
        public string Description {  get; set; } = string.Empty;

    }
}
