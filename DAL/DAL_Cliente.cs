using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;

namespace DAL
{
    public static class DAL_Cliente
    {
        public static int InsertCliente(EL_Cliente Entidad)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.ConexionString()))
            {
                bd.Open();
                SqlCommand cmd = new SqlCommand("InsertCliente", bd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", Entidad.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", Entidad.Telefono);
                cmd.Parameters.AddWithValue("@Correo", Entidad.Correo);
                cmd.Parameters.AddWithValue("@Direccion", Entidad.Direccion);
                cmd.Parameters.AddWithValue("@IdUsuarioRegistro", Entidad.IdUsuarioRegistro);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }


        }
        public static int UpdateCliente(EL_Cliente Entidad)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.ConexionString()))
            {
                bd.Open();
                SqlCommand cmd = new SqlCommand("UpdateCliente", bd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", Entidad.IdCliente);
                cmd.Parameters.AddWithValue("@Nombre", Entidad.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", Entidad.Telefono);
                cmd.Parameters.AddWithValue("@Correo", Entidad.Correo);
                cmd.Parameters.AddWithValue("@Direccion", Entidad.Direccion);
                cmd.Parameters.AddWithValue("@IdUsuarioActualizado", Entidad.IdUsuarioActualizado);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static int DeleteCliente(EL_Cliente Entidad)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.ConexionString()))
            {
                bd.Open();
                SqlCommand cmd = new SqlCommand("DeleteCliente", bd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", Entidad.IdCliente);
                cmd.Parameters.AddWithValue("@IdUsuarioActualizado", Entidad.IdUsuarioActualizado);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static DataTable SelectCliente(int IdCliente = 0)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.ConexionString()))
            {
                bd.Open();
                SqlCommand cmd = new SqlCommand("SelectCliente", bd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
