using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gysto.ViewModels
{
    public class cerrarConsulta
    {
        public string prediagnostico { get; set; }
        public string administrativo { get; set; }
        public string paciente { get; set; }
        public int id_consulta { get; set;  }
        public string diagnostico { get; set;  }
        public string observaciones { get; set;  }
        public int tratamiento { get; set;  }
        public DateTime hora { get; set; }
    }
}