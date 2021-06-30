using Gysto.AccesoDatos;
using Gysto.Models;
using Gysto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gysto.Controllers
{
    public class TransaccionesController : Controller
    {
        // GET: Transacciones
  
        public ActionResult Internacion ()
        {
            List<comboEnfermero> listaRol = AdoRoles.ListadoEnfermero();
            List<SelectListItem> Items = listaRol.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre,
                    Value = d.id.ToString(),
                    Selected = false

                };
            });
            ViewBag.items = Items;

            return View(); 
        }
        [HttpPost]
        public ActionResult Internacion(internacion model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AdoTransacciones.InsertarTransacciones(model);
                if (resultado)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(model);
                }

            }
            else
            {
                return View(model);
            }

        }
        public ActionResult ObtenerDatos (int idInternacion)
        {
            List<comboEnfermero> listaRol = AdoRoles.ListadoEnfermero();
            List<SelectListItem> Items = listaRol.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre,
                    Value = d.id.ToString(),
                    Selected = false

                };
            });
            ViewBag.items = Items;
            internacion resultado = AdoTransacciones.obtenerInternacion(idInternacion);
            foreach (var item in Items)
            {
                if (item.Value.Equals(resultado.enfermero.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }
            return View(resultado); 

        }
        public ActionResult ListadoInternacion()
        {
            List<internacion> lista = AdoTransacciones.ListadoInternacion(); 
            return View(lista);
        }
    }
}