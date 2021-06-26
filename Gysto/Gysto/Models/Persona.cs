using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gysto.Models
{
    public class Persona : Usuario
    {
        public int id_persona { get; set; }
        public int id_dni { get; set;  }
        public string direccion { get; set;  }
        public int localidad { get; set;  }
        public string telefono { get; set;}
        public string nombre { get; set;  }
        public string apellido { get; set;  }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_nac { get; set;  }
        
        public int dni { get; set;  }
        public string image { get; set;  } 
          
        public void SubirImagenUsuario(string ruta, HttpPostedFileBase file)
    {
            file.SaveAs(ruta);
            file.ToString(); 
    }
      
       
    }
   
}