using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SanJacintoServices.Dominio;
using NHibernate;
using NHibernate.Criterion;

namespace SanJacintoServices.Persistencia
{
    public class AutoDAO : BaseDAO<Auto, int>
    {
        public List<Auto> obtenerAutos(int marca, int modelo, decimal precioMin, decimal precioMax, int categoria)
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                ICriteria busqueda = sesion.CreateCriteria<Auto>();
                if (marca != 0)
                {
                    busqueda.Add(Restrictions.Eq("Marca.Codigo", marca));
                }
                if (modelo != 0)
                {
                    busqueda.Add(Restrictions.Eq("Modelo.Codigo", modelo));
                }
                if (categoria != 0)
                {
                    //busqueda.Add(Restrictions.Eq("Categoria.Codigo", categoria));
                }
                if (precioMin != 0 && precioMax != 0)
                {
                    busqueda.Add(Restrictions.Between("Precio", precioMin, precioMax));
                }

                //ICriteria busqueda = sesion.CreateCriteria("from Auto a where a.precio between "+precioMin+" and "+precioMax);
                //List<Auto> busqueda = sesion.CreateCriteria(typeof(Auto)).l;
                return busqueda.List<Auto>().ToList();
            }
        }
    }
}