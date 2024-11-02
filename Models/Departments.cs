using System.ComponentModel.DataAnnotations;

namespace GestionDeAulas.Models
{
    public class Departments
    {
        [Key]
        [Required]
        public string ZipCode { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;

    }
}
