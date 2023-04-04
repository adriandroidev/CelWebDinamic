using System;


namespace EL
{
    public class EL_Cliente
    {

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int? IdUsuarioActualizado { get; set; }
        public DateTime? FechaActualizado { get; set; }


    }
}
