using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EL
{
    [Table("Permisos")]
    public class Permisos
    {
        [Key]
        public int IdPermiso { get; set; }
        [Required]
        [MaxLength(50)]
        public string Permiso { get; set; }

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
