using Gysto.AccesoDatos;
using Gysto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gysto.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Medico()
        {
            List<Especialidad> listae = Ado.ListadoEspecialidad();
            List<SelectListItem> Itemsespe = listae.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre,
                    Value = d.id_especialidad.ToString(),
                    Selected = false

                };
            });
            ViewBag.itemsespe = Itemsespe;
            return View();
        }
        [HttpPost] 
        public ActionResult Medico (Medico model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AdoRoles.InsertarMedico(model);
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
        public ActionResult Administrador ()
        {
            return View(); 
        }
        public ActionResult Administrador(Administrador model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AdoRoles.InsertarAdministrativo(model); 
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
        public ActionResult Enfermero()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Enfermero(Enfermero model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AdoRoles.InsertarEnfermero(model);
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
        public ActionResult DirectorMedico()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DirectorMedico(director_medico model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AdoRoles.InsertarDirector(model);
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
        public ActionResult Paciente()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Paciente(paciente model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AdoRoles.Insertarpaciente(model); 
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
        public ActionResult ListadoPaciente(string dni)
        {
            paciente r = AdoTransacciones.listadoxDni(dni);
            return View(r);
        }
    }
}