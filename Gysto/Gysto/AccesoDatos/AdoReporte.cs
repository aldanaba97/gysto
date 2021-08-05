using Gysto.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Gysto.AccesoDatos
{
    public class AdoReporte
    {
        public static List<reportesEnfermedad> ListadoReporte()
        {
            List<reportesEnfermedad> resultado = new List<reportesEnfermedad>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consulta = "select top 5 COUNT(d.id_enfermedad) cantidad, Enfermedades.nombre from HistoriaClinica hc join detalle_hc d on hc.id_historia = d.id_hc join Enfermedades on d.id_enfermedad = Enfermedades.id_enfermedad group by Enfermedades.nombre";
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

                        reportesEnfermedad e = new reportesEnfermedad();
                        e.enfermedad = dr["nombre"].ToString();
                        e.cantidad= int.Parse(dr["cantidad"].ToString());

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