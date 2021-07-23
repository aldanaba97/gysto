using Gysto.AccesoDatos;
using Gysto.Models;
using Gysto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Gysto.Controllers
{
    public class HomeController : Controller
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

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
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
            ViewBag.item = Items;

            return View();
        }
            [HttpPost]
            public ActionResult Login(string nombreUsuario, string contraseña, int rol)
            {
                if (!string.IsNullOrEmpty(nombreUsuario) && !string.IsNullOrEmpty(contraseña))
                {   
                bool exist = AdoUsuarios.AccederLogin(nombreUsuario, contraseña, rol);
                    if(exist){
                        FormsAuthentication.SetAuthCookie(nombreUsuario, true);
                         return RedirectToAction("contact","home");
                    }
                    else
                    {
                    return RedirectToAction("Index","Home"); 
                    }
                }
                else
                {
                return RedirectToAction("Index", "Home");
                }

            }

        [Authorize]
        public ActionResult Logout ()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");  
        }
    }
}