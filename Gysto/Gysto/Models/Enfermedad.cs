using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gysto.Models
{
    public class Enfermedad
    {
        public int id_enfe { get; set; }
        public string nombreEnfermedad { get; set;}
        public bool estado { get; set; }
    }
}
