using Gysto.AccesoDatos;
using Gysto.Models;
using Gysto.ViewModels;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using static Gysto.Models.Enum;

namespace Gysto.Controllers
{
    public class TransaccionesController : BaseController
    {
        // GET: Transacciones
        string urlDomain = "https://localhost:44399/"; 

        public ActionResult Internacion()
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
                    Alert("Excelente", "Se ha creado una nueva internacion", NotificationType.success);
                    return RedirectToAction("ListadoInternacion", "Transacciones");
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
        public ActionResult obtenerInternacion(int idInternacion)
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
                string si_button = Request.Form["button"].ToString();
            
                  
                   
                        bool resultado2 = AdoTransacciones.ActualizarInternacion(model);
                        if (resultado2)
                        {
                            return RedirectToAction("TodasInternaciones", "Transacciones");
                        }
                  
                
            }
            return View();

        }
        public ActionResult TodasInternaciones()
        {
            List<listadoInternaciones> lista = AdoTransacciones.ListadoTodasInternaciones();
            return View(lista);
        }
        public ActionResult Consulta()
        {
            List<comboAdministrativo> listaRol = AdoRoles.ListadoAdministrativo();
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
            List<SelectListItem> ItemsPaciente = listaPacient.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre,
                    Value = d.id.ToString(),
                    Selected = false

                };
            });
            List<Tratamiento> trata = Ado.ComboboxTratamiento();
            List<SelectListItem> ItemsTratamiento = trata.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre,
                    Value = d.id_tratamiento.ToString(),
                    Selected = false

                };
            });
            List<comboMedico> listame = AdoRoles.ListadoMedico();
            List<SelectListItem> ItemsM = listame.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombreCompleto + " - " + d.espe,
                    Value = d.id_med.ToString(),
                    Selected = false

                };
            });

            ViewBag.itemsM = ItemsM;
            ViewBag.itemsA = Items;
            ViewBag.itemsP = ItemsPaciente;
            ViewBag.itemsT = ItemsTratamiento;
            return View();
        }
        [HttpPost]
        public ActionResult Consulta(Consulta model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AdoTransacciones.InsertarConsulta(model);
                if (resultado)
                {
                    Alert("Excelente", "Se ha creado una nueva consulta", NotificationType.success); 
                    return RedirectToAction("ListadoConsulta", "Transacciones");
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
        public ActionResult ConsultaCerradas()
        {
            List<ListadoConsulta> lista = AdoTransacciones.ListadoConsultasCerradas(); 
            return View(lista);
        }
        public ActionResult ModificarConsultaDx (int idConsulta)
        {
            //List<comboAdministrativo> listaRol = AdoRoles.ListadoAdministrativo();
            //List<SelectListItem> Items = listaRol.ConvertAll(d =>
            //{
            //    return new SelectListItem()
            //    {
            //        Text = d.nombre,
            //        Value = d.id.ToString(),
            //        Selected = false

            //    };
            //});
            //List<comboPaciente> listaPacient = AdoRoles.ListadoPaciente();
            //List<SelectListItem> ItemsPaciente = listaPacient.ConvertAll(d =>
            //{
            //    return new SelectListItem()
            //    {
            //        Text = d.nombre,
            //        Value = d.id.ToString(),
            //        Selected = false

            //    };
            //});
            List<Tratamiento> trata = Ado.ComboboxTratamiento();
            List<SelectListItem> ItemsTratamiento = trata.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre,
                    Value = d.id_tratamiento.ToString(),
                    Selected = false

                };
            });
            //List<comboMedico> listame = AdoRoles.ListadoMedico();
            //List<SelectListItem> ItemsM = listame.ConvertAll(d =>
            //{
            //    return new SelectListItem()
            //    {
            //        Text = d.nombreCompleto + " - " + d.espe,
            //        Value = d.id_med.ToString(),
            //        Selected = false

            //    };
            //});


            cerrarConsulta resultado = AdoTransacciones.ObtenerConsultaParaCerrar(idConsulta); 

            //foreach (var item in Items)
            //{
            //    if (item.Value.Equals(resultado.id_administracion.ToString()))
            //    {
            //        item.Selected = true;
            //        break;
            //    }
            //}
            //foreach (var item in ItemsPaciente)
            //{
            //    if (item.Value.Equals(resultado.id_paciente.ToString()))
            //    {
            //        item.Selected = true;
            //        break;
            //    }
            //}
            //foreach (var item in ItemsM)
            //{
            //    if (item.Value.Equals(resultado.medico.ToString()))
            //    {
            //        item.Selected = true;
            //        break;
            //    }
            //}
            
            //ViewBag.itemsM = ItemsM;
            //ViewBag.itemsA = Items;
            //ViewBag.itemsP = ItemsPaciente;
            ViewBag.itemsT = ItemsTratamiento;
            return View(resultado);
        }
        public ActionResult ListadoConsulta()
        {
            List<ListadoConsulta> lista = AdoTransacciones.ListadoConsultas();
            return View(lista);
        }
        public ActionResult ListadoConsultasxMedico(int Name)
        {
            int idMedico = AdoTransacciones.obtenerIdMedico(Name);
            List<ListadoConsulta> lista = AdoTransacciones.ListadoConsultaxMedico(idMedico);
            return View(lista);
        }
        public ActionResult obtenerConsulta(int idConsulta)
        {
            List<comboAdministrativo> listaRol = AdoRoles.ListadoAdministrativo();
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
            List<SelectListItem> ItemsPaciente = listaPacient.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre,
                    Value = d.id.ToString(),
                    Selected = false

                };
            });
            List<Tratamiento> trata = Ado.ComboboxTratamiento();
            List<SelectListItem> ItemsTratamiento = trata.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre,
                    Value = d.id_tratamiento.ToString(),
                    Selected = false

                };
            });
            List<comboMedico> listame = AdoRoles.ListadoMedico();
            List<SelectListItem> ItemsM = listame.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombreCompleto + " - " + d.espe,
                    Value = d.id_med.ToString(),
                    Selected = false

                };
            });


            Consulta resultado = AdoTransacciones.ObtenerConsulta(idConsulta);

            foreach (var item in Items)
            {
                if (item.Value.Equals(resultado.id_administracion.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }
            foreach (var item in ItemsPaciente)
            {
                if (item.Value.Equals(resultado.id_paciente.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }
            foreach (var item in ItemsM)
            {
                if (item.Value.Equals(resultado.medico.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }
            ViewBag.itemsM = ItemsM;
            ViewBag.itemsA = Items;
            ViewBag.itemsP = ItemsPaciente;
            ViewBag.itemsT = ItemsTratamiento;
            return View(resultado);
        }
        [HttpPost]
        public ActionResult obtenerConsuta(Consulta model)
        {

            if (ModelState.IsValid)
            {
             
                        bool resultado2 = AdoTransacciones.ActualizarConsulta(model);
                        if (resultado2)
                        {
                            return RedirectToAction("ListadoConsulta", "Transacciones");
                        }
                
            }
            return View();

        }
       
        [HttpPost]
        public ActionResult ModificarConsultaDx(cerrarConsulta model)
        {

            if (!ModelState.IsValid)
            {
                if (model.tratamiento == 0)
                {
                    List<Tratamiento> tratam = Ado.ComboboxTratamiento();
                    List<SelectListItem> ItemsTratamientos = tratam.ConvertAll(d =>
                    {
                        return new SelectListItem()
                        {
                            Text = d.nombre,
                            Value = d.id_tratamiento.ToString(),
                            Selected = false

                        };
                    });
                    ViewBag.itemsT = ItemsTratamientos;
                    ModelState.AddModelError("tratamiento", "Seleccione un estado"); 
                   
                }
                List<Tratamiento> trata = Ado.ComboboxTratamiento();
                List<SelectListItem> ItemsTratamiento = trata.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.nombre,
                        Value = d.id_tratamiento.ToString(),
                        Selected = false

                    };
                });
                ViewBag.itemsT = ItemsTratamiento;
                return View(model);
            }
            else { 

              bool resultado2 = AdoTransacciones.CerrarConsulta(model);
                if (resultado2)
                {
                    Alert("Exitoso", "Consulta cerrada correctamente", NotificationType.success);
                    return RedirectToAction("Index2", "Home");
                }
                else
                {
                    return View();
                }
            }
                
           
            

        }
        public ActionResult eliminarTurno(int id)
        {
            bool resultado = AdoTransacciones.eliminarTurno(id);
            if (resultado)
            {
                Alert("ELIMINADO", "Turno eliminado correctamente", NotificationType.success); 
                return Content("1");
                
            }

            return Content("1");
        }
        public ActionResult eliminarConsulta(int id)
        {
            bool resultado = AdoTransacciones.eliminarConsulta(id);
            if (resultado)
            {
                Alert("ELIMINADO", "Turno eliminado correctamente", NotificationType.success);
                return Content("1");

            }

            return Content("1");
        }
        public ActionResult eliminarInternacion(int id)
        {
            bool resultado = AdoTransacciones.eliminarInternacion(id);
            if (resultado)
            {
                Alert("ELIMINADO", "Turno eliminado correctamente", NotificationType.success);
                return Content("1");

            }

            return Content("1");
        }
        public ActionResult Turno()
        {
            List<comboMedico> listaRol = AdoRoles.ListadoMedico();
            List<SelectListItem> Items = listaRol.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombreCompleto + " - " + d.espe,
                    Value = d.id_med.ToString(),
                    Selected = false

                };
            });

            ViewBag.items = Items;
            return View();
        }
        [HttpPost]
        public ActionResult Turno(turno model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AdoTransacciones.InsertarTurno(model);
                if (resultado)
                {
                    Alert("Excelente", "Se ha creado un nuevo turno", NotificationType.success);
                    return RedirectToAction("ListadoTurno", "Transacciones");
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
        public ActionResult ListadoTurno()
        {
            List<listadoTurnos> lista = AdoTransacciones.ListadoTurno();
            return View(lista);
        }
            
        public ActionResult obtenerTurno(int idTurno)
        {
            List<comboMedico> listaRol = AdoRoles.ListadoMedico();
            List<SelectListItem> Items = listaRol.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombreCompleto + " - " + d.espe,
                    Value = d.id_med.ToString(),
                    Selected = false

                };
            });

            turno resultado = AdoTransacciones.ObtenerTurno(idTurno);
            foreach (var item in Items)
            {
                if (item.Value.Equals(resultado.medico.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }

            ViewBag.items = Items;

            return View(resultado);

        }
       

        [HttpPost]
        public ActionResult obtenerTurno(turno model)
        {

            if (ModelState.IsValid)
            {
             
                        bool resultado2 = AdoTransacciones.ActualizarTurno(model);
                        if (resultado2)
                        {
                            return RedirectToAction("ListadoTurno", "Transacciones");
                        }

                
            }
           
            return View();

        }

        public ActionResult TodosTurnos()
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

            List<TurnoMedico> lista = AdoTransacciones.ListadoTurnosDisponibles();
            return View(lista);
        }

        [HttpPost]
        public ActionResult TodosTurnos(int id_espe)
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

            List<TurnoMedico> lista = AdoTransacciones.ListadoxOrden(id_espe);
            return View(lista);
        }
        public ActionResult TurnoSacado(int idTurno)
        {
            turno i = AdoTransacciones.listadoxDniTurno(idTurno);
            SacarTurno s = new SacarTurno();
            s.turno = i;
         
         return View(s);
            
        }
        //[HttpPost]
        //public ActionResult TurnoSacado(string dni)
        //{
        //    /*ist<turno> lista = AdoTransacciones.ListadoxOrden();*/
        //    return View();
        //}
        public ActionResult Datosxdni(SacarTurno model)
        {

            string dni = model.p.dni.ToString();
            paciente resultado = AdoTransacciones.listadoxDni(dni);
            turno i  = AdoTransacciones.listadoxDniTurno(model.turno.id_turno);


            SacarTurno st = new SacarTurno();
            st.turno = i;
            st.p = resultado; 
            return View(st);
        }
        [HttpPost]
        public ActionResult Datosxdni(SacarTurno model, string dni)
        {
              
                bool resultado2 = AdoTransacciones.ConfirmarTurno(model);
                bool resultado3 = AdoTransacciones.ActualizarTurnoxemail(model.turno);
                TurnoMedico tm = AdoTransacciones.obtenerTurnoxMed(model.turno.id_turno); 

                if (resultado2 && resultado3)
                {
                    Alert("Felicitaciones", "Se envio un correo a" + model.turno.email, NotificationType.success);
                    EnviarMail(model.turno.email, model.turno.id_turno, tm); 
                    return RedirectToAction("TodosTurnos", "Transacciones");
                   
                }
     
                else
                {
                    return View(model);
                }

            
      
          
           
        }
       
       
        public ActionResult HistoriaClinica()
        {
            List<comboPaciente> listaPacient = AdoRoles.ListadoPaciente();
            List<SelectListItem> ItemsPaciente = listaPacient.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre,
                    Value = d.id.ToString(),
                    Selected = false

                };
            });

            ViewBag.items = ItemsPaciente;
            return View(); 
        }
        [HttpPost]
        public ActionResult HistoriaClinica(historiaClinica model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AdoTransacciones.InsertarHistoriaClinica(model);
                if (resultado)
                {
                    Alert("Excelente", "Se ha creado una nueva historia clinica", NotificationType.success);
                    return RedirectToAction("DetalleHC", "Transacciones");
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
        public ActionResult DetalleHC() {
            List<Enfermedad> listaE = Ado.Combobox();
            List<SelectListItem> ItemsEnfermedad = listaE.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombreEnfermedad,
                    Value = d.id_enfe.ToString(),
                    Selected = false

                };
            });
            ViewBag.itemsE = ItemsEnfermedad; 
            return View(); 
        }
        [HttpPost]
        public ActionResult DetalleHC(detalleHistoriaClinica model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AdoTransacciones.InsertarDetalleHistoria(model);
                if (resultado)
                {
                    Alert("Excelente", "Se ha creado una nuevo detalle", NotificationType.success);
                    return RedirectToAction("DetalleHC", "Transacciones");
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
        public ActionResult ListadoHC()
        {
            List<listadoHistoriaClinica> lista = AdoTransacciones.ListadoHistorias();
            return View(lista);
        }
        public ActionResult EditarHC(int id)
        {
            List<comboPaciente> listaPacient = AdoRoles.ListadoPaciente();
            List<SelectListItem> ItemsPaciente = listaPacient.ConvertAll(dd =>
            {
                return new SelectListItem()
                {
                    Text = dd.nombre,
                    Value = dd.id.ToString(),
                    Selected = false

                };
            });

            ViewBag.items = ItemsPaciente;
            historiaClinica hc = AdoTransacciones.ObtenerHC(id);
            List<detalleHistoriaClinica> d = AdoTransacciones.listadoDetalle(id);

            foreach (var item in ItemsPaciente)
            {
                if (item.Value.Equals(hc.paciente.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }

            DatosHistoriaClinica da = new DatosHistoriaClinica();
            da.hc = hc;
            da.detalle = d; 
            return View(da);

        }
        [HttpPost]
        public ActionResult EditarHC(DatosHistoriaClinica model)
        {

            if (ModelState.IsValid)
            {
              
                       
                        bool resultado2 = AdoTransacciones.ActualizarHC(model);
                        if (resultado2)
                        {
                    Alert("Excelente", "Se ha modificado la historia clinica", NotificationType.success);
                    return RedirectToAction("ListadoHC", "Transacciones");
                        }
                 
                
            }
            return View();

        }

        public ActionResult EditarDetalle(int idDetalle)
        {
            List<Enfermedad> listaE = Ado.Combobox();
            List<SelectListItem> ItemsEnfermedad = listaE.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombreEnfermedad,
                    Value = d.id_enfe.ToString(),
                    Selected = false

                };
            });
            ViewBag.itemsE = ItemsEnfermedad;

            detalleHistoriaClinica de = AdoTransacciones.ObtenerDetalle(idDetalle);

            return View(de);

        }
        [HttpPost]
        public ActionResult EditarDetalle(detalleHistoriaClinica model)
        {

            if (ModelState.IsValid)
            {
             
                        bool resultado2 = AdoTransacciones.ActualizarDetalle(model);
                        if (resultado2)
                        {
                    Alert("Excelente", "Se ha modificado un detalle", NotificationType.success);
                    return RedirectToAction("ListadoHC", "Transacciones");
                        }
                else
                {
                    return View(); 
                }          
               
            }

            return View();

        }
        [HttpPost]
        public ActionResult eliminarDetalle(int id)
        {
            bool resultado = AdoTransacciones.eliminarDetalle(id);
            if (resultado)
            {
                return Content("1");
            }

            return Content("1");
        }
        public ActionResult PerfilHC(int id, string g )
        {
            List<comboMedico> listaRol = AdoRoles.ListadoMedico();
            List<SelectListItem> Items = listaRol.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombreCompleto,
                    Value = d.id_med.ToString(),
                    Selected = false

                };
            });
            
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
           
            

            List<ConsultaxHistoria> listadoC = AdoTransacciones.listadoConsultaxHistoria(id);
            List<InternacionxHistoria> listadoH = AdoTransacciones.ListadoInternacionxHistoria(id);
            perfilHistoriaClinica resultado = AdoTransacciones.ObtenerPerfilHC(id);
            int pac = AdoTransacciones.ObtenerPacientexid(id);
            historiaCta c = new historiaCta();
            c.perfil = resultado;
            c.consulta = listadoC;
            c.internacion = listadoH;
            c.paciente = pac; 

            
            
            ViewBag.items = Items;
            ViewBag.itemsespe = Itemsespe;
            return View(c); 
        
        }
        [HttpPost]
        public ActionResult PerfilHC(int paciente, int medico = 0 , int id_espe = 0 , string fecha1 = "", string fecha2 = "" )
        {
            List<comboMedico> listaRol = AdoRoles.ListadoMedico();
            List<SelectListItem> Items = listaRol.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombreCompleto,
                    Value = d.id_med.ToString(),
                    Selected = false

                };
            });

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
           ViewBag.items = Items;
            ViewBag.itemsespe = Itemsespe;

            List<ConsultaxHistoria> lista = null; 
            if (medico != 0 && id_espe == 0 & fecha1 == "" && fecha2 == "")
            {
               
                lista = AdoTransacciones.FiltroConsultaxMedico(paciente, medico);
             
            }
            else if (id_espe != 0 && medico == 0 && fecha1 == "" && fecha2 == "")
            {
       

                lista = AdoTransacciones.FiltroConsultaxEspe(paciente,id_espe);
            
            }
            else if (fecha1 != "" && fecha2 != "" && id_espe == 0 && medico == 0)
            {
                lista = AdoTransacciones.FiltroConsultaxFecha(paciente, fecha1, fecha2);
            
            }
            else if (fecha1 != "" && fecha2 != "" && id_espe != 0 && medico != 0)
            {
                lista = AdoTransacciones.FiltroConsultaxTodos(paciente, fecha1, fecha2, id_espe, medico);

            }
            List<InternacionxHistoria> listadoH = AdoTransacciones.ListadoInternacionxHistoria(paciente);
            perfilHistoriaClinica resultado = AdoTransacciones.ObtenerPerfilHC(paciente);
            int pac = AdoTransacciones.ObtenerPacientexid(paciente);
            historiaCta c = new historiaCta();
            c.perfil = resultado;
            c.consulta = lista;
            c.internacion = listadoH;
            c.paciente = paciente;

            return View(c);
        
        }
        public ActionResult ModificarDisponibilidad(int id)
        {
            turno t = new turno();
            t.id_turno = id; 
            return View(t); 
        }
        [HttpPost]
        public ActionResult ModificarDisponibilidad(turno model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AdoTransacciones.ActualizarTurnoxdispo(model);
                if(resultado)
                {
 return RedirectToAction("TodosTurnos", "Transacciones");
                }
               
            }
            return View(); 
        }

        public ActionResult print(int id)
        {
            return new ActionAsPdf("HCImprimir/" + id) { FileName = "HC.pdf" };
        }
        public ActionResult print2(int id)
        {
            return new ActionAsPdf("Comprobante/" + id) { FileName = "Turno.pdf" };
        }
        public ActionResult Comprobante (int id)
        {
            listadoTurnos l = AdoTransacciones.ListadoTurnoxid(id);
            return View(l); 
        }
        public ActionResult HCImprimir (int id)
        {
            List<ConsultaxHistoria> listadoC = AdoTransacciones.listadoConsultaxHistoria(id);
            List<InternacionxHistoria> listadoH = AdoTransacciones.ListadoInternacionxHistoria(id);
            perfilHistoriaClinica resultado = AdoTransacciones.ObtenerPerfilHC(id);
            int pac = AdoTransacciones.ObtenerPacientexid(id);
            historiaCta c = new historiaCta();
            c.perfil = resultado;
            c.consulta = listadoC;
            c.internacion = listadoH;
            c.paciente = pac;

            return View(c);
         
        }

        #region HELPERS
        private void EnviarMail(string emailDestino, int id, TurnoMedico model)
        {
            string emailOrigen = "hospitalvicenteaguero2021@gmail.com";
            string contraseña = "123456aldana";
            string url = urlDomain + "/Transacciones/ModificarDisponibilidad?id=" + id;
            string url2 = urlDomain + "/Transacciones/print2?id=" + id;

            MailMessage mandarMail = new MailMessage(emailOrigen, emailDestino, "Turno generado", "<h4>Usted ha sacado un turno en el Hospital regional de vicente aguero</h4><br/>"+
                "<p>Detalles del turno</p><br/><ul><li>Hora de atencion: " + model.hora2() +"</li><br/><li>Fecha: "+ model.fecha2() + "</li><br/><li>Medico:  " + model.apellido +", "+ model.nombre + "</li></ul><br/>" 
                + "<a href='" + url + "'>Click aqui si quiere cancelar turno</a>" + "<br/>" + 
               "<a href='" + url2 + "'>Descargar comprobante</a>)");

            mandarMail.IsBodyHtml = true;

            SmtpClient cliente = new SmtpClient("smtp.gmail.com");
            cliente.EnableSsl = true;
            cliente.UseDefaultCredentials = false;
            cliente.Port = 587;
            cliente.Credentials = new System.Net.NetworkCredential(emailOrigen, contraseña);
            cliente.Send(mandarMail);
            cliente.Dispose();

        }
        #endregion

    }

}
