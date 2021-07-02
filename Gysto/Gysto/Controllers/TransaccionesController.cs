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
            List<comboPaciente> listaPacient = AdoRoles.ListadoPaciente();
            List<SelectListItem> ItemsPaciente = listaRol.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre,
                    Value = d.id.ToString(),
                    Selected = false

                };
            });
            ViewBag.items = Items;
            ViewBag.item = ItemsPaciente; 
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
        public ActionResult obtenerInternacion  (int idInternacion)
        {
            internacion resultado = AdoTransacciones.obtenerInternacion(idInternacion);
            return View(resultado); 

        }

        [HttpPost]
        public ActionResult obtenerInternacion(internacion model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AdoTransacciones.ActualizarFecha(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoInternacion", "Transacciones");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View();
            }

        }
        public ActionResult ListadoInternacion()
        {
            List<listadoInternaciones> lista = AdoTransacciones.ListadoInternacion(); 
            return View(lista);
        }
        public ActionResult editarInternacion(int idInternacion)
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
            List<comboPaciente> listaPacient = AdoRoles.ListadoPaciente();
            List<SelectListItem> ItemsPaciente = listaRol.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre,
                    Value = d.id.ToString(),
                    Selected = false

                };
            });
           
            internacion resultado = AdoTransacciones.ObtenerDatosInternacion(idInternacion);
            foreach (var item in Items)
            {
                if (item.Value.Equals(resultado.enfermero.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }
            foreach (var item in ItemsPaciente)
            {
                if (item.Value.Equals(resultado.paciente.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }
            ViewBag.items = Items;
            ViewBag.item = ItemsPaciente;
            return View(resultado);

        }
        [HttpPost]
        public ActionResult editarInternacion(internacion model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AdoTransacciones.ActualizarInternacion(model);
                if (resultado)
                {
                    return RedirectToAction("TodasInternaciones", "Transacciones");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View();
            }

        }
        public ActionResult TodasInternaciones()
        {
            List<listadoInternaciones> lista = AdoTransacciones.ListadoInternacion();
            return View(lista);
        }
    }
}