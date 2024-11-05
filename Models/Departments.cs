using System.ComponentModel.DataAnnotations;

namespace GestionDeAulas.Models
{
    public class Departments
    {
        [Key]
        [Required(ErrorMessage = "Debes ingresar un codigo postal")]
        public string ZipCode { get; set; } = string.Empty;
        [Required(ErrorMessage = "Debes ingresar el nombre de la localidad")]
        public string Description { get; set; } = string.Empty;

    }
}
