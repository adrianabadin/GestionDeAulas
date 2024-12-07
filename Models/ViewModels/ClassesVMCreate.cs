using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GestionDeAulas.Models.ViewModels
{
    public class ClassesVMCreate
    {

            [Required(ErrorMessage = "La materia debe tener un nombre")]
            public string Name { get; set; } = string.Empty;
            [Required(ErrorMessage = "La materia debe tener una descripcion")]
            public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Debes Seleccionar una Carrera")]
        [DisplayName("Carrera o Curso")]
        public string Course { get; set; } = string.Empty;
            public List<Course> Courses { get; set; } = new List<Course>();
            [Required(ErrorMessage = "Debes Seleccionar un Docente")]
            [DisplayName("Docente")]
            public string Teacher { get; set; }=string.Empty;
            public List<User> Teachers { get; set; } = new List<User>();

        }
    }


