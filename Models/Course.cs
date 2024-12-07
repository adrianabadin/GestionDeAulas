using GestionDeAulas.Models.IModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GestionDeAulas.Models
{
    public class Course :IActivable
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Debes ingresar un nombre para la carrera")]
        [DisplayName("Carrera")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Descripcion")]
        public string? Description { get; set; }= string.Empty;
        [DisplayName("Año de Inicio")]
        public string StartingYear { get; set; } = string.Empty;
        [ForeignKey("Institutions")]
        [NotNull]
        [Required(ErrorMessage = "Debes ingresar una institucion para la carrera")]
        [DisplayName("Institucion")]
        public string InstitutionId { get; set; } = string.Empty;
        public virtual Institutions? Institution { get; set; } 
        [DefaultValue(true)]
        public bool? IsActive { get; set; } = true;
        
    }
}
