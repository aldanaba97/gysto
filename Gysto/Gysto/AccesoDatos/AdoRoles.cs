﻿using Gysto.Models;
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

                string consulta = "insert into pacientes ( id_paciente, id_persona) values (IDENT_CURRENT('Personas'))";
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
    }
}