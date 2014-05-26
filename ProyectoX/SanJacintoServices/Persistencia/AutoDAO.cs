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
                String squery = "FROM Auto WHERE 1=1 ";

                 
                if( marca != 0){
                    squery += " AND Marca.Codigo = :marca";
                
                }
                if ( modelo != 0)
                {
                    squery += " AND Modelo.Codigo = :modelo";

                }
                if ( precioMin != 0 && precioMax != 0)
                {
                    squery += " AND Precio between :precioMin  AND :precioMax";

                }
               
                if (categoria != 0)
                {
                    squery += " AND Categoria.Codigo = :categoria";

                }

                IQuery query = sesion.CreateQuery(squery);
                if ( marca != 0)
                {
                    query.SetParameter("marca", marca);
                }
                if ( modelo != 0)
                {
                    query.SetParameter("modelo", modelo);
                }
                if ( precioMin != 0 && precioMax != 0)
                {
                    query.SetParameter("precioMax", precioMax);
                    query.SetParameter("precioMin", precioMin);
                }
                if (categoria != 0)
                {
                    query.SetParameter("categoria", categoria);
                }
                
                 query.SetMaxResults(10);
               //  ArrayList<Auto> autos = query.List<Auto>();



                return query.List<Auto>().ToList();
            }
        }
    }
}