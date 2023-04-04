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
    public static class BL_Driver
    {
        public static int InsertDriver(EL_Driver Entidad)
        {
            return DAL_Driver.InsertDriver(Entidad);
        }
        public static int UpdateDriver(EL_Driver Entidad)
        {
            return DAL_Driver.UpdateDriver(Entidad);
        }
        public static int DeleteDriver(EL_Driver Entidad)
        {
            return DAL_Driver.DeleteDriver(Entidad);
        }
        public static DataTable SelectDriver(int IdDriver = 0)
        {
            return DAL_Driver.SelectDriver(IdDriver);
        }
    }
}
