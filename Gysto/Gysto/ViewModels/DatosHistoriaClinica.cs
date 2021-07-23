using Gysto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gysto.ViewModels
{
    public class DatosHistoriaClinica
    {
        public historiaClinica hc { get; set; }
        public List<detalleHistoriaClinica> detalle { get; set; }
    }
}