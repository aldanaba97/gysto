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
        public DateTime fecha { get; set; }
        public TimeSpan hora { get; set; }
        public int medico { get; set; }
        public int paciente { get; set; }
        public bool disponibilidad { get; set; }

    }
}