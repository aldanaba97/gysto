using Gysto.AccesoDatos;
using Gysto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gysto.Controllers
{
    public class ReporteController : Controller
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
    }
}