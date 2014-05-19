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
            
            {
                autoDAO = new AutoDAO();
                usuarioDAO = new UsuarioDAO();
                alquilerDAO = new AlquilerDAO();

                Auto objAutoObtenido = autoDAO.Obtener(intCodigoAuto);
                Usuario objUsuarioObtenido = usuarioDAO.Obtener(intCodigoUsuario);

                Alquiler alquilerCreado = new Alquiler()
                {
                    Costo = objAlquiler.Costo,
                    CostoAdicional = objAlquiler.CostoAdicional,
                    Auto = objAutoObtenido,
                    Usuario = objUsuarioObtenido,
                    FechaInicio = new DateTime(),
                    CantidadDias = objAlquiler.CantidadDias,
                    Accesorios = objAlquiler.Accesorios
                };

                return alquilerDAO.Crear(alquilerCreado);
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
            return alquilerDAO.Obtener(intCodigoAlquiler);
        }

        public List<Alquiler> listaAlquileres()
        {
            return alquilerDAO.ListarTodos().ToList();
        }
    }
}
