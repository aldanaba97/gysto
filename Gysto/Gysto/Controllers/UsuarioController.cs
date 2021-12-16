using Gysto.AccesoDatos;
using Gysto.Models;
using Gysto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

using System.Web.Mvc;
using static Gysto.Models.Enum;

namespace Gysto.Controllers
{
    public class UsuarioController : BaseController
    {
        string urlDomain = "https://localhost:44399/";
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
            //List<localidad> listaloc = AdoUsuarios.comboLocalidad();
            //List<SelectListItem> Itemslocalidad = listaloc.ConvertAll(d =>
            //{
            //    return new SelectListItem()
            //    {
            //        Text = d.nombre,
            //        Value = d.id.ToString(),
            //        Selected = false

            //    };
            //});
            //List<tipoDNI> listadni = AdoUsuarios.ComboboxTipoDNI();
            //List<SelectListItem> Itemsdni = listadni.ConvertAll(d =>
            //{
            //    return new SelectListItem()
            //    {
            //        Text = d.nombreDNI,
            //        Value = d.id.ToString(),
            //        Selected = false

            //    };
            //});

            //ViewBag.itemsloc = Itemslocalidad;

            //ViewBag.itemsdni = Itemsdni;
            ViewBag.itemsrol = Items;

            return View();

        }
        [HttpPost]
        public ActionResult Usuario(CrearUsuario model, HttpPostedFileBase imagen, string rol)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            { 
                string ruta = Server.MapPath("~/imagenesUsuario/");
                ruta += imagen.FileName;
                model.SubirImagenUsuario(ruta, imagen);
                model.imagen= imagen.FileName;
                bool resultado = AdoUsuarios.InsertarPersonaUsuario(model);
                if (resultado)
                {
                    int id = AdoUsuarios.UltimoId(); 
                    EnviarUsuario(model.email);
                    switch (rol)
                    {
                        case "1":
                            return RedirectToAction("Medico", "Roles");
                        case "2":
                            return RedirectToAction("DirectorMedico", "Roles");
                        case "3":
                            return RedirectToAction("Administrador", "Roles");
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
        public ActionResult UsuarioxAdmin()
        {

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


            return View();

        }
        [HttpPost]
        public ActionResult UsuarioxAdmin(CrearPaciente model)
        {
            if (ModelState.IsValid)
            { 
        
                bool resultado = AdoUsuarios.InsertarPersonaUsuarioxAdmin(model);
                if (resultado)
                {
                    
         return RedirectToAction("Paciente", "Roles");
                      
                    
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
        public ActionResult BUsuario(int id)
        {
            bool resultado = AdoUsuarios.BUsuario(id);
            if (resultado)
            {
                Alert("ELIMINADO", "Registro eliminado correctamente", NotificationType.success);
                return Content("1");

            }

            return Content("1");
        }
        public ActionResult ModificarUsuario(int id)
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



            Persona resultado = AdoUsuarios.obtenerPersona(id);

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
        public ActionResult ListadoUsuario(string nombre)
        {

            List<listado> lista2 = AdoUsuarios.FiltrarxPErsona(nombre);
            return View(lista2);

        }
        [HttpPost]
        public ActionResult ModificarUsuario(Persona model)
        {

            if (!ModelState.IsValid)
            {
                if (model.localidad == 0)
                {
                    List<Rol> listaRolw = AdoUsuarios.ComboboxRol();
                    List<SelectListItem> Itemsw = listaRolw.ConvertAll(d =>
                    {
                        return new SelectListItem()
                        {
                            Text = d.nombre,
                            Value = d.id.ToString(),
                            Selected = false

                        };
                    });
                    List<localidad> listalocw = AdoUsuarios.comboLocalidad();
                    List<SelectListItem> Itemslocalidadw = listalocw.ConvertAll(d =>
                    {
                        return new SelectListItem()
                        {
                            Text = d.nombre,
                            Value = d.id.ToString(),
                            Selected = false

                        };
                    });
                    List<tipoDNI> listadniw = AdoUsuarios.ComboboxTipoDNI();
                    List<SelectListItem> Itemsdniw = listadniw.ConvertAll(d =>
                    {
                        return new SelectListItem()
                        {
                            Text = d.nombreDNI,
                            Value = d.id.ToString(),
                            Selected = false

                        };
                    });
                    ViewBag.itemsloc = Itemslocalidadw;

                    ViewBag.itemsdni = Itemsdniw;
                    ViewBag.itemsrol = Itemsw;

                    ModelState.AddModelError("localidad", "Seleccione una localidad");
                }
                else if (model.rol == 0)
                {
                    List<Rol> listaRolw = AdoUsuarios.ComboboxRol();
                    List<SelectListItem> Itemsw = listaRolw.ConvertAll(d =>
                    {
                        return new SelectListItem()
                        {
                            Text = d.nombre,
                            Value = d.id.ToString(),
                            Selected = false

                        };
                    });
                    List<localidad> listalocw = AdoUsuarios.comboLocalidad();
                    List<SelectListItem> Itemslocalidadw = listalocw.ConvertAll(d =>
                    {
                        return new SelectListItem()
                        {
                            Text = d.nombre,
                            Value = d.id.ToString(),
                            Selected = false

                        };
                    });
                    List<tipoDNI> listadniw = AdoUsuarios.ComboboxTipoDNI();
                    List<SelectListItem> Itemsdniw = listadniw.ConvertAll(d =>
                    {
                        return new SelectListItem()
                        {
                            Text = d.nombreDNI,
                            Value = d.id.ToString(),
                            Selected = false

                        };
                    });
                    ViewBag.itemsloc = Itemslocalidadw;

                    ViewBag.itemsdni = Itemsdniw;
                    ViewBag.itemsrol = Itemsw;

                    ModelState.AddModelError("rol", "Seleccione un rol");
                }
                else if (model.id_dni == 0)
                {
                    List<Rol> listaRolw = AdoUsuarios.ComboboxRol();
                    List<SelectListItem> Itemsw = listaRolw.ConvertAll(d =>
                    {
                        return new SelectListItem()
                        {
                            Text = d.nombre,
                            Value = d.id.ToString(),
                            Selected = false

                        };
                    });
                    List<localidad> listalocw = AdoUsuarios.comboLocalidad();
                    List<SelectListItem> Itemslocalidadw = listalocw.ConvertAll(d =>
                    {
                        return new SelectListItem()
                        {
                            Text = d.nombre,
                            Value = d.id.ToString(),
                            Selected = false

                        };
                    });
                    List<tipoDNI> listadniw = AdoUsuarios.ComboboxTipoDNI();
                    List<SelectListItem> Itemsdniw = listadniw.ConvertAll(d =>
                    {
                        return new SelectListItem()
                        {
                            Text = d.nombreDNI,
                            Value = d.id.ToString(),
                            Selected = false

                        };
                    });
                    ViewBag.itemsloc = Itemslocalidadw;

                    ViewBag.itemsdni = Itemsdniw;
                    ViewBag.itemsrol = Itemsw;

                    ModelState.AddModelError("id_dni", "Seleccione un tipo de DNI");
                }
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
                return View(model);
            }
            else
            {
                bool resultado2 = AdoUsuarios.ActualizarDatosPersona(model);
                if (resultado2)
                {
                    Alert("Exitoso", "Se guardaran los datos", Models.Enum.NotificationType.success);
                    return RedirectToAction("Index2", "Home");
                }
                else
                {
                    return View(model);
                }

            }

        }
        public ActionResult BuscarEmail()
        {
            return View();
        }
        public ActionResult RecuperarContraxEmail(string email)
        {
            using (Models.GystoEntities5 db = new Models.GystoEntities5())
            {
                var user = db.Usuarios.Where(d => d.email == email).FirstOrDefault(); 
                if (user == null)
                {
  ViewBag.Messege = "No estas dentro de la base de datos";
                }
                else
                {
  ViewBag.email = user.email;
                ViewBag.Messege = "Estas dentro de la base de datos";
                    ViewBag.nombre = user.nombre;
                }
            

            }
        
              
            return View();

        }
        [HttpPost]
        public ActionResult RecuperarContraxEmail(Usuarios model)
        {

            string tok = Guid.NewGuid().ToString();

            using (Models.GystoEntities5 db = new Models.GystoEntities5())
            {
                var oUser = db.Usuarios.Where(d => d.email == model.email).FirstOrDefault();
                if (oUser != null)
                {
                    oUser.token = tok;
                    db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    EnviarMail(oUser.email, tok);
                }
            }

            return RedirectToAction("Index", "Home");



         
        }
        public ActionResult contraNeuva(string token)
        {
            ViewModelContraseña model = new ViewModelContraseña();
            model.token = token;
                return RedirectToAction("Index", "Home");
          }
        [HttpPost]
        public ActionResult contraNeuva(ViewModelContraseña contra)
        {
            if(!ModelState.IsValid)
            {
                return View(contra); 


            }
            using (Models.GystoEntities5 db = new GystoEntities5() )
            {
                var oUser = db.Usuarios.Where(d=> d.token == contra.token).FirstOrDefault();

                if(oUser != null)
                {
                    oUser.contraseña = contra.contra1;
                    db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges(); 
                }
            }
                return View();
        }

        //}
        #region HELPERS
        private void EnviarMail(string emailDestino, string token)
        {
            string emailOrigen = "hospitalvicenteaguero2021@gmail.com";
            string contraseña = "123456aldana";
            string url = urlDomain+ "/Usuario/contraNeuva?token="+token;

            MailMessage mandarMail = new MailMessage(emailOrigen, emailDestino, "Recuperacion de contraseña",
                "<p>Entre en el siguente enlace para recuperar su contraseña</p><br/>"
                + "<a href='" + url + "'>Click aqui</a>");

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
        #region HELPERS
        private void EnviarUsuario(string emailDestino)
        {
            string emailOrigen = "hospitalvicenteaguero2021@gmail.com";
            string contraseña = "123456aldana";
            string url = urlDomain + "/Home/Login";

            MailMessage mandarMail = new MailMessage(emailOrigen, emailDestino, "Creacio de usuario",
              "<p>Para acceder a su usuario coloque como nombre de usuario la palabra DNI y como contraseña su numero de DNI sin puntos</p><br/>" +
              "<ul><li>Usuario: DNI</li><li>Contraseña: su numero de dni sin puntos</ul><br/> <p>En el caso de que no pueda acceder a su usuario comuniquese al 153562498</p>" 
              
              + "<a href='" + url + "'>Click aqui</a>");

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
