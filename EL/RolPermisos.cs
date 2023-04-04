using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EL
{
    [Table("RolPermisos")]
    public class RolPermisos
    {
        [Key]
        public int IdRolPermiso { get; set; }
        [Required]
        public int IdRol { get; set; }
        [Required]
        public int IdPermiso { get; set; }

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
