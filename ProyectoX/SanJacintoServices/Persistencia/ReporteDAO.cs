using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SanJacintoServices.Dominio;
using NHibernate;
using NHibernate.Criterion;

namespace SanJacintoServices.Persistencia
{
    public class ReporteDAO
    {
        public List<Alquiler> listarAutosMasAlquilados(DateTime fecIni, DateTime fecFin)
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {

                ICriteria busqueda = sesion.CreateCriteria<Alquiler>();
                if (fecIni != null && fecFin != null)
                {
                    busqueda.Add(Restrictions.Between("FechaInicio", fecIni, fecFin));
                }
                busqueda.Add(!Restrictions.Eq("Auto.Estado.Codigo", 4));
                return busqueda.List<Alquiler>().ToList();
            }
        }
    }
}