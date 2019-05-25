using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace GymProject.Models.BaseDeDatos
{
    public static class Conexion
    {
        public static string DATABASE_NAME = "Taller6";

        // ABRIR CONEXION DE LA BASE DE DATOS

        public static SqlConnection AbrirConexion()
        {
            SqlConnection conn;
            try
            {
                conn = new SqlConnection
                {
                    ConnectionString = getConnectionString() 
                };
                conn.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
            return conn;
        }

        // CERRAR CONEXION DE LA BASE DE DATOSs

        public static void CerrarConexion(SqlConnection conn)
        {
            conn.Close();
        }
        // OBTENER EL CONNECTION STRING DE LA BASE DE DATOS
        public static String getConnectionString()
        {
            return "Server=.\\SQLEXPRESS;Database=" + DATABASE_NAME + ";Integrated Security= true";
        }
    }
}