using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestionDeAulas.Models
{
    public class Credentials
    {
        [Required]
        [EmailAddress]
        [DisplayName("Nombre de Usuario")]
        public string UserNama { get; set; } = string.Empty;
        [Required]
        [DisplayName("Contraseña")]
        [PasswordComplexity]
        public string Password { get; set; }= string.Empty;
        [DisplayName("Recuerdame")]
        public bool Persist { get; set; } = false;
    }
}
