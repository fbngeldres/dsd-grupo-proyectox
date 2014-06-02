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
                Placa = objAlquiler.Auto.Placa
            };

            UsuarioModel usuarioModel = new UsuarioModel()
            {
                Nombres = objAlquiler.Usuario.Nombres,
                Apellidos = objAlquiler.Usuario.Apellidos
            };

            AlquilerModel alquilerModel = new AlquilerModel()
            {
                Costo = objAlquiler.Costo,
                CostoAdicional = objAlquiler.CostoAdicional,
                Auto = autoModel,
                Usuario = usuarioModel
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
                //auto.Marca = "Audi R8";

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

    }
}
