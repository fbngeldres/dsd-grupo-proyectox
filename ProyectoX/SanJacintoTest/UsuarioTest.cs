﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SanJacintoTest
{
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void Crear()
        {
            UsuarioWS.UsuarioServiceClient proxy = new UsuarioWS.UsuarioServiceClient();
            UsuarioWS.Usuario usuarioCreado = proxy.CrearUsuario("Urbano", "Dennis", "992842320", "123456", "46474606", 
                                                                  1, "dennis@urbano.pe", "1234567890");
            Assert.IsNotNull(usuarioCreado);
        }
        [TestMethod]
        public void Obtener()
        {
            UsuarioWS.UsuarioServiceClient proxy = new UsuarioWS.UsuarioServiceClient();
            UsuarioWS.Usuario usuarioObtenido = proxy.ObtenerUsuario(2);
            Assert.AreEqual("46474606", usuarioObtenido.Dni);
        }
        [TestMethod]
        public void Modificar()
        {
            UsuarioWS.UsuarioServiceClient proxy = new UsuarioWS.UsuarioServiceClient();
            UsuarioWS.Usuario usuarioObtenido = proxy.ObtenerUsuario(2);
            proxy.ModificarUsuario(usuarioObtenido.Codigo, usuarioObtenido.Apellidos, usuarioObtenido.Nombres, "5492022", usuarioObtenido.Licencia, usuarioObtenido.Dni, 2, "dnnisurb@gmail.com", "9876543210");
            UsuarioWS.Usuario usuarioModificado = proxy.ObtenerUsuario(2);
            Assert.AreEqual("5492022", usuarioModificado.Telefono);
        }
        [TestMethod]
        public void Eliminar()
        {
            UsuarioWS.UsuarioServiceClient proxy = new UsuarioWS.UsuarioServiceClient();
            proxy.EliminarUsuario(2);
            UsuarioWS.Usuario usuarioObtenido = proxy.ObtenerUsuario(2);
            Assert.IsNull(usuarioObtenido);
        }
        [TestMethod]
        public void Listar()
        {
            UsuarioWS.UsuarioServiceClient proxy = new UsuarioWS.UsuarioServiceClient();
            List<UsuarioWS.Usuario> usuarioListado = proxy.ListarUsuarios().ToList();
            Assert.AreEqual(1, usuarioListado.Count());
        }
        [TestMethod]
        public void Autenticar()
        {
            UsuarioWS.UsuarioServiceClient proxy = new UsuarioWS.UsuarioServiceClient();
            string mensaje = proxy.AutenticarUsuario(1, "dnnisurb@gmail.com", "9876543210");
            Assert.AreEqual("", mensaje);
        }
    }
}
