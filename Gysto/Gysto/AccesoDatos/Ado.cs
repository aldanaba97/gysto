using Gysto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Gysto.AccesoDatos
{
    public class Ado
    {
        //ABM DE ESPECIALIDAD
        public static bool InsertarEspecialidad(Especialidad e)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "INSERT INTO Especialidades VALUES(@nombre, @imagen, 1)";
                cmd.Parameters.Clear();
                //string ruta = @"~\imagenes\";
                cmd.Parameters.AddWithValue("@nombre", e.nombre);
                cmd.Parameters.AddWithValue("@imagen", e.imagen);



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
        public static Especialidad obtenerEspe(int idEspecialidad)
        {
            Especialidad resultado = new Especialidad();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT id_espe, nombre, imagen FROM Especialidades WHERE id_espe = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", idEspecialidad);


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;



                cn.Open();

                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                        resultado.id_especialidad = int.Parse(dr["id_espe"].ToString());
                        resultado.nombre = dr["nombre"].ToString();
                        resultado.imagen = dr["imagen"].ToString(); 

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
        public static bool ActualizarDatosEspecialidad(Especialidad e)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "UPDATE Especialidades SET nombre = @nombre, imagen = @imagen WHERE id_espe = @id_espe";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", e.nombre);
                cmd.Parameters.AddWithValue(@"imagen", e.imagen);
                cmd.Parameters.AddWithValue(@"id_espe", e.id_especialidad);



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
        public static bool EliminarEspe(Especialidad e)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();
                string consulta = "Update Especialidades set estado = 0 WHERE id_espe = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue(@"id", e.id_especialidad);


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
        public static List<Especialidad> ListadoEspecialidad()
        {
            List<Especialidad> resultado = new List<Especialidad>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM Especialidades";
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

                        Especialidad e = new Especialidad();
                        e.estado = Boolean.Parse(dr["estado"].ToString());

                        e.id_especialidad = int.Parse(dr["id_espe"].ToString());
                        e.nombre = dr["nombre"].ToString();
                        e.imagen = dr["imagen"].ToString();

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


        //ENFERMEDAD
        public static bool InsertarEnfermedad(Enfermedad e)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "INSERT INTO Enfermedades VALUES(@nombre, 1)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", e.nombreEnfermedad);




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
        public static Enfermedad obtenerEnfermedad(int idEnfermedad)
        {
            Enfermedad resultado = new Enfermedad();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT id_enfermedad, nombre FROM Enfermedades WHERE id_enfermedad = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", idEnfermedad);


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;



                cn.Open();

                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                        resultado.id_enfe = int.Parse(dr["id_enfermedad"].ToString());
                        resultado.nombreEnfermedad = dr["nombre"].ToString();


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
        public static bool ActualizarDatosEnfermedades(Enfermedad e)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "UPDATE Enfermedades SET nombre = @nombre WHERE id_enfermedad = @id_enfermedad";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue(@"nombre", e.nombreEnfermedad);
                cmd.Parameters.AddWithValue("@id_enfermedad", e.id_enfe);
                



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
        public static bool EliminarEnfermedad(Enfermedad e)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();
                string consulta = "Update Enfermedades set estado = 0 WHERE id_enfermedad = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue(@"id", e.id_enfe);


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
        public static List<Enfermedad> Combobox()
        {
            List<Enfermedad> resultado = new List<Enfermedad>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM Enfermedades";
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

                        Enfermedad e = new Enfermedad();
                        if (e.estado == false)
                        {
                            e.estado = Boolean.Parse(dr["estado"].ToString());
                            e.id_enfe = int.Parse(dr["id_enfermedad"].ToString());
                            e.nombreEnfermedad = dr["nombre"].ToString();
                            resultado.Add(e);
                        }



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

        public static List<Enfermedad> listadoEnfermedad()
        {
            List<Enfermedad> resultado = new List<Enfermedad>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM Enfermedades";
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

                        Enfermedad e = new Enfermedad();
                 
                            e.estado = Boolean.Parse(dr["estado"].ToString());
                            e.id_enfe = int.Parse(dr["id_enfermedad"].ToString());
                            e.nombreEnfermedad = dr["nombre"].ToString();
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

        //Tratamiento
        public static bool InsertarTratamiento(Tratamiento t)
    {
        bool resultado = false;
        string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

        SqlConnection cn = new SqlConnection(cadenaConexion);

        try
        {

            SqlCommand cmd = new SqlCommand();

            string consulta = "INSERT INTO Tratamientos VALUES(@nombre, 1)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@nombre", t.nombre);




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
    public static Tratamiento obtenerTratamiento(int idTratamiento)
    {
        Tratamiento resultado = new Tratamiento();
        string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
        SqlConnection cn = new SqlConnection(cadenaConexion);

        try
        {

            SqlCommand cmd = new SqlCommand();

            string consulta = "SELECT id_tratamiento, nombre FROM Tratamientos WHERE id_tratamiento = @id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", idTratamiento);


            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = consulta;



            cn.Open();

            cmd.Connection = cn;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {

                    resultado.id_tratamiento = int.Parse(dr["id_tratamiento"].ToString());
                    resultado.nombre = dr["nombre"].ToString();


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
    public static bool ActualizarDatosTratamiento(Tratamiento t)
    {
        bool resultado = false;
        string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

        SqlConnection cn = new SqlConnection(cadenaConexion);

        try
        {

            SqlCommand cmd = new SqlCommand();

            string consulta = "UPDATE Tratamientos SET nombre = @nombre WHERE id_tratamiento = @id_tratamiento";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue(@"nombre", t.nombre);
            cmd.Parameters.AddWithValue("@id_tratamiento", t.id_tratamiento);

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
    public static bool EliminarTratamiento(Tratamiento t)
    {
        bool resultado = false;
        string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
        SqlConnection cn = new SqlConnection(cadenaConexion);

        try
        {

            SqlCommand cmd = new SqlCommand();
            string consulta = "Update Tratamientos set estado = 0 WHERE id_tratamiento = @id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue(@"id", t.id_tratamiento);


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
    public static List<Tratamiento> ComboboxTratamiento()
    {
        List<Tratamiento> resultado = new List<Tratamiento>();
        string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
        SqlConnection cn = new SqlConnection(cadenaConexion);

        try
        {

            SqlCommand cmd = new SqlCommand();

            string consulta = "SELECT * FROM Tratamientos";
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

                  Tratamiento t = new Tratamiento();
                 t.id_tratamiento = int.Parse(dr["id_tratamiento"].ToString()); 
                        t.nombre = dr["nombre"].ToString();
                        t.estado = Boolean.Parse(dr["estado"].ToString());
                        
                       
                        resultado.Add(t);

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