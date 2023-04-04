using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Conexion
    {
        private static string NombreApplicacion = "CelWeb";
        private static string Servidor = @"DESKTOP-3BJ7OIU";
        private static string Usuario = "sa";
        private static string Password = "1975";
        private static string BaseDatos = "CelWeb";

        public static string ConexionString(bool SqlAutentication = true)
        {
            SqlConnectionStringBuilder Constructor = new SqlConnectionStringBuilder();
            Constructor.ApplicationName = NombreApplicacion;
            Constructor.DataSource = Servidor;
            Constructor.InitialCatalog = BaseDatos;
            Constructor.IntegratedSecurity = SqlAutentication;
            if (SqlAutentication)
            {
                Constructor.UserID = Usuario;
                Constructor.Password = Password;
            }
            return Constructor.ConnectionString;
        }




    }
}
