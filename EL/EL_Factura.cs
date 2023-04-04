using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class EL_Factura
    {
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public int IdCelulares { get; set; }
        public int IdDriver { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioU { get; set; }
        public decimal IVA { get; set; }
        public decimal TotalConIVA { get; set; }
        public string Delivery { get; set; }
        public bool Activo { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int? IdUsuarioActualizado { get; set; }
        public DateTime? FechaActualizado { get; set; }
    }
}
