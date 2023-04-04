using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EL
{
    [Table("Roles")]
    public class Roles
    {
        [Key]
        public int IdRol { get; set; }

        [MaxLength(50)]
        [Required]
        public string Rol { get; set; }

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
