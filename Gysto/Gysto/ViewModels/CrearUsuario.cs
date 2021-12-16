using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gysto.ViewModels
{
    public class CrearUsuario
    {
        [Required]
        public string usuario { get; set; }
        [Required]
        public string contraseña { get; set;  }
        [Required]
        public int rol { get; set; }
        [Required]
        public string email { get; set;  }
        [Required]
        public string imagen { get; set;  }

        public void SubirImagenUsuario(string ruta, HttpPostedFileBase file)
        {
            file.SaveAs(ruta);
            file.ToString();
        }
    }
}