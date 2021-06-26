using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gysto.Models
{
    public class director_medico : Persona
    {
        public int id_director { get; set; }
        public string maestria { get; set;  }
        public string matricula { get; set;  }
    }
}