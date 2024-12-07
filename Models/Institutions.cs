using GestionDeAulas.Models.IModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeAulas.Models
{
    public class Institutions :IActivable
    {
        [Key]
        public string Id { get; set; } =  Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Debes ingresar un nombre de institucion")]
        [DisplayName("Nombre de la Institucion")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Debes ingresar una descripcion para la institucion")]
        [DisplayName("Descripcion")]
        public string Description { get; set; } = string.Empty;
        [Phone]
        [DisplayName("Telefono")]
        public string? PhoneNumber { get; set; }= string.Empty;
        [EmailAddress]
        [DisplayName("Correo Electronico")]
        public string? Email { get; set; }=string.Empty;
        [Required(ErrorMessage = "Debes ingresar un Responsable de contacto")]
        public string ContactName {  get; set; }=string.Empty;
        [ForeignKey("Address")]
        //public string? AddressId { get; set; }
      //  public Address? Address { get; set; } = new Address();
        [DefaultValue(true)]
        public bool? IsActive { get; set; } = true;
    }
}
