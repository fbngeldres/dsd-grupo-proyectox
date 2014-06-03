using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace SanJacintoTest
{

    [TestClass]
    public class AutoRESTTest
    {
        [TestMethod]
        public void AgregarAutoTest()
        {
            Auto auto = new Auto();
            auto.Categoria = new Categoria() {Codigo = 2};
            auto.Estado = new Estado() { Codigo = 1 };
            auto.Marca = new Marca() { Codigo = 1 };
            auto.Modelo = new Modelo() { Codigo = 1 };
            auto.Imagen = "lost444";
            auto.Placa = "123456";
            auto.Precio = 1000;

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string postdata = serializer.Serialize(auto);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1281/AutosServices.svc/Autos");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = null;
            try
            {
            
                res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string autoJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Auto autoCreado = js.Deserialize<Auto>(autoJson);
                Assert.AreEqual(auto.Marca.Codigo, autoCreado.Marca.Codigo);
                Assert.AreEqual(auto.Modelo.Codigo, autoCreado.Modelo.Codigo);
                Assert.AreEqual(auto.Precio, autoCreado.Precio);
                Assert.AreEqual(auto.Categoria.Codigo, autoCreado.Categoria.Codigo);
                Assert.AreEqual(auto.Estado.Codigo, autoCreado.Estado.Codigo);
                Assert.AreEqual(auto.Placa, autoCreado.Placa);
                Assert.AreEqual(auto.Imagen, autoCreado.Imagen);

            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual(Constantes.ERROR_PLACA_CREADA, mensaje);

            }
            
        }

        [TestMethod]
        public void ObtenerAutoTest()
        {
            Auto auto = new Auto();
            auto.Codigo = 30;
            auto.Categoria = new Categoria() { Codigo = 1 };
            auto.Estado = new Estado() { Codigo = 1 };
            auto.Marca = new Marca() { Codigo = 1 };
            auto.Modelo = new Modelo() { Codigo = 1 };
            auto.Imagen = "lost3333";
            auto.Placa = "123456";
            auto.Precio = 1000;
            
            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:1281/AutosServices.svc/Autos/" + auto.Codigo);
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string autoJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Auto autoObtenido = js2.Deserialize<Auto>(autoJson2);
            Assert.AreEqual(auto.Marca.Codigo, autoObtenido.Marca.Codigo);
            Assert.AreEqual(auto.Modelo.Codigo, autoObtenido.Modelo.Codigo);
            Assert.AreEqual(auto.Precio, autoObtenido.Precio);
            Assert.AreEqual(auto.Categoria.Codigo, autoObtenido.Categoria.Codigo);
            Assert.AreEqual(auto.Estado.Codigo, autoObtenido.Estado.Codigo);
            Assert.AreEqual(auto.Placa, autoObtenido.Placa);
            Assert.AreEqual(auto.Imagen, autoObtenido.Imagen);
        }

        [TestMethod]
        public void ModificarAutoTest()
        {
            Auto auto = new Auto();
            auto.Codigo = 30;
            auto.Categoria = new Categoria() { Codigo = 1 };
            auto.Estado = new Estado() { Codigo = 1 };
            auto.Marca = new Marca() { Codigo = 1 };
            auto.Modelo = new Modelo() { Codigo = 1 };
            auto.Imagen = "Pruebita";
            auto.Placa = "Jejejeje";
            auto.Precio = 1000;

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string postdata = serializer.Serialize(auto);
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
            Auto autoModificado = js.Deserialize<Auto>(autoJson);
            Assert.AreEqual(auto.Marca.Codigo, autoModificado.Marca.Codigo);
            Assert.AreEqual(auto.Modelo.Codigo, autoModificado.Modelo.Codigo);
            Assert.AreEqual(auto.Precio, autoModificado.Precio);
            Assert.AreEqual(auto.Categoria.Codigo, autoModificado.Categoria.Codigo);
            Assert.AreEqual(auto.Estado.Codigo, autoModificado.Estado.Codigo);
            Assert.AreEqual(auto.Placa, autoModificado.Placa);
            Assert.AreEqual(auto.Imagen, autoModificado.Imagen);
        }

        [TestMethod]
        public void ListarAutosTest()
        {
            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:1281/AutosServices.svc/Autos");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string autoJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            List<Auto> autoObtenido = js2.Deserialize<List<Auto>>(autoJson2);
            Assert.AreEqual(18, autoObtenido.Count());
        }


        [TestMethod]
        public void EliminarAutoTest()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1281/AutosServices.svc/Autos/25");
            req.Method = "DELETE";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:1281/AutosServices.svc/Autos/25");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string autoJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Auto autoObtenido = js2.Deserialize<Auto>(autoJson2);
            Assert.IsNull(autoObtenido);
        }


    }
}