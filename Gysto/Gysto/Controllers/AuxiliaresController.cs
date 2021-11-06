using Gysto.AccesoDatos;
using Gysto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gysto.Controllers
{
    public class AuxiliaresController : Controller
    {
        // GET: Auxiliares
        public ActionResult Especialidades()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Especialidades(Especialidad modelo, HttpPostedFileBase imagen)

        {
            //  string ruta = Server.MapPath("~/imagenes/");
            //HttpPostedFile file = null;
            //ruta += file.FileName;

            //file.SaveAs(ruta);
            if (ModelState.IsValid)
            {


                string ruta = Server.MapPath("~/imagenes/");
                ruta += imagen.FileName;
                modelo.SubirImagen(ruta, imagen);
                modelo.imagen = imagen.FileName;

                bool resultado = Ado.InsertarEspecialidad(modelo);
                if (resultado)
                {
                    return RedirectToAction("ListadoEspecialidad", "auxiliares");
                }
                else
                {
                    return View(modelo);
                }

            }
            else
            {
                return View(modelo);
            }
            

        }
        public ActionResult ListadoEspecialidad()
        {
            List<Especialidad> lista = Ado.ListadoEspecialidad();
            return View(lista);
        }
        public ActionResult BEspecialidad(int idEspecialidad)
        {
            Especialidad resultado = Ado.obtenerEspe(idEspecialidad);
            ViewBag.nombre = resultado.nombre;

            return View(resultado);
        }
        [HttpPost]
        public ActionResult BEspecialidad(Especialidad model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = Ado.EliminarEspe(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoEspecialidad", "auxiliares");
                }
                else
                {
                    return View(resultado);
                }
            }

            return View();
        }

        public ActionResult MEspecialidad(int idEspecialidad, HttpPostedFileBase imagen)
        {
          
            Especialidad resultado = Ado.obtenerEspe(idEspecialidad);
            ViewBag.nombre = resultado.nombre;
            ViewBag.imagen = resultado.imagen; 
            return View(resultado);
        }
        [HttpPost]
        public ActionResult MEspecialidad(Especialidad model, HttpPostedFileBase imagen)
        {
            
            if (ModelState.IsValid)
            {
           
            string ruta = Server.MapPath("~/imagenes/");
            ruta += imagen.FileName;
            model.SubirImagen(ruta, imagen);
            model.imagen = imagen.FileName;
            bool resultado = Ado.ActualizarDatosEspecialidad(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoEspecialidad", "auxiliares");
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
        public ActionResult Enfermedad()
        {
            return View();
        }
        [HttpPost]

        //ENFERMEDAD
        public ActionResult Enfermedad(Enfermedad modelo)
        {
            if (ModelState.IsValid)
            {
                bool resultado = Ado.InsertarEnfermedad(modelo);
                if (resultado)
                {
                    return RedirectToAction("ListadoEnfermedad", "auxiliares");
                }
                else
                {
                    return View(modelo);
                }
            }
            else
            {
                return View(modelo);
            }

        }
        public ActionResult ListadoEnfermedad()
        {
            List<Enfermedad> lista = Ado.listadoEnfermedad(); 
            return View(lista);
        }
        public ActionResult BEnfermedad(int idEnfermedad)
        {
            Enfermedad resultado = Ado.obtenerEnfermedad(idEnfermedad);
            ViewBag.nombre = resultado.nombreEnfermedad;

            return View(resultado);
        }
        [HttpPost]
        public ActionResult BEnfermedad (Enfermedad model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = Ado.EliminarEnfermedad(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoEnfermedad", "auxiliares");
                }
                else
                {
                    return View(resultado);
                }
            }

            return View();
        }

        public ActionResult MEnfermedad(int idEnfermedad)
        {
            Enfermedad resultado = Ado.obtenerEnfermedad(idEnfermedad);
            ViewBag.nombre = resultado.nombreEnfermedad;
            return View(resultado);
        }
        [HttpPost]
        public ActionResult MEnfermedad(Enfermedad model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = Ado.ActualizarDatosEnfermedades(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoEnfermedad", "auxiliares");
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
        //TRATAMIENTO
        public ActionResult Tratamiento()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Tratamiento(Tratamiento modelo)
        {
            if (ModelState.IsValid)
            {
                bool resultado = Ado.InsertarTratamiento(modelo);
                if (resultado)
                {
                    return RedirectToAction("ListadoTratamientos", "auxiliares");
                }
                else
                {
                    return View(modelo);
                }
            }
            else
            {
                return View(modelo);
            }

        }
        public ActionResult ListadoTratamientos()
        {
            List<Tratamiento> lista = Ado.ComboboxTratamiento();
            return View(lista);
        }
       
        [HttpPost]
        public ActionResult MTratamientos (Tratamiento t)
        {
            if (ModelState.IsValid)
            {

                string si_button = Request.Form["button"].ToString();
                switch (si_button)
                {
                    case "Eliminar":
                        bool resultado = Ado.EliminarTratamiento(t);
                        if (resultado)
                        {
                            // TempData["del"] = "true"; 
                            return RedirectToAction("ListadoTratamientos", "auxiliares");
                        }
                        break;
                    case "Actualizar":
                        bool resultado2 = Ado.ActualizarDatosTratamiento(t);
                        if (resultado2)
                        {
                            // TempData["del"] = "true"; 
                            return RedirectToAction("ListadoTratamientos", "auxiliares");
                        }
                        break; 

                }
            }
   
            return View();
        }

        public ActionResult MTratamientos(int idTratamiento)
        {
            Tratamiento resultado = Ado.obtenerTratamiento(idTratamiento);
            ViewBag.nombre = resultado.nombre;
            return View(resultado);
        }
       
    }
}
