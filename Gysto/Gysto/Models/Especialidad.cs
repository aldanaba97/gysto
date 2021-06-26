using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gysto.Models
{
    public class Especialidad
    {
        public int id_especialidad { get; set; }
        public string nombre { get; set; }
        public string imagen { get; set; }
        public bool estado { get; set; }


        public void SubirImagen(string ruta, HttpPostedFileBase file)
        {
           file.SaveAs(ruta);
        }
    } 
   
}