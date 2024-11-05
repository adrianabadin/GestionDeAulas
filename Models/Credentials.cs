using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestionDeAulas.Models
{
    public class Credentials
    {
        [Required(ErrorMessage = "Debes ingresar un usuario")]
        [EmailAddress(ErrorMessage ="El usuario debe ser un mail valido")]
        [DisplayName("Nombre de Usuario")]
        public string UserNama { get; set; } = string.Empty;
        [Required(ErrorMessage = "Debes ingresar una contraseña")]
        [DisplayName("Contraseña")]
        [PasswordComplexity]
        public string Password { get; set; }= string.Empty;
        [DisplayName("Recuerdame")]
        [DefaultValue(false)]
        public bool Persist { get; set; } = false;
    }
}
