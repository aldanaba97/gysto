using System;
using System.Collections.Generic;
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
        public TimeSpan hora { get; set;  }
        public int medico { get; set;  }

    }
}