using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gysto.ViewModels
{
    public class listadoTurnos
    {
        public int id { get; set; }
        public DateTime hora { get; set;  }
        public DateTime fecha { get; set; }
        public string medico { get; set;  }

        public string fecha2()
        {
            string fechaformato = "";
            fechaformato = fecha.ToString("dd/MM/yyyy");
            return fechaformato;
        }

        public string hora2()
        {
            string horaFormat = "";
            horaFormat = hora.ToString("HH:mm");
            return horaFormat;
        }
    }
}