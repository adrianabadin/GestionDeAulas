using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeAulas.Models
{
    public class Address
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string StreetName { get; set; } = string.Empty;
        [Required]
        public Departments Department { get; set; } = new Departments();
        [Required]
        [ForeignKey("Departments")]
        public Guid ZipCode { get; set; }
        [Required]
        public int Number { get; set; }
    }
}
