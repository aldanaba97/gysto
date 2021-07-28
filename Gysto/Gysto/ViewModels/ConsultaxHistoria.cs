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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha { get; set; }
        public TimeSpan hora { get; set;  }
        public string especialidad { get; set;  }


    }
}