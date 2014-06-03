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


        public Auto buscarAutoUnico(string placa)
        {

            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {

                ICriteria busqueda = sesion.CreateCriteria<Auto>();
                busqueda.Add(Restrictions.Eq("Placa", placa)).Add(Restrictions.Eq("Estado.Codigo", 4));

                if (busqueda.List<Auto>().Count() == 1)
                {
                    return busqueda.List<Auto>()[0];
                }

                else
                {
                    return null;
                }

            }
        }

        public List<Auto> listarAutosHabilitados()
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                ICriteria busqueda = sesion.CreateCriteria<Auto>();
                busqueda.Add(!Restrictions.Eq("Estado.Codigo", 4));
                return busqueda.List<Auto>().ToList();
            }
        }
    }
}