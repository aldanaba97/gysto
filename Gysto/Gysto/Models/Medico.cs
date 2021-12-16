
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gysto.Models
{
    public class Medico : Persona
    {
        public int id_medico { get; set; }
        [Required]
        public int id_espe { get; set; }
        [Required]
        public string matricula { get; set; }


        public string espe(int id)
        {
            string nombre = "";
            switch (id)
            {
                case 2:
                    nombre = "Traumatologia";
                    break;
                case 3:
                    nombre = "Diagnostico en imagenes";
                    break;
                case 4:
                    nombre = "Cardiologia";
                    break;
                case 5:
                    nombre = "Ginecologia";
                    break;
                case 6:
                    nombre = "Nutricion";
                    break;
                case 7:
                    nombre = "Kinesiologia y Fisioterapia";
                    break;
                case 8:
                    nombre = "Neurologia";
                    break;
                case 9:
                    nombre = "Alergia e inmunologia";
                    break;
                case 10:
                    nombre = "Cirugia";
                    break;
                case 11:
                    nombre = "Pediatria";
                    break;
                case 12:
                    nombre = "Clinica medica";
                    break;
                case 13:
                    nombre = "Dermatologia";
                    break;
                case 14:
                    nombre = "Endocrinologia";
                    break;
                case 15:
                    nombre = "Obstetricia";
                    break;
                case 16:
                    nombre = "Oftamologia";
                    break;
                case 17:
                    nombre = "Oncologia";
                    break;
                case 18:
                    nombre = "Otorrinolaringologia";
                    break;
                case 19:
                    nombre = "Psicologia";
                    break;
                case 20:
                    nombre = "Fonoaudiologia";
                    break;


            }
            return nombre;

        }
    }
}