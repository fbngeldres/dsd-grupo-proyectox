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
               /*
               Auto autoAlquilar = new Auto
               {
                   Codigo = intCodigoAuto
               };
               Usuario usuarioAlquilar = new Usuario {
                   Codigo = intCodigoUsuario
               };
               */
                /*
                autoDAO = new AutoDAO();
                usuarioDAO = new UsuarioDAO();
                alquilerDAO = new AlquilerDAO();
                */
                Auto objAutoObtenido = AutoDAO.Obtener(intCodigoAuto);
                Usuario objUsuarioObtenido = UsuarioDAO.Obtener(intCodigoUsuario);

                //DateTime myDate = DateTime.ParseExact("2009-05-08 14:40:52", "yyyy-MM-dd HH:mm:ss",
                  //                     System.Globalization.CultureInfo.InvariantCulture);
                Alquiler alquilerCreado = new Alquiler()
                {
                    Costo = objAlquiler.Costo,
                    CostoAdicional = objAlquiler.CostoAdicional,
                    Auto = objAutoObtenido,
                    Usuario = objUsuarioObtenido,
                    FechaInicio = DateTime.Now,
                    FechaFin = DateTime.Now,
                    CantidadDias = objAlquiler.CantidadDias,
                    Accesorios = objAlquiler.Accesorios
                };

                return AlquilerDAO.Crear(alquilerCreado);
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
            /*alquilerDAO = new AlquilerDAO();*/
            return AlquilerDAO.ListarTodos().ToList();
        }
    }
}
