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

                string consulta = "insert into Medicos (id_espe, matricula, id_persona) values (2, 11111, IDENT_CURRENT('Personas'))";
                cmd.Parameters.Clear();

                //cmd.Parameters.AddWithValue("@id", m.id_espe);
                //cmd.Parameters.AddWithValue("@matri", m.matricula);
 



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
        public static bool Insertarpaciente()
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

                string consulta = "select id_paciente,  apellido + ' , ' +  nombre nombrecto from personas p join Pacientes pa on p.id_persona = pa.id_persona order by apellido asc";
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

                string consulta = "select apellido + ' , ' +  p.nombre nombrecto, id_medico from personas p join Medicos m on p.id_persona = m.id_persona order by apellido asc";
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

                string consulta = "select apellido + ' , ' +  p.nombre nombrecto, id_administrativos from personas p join Administrativos m on p.id_persona = m.id_persona order by apellido asc";
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
        //public static buscaPaciente pacientesxdni(int dni)
        //{
        //    buscaPaciente resultado = new buscaPaciente();
        //    string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
        //    SqlConnection cn = new SqlConnection(cadenaConexion);

        //    try
        //    {

        //        SqlCommand cmd = new SqlCommand();

        //        string consulta = "select id_paciente, nombre + ', ' + apellido nombrec, numero_dni from Pacientes join personas on Pacientes.id_persona = personas.id_persona where numero_dni = @id ";

        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@dni", dni);
        //        cmd.CommandType = System.Data.CommandType.Text;
        //        cmd.CommandText = consulta;
        //        cn.Open();

        //        cmd.Connection = cn;


        //        SqlDataReader dr = cmd.ExecuteReader();

        //        if (dr != null)
        //        {
        //            while (dr.Read())
        //            {


        //                //resultado.id_turno = int.Parse(dr["id_turno"].ToString());  
        //                resultado.nombreC = dr["nombrec"].ToString();

        //                resultado.paciente= int.Parse(dr["id_paciente"].ToString());
        //                resultado.dni = int.Parse(dr["id_paciente"].ToString());

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
        public static MedicoValidar ObtenerMedico(int idDoc)
        {
            MedicoValidar resultado = new MedicoValidar();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select * from Medicos m  join personas on m.id_persona = personas.id_persona where personas.id_usuario=  = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", idDoc);


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        resultado.id_medico = int.Parse(dr["id_medico"].ToString());
                        resultado.id_espe = int.Parse(dr["id_espe"].ToString());
                        resultado.matricula = dr["matricula"].ToString();
                        resultado.id_persona = int.Parse(dr["id_persona"].ToString());

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
        public static bool ActualizarMedico(MedicoValidar i)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "update medicos set id_espe = @1, matricula = @2 where id_medico = @id";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@1", i.id_espe);
                cmd.Parameters.AddWithValue("@2", i.matricula);
                cmd.Parameters.AddWithValue("@id", i.id_medico);

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
        public static Medico PerfilMedico(int usuario)
        {
            Medico resultado = new Medico();
            
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select e.id_espe, Usuarios.nombre name, email, p.id_persona, direccion,telefono, p.nombre, apellido, fecha_nac, numero_dni,Usuarios.imagen, id_medico, e.nombre espe, matricula from Medicos m inner join personas p on m.id_persona = p.id_persona inner join Usuarios on p.id_usuario = Usuarios.id_usuario join Especialidades e on e.id_espe = m.id_espe where p.id_usuario = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", usuario);


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        resultado.nombreUsuario = dr["name"].ToString();
                        resultado.email = dr["email"].ToString();
                        resultado.id_persona = int.Parse(dr["id_persona"].ToString());
                        resultado.direccion = dr["direccion"].ToString();
                        resultado.telefono = dr["telefono"].ToString();
                        resultado.nombre = dr["nombre"].ToString();
                        resultado.apellido= dr["apellido"].ToString();
                        resultado.fecha_nac = DateTime.Parse(dr["fecha_nac"].ToString());
                        resultado.dni = int.Parse(dr["numero_dni"].ToString());
                        resultado.image = dr["imagen"].ToString();
                        resultado.id_medico= int.Parse(dr["id_medico"].ToString());
                        resultado.id_espe = int.Parse(dr["id_espe"].ToString());
                        resultado.matricula = dr["matricula"].ToString();
                      
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
        public static director_medico PerfilDirectorMedico(int usuario)
        {
            director_medico resultado = new director_medico();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select Usuarios.nombre name, email, p.id_persona, direccion,telefono, p.nombre, apellido, fecha_nac, numero_dni, imagen, id_director, maestria, matricula from directores_medicos m inner join personas p on m.id_persona = p.id_persona inner join Usuarios on p.id_usuario = Usuarios.id_usuario where p.id_usuario = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", usuario);


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        resultado.nombreUsuario = dr["name"].ToString();
                        resultado.email = dr["email"].ToString();
                        resultado.id_persona = int.Parse(dr["id_persona"].ToString());
                        resultado.direccion = dr["direccion"].ToString();
                        resultado.telefono = dr["telefono"].ToString();
                        resultado.nombre = dr["nombre"].ToString();
                        resultado.apellido = dr["apellido"].ToString();
                        resultado.fecha_nac = DateTime.Parse(dr["fecha_nac"].ToString());
                        resultado.dni = int.Parse(dr["numero_dni"].ToString());
                        resultado.image = dr["imagen"].ToString();
                        resultado.id_director = int.Parse(dr["id_director"].ToString());
                        resultado.maestria= dr["maestria"].ToString();
                        resultado.matricula = dr["matricula"].ToString();
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
        public static Administrador PerfilAdministrativo(int usuario)
        {
            Administrador resultado = new Administrador();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select personas.id_persona, id_tipoDNI, direccion, localidad_id, telefono, personas.nombre name, apellido, fecha_nac, numero_dni, Usuarios.id_usuario, usuarios.contraseña, usuarios.nombre, id_rol, email, imagen  from personas join Usuarios on personas.id_usuario = Usuarios.id_usuario where Usuarios.id_usuario = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", usuario);


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
                        resultado.nombre = dr["name"].ToString();
                        resultado.apellido = dr["apellido"].ToString();
                        resultado.fecha_nac = DateTime.Parse(dr["fecha_nac"].ToString());
                        resultado.dni = int.Parse(dr["numero_dni"].ToString());
                        resultado.id = int.Parse(dr["id_usuario"].ToString());
                        resultado.contraseña = dr["contraseña"].ToString();
                        resultado.image = dr["imagen"].ToString();
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
        public static Enfermero PerfilEnfermero(int usuario)
        {
            Enfermero resultado = new Enfermero();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select Usuarios.nombre name, email, p.id_persona, direccion,telefono, p.nombre, apellido, fecha_nac, numero_dni, imagen, matricula, id_enfermero from Enfermeros m inner join personas p on m.id_persona = p.id_persona inner join Usuarios on p.id_usuario = Usuarios.id_usuario where p.id_usuario = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", usuario);


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        resultado.nombreUsuario = dr["name"].ToString();
                        resultado.email = dr["email"].ToString();
                        resultado.id_persona = int.Parse(dr["id_persona"].ToString());
                        resultado.direccion = dr["direccion"].ToString();
                        resultado.telefono = dr["telefono"].ToString();
                        resultado.nombre = dr["nombre"].ToString();
                        resultado.apellido = dr["apellido"].ToString();
                        resultado.fecha_nac = DateTime.Parse(dr["fecha_nac"].ToString());
                        resultado.dni = int.Parse(dr["numero_dni"].ToString());
                        resultado.image = dr["imagen"].ToString();             
                        resultado.matricula = dr["matricula"].ToString();
                        resultado.id_enfermero = int.Parse(dr["id_enfermero"].ToString());
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
        public static director_medico Obtenerdirector(int id)
        {
            director_medico resultado = new director_medico();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select * from directores_medicos join personas on directores_medicos.id_persona = personas.id_persona where personas.id_usuario= @id";
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
                        resultado.id_director = int.Parse(dr["id_director"].ToString());
                        resultado.maestria = dr["maestria"].ToString();
                        resultado.matricula = dr["matricula"].ToString();
                        resultado.id_persona = int.Parse(dr["id_persona"].ToString());

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
        public static bool ActualizarDirector(director_medico i)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "update directores_medicos set maestria = @1, matricula = @2 where id_director = @id";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@1", i.maestria);
                cmd.Parameters.AddWithValue("@2", i.matricula);
                cmd.Parameters.AddWithValue("@id", i.id_director);

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
        public static Enfermero Obtenerenfermero(int id)
        {
            Enfermero resultado = new Enfermero();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select * from enfermeros where id_enfermero = @id";
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
                        resultado.id_enfermero= int.Parse(dr["id_enfermero"].ToString());

                        resultado.matricula = dr["matricula"].ToString();
                        resultado.id_persona = int.Parse(dr["id_persona"].ToString());

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
        public static bool ActualizarEnfermero(Enfermero i)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "update enfermeros set matricula = @2 where id_enfermero = @id";
                cmd.Parameters.Clear();

                
                cmd.Parameters.AddWithValue("@2", i.matricula);
                cmd.Parameters.AddWithValue("@id", i.id_enfermero);

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