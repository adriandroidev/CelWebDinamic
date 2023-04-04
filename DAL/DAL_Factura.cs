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
    public static class DAL_Factura
    {
        public static int InsertFactura(EL_Factura Entidad)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.ConexionString()))
            {
                bd.Open();
                SqlCommand cmd = new SqlCommand("InsertFactura", bd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cantidad", Entidad.Cantidad);
                cmd.Parameters.AddWithValue("@PrecioU", Entidad.PrecioU);
                cmd.Parameters.AddWithValue("@IVA", Entidad.IVA);
                cmd.Parameters.AddWithValue("@TotalConIva", Entidad.TotalConIVA);
                cmd.Parameters.AddWithValue("@Delivery", Entidad.Delivery);
                cmd.Parameters.AddWithValue("@IdUsuarioRegistro", Entidad.IdUsuarioRegistro);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }


        }
        public static int UpdateFactura(EL_Factura Entidad)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.ConexionString()))
            {
                bd.Open();
                SqlCommand cmd = new SqlCommand("UpdateFactura", bd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdFactura", Entidad.IdFactura);
                cmd.Parameters.AddWithValue("@Cantidad", Entidad.Cantidad);
                cmd.Parameters.AddWithValue("@PrecioU", Entidad.PrecioU);
                cmd.Parameters.AddWithValue("@IVA", Entidad.IVA);
                cmd.Parameters.AddWithValue("@TotalConIva", Entidad.TotalConIVA);
                cmd.Parameters.AddWithValue("@Delivery", Entidad.Delivery);
                cmd.Parameters.AddWithValue("@IdUsuarioActualizado", Entidad.IdUsuarioActualizado);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static int DeleteFactura(EL_Factura Entidad)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.ConexionString()))
            {
                bd.Open();
                SqlCommand cmd = new SqlCommand("DeleteFactura", bd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdFactura", Entidad.IdFactura);
                cmd.Parameters.AddWithValue("@IdUsuarioActualizado", Entidad.IdUsuarioActualizado);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static DataTable SelectFactura(int IdFactura = 0)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.ConexionString()))
            {
                bd.Open();
                SqlCommand cmd = new SqlCommand("SelectFactura", bd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdFactura", IdFactura);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
