using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SanJacinto.Models;
using System.Web.Security;

namespace SanJacinto.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult RegistarUsuario()
        {
            return View();
        }

        public ActionResult RegistarUsuarioWeb(UsuarioModel model)
        {
            /*Los roles son los siguientes:
             1 = Administrador
             2 = Usuario normal*/
            int rol = 2;
            
            wsUsuarioService.UsuarioServiceClient proxy = new wsUsuarioService.UsuarioServiceClient();
            //CrearUsuario(string apellidos, string nombres, string telefono, string licencia, string dni, int codigo_rol, string correo, string clave)
            wsUsuarioService.Usuario regUsu = proxy.CrearUsuario(model.Apellidos, model.Nombres, model.Telefono, model.Licencia, model.Dni, rol, model.Correo, model.Clave);
            if (regUsu != null)
            {
                FormsAuthentication.SetAuthCookie(model.Correo, true);
                return RedirectToAction("Index", "Home");
            }
            else {
                return View(model);
            }
            
            
        }

        [HttpGet]
        public ActionResult LogOn() {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(UsuarioModel model) {
            wsUsuarioService.UsuarioServiceClient proxy = new wsUsuarioService.UsuarioServiceClient();
            wsUsuarioService.Usuario regUsu = proxy.AutenticarUsuario(model.Correo, model.Clave);

            if (regUsu != null) {
                FormsAuthentication.SetAuthCookie(model.Correo, true);

                string userData = regUsu.Nombres + " " + regUsu.Apellidos ;

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                  model.Correo,
                  DateTime.Now,
                  DateTime.Now.AddMinutes(15),
                  false,
                  userData,
                  FormsAuthentication.FormsCookiePath);

                string encTicket = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                return RedirectToAction("Index", "Home");
            }
            //return Content("thanks for submitting");
            return View(model);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }

    
}
