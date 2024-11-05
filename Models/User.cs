using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace GestionDeAulas.Models
{
    public class PasswordComplexityAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var password = value as string;
            if (!string.IsNullOrEmpty(password))
            {
                var hasUpperCase = Regex.IsMatch(password, @"[A-Z]");
                var hasLowerCase = Regex.IsMatch(password, @"[a-z]");
                var hasDigit = Regex.IsMatch(password, @"[0-9]");

                if (hasUpperCase && hasLowerCase && hasDigit)
                    return ValidationResult.Success ;
            }
            return new ValidationResult("La contraseña debe contener al menos una mayúscula, una minúscula y un número.");
        }
    }
        public class User : IdentityUser
        {
            [DisplayName("Nombre de Usuario")]
            [EmailAddress(ErrorMessage ="El nombre de usuario debe ser un email valido")]
            [Required(ErrorMessage ="El campo nombre de usuario es obligatorio")]
        
            override public string? Email { get; set; } = string.Empty;
        [NotMapped]
        [DisplayName("Password")]
        [Required(ErrorMessage = "El campo clave es obligatorio")]
        [PasswordComplexity]
         public string Password { get; set; } = string.Empty;
        [NotMapped]
        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "El campo clave es obligatorio")]
        [Compare("Password", ErrorMessage = "Las contraseñas deben coincidir")]
        
        public string Password2 { get; set; } = string.Empty;
        [DisplayName("Roles del Usuario")]
        [NotMapped]
        public string? Role { get; set; } = string.Empty;

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
            override public string? PhoneNumber { get; set; }
        [DefaultValue(true)]
        [DisplayName("Estado")]
        public bool IsActive { get; set; } = true; 
        }
    }

