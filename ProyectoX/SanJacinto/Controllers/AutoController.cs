using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SanJacinto.Models;

namespace SanJacinto.Controllers
{
    public class AutoController : Controller
    {
        public ActionResult BuscarAutoAlquilar() {
            return View();
        }

        public ActionResult ResultadoBusquedaAuto() {
            //SanJacintoServices


            //List<AutoModel> model = 
            return View();
        }

        public ActionResult RegistrarAuto()
        {
            return View();
        }

        public ActionResult MantenimientoAuto()
        {
            return View();
        }

        
    }
}
