using EL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DAL_Driver
    {
        public static int InsertDriver(EL_Driver Entidad)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.ConexionString()))
            {
                bd.Open();
                SqlCommand cmd = new SqlCommand("InsertDriver", bd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", Entidad.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", Entidad.Telefono);
                cmd.Parameters.AddWithValue("@Correo", Entidad.Correo);
                cmd.Parameters.AddWithValue("@IdUsuarioRegistro", Entidad.IdUsuarioRegistro);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public static int UpdateDriver(EL_Driver Entidad)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.ConexionString()))
            {
                bd.Open();
                SqlCommand cmd = new SqlCommand("UpdateDriver", bd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDriver", Entidad.IdDriver);
                cmd.Parameters.AddWithValue("@Nombre", Entidad.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", Entidad.Telefono);
                cmd.Parameters.AddWithValue("@Correo", Entidad.Correo);
                cmd.Parameters.AddWithValue("@IdUsuarioActualizado", Entidad.IdUsuarioActualizado);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public static int DeleteDriver(EL_Driver Entidad)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.ConexionString()))
            {
                bd.Open();
                SqlCommand cmd = new SqlCommand("DeleteDriver", bd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDriver", Entidad.IdDriver);
                cmd.Parameters.AddWithValue("@IdUsuarioActualizado", Entidad.IdUsuarioActualizado);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public static DataTable SelectDriver(int IdDriver = 0)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.ConexionString()))
            {
                bd.Open();
                SqlCommand cmd = new SqlCommand("SelectDriver", bd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDriver", IdDriver);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

    }
}
