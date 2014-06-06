using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SanJacinto.Models;
using System.Net;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Text;
using System.IO;
using SanJacinto.JsonObjects;

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


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:1281/AutosServices.svc/Autos");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string autoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<AutoJson> listaAutosJson = js.Deserialize<List<AutoJson>>(autoJson);


            List<AutoModel> listaAuto = new List<AutoModel>();
            foreach (var autoBean in listaAutosJson)
            {
                AutoModel auto = new AutoModel()
                {
                    
                    Codigo = autoBean.Codigo ,
                    MarcaDesc = autoBean.Marca.Descripcion,
                    ModeloDesc = autoBean.Modelo.Descripcion,
                    PrecioMinimo = autoBean.Precio,
                    Placa = autoBean.Placa 
                };
                listaAuto.Add(auto); 
            }
           

            return View(listaAuto);
        }

        public ActionResult PlantillaAgregarAuto()
        {
            AutoModel auto = inicializarListas();
            System.Diagnostics.Debug.WriteLine("Auto---");

            return View(auto);
        }

        public ActionResult PlantillaModificarAuto(String codigo)
        {

            System.Diagnostics.Debug.WriteLine("Modificar---"+codigo);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:1281/AutosServices.svc/Autos/" + codigo);
            request.Method = "GET";
            HttpWebResponse respond = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(respond.GetResponseStream());
            string autoJson = reader.ReadToEnd();
            JavaScriptSerializer jsd = new JavaScriptSerializer();
            AutoJson autoObtenido = jsd.Deserialize<AutoJson>(autoJson);
            AutoModel auto = inicializarListas();
            
            AutoModel autoModel = new AutoModel() {
                Marca = autoObtenido.Marca .Codigo ,
                Modelo = autoObtenido.Modelo .Codigo ,
                Categoria = autoObtenido.Categoria .Codigo ,
                PrecioMinimo = autoObtenido.Precio ,
                Placa = autoObtenido.Placa ,
                Imagen = autoObtenido.Imagen ,
                lstCategorias = auto.lstCategorias,
                lstMarcas =auto .lstMarcas,
                lstModelos=auto .lstModelos 
            
            };

            return View(autoModel);
        }

        public ActionResult AgregarAuto(AutoModel model)
        {
            wsAutoService.Auto autoCrear = new wsAutoService.Auto()
            {
                Marca = new wsAutoService.Marca() { Codigo = model.Marca },
                Modelo = new wsAutoService.Modelo() { Codigo = model.Modelo },
                Precio = model.PrecioMinimo,
                Categoria = new wsAutoService.Categoria() { Codigo = model.Categoria },
                Placa = model.Placa,
                Estado = new wsAutoService.Estado() {Codigo=1 },
                Imagen = model.Imagen  
            };


            try {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string postdata = serializer.Serialize(autoCrear);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1281/AutosServices.svc/Autos");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string autoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            AutoJson autoCreado = js.Deserialize<AutoJson>(autoJson);

            System.Diagnostics.Debug.WriteLine("Auto---" + autoCreado.Codigo);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string mensaje=((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream()  );
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensajeError = js.Deserialize<string>(error);
                throw new Exception(mensajeError);
               
            }
            return RedirectToAction( "MantenimientoAuto","Auto");
        }


        public ActionResult ModificarAuto(AutoModel model)
        {
            System.Diagnostics.Debug.WriteLine("Auto---" + model.Codigo);
            wsAutoService.Auto autoModificar = new wsAutoService.Auto()
            {
                Codigo = model .Codigo ,
                Marca = new wsAutoService.Marca() { Codigo = model.Marca },
                Modelo = new wsAutoService.Modelo() { Codigo = model.Modelo },
                Precio = model.PrecioMinimo,
                Categoria = new wsAutoService.Categoria() { Codigo = model.Categoria },
                Placa = model.Placa,
                Estado = new wsAutoService.Estado() { Codigo = 1 },
                Imagen = model.Imagen
            };
            try {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string postdata = serializer.Serialize(autoModificar);
            System.Diagnostics.Debug.WriteLine("Auto---" + postdata);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1281/AutosServices.svc/Autos");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string autoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            AutoJson autoCreado = js.Deserialize<AutoJson>(autoJson);

            System.Diagnostics.Debug.WriteLine("Auto---" + autoCreado.Codigo);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string mensaje = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensajeError = js.Deserialize<string>(error);
                System.Diagnostics.Debug.WriteLine("Auto>>---" + mensajeError);
                throw new Exception(mensajeError);

            }
            return RedirectToAction("MantenimientoAuto", "Auto");
        }


        public ActionResult EliminarAuto(String codigoEliminar)
        {
        
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1281/AutosServices.svc/Autos/" + codigoEliminar);
            req.Method = "DELETE";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            return RedirectToAction("MantenimientoAuto", "Auto");
        }

        
    }
}
