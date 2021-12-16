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
      
       public string ciudad2(int id)
        {
            string ciudad = ""; 
            switch (id)
            {
                case 2: ciudad = "Colonia caroya";
                    break;
                case 3: ciudad = "Jesus maria"; 
                    break;

                case 7: ciudad = "General paz";

                    break; 
                case 8: ciudad = "Sinsacate"; 
                    break; 
            }
            return ciudad; 
        }
        //public string fecha2()
        //{
        //    string fechaformato = "";
        //    fechaformato = fecha.ToString("dd/MM/yyyy");
        //    return fechaformato;
        //}
    }
   
}