using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestionDeAulas.Models.ViewModels.Account
{
    public class Credentials
    {
        [Required(ErrorMessage = "Debes ingresar un usuario")]
        [EmailAddress(ErrorMessage = "El usuario debe ser un mail valido")]
        [DisplayName("Nombre de Usuario")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Debes ingresar una contraseña")]
        [DisplayName("Contraseña")]
        public string Password { get; set; } = string.Empty;
        [DisplayName("Recuerdame")]
        [DefaultValue(false)]
        public bool Persist { get; set; } = false;
    }
}
