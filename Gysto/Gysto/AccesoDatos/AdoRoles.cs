using Gysto.Models;
using Gysto.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Gysto.AccesoDatos
{
    public class AdoRoles
    {
        public static bool InsertarMedico(Medico m )
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "insert into Medicos (id_espe, matricula, id_persona) values (@id, @matri, IDENT_CURRENT('Personas'))";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@id", m.id_espe);
                cmd.Parameters.AddWithValue("@matri", m.matricula);
 



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
        public static bool InsertarAdministrativo (Administrador a)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "insert into Administrativos (fecha_alta , id_persona) values (@fec, IDENT_CURRENT('Personas'))";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@fec", a.fecha);


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
        public static bool InsertarEnfermero(Enfermero e)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "insert into Enfermeros (id_persona, matricula) values ( IDENT_CURRENT('Personas'), @matri)";
                cmd.Parameters.Clear();

                
                cmd.Parameters.AddWithValue("@matri", e.matricula);




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
        public static bool InsertarDirector(director_medico m)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "insert into directores_medicos ( id_persona, matricula, maestria) values (IDENT_CURRENT('Personas'), @matri, @mae )";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@matri", m.matricula);
                cmd.Parameters.AddWithValue("@mae", m.maestria);




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
        public static bool Insertarpaciente(paciente p)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "insert into pacientes ( id_persona) values (IDENT_CURRENT('Personas'))";
                cmd.Parameters.Clear();

    



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
        public static List<comboEnfermero> ListadoEnfermero()
        {
            List<comboEnfermero> resultado = new List<comboEnfermero>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select nombre + ' ' + apellido nombreCompleto, id_enfermero " +
                    "from personas join Enfermeros on personas.id_persona = Enfermeros.id_persona";
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

                        comboEnfermero e = new comboEnfermero();                       
                        e.id = int.Parse(dr["id_enfermero"].ToString());             
                        e.nombre = dr["nombreCompleto"].ToString();

                        resultado.Add(e);
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
        public static List<comboPaciente> ListadoPaciente()
        {
            List<comboPaciente> resultado = new List<comboPaciente>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select id_paciente,  apellido + ' , ' +  nombre nombrecto from personas p join Pacientes pa on p.id_persona = pa.id_persona";
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

                        comboPaciente e = new comboPaciente();
                        e.id = int.Parse(dr["id_paciente"].ToString());
                        e.nombre = dr["nombrecto"].ToString();

                        resultado.Add(e);
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
        public static List<comboMedico> ListadoMedico()
        {
            List<comboMedico> resultado = new List<comboMedico>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select apellido + ' , ' +  p.nombre nombrecto, id_medico from personas p join Medicos m on p.id_persona = m.id_persona";
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

                        comboMedico e = new comboMedico();
                        e.nombreCompleto = dr["nombrecto"].ToString();
                        e.id_med = int.Parse(dr["id_medico"].ToString());

                        resultado.Add(e);
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
        public static List<comboAdministrativo> ListadoAdministrativo()
        {
            List<comboAdministrativo> resultado = new List<comboAdministrativo>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select apellido + ' , ' +  p.nombre nombrecto, id_administrativos from personas p join Administrativos m on p.id_persona = m.id_persona";
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

                        comboAdministrativo e = new comboAdministrativo();
                        e.nombre = dr["nombrecto"].ToString();
                        e.id = int.Parse(dr["id_administrativos"].ToString());

                        resultado.Add(e);
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