using GestionDeAulas.Models.IModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeAulas.Models
{
    public class Classes :IActivable
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "La materia debe tener un nombre")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "La materia debe tener una descripcion")]
        public string Description { get; set; }= string.Empty;

        [ForeignKey("Courses")]
        [Required(ErrorMessage = "Debes elegir una carrera")]
        public string CourseId { get; set; } = string.Empty;
        public  Course Course { get; set; } 
        [ForeignKey("User")]
        [Required(ErrorMessage = "Debes elegir un docente")]
        public string UserId { get; set; } = string.Empty;
        public  User User { get; set; } 
        [DefaultValue(true)]
        public bool? IsActive { get; set; } = true;

    }
}
