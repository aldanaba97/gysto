using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gysto.Models
{
    public class Consulta
    {
        public int id_consulta { get; set;  }
     
        public int id_administracion { get; set;  }
       
        public int id_paciente { get; set;  }
  
        public string prediagnostico { get; set; }

        public string diagnostico { get; set;  }

        public string observaciones{ get; set;  }
 
        public int tratamiento { get; set;  }

        public DateTime hora { get; set;  }

        public DateTime fecha { get; set; }

        public int medico { get; set;  }



        public string hora2()
        {
            string horaFormat = "";
            horaFormat = hora.ToString("HH:mm");
            return horaFormat;
        }

    }
}