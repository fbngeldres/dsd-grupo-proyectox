using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SanJacintoRESTServices.Dominio;
using SanJacintoRESTServices.Persistencia;

namespace SanJacintoRESTServices
{
    
    public class AutosServices : IAutosServices
    {
        private AutoDAO dao = new AutoDAO();

        public Auto CrearAuto(Auto autoACrear)
        {
            return dao.Crear(autoACrear);
        }

        public Auto ObtenerAuto(int  codigo)
        {
              return dao.Obtener(codigo);
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
