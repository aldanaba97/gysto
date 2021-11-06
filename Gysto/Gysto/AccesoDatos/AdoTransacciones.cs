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
        public static bool InsertarHistoriaClinica(historiaClinica i)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "insert into HistoriaClinica (medicacion, id_paciente, fecha_creacion, grupo_sanguineo) values ( @1, @2, getdate(), @4)";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@1", i.Medicacion);              
                cmd.Parameters.AddWithValue("@2", i.paciente);
                cmd.Parameters.AddWithValue("@4", i.grupo_sanguineo);
                

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
        public static bool InsertarConsulta(Consulta i)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "insert into Consultas (id_admnistrativo, diagnostico , observaciones, id_tratamiento, id_paciente, diagnostico_final, hora, fecha, medico) values ( @1, @2, null, null, @3, null, null, getdate(), @5)";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@1", i.id_administracion);
                cmd.Parameters.AddWithValue("@2", i.prediagnostico);
                cmd.Parameters.AddWithValue("@3", i.id_paciente);
               
                cmd.Parameters.AddWithValue("@5", i.medico);



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
        public static bool InsertarTurno(turno i)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "insert into Turnos (fecha , hora, id_medico, paciente, disponibilidad) values ( @1, @2,@3, null, 1)";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@1", i.fecha);
                cmd.Parameters.AddWithValue("@2", i.hora);
                cmd.Parameters.AddWithValue("@3", i.medico);



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
        public static List<listadoTurnos> ListadoTurno()
        {
            List<listadoTurnos> resultado = new List<listadoTurnos>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select id_turno,  hora, fecha, apellido + ' , '  + nombre medico from Turnos join Medicos on Turnos.id_medico = Medicos.id_medico join personas on personas.id_persona = Medicos.id_persona";

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

                        listadoTurnos i = new listadoTurnos();
                        i.id = int.Parse(dr["id_turno"].ToString());
                        i.hora = dr["hora"].ToString();
                        i.fecha = dr["fecha"].ToString();
                        i.medico = dr["medico"].ToString();
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
        public static turno ObtenerTurno(int idTurno)
        {
            turno resultado = new turno();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select * from Turnos where id_turno = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", idTurno);


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                        resultado.fecha = DateTime.Parse(dr["fecha"].ToString());
                        resultado.hora = TimeSpan.Parse(dr["hora"].ToString());
                        resultado.medico = int.Parse(dr["id_medico"].ToString());
                        resultado.id_turno = int.Parse(dr["id_turno"].ToString());

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
        public static bool ActualizarTurno(turno t)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "update Turnos set fecha= @1, hora = @2, id_medico = @3 where id_turno = @id";
                cmd.Parameters.Clear();


                cmd.Parameters.AddWithValue("@1", t.fecha);
                cmd.Parameters.AddWithValue("@2", t.hora);
                cmd.Parameters.AddWithValue("@3", t.medico);
                cmd.Parameters.AddWithValue("@id", t.id_turno);

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
        public static bool eliminarTurno(turno i)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "delete Turno where id_turno = @id";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@id", i.id_turno);

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
        public static List<turno> ListadoTurnosDisponibles()
        {
            List<turno> resultado = new List<turno>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select hora, fecha, id_turno, disponibilidad from Turnos";

                cmd.Parameters.Clear();
                //cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();

                cmd.Connection = cn;


                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                        turno i = new turno();
                        //  i.id_turno = int.Parse(dr["id_turno"].ToString());
                        i.hora = TimeSpan.Parse(dr["hora"].ToString());
                        i.fecha = DateTime.Parse(dr["fecha"].ToString());
                        i.id_turno = int.Parse(dr["id_turno"].ToString());
                        i.disponibilidad = Boolean.Parse(dr["disponibilidad"].ToString());

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
        public static List<turno> ListadoxOrden(int id)
        {
            List<turno> resultado = new List<turno>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select hora, fecha, id_turno, disponibilidad from Turnos where id_medico = @id";

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

                        turno i = new turno();
                        //  i.id_turno = int.Parse(dr["id_turno"].ToString());
                        i.hora = TimeSpan.Parse(dr["hora"].ToString());
                        i.fecha = DateTime.Parse(dr["fecha"].ToString());
                        i.id_turno = int.Parse(dr["id_turno"].ToString());
                        i.disponibilidad = Boolean.Parse(dr["disponibilidad"].ToString());

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
        public static paciente listadoxDni (string dni)
        {
            paciente resultado = new paciente();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select nombre, apellido, telefono, id_paciente, numero_dni from Pacientes join personas p on Pacientes.id_persona = p.id_persona where numero_dni = @dni";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();

                cmd.Connection = cn;


                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                     
                        //resultado.id_turno = int.Parse(dr["id_turno"].ToString());  
                        resultado.nombre = dr["nombre"].ToString();
                        resultado.apellido = dr["apellido"].ToString();                 
                        resultado.telefono = dr["telefono"].ToString();
                        resultado.id_paciente= int.Parse(dr["id_paciente"].ToString());
                        resultado.dni = int.Parse(dr["numero_dni"].ToString());
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
        public static turno listadoxDniTurno(int id )
        {
            turno resultado = new turno(); 
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select id_turno from Turnos where id_turno = @id";

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
                        
                        resultado.id_turno = int.Parse(dr["id_turno"].ToString());
                     
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
        public static bool ConfirmarTurno(SacarTurno t)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "update Turnos set paciente= @1, disponibilidad = 1 where id_turno = @id";
                cmd.Parameters.Clear();


                cmd.Parameters.AddWithValue("@1", t.p.id_paciente);
                cmd.Parameters.AddWithValue("@id", t.turno.id_turno);

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
        public static List<ListadoConsulta> ListadoConsultas()
        {
            List<ListadoConsulta> resultado = new List<ListadoConsulta>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select hora, fecha,  p.apellido +' , ' + p.nombre NombreMedico, id_consulta, (select apellido + ' , ' + nombre from personas p join Pacientes pa on p.id_persona = pa.id_persona join Consultas con on pa.id_paciente = con.id_paciente where id_consulta = c.id_consulta) nombrePaciente from consultas c join Medicos a on a.id_medico = c.medico join personas p on p.id_persona = a.id_persona";
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

                        ListadoConsulta i = new ListadoConsulta();
                        i.hora = dr["hora"].ToString();
                        i.fecha = dr["fecha"].ToString();
                        i.NombreMedico = dr["NombreMedico"].ToString();
                        i.NombrePaciente = dr["nombrePaciente"].ToString();
                        i.id = int.Parse(dr["id_consulta"].ToString());
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
        public static int obtenerIdMedico (int idUsuario)
        {
            int idMedico = 0;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select id_medico from Medicos m inner join personas p on m.id_persona = p.id_persona inner join Usuarios on p.id_usuario = Usuarios.id_usuario where p.id_usuario = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", idUsuario);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();

                cmd.Connection = cn;


                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        idMedico = int.Parse(dr["id_medico"].ToString());
                      
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

            return idMedico;

        }
        public static List<ListadoConsulta> ListadoConsultaxMedico(int id)
        {
            List<ListadoConsulta> resultado = new List<ListadoConsulta>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select hora, fecha,  p.apellido +' , ' + p.nombre nombreadmi, id_consulta, (select apellido + ' , ' + nombre from personas p join Pacientes pa on p.id_persona = pa.id_persona join Consultas con on pa.id_paciente = con.id_paciente where id_consulta = c.id_consulta) nombrePaciente from consultas c join Administrativos a on a.id_administrativos = c.id_admnistrativo join personas p on p.id_persona = a.id_persona where medico = @id and diagnostico_final is null";
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

                        ListadoConsulta i = new ListadoConsulta();
                        i.hora = dr["hora"].ToString();
                        i.fecha = dr["fecha"].ToString();
                        i.NombreMedico = dr["nombreadmi"].ToString();
                        i.NombrePaciente = dr["nombrePaciente"].ToString();
                        i.id = int.Parse(dr["id_consulta"].ToString());
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
        public static List<ListadoConsulta> ListadoConsultasCerradas()
        {
            List<ListadoConsulta> resultado = new List<ListadoConsulta>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select hora, fecha,  p.apellido +' , ' + p.nombre nombreadmi, id_consulta, (select apellido + ' , ' + nombre from personas p join Pacientes pa on p.id_persona = pa.id_persona join Consultas con on pa.id_paciente = con.id_paciente where id_consulta = c.id_consulta) nombrePaciente from consultas c join Medicos a on a.id_medico = c.medico join personas p on p.id_persona = a.id_persona where diagnostico_final is not null";
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

                        ListadoConsulta i = new ListadoConsulta();
                        i.hora = dr["hora"].ToString();
                        i.fecha = dr["fecha"].ToString();
                        i.NombreMedico = dr["NombreMedico"].ToString();
                        i.NombrePaciente = dr["nombrePaciente"].ToString();
                        i.diagnostico = dr["diagnostico_final"].ToString();
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
        public static Consulta ObtenerConsulta(int idConsulta)
        {
            Consulta resultado = new Consulta();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select hora, id_consulta, medico, id_paciente, id_admnistrativo, diagnostico from Consultas where id_consulta = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", idConsulta);


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                        resultado.hora = TimeSpan.Parse(dr["hora"].ToString());
                        resultado.id_consulta = int.Parse(dr["id_consulta"].ToString());
                        resultado.medico = int.Parse(dr["medico"].ToString());
                        resultado.id_paciente = int.Parse(dr["id_paciente"].ToString());
                        resultado.id_administracion = int.Parse(dr["id_admnistrativo"].ToString());
                        resultado.prediagnostico = dr["diagnostico"].ToString();

                    
                        
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
        public static bool ActualizarConsulta(Consulta i)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "update consultas set hora = @hora,  medico = @medico, id_paciente = @idpaciente, id_admnistrativo = @administrativo , diagnostico = @diag where id_consulta = @consulta";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@hora", i.hora);
                cmd.Parameters.AddWithValue("@medico", i.medico);
                cmd.Parameters.AddWithValue("@id_paciente", i.id_paciente); 
                cmd.Parameters.AddWithValue("@id_administrativo", i.id_administracion);
                cmd.Parameters.AddWithValue("@diag", i.prediagnostico);
                cmd.Parameters.AddWithValue("@consulta", i.id_consulta);




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
        public static bool eliminarConsulta(Consulta i)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "delete Consultas where id_consulta = @id";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@id", i.id_consulta);

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
        public static bool CerrarConsulta(Consulta i)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "update consultas set diagnostico_final = @1,  observaciones = @2, id_tratamiento = @3 where id_consulta = @consulta";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@1", i.diagnostico);
                cmd.Parameters.AddWithValue("@2", i.observaciones);
                cmd.Parameters.AddWithValue("@3", i.tratamiento);
                cmd.Parameters.AddWithValue("@consulta", i.id_consulta);




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
        public static Consulta ObtenerConsultaParaCerrar(int idConsulta)
        {
            Consulta resultado = new Consulta();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select hora, id_consulta, medico, id_paciente, id_admnistrativo, diagnostico from Consultas where id_consulta = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", idConsulta);


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        resultado.hora = TimeSpan.Parse(dr["hora"].ToString());
                        resultado.id_consulta = int.Parse(dr["id_consulta"].ToString());
                        resultado.medico = int.Parse(dr["medico"].ToString());
                        resultado.id_paciente = int.Parse(dr["id_paciente"].ToString());
                        resultado.id_administracion = int.Parse(dr["id_admnistrativo"].ToString());
                        resultado.prediagnostico = dr["diagnostico"].ToString();
                        //resultado.observaciones = dr["observaciones"].ToString();
                        //resultado.tratamiento = int.Parse(dr["id_tratamiento"].ToString());
                        //resultado.diagnostico = dr["diagnostico_final"].ToString();
                        


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
        public static bool InsertarDetalleHistoria(detalleHistoriaClinica i)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "insert into detalle_hc (id_enfermedad, id_hc, observaciones, alergia, detalles_alergia) values ( @1, IDENT_CURRENT('HistoriaClinica'), @2, @3, @4)";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@1", i.enfermedades);
                cmd.Parameters.AddWithValue("@2", i.observaciones);
                cmd.Parameters.AddWithValue("@3", i.alergia);
                cmd.Parameters.AddWithValue("@4", i.detalle_alergia);



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
        public static List<listadoHistoriaClinica> ListadoHistorias()
        {
            List<listadoHistoriaClinica> resultado = new List<listadoHistoriaClinica>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select pe.apellido + ' , ' + pe.nombre nombreC, pe.numero_dni, h.id_historia, h.id_paciente  from Pacientes p join HistoriaClinica h on p.id_paciente = h.id_paciente join personas pe on pe.id_persona = p.id_persona";
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

                        listadoHistoriaClinica i = new listadoHistoriaClinica();
                        i.nombreC = dr["nombreC"].ToString();
                        i.dni = dr["numero_dni"].ToString();
                        i.id_historia = int.Parse(dr["id_historia"].ToString());
                        i.paciente = int.Parse(dr["id_paciente"].ToString());


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
        public static historiaClinica ObtenerHC(int idHistoriaClinica)
        {
            historiaClinica resultado = new historiaClinica(); 
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select id_historia, medicacion, id_paciente, grupo_sanguineo from historiaClinica where id_historia = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", idHistoriaClinica);


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                        resultado.id_hc = int.Parse(dr["id_historia"].ToString());
                        resultado.Medicacion = dr["medicacion"].ToString();
                        resultado.paciente = int.Parse(dr["id_paciente"].ToString());
                        resultado.grupo_sanguineo = dr["grupo_sanguineo"].ToString();
                        

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
        public static List<detalleHistoriaClinica> listadoDetalle(int id)
        {
            List<detalleHistoriaClinica> resultado = new List<detalleHistoriaClinica>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select * from detalle_hc where id_hc = @id";

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

                        detalleHistoriaClinica i = new detalleHistoriaClinica();                       
                        i.id_detalle= int.Parse(dr["id_detalle"].ToString());
                        i.enfermedades = int.Parse(dr["id_enfermedad"].ToString());
                        i.hc = int.Parse(dr["id_hc"].ToString());
                        i.observaciones = dr["observaciones"].ToString();
                        i.alergia = Boolean.Parse(dr["alergia"].ToString());
                        i.detalle_alergia = dr["detalles_alergia"].ToString();

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
        public static bool eliminarDetalle(int id )
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "delete detalle_hc where id_detalle = @id";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@id", id);

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
        public static bool ActualizarHC(DatosHistoriaClinica i)
        {

            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "update HistoriaClinica set medicacion = @1 , id_paciente = @2 , grupo_sanguineo = @3 where id_historia = @id";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@1", i.hc.Medicacion);
                cmd.Parameters.AddWithValue("@2", i.hc.paciente);
                cmd.Parameters.AddWithValue("@3", i.hc.grupo_sanguineo);
                cmd.Parameters.AddWithValue("@id", i.hc.id_hc);
                
                




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
        public static bool ActualizarDetalle(detalleHistoriaClinica i)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "update detalle_hc set id_enfermedad = @1, observaciones = @2, alergia = @3, detalles_alergia = @4 where id_hc = @id";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@1", i.enfermedades);
                cmd.Parameters.AddWithValue("@2", i.observaciones);
                cmd.Parameters.AddWithValue("@3", i.alergia);
                cmd.Parameters.AddWithValue("@4", i.detalle_alergia);
                cmd.Parameters.AddWithValue("@id", i.id_detalle);

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
        public static detalleHistoriaClinica ObtenerDetalle(int idDetalle)
        {
            detalleHistoriaClinica resultado = new detalleHistoriaClinica();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select id_enfermedad, observaciones, alergia, detalles_alergia, id_detalle, id_hc from detalle_hc where id_detalle = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", idDetalle);


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        resultado.enfermedades = int.Parse(dr["id_enfermedad"].ToString());
                        resultado.observaciones = dr["observaciones"].ToString();
                        resultado.alergia = Boolean.Parse(dr["alergia"].ToString());
                        resultado.detalle_alergia = dr["detalles_alergia"].ToString();
                        resultado.id_detalle = int.Parse(dr["id_detalle"].ToString());
                        resultado.hc= int.Parse(dr["id_hc"].ToString());



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
        public static bool eliminarHC(DatosHistoriaClinica i)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "delete HistoriaClinica where id_historia = @id";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@id", i.hc.id_hc);

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
        public static List<ConsultaxHistoria> listadoConsultaxHistoria(int id)
        {
            List<ConsultaxHistoria> resultado = new List<ConsultaxHistoria>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select apellido  + ' , ' + p.nombre nombremedico, diagnostico, fecha, hora, e.nombre especialidad from Consultas c join Medicos m on c.medico = m.id_medico join personas p on p.id_persona = m.id_persona join especialidades e on e.id_espe = m.id_espe where id_paciente = @id";

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

                        ConsultaxHistoria i = new ConsultaxHistoria();
                        i.medico = dr["nombremedico"].ToString();
                        i.diagnostico = dr["diagnostico"].ToString();
                        i.fecha = DateTime.Parse(dr["fecha"].ToString());
                        //i.hora = TimeSpan.Parse(dr["hora"].ToString());
                        i.especialidad = dr["especialidad"].ToString();
                        

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
        public static List<InternacionxHistoria> ListadoInternacionxHistoria(int id)
        {
            List<InternacionxHistoria> resultado = new List<InternacionxHistoria>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select fecha_ingreso, Fecha_egreso, nombre + ' , ' + apellido nombreEnfermero from Internaciones i join Enfermeros enfe on i.id_enfermero = enfe.id_enfermero join personas perso on enfe.id_persona = perso.id_persona where paciente = @id";

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

                        InternacionxHistoria i = new InternacionxHistoria();
                        i.fecha_ingreso = dr["fecha_ingreso"].ToString();
                        i.fecha_alta = dr["fecha_egreso"].ToString();
                   
                        i.enfermero = dr["nombreEnfermero"].ToString();
                        

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

        public static perfilHistoriaClinica ObtenerPerfilHC(int id)
        {
            perfilHistoriaClinica resultado = new perfilHistoriaClinica();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select pe.apellido + ' , ' + pe.nombre nombrecompleto , telefono, pe.numero_dni, pe.direccion, pe.fecha_nac, c.nombre ciudad, hc.id_paciente from HistoriaClinica hc join Pacientes pa on hc.id_paciente = pa.id_paciente join personas pe on pa.id_persona = pe.id_persona join Ciudades c on c.id_ciudad = pe.localidad_id where hc.id_paciente = @id";
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

                        resultado.nombreCto = dr["nombrecompleto"].ToString();
                        resultado.telefono = dr["telefono"].ToString();
                        resultado.dni = int.Parse(dr["numero_dni"].ToString());
                        resultado.direccion = dr["direccion"].ToString();
                        resultado.fecha = DateTime.Parse(dr["fecha_nac"].ToString());
                        resultado.nombre_c = dr["ciudad"].ToString();
                        //resultado.paciente = int.Parse(dr["id_paciente"].ToString());

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
        public static List<ConsultaxHistoria> FiltroConsultaxMedico(int idPaciente, int idMedico)
        {
            List<ConsultaxHistoria> resultado = new List<ConsultaxHistoria>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();
               string consulta = "select apellido  + ' , ' + p.nombre nombremedico, diagnostico, fecha, hora, e.nombre especialidad  from Consultas c join Medicos m on c.medico = m.id_medico join personas p on p.id_persona = m.id_persona join especialidades e on e.id_espe = m.id_espe where id_paciente = @idpaciente and c.medico = @idmedico";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idpaciente", idPaciente);
                cmd.Parameters.AddWithValue("@idmedico", idMedico);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();

                cmd.Connection = cn;


                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        ConsultaxHistoria i = new ConsultaxHistoria();
                        i.medico = dr["nombremedico"].ToString();
                        i.diagnostico = dr["diagnostico"].ToString();
                        i.fecha = DateTime.Parse(dr["fecha"].ToString());
                        //i.hora = TimeSpan.Parse(dr["hora"].ToString());
                        i.especialidad = dr["especialidad"].ToString();


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
        public static List<ConsultaxHistoria> FiltroConsultaxEspe(int idPaciente, int idEspe)
        {
            List<ConsultaxHistoria> resultado = new List<ConsultaxHistoria>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();
                string consulta = "select apellido  + ' , ' + p.nombre nombremedico, diagnostico, fecha, hora, e.nombre especialidad  from Consultas c join Medicos m on c.medico = m.id_medico join personas p on p.id_persona = m.id_persona join especialidades e on e.id_espe = m.id_espe where id_paciente = @idpaciente and m.id_espe = @idespe";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idpaciente", idPaciente);
                cmd.Parameters.AddWithValue("@idespe", idEspe);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();

                cmd.Connection = cn;


                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        ConsultaxHistoria i = new ConsultaxHistoria();
                        i.medico = dr["nombremedico"].ToString();
                        i.diagnostico = dr["diagnostico"].ToString();
                        i.fecha = DateTime.Parse(dr["fecha"].ToString());
                        //i.hora = TimeSpan.Parse(dr["hora"].ToString());
                        i.especialidad = dr["especialidad"].ToString();


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

        public static List<ConsultaxHistoria> FiltroConsultaxFecha(int idPaciente, string fecha1, string fecha2)
        {
            List<ConsultaxHistoria> resultado = new List<ConsultaxHistoria>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();
                string consulta = "select apellido  + ' , ' + p.nombre nombremedico, diagnostico, fecha, hora, e.nombre especialidad from Consultas c join Medicos m on c.medico = m.id_medico join personas p on p.id_persona = m.id_persona join especialidades e on e.id_espe = m.id_espe where id_paciente = @id and fecha between @fecha1 and @fecha2";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", idPaciente);
                cmd.Parameters.AddWithValue("@fecha1", fecha1);
                cmd.Parameters.AddWithValue("@fecha2", fecha2);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open();

                cmd.Connection = cn;


                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        ConsultaxHistoria i = new ConsultaxHistoria();
                        i.medico = dr["nombremedico"].ToString();
                        i.diagnostico = dr["diagnostico"].ToString();
                        i.fecha = DateTime.Parse(dr["fecha"].ToString());
                        //i.hora = TimeSpan.Parse(dr["hora"].ToString());
                        i.especialidad = dr["especialidad"].ToString();


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
        public static int ObtenerPacientexid(int id )
        {
            int pac = 0; 
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();
                string consulta = "select id_paciente from pacientes where id_paciente = @id";

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
                             pac = int.Parse(dr["id_paciente"].ToString()); 
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

            return pac;
        }

    }
}
