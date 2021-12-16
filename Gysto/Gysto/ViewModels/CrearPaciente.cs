using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gysto.ViewModels
{
    public class CrearPaciente
    {
        public int id_persona { get; set; }
        [Required]
        public int id_dni { get; set; }
        [Required]
        public string direccion { get; set; }
        [Required]
        public int localidad { get; set; }
        [Required]
        public string telefono { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_nac { get; set; }
        [Required]
        public int dni { get; set; }
        public int id_usuario{ get; set; }
      
        public string email { get; set; }
      
    }
}