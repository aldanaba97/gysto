using Gysto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Gysto.AccesoDatos
{
    public class AdoTransacciones
    {
        public static bool InsertarTransacciones(internacion i )
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "insert into Internaciones (motivo, Fecha_ingreso, Fecha_egreso, Temperatura, tension, Frecuencia_cardiaca, Frecuencia_Respiratoria, id_enfermero) values ( @1, @2, @3, @4, @5, @6, @7, @8)";
                cmd.Parameters.Clear();
            
                cmd.Parameters.AddWithValue("@1", i.motivo);
                cmd.Parameters.AddWithValue("@2", i.fecha_ingreso);
                cmd.Parameters.AddWithValue("@3", i.fecha_egreso);
                cmd.Parameters.AddWithValue("@4", i.temperatura);
                cmd.Parameters.AddWithValue("@5", i.tension);
                cmd.Parameters.AddWithValue("@6", i.frecuencia_c);
                cmd.Parameters.AddWithValue("@7", i.frecuencia_respiratoria);
                cmd.Parameters.AddWithValue("@8", i.enfermero);


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();

                resultado = true;

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                cn.Close();
            }

            return resultado;
        }

    }
}