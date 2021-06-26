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
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Usuario()
        {
            List<Rol> listaRol = AdoUsuarios.ComboboxRol();
            List<SelectListItem> Items = listaRol.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre,
                    Value = d.id.ToString(),
                    Selected = false

                };
            });
            List<localidad> listaloc = AdoUsuarios.comboLocalidad();
            List<SelectListItem> Itemslocalidad = listaloc.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre,
                    Value = d.id.ToString(),
                    Selected = false

                };
            });
            List<tipoDNI> listadni = AdoUsuarios.ComboboxTipoDNI();
            List<SelectListItem> Itemsdni = listadni.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombreDNI,
                    Value = d.id.ToString(),
                    Selected = false

                };
            });

            ViewBag.itemsloc = Itemslocalidad;

            ViewBag.itemsdni = Itemsdni;
            ViewBag.itemsrol = Items;

            return View();

        }
        [HttpPost]
        public ActionResult Usuario(Persona model, HttpPostedFileBase image, string rol)
        {
            if (ModelState.IsValid)
            {
                string ruta = Server.MapPath("~/imagenesUsuario/");
                ruta += image.FileName;
                model.SubirImagenUsuario(ruta, image);
                model.image = image.FileName;
                bool resultado = AdoUsuarios.InsertarPersonaUsuario(model);
                if (resultado)
                {
                  
                    switch (rol)
                    {
                        case "1":
                          return RedirectToAction("Medico", "Roles");
                        case "2":
                            return RedirectToAction("DirectorMedico", "Roles");
                        case "3":
                            return RedirectToAction("Administrativo", "Roles");                           
                        case "4":
                            return RedirectToAction("ListadoUsuario", "Usuario");                  
                        case "5":
                            return RedirectToAction("Enfermero", "Roles");
                        case "1002":
                            return RedirectToAction("Paciente", "Roles");
                    }
                }
                else
                {
                    return View(model);
                }
            }
           
                return View(model);
            
        }
        public ActionResult ModificarUsuario(int idPersona)
        {
            List<Rol> listaRol = AdoUsuarios.ComboboxRol();
            List<SelectListItem> Items = listaRol.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre,
                    Value = d.id.ToString(),
                    Selected = false

                };
            });
            List<localidad> listaloc = AdoUsuarios.comboLocalidad();
            List<SelectListItem> Itemslocalidad = listaloc.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre,
                    Value = d.id.ToString(),
                    Selected = false

                };
            });
            List<tipoDNI> listadni = AdoUsuarios.ComboboxTipoDNI();
            List<SelectListItem> Itemsdni = listadni.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombreDNI,
                    Value = d.id.ToString(),
                    Selected = false

                };
            });



            Persona resultado = AdoUsuarios.obtenerPersona(idPersona);

            foreach (var item in Itemslocalidad)
            {
                if (item.Value.Equals(resultado.localidad.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }
            foreach (var item in Items)
            {
                if (item.Value.Equals(resultado.rol.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }
            foreach (var item in Itemsdni)
            {
                if (item.Value.Equals(resultado.id_dni.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }
          

            ViewBag.itemsloc = Itemslocalidad;

            ViewBag.itemsdni = Itemsdni;
            ViewBag.itemsrol = Items;
            ViewBag.nombre = resultado.nombre + ' ' + resultado.apellido;

            return View(resultado);


        }
        public ActionResult ListadoUsuario()
        {
            List<listado> lista = AdoUsuarios.Listadopersona();
            return View(lista);
        }

        [HttpPost]
        public ActionResult ModificarUsuario(Persona model)
        {

            if (ModelState.IsValid)
            {
                string si_button = Request.Form["button"].ToString();
                switch (si_button)
                {
                    case "Eliminar":
                        bool resultado = AdoUsuarios.EliminarUsuario(model);
                        if (resultado)
                        {
                            // TempData["del"] = "true"; 
                            return RedirectToAction("ListadoUsuario", "Usuario");
                        }
                        break;
                    case "actualizar":
                        bool resultado2 = AdoUsuarios.ActualizarDatosPersona(model);
                        if (resultado2)
                        {
                            return RedirectToAction("ListadoUsuario", "Usuario");
                        }
                        break;


                }
            }
            return View();
        }
    }
}