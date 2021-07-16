using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gysto.ViewModels
{
    public class ListadoConsulta
    {
        public string hora { get; set;  }
        public string fecha { get; set;  }
        public string NombreMedico { get; set;  }
        public string NombrePaciente { get; set; }
        public int id { get; set;  }
        public string diagnostico { get; set; }

    }
}