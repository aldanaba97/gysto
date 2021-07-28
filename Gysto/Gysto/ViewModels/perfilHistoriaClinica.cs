using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gysto.ViewModels
{
    public class perfilHistoriaClinica
    {
        public string nombreCto { get; set; }
        public string telefono {get;set; }
        public int dni { get; set;  } 
        public string direccion { get; set;  }
       
        public DateTime fecha { get; set;  }
        public string nombre_c { get; set;}

        //[DisplayName("paciente")]

        //public int paciente { get; set; }

    }


}