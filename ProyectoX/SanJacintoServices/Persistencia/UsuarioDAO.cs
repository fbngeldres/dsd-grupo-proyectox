using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SanJacintoServices.Dominio;
using NHibernate;
using NHibernate.Criterion;

namespace SanJacintoServices.Persistencia
{
    public class UsuarioDAO : BaseDAO<Usuario, int>
    {
        public Usuario obtenerUsuarioLogeado(string usuario, string clave)
        {

            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {

                ICriteria busqueda = sesion.CreateCriteria<Usuario>();
                busqueda.Add(Restrictions.Eq("Correo", usuario)).Add(Restrictions.Eq("Clave", clave));

               // List<Usuario> usuarios = ;

                if (busqueda.List<Usuario>().Count() == 1) {
                    return busqueda.List<Usuario>()[0];
                }
                
                else {
                    return null;
                }
                
            }
        }
    }
}