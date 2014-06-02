﻿using System;
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
    public class AutoRestRESTTest
    {
        [TestMethod]
        public void AgregarAutoRestTest()
        {
            AutoRest autoPrueba = new AutoRest()
            {
                Codigo = 19,
                Marca = 1,
                Modelo = 1,
                Precio = 1000,
                Categoria = 1,
                Estado = 2,
                Placa = "AGBF586",
                Imagen = "aaaaa.jpg "

            };

            //Prueba de creación de auto vía HTTP POST
            string postdata = "{\"Codigo\":\"" + autoPrueba.Codigo + "\", \"Marca\":\"" +
                autoPrueba.Marca + "\",\"Modelo\":\"" + autoPrueba.Modelo + "\",\"Precio\":\"" +
                autoPrueba.Precio + "\",\"Categoria\":\"" + autoPrueba.Categoria + "\",\"Estado\":\"" +
                autoPrueba.Estado + "\",\"Placa\":\"" + autoPrueba.Placa + "\", \"Imagen\":\"" +
                autoPrueba.Imagen + "\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:1281/AutoRestsServices.svc/AutoRests");
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
                AutoRest autoCreado = js.Deserialize<AutoRest>(autoJson);
                Assert.AreEqual(autoPrueba.Codigo, autoCreado.Codigo);
                Assert.AreEqual(autoPrueba.Marca, autoCreado.Marca);
                Assert.AreEqual(autoPrueba.Modelo, autoCreado.Modelo);
                Assert.AreEqual(autoPrueba.Precio, autoCreado.Precio);
                Assert.AreEqual(autoPrueba.Categoria, autoCreado.Categoria);
                Assert.AreEqual(autoPrueba.Estado, autoCreado.Estado);
                Assert.AreEqual(autoPrueba.Placa, autoCreado.Placa);
                Assert.AreEqual(autoPrueba.Imagen, autoCreado.Imagen);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("Faltan Datos para crear el auto", mensaje);

            }

        }

        [TestMethod]
        public void ObtenerAutoRestTest()
        {
            AutoRest auto = new AutoRest()
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

            //Prueba de Obtención de AutoRest vía HTTP GET
            HttpWebRequest req2 = (HttpWebRequest)WebRequest
                .Create("http://localhost:1281/AutoRestsServices.svc/AutoRests/17");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string autoJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            AutoRest autoObtenido = js2.Deserialize<AutoRest>(autoJson2);
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
        public void ModificarAutoRestTest()
        {
            AutoRest autoPrueba = new AutoRest()
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
               .Create("http://localhost:1281/AutoRestsServices.svc/AutoRests");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string autoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            AutoRest autoCreado = js.Deserialize<AutoRest>(autoJson);
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
        public void ListarAutoRestsTest()
        {
            //Prueba de Obtención de AutoRest vía HTTP GET
            HttpWebRequest req2 = (HttpWebRequest)WebRequest
                .Create("http://localhost:1281/AutoRestsServices.svc/AutoRests");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string autoJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            List<AutoRest> autoObtenido = js2.Deserialize<List<AutoRest>>(autoJson2);
            Assert.AreEqual(16, autoObtenido.Count());
        }

        ///////////////////////////////////////////////////////////////

        [TestMethod]
        public void EliminarAutoRestTest()
        {
            AutoRest autoPrueba = new AutoRest()
            {
                Codigo = 16,
                Estado = 2,
              
            };

            string postdata = "{\"Codigo\":\"" + autoPrueba.Codigo + "\",\"Estado\":\"" + autoPrueba.Estado  + "\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
               .Create("http://localhost:1281/AutoRestsServices.svc/AutoRestsE");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string autoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            AutoRest autoCreado = js.Deserialize<AutoRest>(autoJson);
            Assert.AreEqual(autoPrueba.Codigo, autoCreado.Codigo);
             Assert.AreEqual(autoPrueba.Estado, autoCreado.Estado);
   
        }


    }
}
