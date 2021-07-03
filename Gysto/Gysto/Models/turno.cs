using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gysto.Models
{
    public class turno
    {
        public int id_turno { get; set; }
        public DateTime fecha { get; set; }
        public DateTime hora { get; set;  }
        public int medico { get; set;  }

    }
}