using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SanJacinto.Models;

namespace SanJacinto.Controllers
{
    public class ReporteController : Controller
    {
        //
        // GET: /Reporte/

        public ActionResult BuscarAutoReporte()
        {
            return View();
        }

        public ActionResult ResultadoBusquedaMejoresAuto(ReporteModel model)
        {
            wsReporteService.ReportingServicesClient proxy = new wsReporteService.ReportingServicesClient();
            DateTime fecInicio = Convert.ToDateTime(model.FechaInicioCadena);
            DateTime fecFin = Convert.ToDateTime(model.FechaFinCadena); 
            return View(proxy.listarAutosMasAlquilados(fecInicio, fecFin));

        }
    }
}
