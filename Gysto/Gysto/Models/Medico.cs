
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gysto.Models
{
    public class Medico : Persona
    {
        public int id_medico { get; set;  }
        public int id_espe { get; set; }
        public string matricula { get; set;}
       

    }
}