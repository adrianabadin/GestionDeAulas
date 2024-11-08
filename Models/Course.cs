﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GestionDeAulas.Models
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; }
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
        public Guid InstitutionId { get; set; }
        public Institutions Institution { get; set; } = new Institutions();
        [DefaultValue(true)]
        public bool? IsActive { get; set; } = true;
        
    }
}
