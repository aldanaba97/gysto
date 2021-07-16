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
                switch (si_button)
                {
                    case "Eliminar":
                        bool resultado = AdoTransacciones.eliminarInternacion(model);
                        if (resultado)
                        {
                            return RedirectToAction("TodasInternaciones", "Transacciones");
                        }
                        break;
                    case "Actualizar":
                        bool resultado2 = AdoTransacciones.ActualizarInternacion(model);
                        if (resultado2)
                        {
                            return RedirectToAction("TodasInternaciones", "Transacciones");
                        }
                        break;
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
                    return RedirectToAction("ListadoConsultas", "Transacciones");
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


            Consulta resultado = AdoTransacciones.ObtenerConsultaParaCerrar(idConsulta); 

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
        public ActionResult ListadoConsulta()
        {
            List<ListadoConsulta> lista = AdoTransacciones.ListadoConsultas();
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
                string si_button = Request.Form["button"].ToString();
                switch (si_button)
                {
                    case "Eliminar":
                        bool resultado = AdoTransacciones.eliminarConsulta(model);
                        if (resultado)
                        {
                            return RedirectToAction("ListadoConsulta", "Transacciones");
                        }
                        break;
                    case "Actualizar":
                        bool resultado2 = AdoTransacciones.ActualizarConsulta(model);
                        if (resultado2)
                        {
                            return RedirectToAction("ListadoConsulta", "Transacciones");
                        }
                        break;
                }
            }
            return View();

        }
        [HttpPost]
        public ActionResult ModificarConsultaDx(Consulta model)
        {

            if (ModelState.IsValid)
            {

                bool resultado2 = AdoTransacciones.CerrarConsulta(model);
                if (resultado2)
                {
                    return RedirectToAction("ConsultaCerradas", "Transacciones");
                }
                else
                {
                    return View();
                }
            }
            else { return View();
            }
                
           
            

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
                string si_button = Request.Form["button"].ToString();
                switch (si_button)
                {
                    case "eliminar":
                        bool resultado = AdoTransacciones.eliminarTurno(model);
                        if (resultado)
                        {
                            return RedirectToAction("ListadoTurno", "Transacciones");
                        }
                        break;
                    case "actualizar":
                        bool resultado2 = AdoTransacciones.ActualizarTurno(model);
                        if (resultado2)
                        {
                            return RedirectToAction("ListadoTurno", "Transacciones");
                        }
                        break;
                }
            }
            return View();

        }

        public ActionResult TodosTurnos()
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
            ViewBag.items = Items;

            List<turno> lista = AdoTransacciones.ListadoTurnosDisponibles();
            return View(lista);
        }

        [HttpPost]
        public ActionResult TodosTurnos(int medico)
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
            ViewBag.items = Items;

            List<turno> lista = AdoTransacciones.ListadoxOrden(medico);
            return View(lista);
        }
        public ActionResult TurnoSacado()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult TurnoSacado(string dni)
        //{
        //    /*ist<turno> lista = AdoTransacciones.ListadoxOrden();*/
        //    return View();
        //}
        public ActionResult Datosxdni(string dni)
        {
            paciente resultado = AdoTransacciones.listadoxDni(dni);
            turno i  = AdoTransacciones.listadoxDniTurno(dni);


            SacarTurno st = new SacarTurno();
            st.turno = i;
            st.p = resultado; 
            return View(st);
        }
        [HttpPost]
        public ActionResult Datosxdni(turno model )
        {
            if (ModelState.IsValid)
            {

                bool resultado2 = AdoTransacciones.ConfirmarTurno(model); 
                if (resultado2)
                {
                    return RedirectToAction("TodosTurnos", "Transacciones");
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

    }
}