using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SanJacinto.Models;

namespace SanJacinto.Controllers
{
    public class AlquilerController : Controller
    {
        public ActionResult CrearAlquiler(int intCodAuto, decimal dcPrecio, int intCodEstado,
            string strEstado, int intCodMarca, string strMarca, int intCodModelo, string strModelo)
        {
            AutoModel autoModel = new AutoModel()
            {
                Codigo = intCodAuto,
                PrecioMinimo = dcPrecio,
                EstadoDesc = strEstado,
                MarcaDesc = strMarca,
                ModeloDesc = strModelo
            };

            UsuarioModel usuarioModel = new UsuarioModel()
            {
                Codigo = 1,
                Nombres = "Ronal",
                Apellidos = "Crisostomo Matias"
            };

            AlquilerModel nuevoAlquiler = new AlquilerModel()
            {
                Auto = autoModel,
                Usuario = usuarioModel
            };

            return View(nuevoAlquiler);
        }

        public ActionResult RegistrarAlquiler(int CantidadDias, decimal strPrecioAuto, int intCodigoAuto, int intCodigoUsuario,
            string txtFechaInicio,string txtAccesorios,string txtCostoAdicional)
        {
            wsAlquiler.AlquilerServiceClient miAlquiler = new wsAlquiler.AlquilerServiceClient();

            wsAlquiler.Alquiler objAlquiler = new wsAlquiler.Alquiler();
            objAlquiler.Costo = strPrecioAuto;
            objAlquiler.CantidadDias = CantidadDias;

            if(txtCostoAdicional.Length > 0 )
                objAlquiler.CostoAdicional = Convert.ToDecimal(txtCostoAdicional);

            objAlquiler.Accesorios = txtAccesorios;

            decimal subMonto = objAlquiler.Costo * CantidadDias;
            decimal igv = Convert.ToDecimal(0.18);
            objAlquiler.Igv = igv * subMonto;
            objAlquiler.MontoTotal = subMonto + objAlquiler.Igv + objAlquiler.CostoAdicional;

            DateTime fecInicio = Convert.ToDateTime(txtFechaInicio);
            DateTime fecFin = fecInicio.AddDays(CantidadDias);
            objAlquiler.FechaInicio = fecInicio;
            objAlquiler.FechaFin = fecFin;

            objAlquiler = miAlquiler.registrarAlquiler(objAlquiler, intCodigoAuto, intCodigoUsuario);

            AutoModel autoModel = new AutoModel()
            {
                MarcaDesc = objAlquiler.Auto.Marca.Descripcion,
                ModeloDesc = objAlquiler.Auto.Modelo.Descripcion,
                Imagen = objAlquiler.Auto.Imagen
            };

            AlquilerModel alquilerModel = new AlquilerModel()
            {
                FechaFin = objAlquiler.FechaFin,
                Auto = autoModel
            };

            return View(alquilerModel);
        }

        public ActionResult ListarAlquileres()
        {
            wsAlquiler.AlquilerServiceClient miAlquiler = new wsAlquiler.AlquilerServiceClient();
            List<wsAlquiler.Alquiler> listaAlquileres = miAlquiler.listaAlquileres().ToList();

            AlquilerModel alquilerModel;
            List<AlquilerModel> listaAlquilerModel = new List<AlquilerModel>();
            foreach (var item in listaAlquileres)
            {
                AutoModel auto = new AutoModel();
                auto.MarcaDesc = item.Auto.Marca.Descripcion;

                alquilerModel = new AlquilerModel();
                alquilerModel.Auto = auto;
                alquilerModel.Costo = item.Costo;
                alquilerModel.CostoAdicional = item.CostoAdicional;
                alquilerModel.Accesorios = item.Accesorios;
                alquilerModel.CantidadDias = item.CantidadDias;
                alquilerModel.FechaInicio = item.FechaInicio;
                listaAlquilerModel.Add(alquilerModel);
            }

            return View(listaAlquilerModel);
        }


        public ActionResult DevolverVehiculo(string idAuto)
        {

           

            System.Diagnostics.Debug.WriteLine("PRUEBA" + idAuto);
            System.Diagnostics.Debug.WriteLine("-" + idAuto + "-");

            wsAlquiler.AlquilerServiceClient proxy = new wsAlquiler.AlquilerServiceClient();

            wsAlquiler.Alquiler alquiler=  proxy.RealizarDevolucion(Int32.Parse(  idAuto));

            if(alquiler.Auto.Estado.Codigo ==1   ){
                //Exception no se realizo devolucion
            }


            List<wsAlquiler.Alquiler> listaAlquiler = proxy.listaAlquileres().ToList<wsAlquiler.Alquiler>();


            return View(transformarListaAlquilerToListAlquilerModel(listaAlquiler));
            
        }
        List<AutoModel> transformarListaAlquilerToListAlquilerModel(List<wsAlquiler.Alquiler> listaAlquiler)
        {

            List<AutoModel> listaAlquilerModel = new List<AutoModel>();
            System.Diagnostics.Debug.WriteLine("PRUEBA" + listaAlquiler.Count);
            foreach (var item in listaAlquiler)
            {
                MarcaModel marcaModel = new MarcaModel()
                {
                    Codigo = item.Auto.Marca.Codigo,
                    Descripcion = item.Auto.Marca.Descripcion
                };

                ModeloModel modeloModel = new ModeloModel()
                {
                    Codigo = item.Auto.Modelo.Codigo,
                    Descripcion = item.Auto.Modelo.Descripcion
                };

                EstadoModel estradoModel = new EstadoModel()
                {
                    Codigo = item.Auto.Estado.Codigo,
                    Descripcion = item.Auto.Estado.Descripcion
                };


                AutoModel auto = new AutoModel()
                {


                    Codigo = item.Codigo,
                    Marca = 1,
                    Modelo = 1,
                    Estado = 1,
                    Placa = item.Auto.Placa,
                    Imagen = item.Auto.Imagen,

                };
                listaAlquilerModel.Add(auto);
            }

            return listaAlquilerModel;
        }

        public ActionResult ListarAutosDevolucion()
        {
            
            wsAlquiler.AlquilerServiceClient proxy = new wsAlquiler.AlquilerServiceClient();

           List<wsAlquiler.Alquiler> listaAlquiler = proxy.listaAlquileres().ToList<wsAlquiler.Alquiler>();



           return View(transformarListaAlquilerToListAlquilerModel(listaAlquiler));
        }
    }
}
