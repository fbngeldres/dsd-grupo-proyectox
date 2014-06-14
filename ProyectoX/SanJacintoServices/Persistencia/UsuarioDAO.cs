using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SanJacintoServices.Dominio;
using NHibernate;
using NHibernate.Criterion;
using System.Data.SqlClient;

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
        public Usuario ObtenerPorDni(string dni)
        {
            Usuario usuarioEncontrado = null;
            string sql = "SELECT * FROM tb_usuario WHERE dni=@dni";
            
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@dni", dni));

                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            usuarioEncontrado = new Usuario()
                            {
                                Codigo = (int)resultado["codigo"],
                                Apellidos = (string)resultado["apellidos"],
                                Nombres = (string)resultado["nombres"],
                                Telefono = (string)resultado["telefono"],
                                Licencia = (string)resultado["licencia"],
                                Dni = (string)resultado["dni"],
                                Codigo_rol = (int)resultado["codigo_rol"],
                                Correo = (string)resultado["correo"],
                                Clave = (string)resultado["clave"]
                            };
                        }
                    }
                }
            }
            return usuarioEncontrado;
        }
        public int AlquilerActivo(int codigo)
        {
            string sql = "SELECT * FROM tb_alquiler WHERE codigo_usuario=@codigo";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@codigo", codigo));

                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            return 1;   //AlquilerActivo
                        }
                        else 
                        {
                            return 0;   //No tiene alquiler activo OK
                        }
                    }
                }
            }
        }

        public Usuario obtenerUsuario(string correo)
        {

            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {

                ICriteria busqueda = sesion.CreateCriteria<Usuario>();
                busqueda.Add(Restrictions.Eq("Correo", correo));

                // List<Usuario> usuarios = ;

                if (busqueda.List<Usuario>().Count() == 1)
                {
                    return busqueda.List<Usuario>()[0];
                }

                else
                {
                    return null;
                }

            }
        }

    }
}