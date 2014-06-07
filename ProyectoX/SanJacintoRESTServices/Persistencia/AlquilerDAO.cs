using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SanJacintoRESTServices.Dominio;
using NHibernate;
using NHibernate.Criterion;

namespace SanJacintoRESTServices.Persistencia
{
    public class AlquilerDAO : BaseDAO<Alquiler , int >
    {
        public List<Auto> listarAlquileresXUsuario()
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                ICriteria busqueda = sesion.CreateCriteria<Auto>();
                busqueda.Add(!Restrictions.Eq("Usuario.Codigo", 4));
                return busqueda.List<Auto>().ToList();
            }
        }


    }
}