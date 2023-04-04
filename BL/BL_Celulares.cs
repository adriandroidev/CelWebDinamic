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
    public static class BL_Celulares
    {
        public static int InsertCelulares(EL_Celulares Entidad)
        {
            return DAL_Celulares.InsertCelulares(Entidad);
        }
        public static int UpdateCelulares(EL_Celulares Entidad)
        {
            return DAL_Celulares.UpdateCelulares(Entidad);
        }
        public static int DeleteCelulares(EL_Celulares Entidad)
        {
            return DAL_Celulares.DeleteCelulares(Entidad);
        }
        public static DataTable SelectCelulares(int IdCelulares = 0)
        {
            return DAL_Celulares.SelectCelulares(IdCelulares);
        }
    }
}
