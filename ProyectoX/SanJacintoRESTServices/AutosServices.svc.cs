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

        public Auto CrearAuto(Auto autoACrear)
        {
            Auto auto = new Auto
            {
                Placa = "ddd"


            };
            //return dao.Crear(autoACrear);
            return null;
        }

        public Auto ObtenerAuto(string  codigo)
        {
            int cod = Convert.ToInt32(codigo);
            return AutoDAO.Obtener(cod);
        }

        public Auto ModificarAuto(Auto autoAModificar)
        {
            //return dao.Modificar(autoAModificar);
            return null;
        }

        public void EliminarAuto(string codigoAutoAEliminar)
        {
            //return dao.Eliminar (codigoAutoAEliminar);
            //return null;
        }

        public List<Auto> ListarAuto()
        {
            //return dao.ListarTodos();
            return AutoDAO.ListarTodos().ToList();
        }
    }
}
