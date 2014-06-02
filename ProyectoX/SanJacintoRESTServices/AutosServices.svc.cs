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
            return AutoDAO.Crear(autoACrear);
        }

        public Auto ObtenerAuto(string  codigo)
        {
            int cod = Convert.ToInt32(codigo);
            return AutoDAO.Obtener(cod);
        }

        public Auto ModificarAuto(Auto autoAModificar)
        {
            return AutoDAO.Modificar(autoAModificar);
        }

        public void EliminarAuto(string codigoAutoAEliminar)
        {
            Auto autoExistente = new Auto();
            autoExistente = AutoDAO.Obtener(Int32.Parse(codigoAutoAEliminar));
            AutoDAO.Eliminar(autoExistente);
        }

        public List<Auto> ListarAuto()
        {
            return AutoDAO.ListarTodos().ToList();
        }


        public List<Marca> ListarMarcas()
        {
            return AutoDAO.obtenerMarcas();
        }

        public List<Categoria> ListarCategorias()
        {
            return AutoDAO.obtenerCategorias();
        }

        public List<Modelo> ListarModelos()
        {
            return AutoDAO.obtenerModelos();
        }
    }
}
