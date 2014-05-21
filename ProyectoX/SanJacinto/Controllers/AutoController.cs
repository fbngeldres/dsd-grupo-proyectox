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
            autos.GetType().GetFields();
            List<AutoModel> lstAutos = new List<AutoModel>();

            AutoModel autoModel = null;
            ModeloModel modeloModel = null;
            EstadoModel estadoModel = null;
            MarcaModel marcaModel = null;

            foreach(wsAutoService.Auto a in autos){
                modeloModel = new ModeloModel(){
                    Codigo = a.Modelo.Codigo,
                    Descripcion = a.Modelo.Descripcion
                };

                marcaModel = new MarcaModel(){
                    Codigo = a.Marca.Codigo,
                    Descripcion = a.Marca.Descripcion
                };

                estadoModel = new EstadoModel(){
                    Codigo = a.Estado.Codigo,
                    Descripcion = a.Estado.Descripcion
                };

                autoModel = new AutoModel() { 
                    Codigo = a.Codigo,
                    Estado = estadoModel,
                    Imagen = a.Imagen,
                    Marca = marcaModel,
                    Modelo = modeloModel,
                    Placa = a.Placa,
                    Precio = a.Precio,
                    Categoria = a.Categoria
                };
                lstAutos.Add(autoModel);
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
