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
            wsAutoService.AutoServiceClient proxy = new wsAutoService.AutoServiceClient();
            List<wsAutoService.Auto> autos = proxy.listarResultadoAutos(0, 0, 0, 0, 0).ToList();

            List<AutoModel> lstAutos = new List<AutoModel>();
            foreach(wsAutoService.Auto a in autos){


                //lstAutos.Add(a);
            }
            return View(lstAutos);
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
