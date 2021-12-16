using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gysto.Models
{
    public class turno
    {
        public int id_turno { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        [Required]
        public DateTime fecha { get; set; }
        [Required]
        public TimeSpan hora { get; set; }
        [Required]
        public int medico { get; set; }
        public int paciente { get; set; }
        public bool disponibilidad { get; set; }
        public string email { get; set; }
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