using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gysto.ViewModels
{
    public class ConsultaxHistoria
    {
        public string medico { get; set; }
        public string diagnostico { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fecha { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime hora { get; set;  }
        public string especialidad { get; set;  }

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