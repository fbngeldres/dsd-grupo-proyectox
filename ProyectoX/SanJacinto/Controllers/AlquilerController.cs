using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SanJacinto.Models;
using System.Net;
using System.ServiceModel;
using System.Web.Security;

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
                Codigo = 2
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
            wsUsuarioService.UsuarioServiceClient proxyUsuario = new wsUsuarioService.UsuarioServiceClient();  
            FormsIdentity id = (FormsIdentity)this.User.Identity;
            FormsAuthenticationTicket ticket = id.Ticket;
            wsUsuarioService.Usuario usuario = proxyUsuario.ObtenerUsuarioPorCorreo(ticket.Name);
            intCodigoUsuario = usuario.Codigo;
            System.Diagnostics.Debug.WriteLine("intCodigoUsuario " + intCodigoUsuario);
            System.Diagnostics.Debug.WriteLine("ticket " + ticket.Name  );

            wsAlquiler.AlquilerServiceClient miAlquiler = new wsAlquiler.AlquilerServiceClient();
            System.Diagnostics.Debug.WriteLine("strPrecioAuto " + strPrecioAuto);
            System.Diagnostics.Debug.WriteLine("CantidadDias " + CantidadDias);
            wsAlquiler.Alquiler objAlquiler = new wsAlquiler.Alquiler();
            objAlquiler.Costo = strPrecioAuto;
            objAlquiler.CantidadDias = CantidadDias;

            if(txtCostoAdicional.Length > 0 )
                objAlquiler.CostoAdicional = Convert.ToDecimal(txtCostoAdicional);

            System.Diagnostics.Debug.WriteLine("txtAccesorios " + txtAccesorios);
            

            objAlquiler.Accesorios = txtAccesorios;

            System.Diagnostics.Debug.WriteLine("txtAccobjAlquiler.Costo " + objAlquiler.Costo);

            System.Diagnostics.Debug.WriteLine("CantidadDias " + CantidadDias);

            decimal subMonto = objAlquiler.Costo * CantidadDias;
            decimal igv = Convert.ToDecimal(0.18);
            objAlquiler.Igv = igv * subMonto;
            objAlquiler.MontoTotal = subMonto + objAlquiler.Igv + objAlquiler.CostoAdicional;
            System.Diagnostics.Debug.WriteLine(" objAlquiler.Igv  " + objAlquiler.Igv);
            System.Diagnostics.Debug.WriteLine(" objAlquiler.MontoTotal  " + objAlquiler.MontoTotal);
            System.Diagnostics.Debug.WriteLine(txtFechaInicio);
            System.Diagnostics.Debug.WriteLine("Paso error");
            DateTime fecInicio = Convert.ToDateTime(txtFechaInicio);
            DateTime fecFin = fecInicio.AddDays(CantidadDias);
            objAlquiler.FechaInicio = fecInicio;
            objAlquiler.FechaFin = fecFin;
            System.Diagnostics.Debug.WriteLine("fecInicio " + fecInicio);
            System.Diagnostics.Debug.WriteLine("fecFin " + fecFin);
            try
            {
                objAlquiler = miAlquiler.registrarAlquiler(objAlquiler, intCodigoAuto, intCodigoUsuario);
            }
            catch (FaultException<wsAlquiler.ValidationException> ex)
            {
                Console.WriteLine(ex.Detail.ValidationError);
                throw new Exception(ex.Detail.ValidationError, ex);
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message, ex);
            }

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

            wsAlquiler.Alquiler alquiler = proxy.RealizarDevolucion(Int32.Parse(idAuto));

            if(alquiler.Auto.Estado.Codigo ==1   ){
                //Exception no se realizo devolucion
            }

            return RedirectToAction("ListarAutosDevolucion", "Alquiler");
            
        }
        List<AutoModel> transformarListaAlquilerToListAlquilerModel(List<wsAlquiler.Alquiler> listaAlquiler)
        {

            List<AutoModel> listaAlquilerModel = new List<AutoModel>();
            System.Diagnostics.Debug.WriteLine("PRUEBA" + listaAlquiler.Count);
            foreach (var item in listaAlquiler)
            {
                               AutoModel auto = new AutoModel()
                {


                    Codigo = item.Codigo,
                    MarcaDesc = item.Auto.Marca.Descripcion,
                    ModeloDesc = item.Auto.Modelo.Descripcion,
                    EstadoDesc = item.Auto.Estado .Descripcion ,
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
