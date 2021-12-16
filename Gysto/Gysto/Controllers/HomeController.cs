using Gysto.AccesoDatos;
using Gysto.Filters;
using Gysto.Models;
using Gysto.ViewModels;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using static Gysto.Models.Enum;

namespace Gysto.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {

            return View();
        }
     
        public ActionResult About()
        {
           
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult print ()
        {
            return new ActionAsPdf("About") { FileName = "Tes.pdf" };
        }

  
        public ActionResult Contact()
        {
            //swal("Good job!", "You clicked the button!", "success");
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string nombreUsuario, string contraseña)
        {
            try
            {
                using (Models.GystoEntities5 g = new Models.GystoEntities5())
                {
                    var oUser = (from d in g.Usuarios where d.nombre == nombreUsuario && d.contraseña == contraseña select d).FirstOrDefault();
                    if (oUser == null)
                    {

                        ViewBag.Error = "Usuario Incorrecto"; 
                        return View();
                    }
                    Session["user"] = oUser;
                    Session["Rol"] = oUser.id_rol;
                    string id = oUser.id_usuario.ToString(); 
                    FormsAuthentication.SetAuthCookie(id, true);


                    return RedirectToAction("index2", "home");


                }
            }

            catch (Exception)
            {
                return View();
            }





        
        }
        //public ActionResult Login(string nombreUsuario, string contraseña, int rol)
        //{
        //    if (!string.IsNullOrEmpty(nombreUsuario) && !string.IsNullOrEmpty(contraseña))
        //    {
        //        bool u = AdoUsuarios.AccederLogin(nombreUsuario, contraseña, rol);

        //        if (u)
        //        {
        //            Usuario usu = AdoUsuarios.obtenerusuario(nombreUsuario, contraseña, rol);
        //            Session["nombre"] = nombreUsuario;
        //            //TempData["rol"] = usu.rol;
        //            //int i = (int)Membership.GetUser().ProviderUserKey;
        //            FormsAuthentication.SetAuthCookie(nombreUsuario, true);
        //            //string id = User.Identity.Name;

        //            return RedirectToAction("contact", "home");
        //        }

        //        else
        //        {
        //            return RedirectToAction("Login", "Home");
        //        }

        //    }
        //    return View();



        //}

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Terminos ()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult Terminos (string acepta)
        {
            if (acepta == "on")
            {
                return RedirectToAction("Index", "Home"); 
            }
            else
            {
                return View(); 
            }

        }
        public ActionResult Index2 ()
        {
            return View(); 
        }
    }
}