using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SanJacintoRESTServices.Dominio;
using NHibernate;
using NHibernate.Criterion;

namespace SanJacintoRESTServices.Persistencia
{
    public class AutoDAO : BaseDAO<Auto, int>
    {
        public List<Marca> obtenerMarcas()
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                ICriteria busqueda = sesion.CreateCriteria<Marca>();
                return busqueda.List<Marca>().ToList();
            }
        }

        public List<Categoria> obtenerCategorias()
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                ICriteria busqueda = sesion.CreateCriteria<Categoria>();
                return busqueda.List<Categoria>().ToList();
            }
        }

        public List<Modelo> obtenerModelos()
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                ICriteria busqueda = sesion.CreateCriteria<Modelo>();
                return busqueda.List<Modelo>().ToList();
            }
        }
    }
}