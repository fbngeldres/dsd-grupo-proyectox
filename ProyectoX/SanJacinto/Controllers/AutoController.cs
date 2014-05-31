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
            wsAutoService.AutoServiceClient proxy = new wsAutoService.AutoServiceClient();
            List<wsAutoService.Marca> lstMarcas = proxy.listarMarcas().ToList();
            List<wsAutoService.Modelo> lstModelos = proxy.listarModelos().ToList();
            List<wsAutoService.Categoria> lstCategorias = proxy.listarCategorias().ToList();
            return View();
        }

        public ActionResult ResultadoBusquedaAuto() {
            wsAutoService.AutoServiceClient proxy = new wsAutoService.AutoServiceClient();
            List<wsAutoService.Auto> autos = proxy.listarResultadoAutos(0, 0, 0, 0, 0).ToList();
            
            return View(autos);
            
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
