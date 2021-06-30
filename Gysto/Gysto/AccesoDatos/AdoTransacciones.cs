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
        public static internacion obtenerInternacion(int idInternacion)
        {
            internacion resultado = new internacion();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select * from internacion where id_internacion = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", idInternacion);


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                        resultado.id_internacion = int.Parse(dr["id_internacion"].ToString());
                        resultado.motivo = dr["motivo"].ToString();
                        resultado.fecha_ingreso = DateTime.Parse( dr["fecha_ingreso"].ToString());
                        resultado.fecha_egreso = DateTime.Parse(dr["fecha_egreso"].ToString());
                        resultado.temperatura =float.Parse( dr["telefono"].ToString());
                        resultado.tension= float.Parse(dr["tension"].ToString());
                        resultado.frecuencia_c = float.Parse(dr["frecuencia_C"].ToString());
                        resultado.frecuencia_respiratoria = float.Parse(dr["frecuencia_r"].ToString());
                        resultado.enfermero = int.Parse(dr["enfermero"].ToString());
                        
                    }
                }
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
        public static List<internacion> ListadoInternacion()
        {
            List<internacion> resultado = new List<internacion>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM internacion where fecha_egreso is null";
                cmd.Parameters.Clear();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();

                cmd.Connection = cn;


                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                        internacion i = new internacion();
                        i.id_internacion = int.Parse(dr["id_internacion"].ToString());
                        i.motivo = dr["motivo"].ToString();
                        i.fecha_ingreso = DateTime.Parse(dr["fecha_ingreso"].ToString());
                        i.fecha_egreso = DateTime.Parse(dr["fecha_egreso"].ToString());
                        i.temperatura = float.Parse(dr["telefono"].ToString());
                        i.tension = float.Parse(dr["tension"].ToString());
                        i.frecuencia_c = float.Parse(dr["frecuencia_C"].ToString());
                        i.frecuencia_respiratoria = float.Parse(dr["frecuencia_r"].ToString());
                        i.enfermero = int.Parse(dr["enfermero"].ToString());
                        resultado.Add(i);
                    }
                }

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