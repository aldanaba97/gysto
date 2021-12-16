using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gysto.ViewModels
{
    public class ListadoConsulta
    {

        public DateTime hora { get; set;  }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha { get; set;  }
        public string NombreMedico { get; set;  }
        public string NombrePaciente { get; set; }
        public int id { get; set;  }
        public string diagnostico { get; set; }

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