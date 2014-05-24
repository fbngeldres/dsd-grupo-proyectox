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
            
           /*try {*/
                wsAutoService.AutoServiceClient proxy = new wsAutoService.AutoServiceClient();
                wsAutoService.Auto objAutoObtenido = proxy.obtenerAuto(intCodigoAuto);

                wsUsuarioService.UsuarioServiceClient proxyU = new wsUsuarioService.UsuarioServiceClient();
                wsUsuarioService.Usuario objUsuObtenido = proxyU.ObtenerUsuario(intCodigoUsuario);

                //DateTime myDate = DateTime.ParseExact("2009-05-08 14:40:52", "yyyy-MM-dd HH:mm:ss",
                  //                     System.Globalization.CultureInfo.InvariantCulture);
                Auto autoObtenido = new Auto();
                autoObtenido.Codigo = objAutoObtenido.Codigo;
                autoObtenido.Placa = objAutoObtenido.Placa;
                autoObtenido.Precio = objAutoObtenido.Precio;
                autoObtenido.Categoria = objAutoObtenido.Categoria;

                Marca marca = new Marca();
                marca.Codigo = objAutoObtenido.Marca.Codigo;
                marca.Descripcion = objAutoObtenido.Marca.Descripcion;

                Modelo modelo = new Modelo();
                modelo.Codigo = objAutoObtenido.Modelo.Codigo;
                modelo.Descripcion = objAutoObtenido.Modelo.Descripcion;

                Estado estado = new Estado();
                estado.Codigo = objAutoObtenido.Estado.Codigo;
                estado.Descripcion = objAutoObtenido.Estado.Descripcion;

                autoObtenido.Marca = marca;
                autoObtenido.Modelo = modelo;
                autoObtenido.Estado = estado;
                
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
                    Auto = autoObtenido,
                    Usuario = usuarioObtenido,
                    FechaInicio = DateTime.Now,
                    FechaFin = DateTime.Now,
                    CantidadDias = objAlquiler.CantidadDias,
                    Accesorios = objAlquiler.Accesorios,
                    Igv = 100
                };

                alquilerCreado = AlquilerDAO.Crear(alquilerCreado);

                return alquilerCreado;
            /*}
            catch (Exception)
            {
                throw new FaultException<ValidationException>(new ValidationException 
                { ValidationError = "Error en el servicio, no se pudo registrar su alquiler" }, 
                new FaultReason("Validation Failed"));
            }*/
        }

        public Alquiler obtenerAlquiler(int intCodigoAlquiler)
        {
            return AlquilerDAO.Obtener(intCodigoAlquiler);
        }

        public List<Alquiler> listaAlquileres()
        {
            /*alquilerDAO = new AlquilerDAO();*/
            return AlquilerDAO.ListarTodos().ToList();
        }
    }
}
