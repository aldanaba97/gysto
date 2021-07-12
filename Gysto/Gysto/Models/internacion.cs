using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gysto.Models
{
    public class internacion
    {
        public int id_internacion { get; set; }
        public string motivo { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public DateTime fecha_egreso { get; set; }
        public float temperatura { get; set; }
        public float tension { get; set; }
        public float frecuencia_c { get; set; }
        public float frecuencia_respiratoria { get; set; }
        public int enfermero { get; set;  } 
        public int paciente { get; set;  }


    }
}