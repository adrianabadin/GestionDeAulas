using GestionDeAulas.Models;
using GestionDeAulas.Models.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GestionDeAulas.Models.ViewModels.Classes
{
    public class ClassessCreateVM : GestionDeAulas.Models.Classes
    {
        public IEnumerable<NamedEntity> TeachersList { get; set; } = new List<NamedEntity>();
        public IEnumerable<NamedEntity> CoursesList { get; set; } = new List<NamedEntity>();

    }
}
