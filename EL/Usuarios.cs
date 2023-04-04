using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EL
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required]
        [MaxLength(200)]
        public string NombreCompleto { get; set; }
        [Required]
        [MaxLength(200)]
        public string Correo { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        public byte[] Password { get; set; }
        [Required]
        public bool Bloqueado { get; set; }
        [Required]
        public byte IntentosFallidos { get; set; }
        [Required]
        public int IdRol { get; set; }

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