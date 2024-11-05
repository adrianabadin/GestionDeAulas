using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeAulas.Models
{
    public class Classes
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "La materia debe tener un nombre")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "La materia debe tener una descripcion")]
        public string Description { get; set; }= string.Empty;
        [ForeignKey("Courses")]
        [Required(ErrorMessage ="Debes Seleccionar una Carrera")]
        [DisplayName("Carrera o Curso")]
        public Guid CourseId { get; set; }
        public Course Course { get; set; } = new Course();
        [ForeignKey("User")]
        [Required(ErrorMessage = "Debes Seleccionar un Docente")]
        [DisplayName("Docente")]

        public string UserId { get; set; }
        public User User { get; set; } = new User();
        [DefaultValue(true)]
        public bool IsActive { get; set; } = true;

    }
}
