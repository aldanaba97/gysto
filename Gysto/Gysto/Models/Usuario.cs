using Gysto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gysto.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombreUsuario { set; get; }
        public string contraseña { get; set;  }
        public int rol { get; set; }
        public string email { get; set;  }
        


        //public void SubirImagen(string ruta, HttpPostedFileBase file)
        //{
        //    file.SaveAs(ruta);
        //}
    }
}