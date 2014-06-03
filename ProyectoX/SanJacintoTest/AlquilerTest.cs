using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SanJacintoTest
{
    [TestClass]
    public class AlquilerTest
    {
        [TestMethod]
        public void registrar()
        {
            wsAlquiler.AlquilerServiceClient proxy = new wsAlquiler.AlquilerServiceClient();
            wsAlquiler.Alquiler alquiler = new wsAlquiler.Alquiler();
           // alquiler.Costo = 1478;
            alquiler.Accesorios = "RADIO MP4";

            wsAlquiler.Alquiler alquilerNuevo = new wsAlquiler.Alquiler();
            alquilerNuevo = proxy.registrarAlquiler(alquiler, 1, 1);

            Assert.IsNotNull(alquilerNuevo);

        }

        [TestMethod]
        public void obtenerAlquiler()
        {
            wsAlquiler.AlquilerServiceClient proxy = new wsAlquiler.AlquilerServiceClient();

            wsAlquiler.Alquiler alquilerNuevo = proxy.obtenerAlquiler(2);

            Assert.IsNotNull(alquilerNuevo);

        }

        [TestMethod]
        public void listarAlquiler()
        {
            wsAlquiler.AlquilerServiceClient proxy = new wsAlquiler.AlquilerServiceClient();

            List<wsAlquiler.Alquiler> lista = proxy.listaAlquileres().ToList();

            Assert.IsNotNull(lista);
            Assert.IsTrue(lista.Count > 0);

        }



        [TestMethod]
        public void RealizarDevolucion()
        {
            wsAlquiler.AlquilerServiceClient proxy = new wsAlquiler.AlquilerServiceClient();

            wsAlquiler.Alquiler alquilerDevuelto = proxy.RealizarDevolucion(1);


            Assert.AreEqual(1, alquilerDevuelto.Auto.Estado.Codigo);
            Assert.IsTrue(1 == alquilerDevuelto.Auto.Estado.Codigo);
          

        }
    }
}
