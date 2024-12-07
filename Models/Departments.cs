using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeAulas.Models
{
    public class Departments
    {
        [Key]
        [Required(ErrorMessage = "Debes ingresar un codigo postal")]
        [Column("ZipCode")]
        public string Id { get; set; } = string.Empty;
        [Required(ErrorMessage = "Debes ingresar el nombre de la localidad")]
        public string Description { get; set; } = string.Empty;

    }
}
