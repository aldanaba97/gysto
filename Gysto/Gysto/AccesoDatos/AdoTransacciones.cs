using Gysto.Models;
using Gysto.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Gysto.AccesoDatos
{
    public class AdoTransacciones
    {
        public static bool InsertarTransacciones(internacion i)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "insert into Internaciones (motivo, Fecha_ingreso, Fecha_egreso, Temperatura, tension, Frecuencia_cardiaca, Frecuencia_Respiratoria, id_enfermero, paciente) values ( @1, @2, null, @4, @5, @6, @7, @8, @9)";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@1", i.motivo);
                cmd.Parameters.AddWithValue("@2", i.fecha_ingreso);

                cmd.Parameters.AddWithValue("@4", i.temperatura);
                cmd.Parameters.AddWithValue("@5", i.tension);
                cmd.Parameters.AddWithValue("@6", i.frecuencia_c);
                cmd.Parameters.AddWithValue("@7", i.frecuencia_respiratoria);
                cmd.Parameters.AddWithValue("@8", i.enfermero);
                cmd.Parameters.AddWithValue("@9", i.paciente);


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
        public static bool InsertarConsulta(consulta i)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "insert into Internaciones (motivo, Fecha_ingreso, Fecha_egreso, Temperatura, tension, Frecuencia_cardiaca, Frecuencia_Respiratoria, id_enfermero, paciente) values ( @1, @2, null, @4, @5, @6, @7, @8, @9)";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@1", i.motivo);
                cmd.Parameters.AddWithValue("@2", i.fecha_ingreso);

                cmd.Parameters.AddWithValue("@4", i.temperatura);
                cmd.Parameters.AddWithValue("@5", i.tension);
                cmd.Parameters.AddWithValue("@6", i.frecuencia_c);
                cmd.Parameters.AddWithValue("@7", i.frecuencia_respiratoria);
                cmd.Parameters.AddWithValue("@8", i.enfermero);
                cmd.Parameters.AddWithValue("@9", i.paciente);


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

                string consulta = "select id_internacion from internaciones where id_internacion = @id";
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
        public static List<listadoInternaciones> ListadoInternacion()
        {
            List<listadoInternaciones> resultado = new List<listadoInternaciones>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select apellido +' , ' + nombre nombrecto, Fecha_ingreso, motivo, id_internacion from Pacientes p inner join Internaciones i on i.paciente = p.id_paciente inner join personas pe on pe.id_persona = p.id_persona where fecha_egreso is null";
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

                        listadoInternaciones i = new listadoInternaciones();
                        i.nombrecto = dr["nombrecto"].ToString();
                        i.motivo = dr["motivo"].ToString();
                        i.fecha = DateTime.Parse(dr["fecha_ingreso"].ToString());
                        i.id = int.Parse(dr["id_internacion"].ToString());
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
        public static bool ActualizarFecha(internacion i )
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = " update Internaciones set Fecha_egreso = @fecha where id_internacion = @id";
                cmd.Parameters.Clear();
                
                cmd.Parameters.AddWithValue("@fecha", i.fecha_egreso);
                cmd.Parameters.AddWithValue("@id", i.id_internacion);




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
        public static internacion ObtenerDatosInternacion(int idInternacion)
        {
            internacion resultado = new internacion();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select * from internaciones where id_internacion = @id";
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
                        resultado.fecha_ingreso = DateTime.Parse(dr["fecha_ingreso"].ToString());
                        resultado.fecha_egreso = DateTime.Parse(dr["fecha_egreso"].ToString());
                        resultado.temperatura = float.Parse(dr["temperatura"].ToString());
                        resultado.tension = float.Parse(dr["tension"].ToString());
                        resultado.frecuencia_c = float.Parse(dr["frecuencia_cardiaca"].ToString());
                        resultado.frecuencia_respiratoria = float.Parse(dr["frecuencia_respiratoria"].ToString());
                        resultado.enfermero = int.Parse(dr["id_enfermero"].ToString());
                        resultado.paciente = int.Parse(dr["paciente"].ToString());

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
        public static bool ActualizarInternacion(internacion i)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "update Internaciones set motivo= @1, fecha_ingreso = @2, Fecha_egreso = @3, temperatura = @4, tension = @5, frencuencia_cardiaca= @6, frecuencia _respiratoria = @7, id_enfermero = @8, paciente = @9 where id_internacion = @id";
                cmd.Parameters.Clear();


                cmd.Parameters.AddWithValue("@1", i.motivo);
                cmd.Parameters.AddWithValue("@2", i.fecha_ingreso);
                cmd.Parameters.AddWithValue("@3", i.fecha_egreso);
                cmd.Parameters.AddWithValue("@4", i.temperatura);
                cmd.Parameters.AddWithValue("@5", i.tension);
                cmd.Parameters.AddWithValue("@6", i.frecuencia_c);
                cmd.Parameters.AddWithValue("@7", i.frecuencia_respiratoria);
                cmd.Parameters.AddWithValue("@8", i.enfermero);
                cmd.Parameters.AddWithValue("@9", i.paciente);                
                cmd.Parameters.AddWithValue("@id",i.id_internacion);

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
        public static List<listadoInternaciones> ListadoTodasInternaciones()
        {
            List<listadoInternaciones> resultado = new List<listadoInternaciones>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select apellido +' , ' + nombre nombrecto, Fecha_ingreso, motivo, id_internacion from Pacientes p inner join Internaciones i on i.paciente = p.id_paciente inner join personas pe on pe.id_persona = p.id_persona where fecha_egreso is not null";
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

                        listadoInternaciones i = new listadoInternaciones();
                        i.nombrecto = dr["nombrecto"].ToString();
                        i.motivo = dr["motivo"].ToString();
                        i.fecha = DateTime.Parse(dr["fecha_ingreso"].ToString());
                        i.id = int.Parse(dr["id_internacion"].ToString());
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
        public static bool eliminarInternacion(internacion i)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "update Internaciones set estado= false where id_internacion = @id";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@id", i.id_internacion);

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