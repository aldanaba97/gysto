using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gysto.ViewModels
{
    public class listadoInternaciones
    {
        public string nombrecto { get; set; } 
        public DateTime fecha { get; set;  }
        public string motivo { get; set;  }
        public int id { get; set;  }

        public string fecha2()
        {
            string fechaformato = "";
            fechaformato = fecha.ToString("dd/MM/yyyy");
            return fechaformato;
        }
    }
}