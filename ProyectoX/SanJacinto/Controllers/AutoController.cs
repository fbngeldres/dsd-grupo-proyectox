using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanJacinto.Controllers
{
    public class AutoController : Controller
    {
        public ActionResult BuscarAutoAlquilar() {
            return View();
        }

        public ActionResult ResultadoBusquedaAuto() {
            return View();
        }
        
    }
}
