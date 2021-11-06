using Gysto.Controllers;
using Gysto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gysto.Filters
{
    public class VerificarSesion : ActionFilterAttribute
    {
        private Usuarios oUser;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                oUser = (Usuarios)HttpContext.Current.Session["user"];
                if (oUser == null)
                {
                    if (filterContext.Controller is HomeController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Home/Login");
                    }
                }
            }

            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Home/Login"); 
            }


        }
    }
}