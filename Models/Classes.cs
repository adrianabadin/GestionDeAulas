using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeAulas.Models
{
    public class Classes
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; }= string.Empty;
        [ForeignKey("Courses")]
        [Required(ErrorMessage ="Debes Seleccionar una Carrera")]
        [DisplayName("Carrera o Curso")]
        public Guid CourseId { get; set; }
        public Course Course { get; set; } = new Course();
        [ForeignKey("User")]
        [Required(ErrorMessage = "Debes Seleccionar un Docente")]
        [DisplayName("Docente")]

        public Guid UserId { get; set; }
        public User User { get; set; } = new User();
        [DefaultValue(true)]
        public bool IsActive { get; set; } = true;

    }
}
