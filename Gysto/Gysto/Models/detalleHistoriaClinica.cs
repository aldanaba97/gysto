﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gysto.Models
{
    public class detalleHistoriaClinica
    {
        public int id_detalle { get; set; }
        public Boolean alergia { get; set; }
        public int enfermedades { get; set; }
        public string observaciones { get; set; }
        public int hc { get; set; }
        public string detalle_alergia {get; set;  }


    }
}