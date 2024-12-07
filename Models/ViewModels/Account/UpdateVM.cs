using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace GestionDeAulas.Models.ViewModels.Account
{
    public class UserUpdateVM
    {
        
        public string Id { get; set; } = string.Empty;
        [DisplayName("Nombre de Usuario")]
        [EmailAddress(ErrorMessage = "El nombre de usuario debe ser un email valido")]
        [Required(ErrorMessage = "El campo nombre de usuario es obligatorio")]
        public string? UserName { get; set; } = string.Empty;
        [DisplayName("Password")]
        [PasswordComplexity]
        
        public string? Password { get; set; } = string.Empty;
        [DisplayName("Confirm Password")]
        
        [Compare("Password", ErrorMessage = "Las contraseñas deben coincidir")]
        public string? Password2 { get; set; } = string.Empty;
        [DisplayName("Roles del Usuario")]
        public ICollection<string> Role { get; set; } = new List<string>();
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string FirstName { get; set; } = string.Empty;
        [DisplayName("Apellido")]
        [Required(ErrorMessage = "El campo apellido es obligatorio")]
        public string LastName { get; set; } = string.Empty;
        [DisplayName("Legajo")]
        [Required(ErrorMessage = "El campo legajo es obligatorio")]
        public string EmployeeCode { get; set; } = string.Empty;
        [DisplayName("DNI")]
        [Required(ErrorMessage = "El campo DNI es obligatorio")]
        public string Dni { get; set; } = string.Empty;
        [DisplayName("Telefono")]
        [Required(ErrorMessage = "El campo telefono es obligatorio")]
        [Phone(ErrorMessage = "Debe ser un telefono valido")]
        public string? PhoneNumber { get; set; }
        [DisplayName("Estado")]
        public bool? IsActive { get; set; } = true;
    }
    
}
