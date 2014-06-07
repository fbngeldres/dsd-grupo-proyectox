using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SanJacintoRESTServices.Dominio;
using SanJacintoRESTServices.Persistencia;

namespace SanJacintoRESTServices
{
    
    public class ReportingServices : IReportingServices
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


        /*
               public List<Auto> ListarAlquileres()
               {
                   return AutoDAO.listarAutosHabilitados();
               }

       
               public List<Auto> ListarAuto()
               {
                   return AutoDAO.listarAutosXMarca();
               }
        


               public List<Alquiler> listaAlquileres()
               {
                   return AlquilerDAO.ListarTodos().ToList();
               }

        
               public List<Alquiler> listaAlquileres()
               {
                   return AlquilerDAO.listarAlquileresXUsuario().ToList();
               }
                */


       public List<Auto> ListarAuto()
        {
            return AutoDAO.listarAutosHabilitados();
        }
       
        
/*
        List<Alquiler> ListarAlquileres()
        {
            return AlquilerDAO.listarAlquileresXUsuario();
        }
 */ 
 
    }
}
