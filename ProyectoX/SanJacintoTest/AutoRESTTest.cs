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
            Auto autoPrueba = new Auto()
            {
                Codigo = 18,
                Marca = 2,
                Modelo = 1,
                Precio = 1000,
                Categoria = 1,
                Estado = 1,
                Placa = "BB456",
                Imagen = "picanto.jpg"

            };

            //Prueba de creación de auto vía HTTP POST
            string postdata = "{\"Codigo\":\"" + autoPrueba.Codigo + "\", \"Marca\":\"" +
                autoPrueba.Marca + "\",\"Modelo\":\"" + autoPrueba.Modelo + "\",\"Precio\":\"" +
                autoPrueba.Precio + "\",\"Categoria\":\"" + autoPrueba.Categoria + "\",\"Estado\":\"" +
                autoPrueba.Estado + "\",\"Placa\":\"" + autoPrueba.Placa + "\", \"Imagen\":\"" +
                autoPrueba.Imagen + "\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:1281/AutosServices.svc/Autos");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string autoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Auto autoCreado = js.Deserialize<Auto>(autoJson);
            Assert.AreEqual(autoPrueba.Codigo, autoCreado.Codigo);
            Assert.AreEqual(autoPrueba.Marca, autoCreado.Marca);
            Assert.AreEqual(autoPrueba.Modelo, autoCreado.Modelo);
            Assert.AreEqual(autoPrueba.Precio, autoCreado.Precio);
            Assert.AreEqual(autoPrueba.Categoria, autoCreado.Categoria);
            Assert.AreEqual(autoPrueba.Estado, autoCreado.Estado);
            Assert.AreEqual(autoPrueba.Placa, autoCreado.Placa);
            Assert.AreEqual(autoPrueba.Imagen, autoCreado.Imagen);
        }

        [TestMethod]
        public void ObtenerAutoTest()
        {
            Auto auto = new Auto()
            {
                Codigo = 17,
                Marca = 4,
                Modelo = 4,
                Precio = 40,
                Categoria = 3,
                Estado = 1,
                Placa = "HYUNDAI",
                Imagen = "Hyundai_ix35.jpg"

            };

            //Prueba de Obtención de Auto vía HTTP GET
            HttpWebRequest req2 = (HttpWebRequest)WebRequest
                .Create("http://localhost:1281/AutosServices.svc/Autos/17");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string autoJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Auto autoObtenido = js2.Deserialize<Auto>(autoJson2);
            Assert.AreEqual(auto.Codigo, autoObtenido.Codigo);
            Assert.AreEqual(auto.Marca, autoObtenido.Marca);
            Assert.AreEqual(auto.Modelo, autoObtenido.Modelo);
            Assert.AreEqual(auto.Precio, autoObtenido.Precio);
            Assert.AreEqual(auto.Categoria, autoObtenido.Categoria);
            Assert.AreEqual(auto.Estado, autoObtenido.Estado);
            Assert.AreEqual(auto.Placa, autoObtenido.Placa);
            Assert.AreEqual(auto.Imagen, autoObtenido.Imagen);
        }

        [TestMethod]
        public void ModificarAutoTest()
        {
            Auto autoPrueba = new Auto()
            {
                Codigo = 17,
                Marca = 4,
                Modelo = 4,
                Precio = 40,
                Categoria = 3,
                Estado = 1,
                Placa = "HYUNDAI",
                Imagen = "Hyundai_ix35.jpg"
            };

            //Prueba de creación de auto vía HTTP POST
            string postdata = "{\"Codigo\":\"" + autoPrueba.Codigo + "\", \"Marca\":\"" +
                autoPrueba.Marca + "\",\"Modelo\":\"" + autoPrueba.Modelo + "\",\"Precio\":\"" +
                autoPrueba.Precio + "\",\"Categoria\":\"" + autoPrueba.Categoria + "\",\"Estado\":\"" +
                autoPrueba.Estado + "\",\"Placa\":\"" + autoPrueba.Placa + "\", \"Imagen\":\"" +
                autoPrueba.Imagen + "\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
               .Create("http://localhost:1281/AutosServices.svc/Autos");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string autoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Auto autoCreado = js.Deserialize<Auto>(autoJson);
            Assert.AreEqual(autoPrueba.Codigo, autoCreado.Codigo);
            Assert.AreEqual(autoPrueba.Marca, autoCreado.Marca);
            Assert.AreEqual(autoPrueba.Modelo, autoCreado.Modelo);
            Assert.AreEqual(autoPrueba.Precio, autoCreado.Precio);
            Assert.AreEqual(autoPrueba.Categoria, autoCreado.Categoria);
            Assert.AreEqual(autoPrueba.Estado, autoCreado.Estado);
            Assert.AreEqual(autoPrueba.Placa, autoCreado.Placa);
            Assert.AreEqual(autoPrueba.Imagen, autoCreado.Imagen);
        }

        [TestMethod]
        public void ListarAutosTest()
        {
            //Prueba de Obtención de Auto vía HTTP GET
            HttpWebRequest req2 = (HttpWebRequest)WebRequest
                .Create("http://localhost:1281/AutosServices.svc/Autos");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string autoJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            List<Auto> autoObtenido = js2.Deserialize<List<Auto>>(autoJson2);
            Assert.AreEqual(17, autoObtenido.Count());
        }

        ///////////////////////////////////////////////////////////////

        [TestMethod]
        public void EliminarAutoTest()
        {
            Auto autoPrueba = new Auto()
            {
                Codigo = 16,
                Estado = 0,
              
            };

            string postdata = "{\"Codigo\":\"" + autoPrueba.Codigo + "\",\"Estado\":\"" + autoPrueba.Estado  + "\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
               .Create("http://localhost:1281/AutosServices.svc/AutosE");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string autoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Auto autoCreado = js.Deserialize<Auto>(autoJson);
            Assert.AreEqual(autoPrueba.Codigo, autoCreado.Codigo);
             Assert.AreEqual(autoPrueba.Estado, autoCreado.Estado);
   
        }


    }
}
