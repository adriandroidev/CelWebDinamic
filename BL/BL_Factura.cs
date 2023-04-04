using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class BL_Factura
    {
        public static int InsertFactura(EL_Factura Entidad)
        {
            return DAL_Factura.InsertFactura(Entidad);
        }
        public static int UpdateFactura(EL_Factura Entidad)
        {
            return DAL_Factura.UpdateFactura(Entidad);
        }
        public static int DeleteFactura(EL_Factura Entidad)
        {
            return DAL_Factura.DeleteFactura(Entidad);
        }
        public static DataTable SelectFactura(int IdFactura = 0)
        {
            return DAL_Factura.SelectFactura(IdFactura);
        }
    }
}
