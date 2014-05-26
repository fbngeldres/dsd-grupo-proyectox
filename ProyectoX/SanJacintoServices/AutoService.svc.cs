using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SanJacintoServices.Dominio;
using SanJacintoServices.Persistencia;

namespace SanJacintoServices
{
    
    public class AutoService : IAutoService
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

        private MarcaDAO marcaDAO = null;
        private MarcaDAO MarcaDAO
        {
            get
            {
                if (marcaDAO == null)
                    marcaDAO = new MarcaDAO();
                return marcaDAO;
            }
        }

        private ModeloDAO modeloDAO = null;
        private ModeloDAO ModeloDAO
        {
            get
            {
                if (modeloDAO == null)
                    modeloDAO = new ModeloDAO();
                return modeloDAO;
            }
        }

        public List<Marca> listarMarcas()
        {
            return MarcaDAO.ListarTodos().ToList();
        }


        public List<Modelo> listarModelos()
        {
            return ModeloDAO.ListarTodos().ToList();
        }


        public List<Auto> listarResultadoAutos(int marca, int modelo, decimal precioMin, decimal precioMax, int categoria)
        {

           
            return AutoDAO.obtenerAutos(marca,modelo ,precioMin,precioMax,categoria);
        }

        public Auto obtenerAuto(int intCodigoAuto){
            return AutoDAO.Obtener(intCodigoAuto);
        }
    }
}
