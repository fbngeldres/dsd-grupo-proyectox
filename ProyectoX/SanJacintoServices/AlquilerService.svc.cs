using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SanJacintoServices.Dominio;
using SanJacintoServices.Persistencia;
using SOAPServices.Dominio;
using System.Messaging;

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

            Alquiler alquilerCreado = null;
            try
            {
                Auto autoObtenido = AutoDAO.Obtener(intCodigoAuto);
                Usuario usaurioObetenido = UsuarioDAO.Obtener(intCodigoUsuario);

                Estado estaAlquilado = new Estado();
                estaAlquilado.Codigo = 2;
                autoObtenido.Estado = estaAlquilado;
                objAlquiler.Usuario = usaurioObetenido;
                objAlquiler.Auto = autoObtenido;
                alquilerCreado = AlquilerDAO.Crear(objAlquiler);
                AutoDAO.Modificar(autoObtenido);
                
                return alquilerCreado;
            }
            catch (Exception ex)
            {
                registrarAlquilerCola(objAlquiler);
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw new FaultException<ValidationException>(new ValidationException { ValidationError = "Error en el servicio, no se pudo registrar su alquiler" },
                new FaultReason("Validation Failed"));
            }

            /*
            Alquiler alquilerCreado = null;
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

                alquilerCreado = new Alquiler()
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
            catch (Exception ex)
            {
                registrarAlquilerCola(alquilerCreado);
                System.Diagnostics.Debug.WriteLine(ex.Message );
                throw new FaultException<ValidationException>(new ValidationException 
                { ValidationError = "Error en el servicio, no se pudo registrar su alquiler" }, 
                new FaultReason("Validation Failed"));
            }
             */
        }

        private void registrarAlquilerCola(Alquiler alquiler)
        {
            try
            {
                string rutaCola2 = @".\private$\alquileres";
                if (!MessageQueue.Exists(rutaCola2))
                    MessageQueue.Create(rutaCola2);

                MessageQueue cola = new MessageQueue(rutaCola2);
                Message mensaje2 = new Message();

                mensaje2.Label = "Alquiler";
                mensaje2.Body = alquiler;
                cola.Send(mensaje2);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public Alquiler obtenerAlquiler(int intCodigoAlquiler)
        {
            return AlquilerDAO.Obtener(intCodigoAlquiler);
        }

        public List<Alquiler> listaAlquileres()
        {
            obtenerAlquileresColas();
            return AlquilerDAO.ListarTodos().ToList();
        }

        private void obtenerAlquileresColas()
        {
            try
            {
                string rutaCola = @".\private$\alquileres";
                if (MessageQueue.Exists(rutaCola))
                {
                    MessageQueue cola = new MessageQueue(rutaCola);
                    cola.Formatter = new XmlMessageFormatter(new Type[] { typeof(Alquiler) });

                    if (cola.GetAllMessages().Count() > 0)
                    {
                        Message msg;

                        while ((msg = Receive(cola)) != null)
                        {
                            Alquiler alquiler = (Alquiler)msg.Body;
                            AlquilerDAO.Crear(alquiler);
                        }
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private Message Receive(MessageQueue queue)
        {
            try
            {
                return queue.Receive(TimeSpan.Zero);
            }
            catch (MessageQueueException mqe)
            {
                if (mqe.MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout)
                    return null;
                throw;
            }
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
