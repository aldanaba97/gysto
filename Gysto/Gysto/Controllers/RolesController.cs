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
    public class RolesController : BaseController
    {
        // GET: Roles
        public ActionResult Medico ()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult Medico(Medico model)
        {
            bool resultado = AdoRoles.InsertarMedico(model);
            if (resultado)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
             return View();
            }   

            
        }
       
        public ActionResult Administrador ()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult Administrador(Administrador model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AdoRoles.InsertarAdministrativo(model); 
                if (resultado)
                {
                    return RedirectToAction("ListadoUsuario", "Usuario");
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
        public ActionResult Paciente(int id = 0)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AdoRoles.Insertarpaciente(); 
                if (resultado)
                {
                    Alert("Excelente", "Se ha creado un nuevo paciente", Models.Enum.NotificationType.success);
                    return RedirectToAction("Index2", "Home");
                }
                else
                {
                    return View();
                }

            }
            else
            {
                return View();
            }

        }
        public ActionResult ListadoPaciente(string dni)
        {
            paciente r = AdoTransacciones.listadoxDni(dni);
            return View(r);
        }
        [HttpPost]
        public ActionResult ModificarMedico(MedicoValidar model)
        {

            if (!ModelState.IsValid)
            {
                if(model.id_espe == 0)
                {
  List<Especialidad> listaew = Ado.ListadoEspecialidad();
                List<SelectListItem> Itemsespew = listaew.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.nombre,
                        Value = d.id_especialidad.ToString(),
                        Selected = false

                    };
                });
                ViewBag.itemsespe = Itemsespew;
                    ModelState.AddModelError("tratamiento", "Seleccione una especialidad");
                }
        
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
                    return View(model);
                    

             

            }
            else
            {  
                bool resultado2 = AdoRoles.ActualizarMedico(model);
                  if (resultado2)
                {
                    Alert("Exitoso", "Se guardaron sus datos", Models.Enum.NotificationType.success); 
                    return RedirectToAction("Index2", "Home");
                }
                else
                {

                    return View(model);
                }
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
            MedicoValidar resultado = AdoRoles.ObtenerMedico(id);

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
        public ActionResult ModificarDirectorMedico(int id)
        {

            director_medico resultado = AdoRoles.Obtenerdirector(id);
            return View(resultado);
        }
        [HttpPost]
        public ActionResult ModificarDirectorMedico(director_medico model)
        {

            if (ModelState.IsValid)
            {
                bool resultado2 = AdoRoles.ActualizarDirector(model);
               
                if (resultado2)
                {
                    return RedirectToAction("PerfilUsuarioDirector", "Roles", new { Name = model.id }); 
                    


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