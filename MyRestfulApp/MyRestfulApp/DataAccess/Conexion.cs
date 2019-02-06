using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace MyRestfulApp.DataAccess
{
    public interface IConexion
    {
        DataTable RealizarConsulta(string sql);
        void EjecutarComando(string sql);
    }

    public class Conexion : IConexion
    {
        private static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["TestConnection"].ToString());
        }

        public DataTable RealizarConsulta(string sql)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = ObtenerConexion())
            {
                conn.Open();

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = comm;
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public void EjecutarComando(string sql)
        {

            using (SqlConnection conn = ObtenerConexion())
            {
                conn.Open();

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.ExecuteNonQuery();
                }
            }
        }
    }
}