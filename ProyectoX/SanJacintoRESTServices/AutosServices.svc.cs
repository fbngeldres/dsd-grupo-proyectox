using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SanJacintoRESTServices.Dominio;
using SanJacintoRESTServices.Persistencia;
using System.Net;

namespace SanJacintoRESTServices
{
    
    public class AutosServices : IAutosServices
    {

        private AutoDAO dao = new AutoDAO();

        public Auto CrearAuto(Auto autoACrear)
        {
            Auto objetoAuto = new Auto()
            {
                Codigo = 19,

            };

            if (objetoAuto.Codigo.Equals(autoACrear.Codigo ))
            {
                throw new WebFaultException<string>(
                    "Faltan Datos para crear el auto", HttpStatusCode.InternalServerError);

            }
            return dao.Crear(autoACrear);
        }

        public Auto ObtenerAuto(string  codigo)
        {
            int cod = Convert.ToInt32(codigo);
            return dao.Obtener(cod);
        }

        public Auto ModificarAuto(Auto autoAModificar)
        {
            return dao.Modificar(autoAModificar);
        }

        public Auto  EliminarAuto(Auto  codigoAutoAEliminar)
        {
            return dao.Eliminar (codigoAutoAEliminar);

        }

        public List<Auto> ListarAuto()
        {
            return dao.ListarTodos();
        }
    }
}
