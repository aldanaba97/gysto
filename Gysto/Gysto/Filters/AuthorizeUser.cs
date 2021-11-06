using Gysto.AccesoDatos;
using Gysto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gysto.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeUser : AuthorizeAttribute
    {
        private Usuarios oUsuario;
        private GystoEntities5 g = new GystoEntities5(); 
        private int idOperacion; 


        public AuthorizeUser(int idOperacion = 0)
        {
            this.idOperacion = idOperacion; 
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            try {

                oUsuario = (Usuarios)HttpContext.Current.Session["user"];
                var listUsuario = from m in g.permisoxroles
                                  where m.id_rol == oUsuario.id_rol && m.id_permiso == idOperacion
                                  select m;
                //List <Usuario> lis = AdoUsuarios.ListadoUsuarioConPermiso(idOperacion);
                
                if (listUsuario.ToList().Count() == 0 )
                {
                    filterContext.Result = new RedirectResult("~/Shared/Error");
                }
            }
            catch (Exception) {
                filterContext.Result = new RedirectResult("~/Shared/Error");
                    }
         
        }
    }
}