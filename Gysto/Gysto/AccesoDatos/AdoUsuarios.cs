using Gysto.Models;
using Gysto.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Gysto.AccesoDatos
{
    public class AdoUsuarios
    {
        //public static bool InsertarUsuario(Usuario u)
        //{
        //    bool resultado = false;
        //    string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

        //    SqlConnection cn = new SqlConnection(cadenaConexion);

        //    try
        //    {

        //        SqlCommand cmd = new SqlCommand();

        //        string consulta = "INSERT INTO Usuarios VALUES(@contraseña, @nombre, @id_rol, @email, @imagen )";
        //        cmd.Parameters.Clear();

        //        cmd.Parameters.AddWithValue("@contraseña", u.contraseña);
        //        cmd.Parameters.AddWithValue("@nombre", u.nombreUsuario);
        //        cmd.Parameters.AddWithValue("@id_rol", u.rol);
        //        cmd.Parameters.AddWithValue("@email", u.email);
        //        cmd.Parameters.AddWithValue("@imagen", u.imagen);




        //        cmd.CommandType = System.Data.CommandType.Text;
        //        cmd.CommandText = consulta;
        //        cn.Open();
        //        cmd.Connection = cn;
        //        cmd.ExecuteNonQuery();

        //        resultado = true;

        //    }
        //    catch (Exception)
        //    {
        //        throw;

        //    }
        //    finally
        //    {
        //        cn.Close();
        //    }

        //    return resultado;
        //}
        public static List<Rol> ComboboxRol()
        {
            List<Rol> resultado = new List<Rol>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM Roles";
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
                        Rol l = new Rol();
                        l.id = int.Parse(dr["id_rol"].ToString());
                        l.nombre = dr["nombre"].ToString();

                        resultado.Add(l);




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

        public static bool InsertarPersonaUsuario(Persona p)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "exec InsertUsuario1 @contraseña, @usuario, @rol, @email, @imagen, @dni, @direccion, @localidad, @telefono, @nombre, @apellido, @fecha_nac, @numero_dni";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@contraseña", p.contraseña);
                cmd.Parameters.AddWithValue("@usuario", p.nombreUsuario);
                cmd.Parameters.AddWithValue("@rol", p.rol);
                cmd.Parameters.AddWithValue("@email", p.email);
                cmd.Parameters.AddWithValue("@imagen", p.image);
                cmd.Parameters.AddWithValue("@dni", p.id_dni);
                cmd.Parameters.AddWithValue("@direccion", p.direccion);
                cmd.Parameters.AddWithValue("@localidad", p.localidad);
                cmd.Parameters.AddWithValue("@telefono", p.telefono);
                cmd.Parameters.AddWithValue("@nombre", p.nombre);
                cmd.Parameters.AddWithValue("@apellido", p.apellido);
                cmd.Parameters.AddWithValue("@fecha_nac", p.fecha_nac);
                cmd.Parameters.AddWithValue("@numero_dni", p.dni);




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
        public static List<tipoDNI> ComboboxTipoDNI()
        {
            List<tipoDNI> resultado = new List<tipoDNI>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM TipoDNIs";
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
                        tipoDNI t = new tipoDNI();
                        t.id = int.Parse(dr["id_tipoDNI"].ToString());
                        t.nombreDNI = dr["nombre"].ToString();

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
        public static List<localidad> comboLocalidad()
        {
            List<localidad> resultado = new List<localidad>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT id_ciudad, nombre FROM Ciudades";
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
                        localidad l = new localidad();
                        l.id = int.Parse(dr["id_ciudad"].ToString());
                        l.nombre = dr["nombre"].ToString();

                        resultado.Add(l);

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
        public static bool ActualizarDatosPersona(Persona p)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "exec actualizarUsu @contraseña, @usuario, @email, @dni, @direccion, @localidad, @telefono , @nombre , @apellido , @fecha_nac , @numero_dni , @id_usu , @id_perso ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@contraseña", p.contraseña);
                cmd.Parameters.AddWithValue("@usuario", p.nombreUsuario);

                cmd.Parameters.AddWithValue("@email", p.email);

                cmd.Parameters.AddWithValue("@dni", p.id_dni);
                cmd.Parameters.AddWithValue("@direccion", p.direccion);
                cmd.Parameters.AddWithValue("@localidad", p.localidad);
                cmd.Parameters.AddWithValue("@telefono", p.telefono);
                cmd.Parameters.AddWithValue("@nombre", p.nombre);
                cmd.Parameters.AddWithValue("@apellido", p.apellido);
                cmd.Parameters.AddWithValue("@fecha_nac", p.fecha_nac);
                cmd.Parameters.AddWithValue("@numero_dni", p.dni);
                cmd.Parameters.AddWithValue("@id_usu", p.id);
                cmd.Parameters.AddWithValue("@id_perso", p.id_persona);




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
        public static Persona obtenerPersona(int id)
        {
            Persona resultado = new Persona();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select personas.id_persona, id_tipoDNI, direccion, localidad_id, telefono, personas.nombre name, apellido, fecha_nac, numero_dni, Usuarios.id_usuario, usuarios.contraseña, usuarios.nombre, id_rol, email  from personas join Usuarios on personas.id_usuario = Usuarios.id_usuario where Usuarios.id_usuario = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                        resultado.id_persona = int.Parse(dr["id_persona"].ToString());
                        resultado.id_dni = int.Parse(dr["id_tipoDNI"].ToString());
                        resultado.direccion = dr["direccion"].ToString();
                        resultado.localidad = int.Parse(dr["localidad_id"].ToString());
                        resultado.telefono = dr["telefono"].ToString();
                        resultado.nombre = dr["nombre"].ToString();
                        resultado.apellido = dr["apellido"].ToString();
                        resultado.fecha_nac = DateTime.Parse(dr["fecha_nac"].ToString());
                        resultado.dni = int.Parse(dr["numero_dni"].ToString());
                        resultado.id = int.Parse(dr["id_usuario"].ToString());
                        resultado.contraseña = dr["contraseña"].ToString();
                        resultado.nombreUsuario = dr["nombre"].ToString();
                        resultado.rol = int.Parse(dr["id_rol"].ToString());
                        resultado.email = dr["email"].ToString();

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
        public static List<listado> Listadopersona()
        {
            List<listado> resultado = new List<listado>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select id_persona, personas.nombre + ' ' +  personas.apellido nombreCompleto, email, Usuarios.nombre name from personas join Usuarios on personas.id_usuario = Usuarios.id_usuario";
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

                        listado e = new listado();
                        e.id = int.Parse(dr["id_persona"].ToString());
                        e.nombreCompleto = dr["nombreCompleto"].ToString();
                        e.email = dr["email"].ToString();
                        e.usuario = dr["name"].ToString();

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
        public static bool EliminarUsuario(Persona p)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();
                string consulta = "DELETE personas FROM personas p INNER JOIN Usuarios T ON p.id_usuario = T.id_usuario WHERE id_persona = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue(@"id", p.id_persona);


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

        //public static bool AccederLogin(string usuario, string contra, int rol)
        //{
        //    bool resultado = false;
        //    string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
        //    SqlConnection cn = new SqlConnection(cadenaConexion);

        //    try
        //    {

        //        SqlCommand cmd = new SqlCommand();


        //        string consulta = "select count(*) c from usuarios where nombre = '@1' and contraseña = '@2' and id_rol = @3 ";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@1", usuario);
        //        cmd.Parameters.AddWithValue("@2", contra);
        //        cmd.Parameters.AddWithValue("@3", rol);
        //        cmd.CommandType = System.Data.CommandType.Text;
        //        cmd.CommandText = consulta;

        //        cn.Open();
        //        cmd.Connection = cn;

        //        SqlDataReader dr = cmd.ExecuteReader();

        //        if (dr != null)
        //        {
        //            while (dr.Read())
        //            {
        //                int count = int.Parse(dr["c"].ToString());

        //                if (count == 0)
        //                    resultado = false;
        //                else
        //                    resultado = true;
        //            }
        //        }


        //    }
        //    catch (Exception)
        //    {
        //        throw;

        //    }
        //    finally
        //    {
        //        cn.Close();
        //    }
        //    return resultado;
        //}
        public static bool AccederLogin(string usuario, string contra, int rol)
        {
            bool resultado = false;

            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select count(*) c, nombre, id_usuario, id_rol, email, contraseña from usuarios where nombre = @1 and contraseña = @2 and id_rol = @3  group by id_usuario, contraseña, nombre, id_rol, email";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@1", usuario);
                cmd.Parameters.AddWithValue("@2", contra);
                cmd.Parameters.AddWithValue("@3", rol);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    if (dr.Read())
                    {
                        Usuario e = new Usuario(); 
                        int count = int.Parse(dr["c"].ToString());
                        e.id = int.Parse(dr["id_usuario"].ToString());
                        e.nombreUsuario = dr["nombre"].ToString();
                        e.contraseña = dr["contraseña"].ToString();
                        e.email = dr["email"].ToString();
                        e.rol = int.Parse(dr["id_rol"].ToString());

                        if (count == 0)
                            resultado = false;
                        else
                            resultado = true;

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
        public static List<Usuario> ListadoUsuarioConPermiso(int permiso)
        {
            List<Usuario> resultado = new List<Usuario>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select Usuarios.nombre, id_usuario, contraseña, email, Roles.id_rol from Usuarios join Roles on Usuarios.id_rol = Roles.id_rol join permisoxroles on permisoxroles.id_rol = Roles.id_rol join permiso on permiso.id = permisoxroles.id_permiso where permisoxroles.id_permiso = @a";




                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue( "@a", permiso);


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();

                cmd.Connection = cn;


                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                        Usuario e = new Usuario();
                        e.id = int.Parse(dr["id_usuario"].ToString()); 
                        e.nombreUsuario = dr["nombre"].ToString();
                        e.contraseña = dr["contraseña"].ToString();
                        e.email = dr["email"].ToString();
                        e.rol = int.Parse(dr["id_rol"].ToString());
                    
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
        public static Usuario obtenerusuario (string usuario, string contra, int rol)
        {
            Usuario resultado = new Usuario();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();


                string consulta = "select count(*) c, nombre, id_usuario, id_rol, email, contraseña from usuarios where nombre = @1 and contraseña = @2 and id_rol = @3  group by id_usuario, contraseña, nombre, id_rol, email";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@1", usuario);
                cmd.Parameters.AddWithValue("@2", contra);
                cmd.Parameters.AddWithValue("@3", rol);


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                        resultado.id = int.Parse(dr["id_usuario"].ToString());
                        resultado.contraseña = dr["contraseña"].ToString();
                        resultado.nombreUsuario = dr["nombre"].ToString();
                        resultado.rol = int.Parse(dr["id_rol"].ToString());
                        resultado.email = dr["email"].ToString();

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