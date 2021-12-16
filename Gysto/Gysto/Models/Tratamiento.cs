using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gysto.Models
{
    public class Tratamiento
    {
        public int id_tratamiento { get; set;  }
        [Required]

        public string nombre { get; set;  }


        public bool estado { get; set;  }

    }
}