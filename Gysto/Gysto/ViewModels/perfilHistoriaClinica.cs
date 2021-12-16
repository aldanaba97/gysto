using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gysto.ViewModels
{
    public class perfilHistoriaClinica
    {
        public string nombreCto { get; set; }
        public string telefono {get;set; }
        public int dni { get; set;  } 
        public string direccion { get; set;  }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha { get; set;  }
        public string nombre_c { get; set;}
        public string medicacion { get; set; }
        public DateTime fecha_alta { get; set;  }
         public string grupoS { get; set;  }
        public string enfermedad { get; set;  }
        public string observaciones { get; set;  }
        public string detalle_alergia { get; set; }
        public int idHC { get; set;  }
        //[DisplayName("paciente")]

        //public int paciente { get; set; }
        public string fecha2()
        {
            string fechaformato = "";
            fechaformato = fecha.ToString("dd/MM/yyyy");
            return fechaformato;
        }
        public string fecha3()
        {
            string fechaformato = "";
            fechaformato = fecha_alta.ToString("dd/MM/yyyy");
            return fechaformato;
        }

    }


}