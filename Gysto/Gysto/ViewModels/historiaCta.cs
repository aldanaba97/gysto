using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gysto.ViewModels
{
    public class historiaCta
    {
        public perfilHistoriaClinica perfil { get; set; }
        public List<ConsultaxHistoria> consulta { get; set; }
        public List<InternacionxHistoria> internacion { get; set; }
       
    }
}