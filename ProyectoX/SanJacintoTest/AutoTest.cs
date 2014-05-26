using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SanJacintoTest
{
    [TestClass]
    public class AutoTest
    {
        [TestMethod]
        public void ListarResutadoAutosTest()
        {
            wsAutoService.AutoServiceClient proxy = new wsAutoService.AutoServiceClient();
            List<wsAutoService.Auto> list;

            list = proxy.listarResultadoAutos(0, 0, 0, 0, 0).ToList();
            Assert.IsNotNull(list);
            System.Diagnostics.Debug.WriteLine("" + list.Count);
            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        public void ListarResutadoEntrePrecioTest()
        {
            wsAutoService.AutoServiceClient proxy = new wsAutoService.AutoServiceClient();
            List<wsAutoService.Auto> list;

            list = proxy.listarResultadoAutos(0, 0, 11, 13, 0).ToList();
            Assert.IsNotNull(list);
            System.Diagnostics.Debug.WriteLine("" + list.Count);
            Assert.IsTrue(list.Count == 1);
        }
    }
}
