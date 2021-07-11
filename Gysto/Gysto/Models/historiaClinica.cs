using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gysto.Models
{
    public class historiaClinica
    {
       public int id_hc { get; set;  }
        public string alergias { get; set; }
        public int paciente { get; set; }
        public int enfermedad { get; set;  }
        public int consultas { get; set;  }
        //public int enfermedad { get; set;  } 


    }
}