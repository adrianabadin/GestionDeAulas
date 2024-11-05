using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeAulas.Models
{
    public class Address
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "La Calle es Obligatoria")]
        public string StreetName { get; set; } = string.Empty;
        
        public Departments Department { get; set; } = new Departments();
        [Required(ErrorMessage = "La Localidad des Obligatoria")]
        [ForeignKey("Departments")]
        public Guid ZipCode { get; set; }
        [Required(ErrorMessage = "La altura es Obligatoria")]
        public int Number { get; set; }
    }
}
