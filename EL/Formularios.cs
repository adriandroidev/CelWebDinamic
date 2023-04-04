using System;
using System.ComponentModel.DataAnnotations;

namespace EL
{
    public class Formularios
    {
        [Key]
        public int IdFormulario { get; set; }

        [Required]
        [MaxLength(50)]
        public string Formulario { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        public int IdUsuarioRegistro { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }

        public int? IdUsuarioActualizado { get; set; }
        public DateTime? FechaActualizado { get; set; }

    }
}
