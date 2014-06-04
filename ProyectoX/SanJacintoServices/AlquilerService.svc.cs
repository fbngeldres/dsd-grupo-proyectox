using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SanJacintoServices.Dominio;
using SanJacintoServices.Persistencia;
using SOAPServices.Dominio;

namespace SanJacintoServices
{
    public class AlquilerService : IAlquilerService
    {
        private AlquilerDAO alquilerDAO = null;
        private AlquilerDAO AlquilerDAO
        {
            get
            {
                if (alquilerDAO == null)
                    alquilerDAO = new AlquilerDAO();
                return alquilerDAO;
            }
        }

        private AutoDAO autoDAO = null;
        private AutoDAO AutoDAO
        {
            get
            {
                if (autoDAO == null)
                    autoDAO = new AutoDAO();
                return autoDAO;
            }
        }

        private UsuarioDAO usuarioDAO = null;
        private UsuarioDAO UsuarioDAO
        {
            get
            {
                if (usuarioDAO == null)
                    usuarioDAO = new UsuarioDAO();
                return usuarioDAO;
            }
        }

        public Alquiler registrarAlquiler(Alquiler objAlquiler, int intCodigoAuto, int intCodigoUsuario)
        {
            
           try {
                wsAuto.AutoServiceClient proxy = new wsAuto.AutoServiceClient();
                wsAuto.Auto autoObtenido = proxy.obtenerAuto(intCodigoAuto);
                
                wsUsuarioService.UsuarioServiceClient proxyU = new wsUsuarioService.UsuarioServiceClient();
                wsUsuarioService.Usuario objUsuObtenido = proxyU.ObtenerUsuario(intCodigoUsuario);

                Auto auto = new Auto();
                auto.Codigo = autoObtenido.Codigo;
                auto.Placa = autoObtenido.Placa;
                auto.Precio = autoObtenido.Precio;
                auto.Imagen = autoObtenido.Imagen;

                Marca marca = new Marca();
                marca.Codigo = autoObtenido.Marca.Codigo;
                marca.Descripcion = autoObtenido.Marca.Descripcion;

                Modelo modelo = new Modelo();
                modelo.Codigo = autoObtenido.Modelo.Codigo;
                modelo.Descripcion = autoObtenido.Modelo.Descripcion;

                Estado estaAlquilado = new Estado();
                estaAlquilado.Codigo = 2;

                auto.Marca = marca;
                auto.Modelo = modelo;
                auto.Estado = estaAlquilado;
                
                Usuario usuarioObtenido = new Usuario();
                usuarioObtenido.Codigo = objUsuObtenido.Codigo;
                usuarioObtenido.Nombres = objUsuObtenido.Nombres;
                usuarioObtenido.Apellidos = objUsuObtenido.Apellidos;
                usuarioObtenido.Correo = objUsuObtenido.Correo;
                usuarioObtenido.Dni = objUsuObtenido.Dni;
                usuarioObtenido.Licencia = objUsuObtenido.Licencia;
                usuarioObtenido.Telefono = objUsuObtenido.Telefono;

                Alquiler alquilerCreado = new Alquiler()
                {
                    Costo = objAlquiler.Costo,
                    CostoAdicional = objAlquiler.CostoAdicional,
                    MontoTotal = objAlquiler.MontoTotal,
                    Auto = auto,
                    Usuario = usuarioObtenido,
                    FechaInicio = objAlquiler.FechaInicio,
                    FechaFin = objAlquiler.FechaFin,
                    CantidadDias = objAlquiler.CantidadDias,
                    Accesorios = objAlquiler.Accesorios,
                    Igv = objAlquiler.Igv
                };

                alquilerCreado = AlquilerDAO.Crear(alquilerCreado);

                return alquilerCreado;
            }
            catch (Exception)
            {
                throw new FaultException<ValidationException>(new ValidationException 
                { ValidationError = "Error en el servicio, no se pudo registrar su alquiler" }, 
                new FaultReason("Validation Failed"));
            }
        }

        public Alquiler obtenerAlquiler(int intCodigoAlquiler)
        {
            return AlquilerDAO.Obtener(intCodigoAlquiler);
        }

        public List<Alquiler> listaAlquileres()
        {
            return AlquilerDAO.ListarTodos().ToList();
        }


        public Alquiler RealizarDevolucion(int codigo)
        {
            Auto autoAlquilado = AlquilerDAO.Obtener(codigo).Auto;
            
         
            Estado estaLibre = new Estado();
            estaLibre.Codigo = 1;
            autoAlquilado.Estado = estaLibre;

            AutoDAO.Modificar(autoAlquilado);

            return AlquilerDAO.Obtener(codigo); 
        }
    }
}
