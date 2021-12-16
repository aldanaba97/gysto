using Gysto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gysto.ViewModels
{
    public class TurnoMedico
    {
        public DateTime hora { get; set;  }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha { get; set;  }
        public int id_turno { get; set;  }
        public bool disponibilidad { get; set;  }
        public string nombre { get; set; }
        public string apellido { get; set;  } 
        public int id_espe { get; set; }


        public string fecha2 ()
        {
            string fechaformato= ""; 
          fechaformato = fecha.ToString("dd/MM/yyyy");
            return fechaformato; 
        }

        public string hora2 ()
        {
            string horaFormat = "";
            horaFormat = hora.ToString("HH:mm");
            return horaFormat; 
        }
        
    }
}