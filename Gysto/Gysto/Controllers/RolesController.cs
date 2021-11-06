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
        [HttpPost]
        public ActionResult ModificarMedico(Medico model)
        {

            if (ModelState.IsValid)
            {
                bool resultado2 = AdoRoles.ActualizarMedico(model);
                //switch (rol)
                //{
                //    case "1":
                //        return RedirectToAction("ModificarMedico", "Roles");
                //    case "2":
                //        return RedirectToAction("ModificarDirectorMedico", "Roles");
                //    case "3":
                //        return RedirectToAction("ModificarAdministrador", "Roles");
                //    //case "4":
                //    //    return RedirectToAction("ModificarTecnico", "Usuario");
                //    case "5":
                //        return RedirectToAction("ModificarEnfermero", "Roles");
                //    case "1002":
                //        return RedirectToAction("ModificarPaciente", "Roles");
                //}                         
                if (resultado2)
                {
                    return RedirectToAction("Index2", "Home");
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
        public ActionResult ModificarMedico(int id)
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
            Medico resultado = AdoRoles.ObtenerMedico(id);

            foreach (var item in Itemsespe)
            {
                if (item.Value.Equals(resultado.id_espe.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }
            return View(resultado);
        }
        public ActionResult PerfilUsuarioMedico(int Name)
        {

            Medico resultado = AdoRoles.PerfilMedico(Name);
            return View(resultado);
        }

        public ActionResult PerfilUsuarioDirector(int Name)
        {

            director_medico resultado = AdoRoles.PerfilDirectorMedico(Name);
            return View(resultado);
        }
        public ActionResult PerfilUsuarioAdministrativo(int Name)
        {

            Administrador resultado = AdoRoles.PerfilAdministrativo(Name);
            return View(resultado);
        }
        public ActionResult PerfiUsuarioEnfermero(int Name)
        {

            Enfermero resultado = AdoRoles.PerfilEnfermero(Name);
            return View(resultado);
        }
        [HttpPost]
        public ActionResult ModificarDirectorMedico(director_medico model)
        {

            if (ModelState.IsValid)
            {
                bool resultado2 = AdoRoles.ActualizarDirector(model);
                //switch (rol)
                //{
                //    case "1":
                //        return RedirectToAction("ModificarMedico", "Roles");
                //    case "2":
                //        return RedirectToAction("ModificarDirectorMedico", "Roles");
                //    case "3":
                //        return RedirectToAction("ModificarAdministrador", "Roles");
                //    //case "4":
                //    //    return RedirectToAction("ModificarTecnico", "Usuario");
                //    case "5":
                //        return RedirectToAction("ModificarEnfermero", "Roles");
                //    case "1002":
                //        return RedirectToAction("ModificarPaciente", "Roles");
                //}                         
                if (resultado2)
                {
                    return RedirectToAction("Index2", "Home");
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
        public ActionResult ModificarDirectorMedico(int id)
        {

            director_medico resultado = AdoRoles.Obtenerdirector(id);
            return View(resultado);
        }
        [HttpPost]
        public ActionResult ModificarEnfermero(Enfermero model)
        {

            if (ModelState.IsValid)
            {
                bool resultado2 = AdoRoles.ActualizarEnfermero(model);
                //switch (rol)
                //{
                //    case "1":
                //        return RedirectToAction("ModificarMedico", "Roles");
                //    case "2":
                //        return RedirectToAction("ModificarDirectorMedico", "Roles");
                //    case "3":
                //        return RedirectToAction("ModificarAdministrador", "Roles");
                //    //case "4":
                //    //    return RedirectToAction("ModificarTecnico", "Usuario");
                //    case "5":
                //        return RedirectToAction("ModificarEnfermero", "Roles");
                //    case "1002":
                //        return RedirectToAction("ModificarPaciente", "Roles");
                //}                         
                if (resultado2)
                {
                    return RedirectToAction("Index2", "Home");
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
        public ActionResult ModificarEnfermero(int id)
        {

            Enfermero resultado = AdoRoles.Obtenerenfermero(id);
            return View(resultado);
        }
    
      
    }
}