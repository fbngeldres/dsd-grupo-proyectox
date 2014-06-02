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
        private AutoModel inicializarListas() {
            AutoModel auto = new AutoModel();
            auto.lstCategorias = new List<SelectListItem>();
            auto.lstModelos = new List<SelectListItem>();
            auto.lstMarcas = new List<SelectListItem>();

            SelectListItem item = null;
            item = new SelectListItem
            {
                Value = "0",
                Text = "-- Seleccione --"
            };

            auto.lstMarcas.Add(item);
            auto.lstModelos.Add(item);
            auto.lstCategorias.Add(item);

            wsAutoService.AutoServiceClient proxy = new wsAutoService.AutoServiceClient();

            List<wsAutoService.Marca> lstMarcas = proxy.listarMarcas().ToList();
            foreach (wsAutoService.Marca l in lstMarcas)
            {
                item = new SelectListItem
                {
                    Value = l.Codigo.ToString(),
                    Text = l.Descripcion
                };
                auto.lstMarcas.Add(item);
            }

            List<wsAutoService.Modelo> lstModelos = proxy.listarModelos().ToList();
            foreach (wsAutoService.Modelo l in lstModelos)
            {
                item = new SelectListItem
                {
                    Value = l.Codigo.ToString(),
                    Text = l.Descripcion
                };
                auto.lstModelos.Add(item);
            }

            List<wsAutoService.Categoria> lstCategorias = proxy.listarCategorias().ToList();
            foreach (wsAutoService.Categoria l in lstCategorias)
            {
                item = new SelectListItem
                {
                    Value = l.Codigo.ToString(),
                    Text = l.Descripcion
                };
                auto.lstCategorias.Add(item);
            }
            return auto;
        }

        public ActionResult BuscarAutoAlquilar() {
            AutoModel auto = inicializarListas();

            return View(auto);
        }

        public ActionResult ResultadoBusquedaAuto(AutoModel model) {
            wsAutoService.AutoServiceClient proxy = new wsAutoService.AutoServiceClient();
            List<wsAutoService.Auto> autos = proxy.listarResultadoAutos(model.Marca, model.Modelo, model.PrecioMinimo, model.PrecioMaximo, model.Categoria).ToList();

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
