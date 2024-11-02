using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeAulas.Models
{
    public class Institutions
    {
        [Key]
        public System.Guid Id { get; set; }
        [Required]
        [DisplayName("Nombre de la Institucion")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [DisplayName("Descripcion")]
        public string Description { get; set; } = string.Empty;
        [Phone]
        [DisplayName("Telefono")]
        public string? PhoneNumber { get; set; }= string.Empty;
        [EmailAddress]
        [DisplayName("Correo Electronico")]
        public string? Email { get; set; }=string.Empty;
        [Required]
        public string ContactName {  get; set; }=string.Empty;
        [ForeignKey("Address")]
        [Required]
        public Guid? AddressId { get; set; }
        public Address? Address { get; set; } = new Address();
        
        [DefaultValue(true)]
        public bool IsActive { get; set; } = true;
    }
}
