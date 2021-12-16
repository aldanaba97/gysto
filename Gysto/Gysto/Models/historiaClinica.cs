using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gysto.Models
{
    public class historiaClinica
    {
       public int id_hc { get; set;  }
        public string Medicacion{ get; set; }
        public DateTime fecha { get; set; }
        public string grupo_sanguineo  { get; set;  }
        public int paciente { get; set;  } 

      

    }
}