using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestionDeAulas.Models
{
    public class IsNumber : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return new ValidationResult("Debe ser un numero entero");
            int data = -1;
            int.TryParse(value as string, out data);
            if (data <0) return new ValidationResult("No es un numero entero");
            return ValidationResult.Success;
        }
    }
    public class ClassRoom
    {
        [DefaultValue("Sin Asignar")]
        [DisplayName("Nombre del Aula")]
        public string? Name { get; set; }
        [DefaultValue("Sin Descripcion")]
        [DisplayName("Observaciones")]
        public string? Description { get; set; }
        [Required]
        [IsNumber]
        [DisplayName("Numero de Aula")]
        [Key]
        public string RoomNumber {  get; set; } = string.Empty;
        [Range(1,300)]
        
        [Required]
        [DisplayName("Capacidad Maxima")]
        public int Seats {  get; set; }
        [DefaultValue(true)]
        public bool IsActive {  get; set; }
        [DefaultValue(false)]
        [DisplayName("Reserva Especial")]
        public bool IsSpecial {  get; set; }

    }
}
