using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gysto.ViewModels
{
    public class MedicoValidar
    {

        public int id_medico { get; set; }
        [Required]
        public int id_espe { get; set; }
        [Required]
        public string matricula { get; set; }
        public int id_persona { get; set;  }
    }
}