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
    public static class DAL_Celulares
    {
        public static int InsertCelulares(EL_Celulares Entidad)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.ConexionString()))
            {
                bd.Open();
                SqlCommand cmd = new SqlCommand("InsertCelulares", bd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Marca", Entidad.Marca);
                cmd.Parameters.AddWithValue("@Modelo", Entidad.Modelo);
                cmd.Parameters.AddWithValue("@Color", Entidad.Color);

                cmd.Parameters.AddWithValue("@IdUsuarioRegistro", Entidad.IdUsuarioRegistro);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public static int UpdateCelulares(EL_Celulares Entidad)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.ConexionString()))
            {
                bd.Open();
                SqlCommand cmd = new SqlCommand("UpdateCelulares", bd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", Entidad.IdCelulares);
                cmd.Parameters.AddWithValue("@Marca", Entidad.Marca);
                cmd.Parameters.AddWithValue("@Modelo", Entidad.Modelo);
                cmd.Parameters.AddWithValue("@Color", Entidad.Color);
                cmd.Parameters.AddWithValue("@IdUsuarioActualizado", Entidad.IdUsuarioActualizado);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public static int DeleteCelulares(EL_Celulares Entidad)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.ConexionString()))
            {
                bd.Open();
                SqlCommand cmd = new SqlCommand("DeleteCelulares", bd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCelulares", Entidad.IdCelulares);
                cmd.Parameters.AddWithValue("@IdUsuarioActualizado", Entidad.IdUsuarioActualizado);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public static DataTable SelectCelulares(int IdCelulares = 0)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.ConexionString()))
            {
                bd.Open();
                SqlCommand cmd = new SqlCommand("SelectCelulares", bd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCelulares", IdCelulares);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

    }
}
