using Gysto.AccesoDatos;
using Gysto.Filters;
using Gysto.ViewModels;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gysto.Controllers
{
    
    public class ReporteController : BaseController
    {
    
    
        // GET: Reporte
        public ActionResult Enfermedadxcantidad()
        {
            List<reportesEnfermedad> enfermedad = AdoReporte.ListadoReporte();
           foreach (var i in enfermedad)
            {
                ViewBag.n = i.enfermedad;
                ViewBag.can = i.cantidad;
            }
            string datos;
            datos = "[['task', 'hours'],";

           foreach (var item  in enfermedad)
           {
                datos = datos + "[";
                datos = datos + "'" + item.enfermedad + "'" + "," + item.cantidad;
                datos = datos + "],";

            }
            datos = datos + "]";
            ViewBag.lista = datos;

            return View();
        }

        public ActionResult CantidadConsultasxaño()
        {
            List<reporteConsultas> consultas = AdoReporte.ListadoConsultasTodas();
            foreach (var i in consultas)
            {
                ViewBag.n = i.nombre;
                ViewBag.can = i.cantidad;
            }
            string datos;
            datos = "[['task', 'Consultas'],";

            foreach (var item in consultas)
            {
                datos = datos + "[";
                datos = datos + "'" + item.nombre + "'" + "," + item.cantidad;
                datos = datos + "],";

            }
            datos = datos + "]";
            ViewBag.lista = datos;

            return View();
        }
        [HttpPost]
        public ActionResult CantidadConsultasxaño (string combo)
        {
            List<reporteConsultas> consultas = AdoReporte.ListadoConsultasxaño(combo);
            foreach (var i in consultas)
            {
                ViewBag.n = i.nombre;
                ViewBag.can = i.cantidad;
            }
            string datos;
            datos = "[['task', 'Consultas'],";

            foreach (var item in consultas)
            {
                datos = datos + "[";
                datos = datos + "'" + item.nombre + "'" + "," + item.cantidad;
                datos = datos + "],";

            }
            datos = datos + "]";
            ViewBag.lista = datos;

            ViewBag.año = "CONSULTAS DEL AÑO " + combo; 
            return View();
        }
        public ActionResult pdfEnfermedad()
        {
            List<reporteConsultas> consultas = AdoReporte.ListadoConsultasTodas();
            foreach (var i in consultas)
            {
                ViewBag.n = i.nombre;
                ViewBag.can = i.cantidad;
            }
            string datos;
            datos = "[['task', 'Consultas'],";

            foreach (var item in consultas)
            {
                datos = datos + "[";
                datos = datos + "'" + item.nombre + "'" + "," + item.cantidad;
                datos = datos + "],";

            }
            datos = datos + "]";
            ViewBag.lista = datos;
            return View(); 
        }
        public ActionResult print()
        {
            return new ActionAsPdf("CantidadConsultasxaño") { FileName = "reporteEnfermedad.pdf" };
        }
    }
}