using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SanJacintoServices.Persistencia;
using SanJacintoServices.Dominio;

namespace SanJacintoServices
{    
    public class UsuarioService : IUsuarioService
    {
        private UsuarioDAO usuarioDAO = null;
        private UsuarioDAO UsuarioDAO
        {
            get
            {
                if (usuarioDAO == null)
                    usuarioDAO = new UsuarioDAO();
                return usuarioDAO;
            }
        }

        public Usuario CrearUsuario(string apellidos, string nombres, string telefono, string licencia, string dni, string correo)
        {
            Usuario usuarioACrear = new Usuario()
            {
                Apellidos = apellidos,
                Nombres = nombres,
                Telefono = telefono,
                Licencia = licencia,
                Dni = dni,
                Correo = correo
            };
            return UsuarioDAO.Crear(usuarioACrear);
        }

        public Usuario ObtenerUsuario(int codigo)
        {
            return UsuarioDAO.Obtener(codigo);
        }

        public Usuario ModificarUsuario(int codigo, string telefono, string correo)
        {
            Usuario usuarioAModificar = new Usuario()
            {
                Codigo = codigo,
                Telefono = telefono,
                Correo = correo
            };

            return UsuarioDAO.Modificar(usuarioAModificar);
        }

        public void EliminarUsuario(int codigo)
        {
            Usuario usuarioExistente = UsuarioDAO.Obtener(codigo);
            UsuarioDAO.Eliminar(usuarioExistente);
        }

        public List<Usuario> ListarUsuarios()
        {
            return UsuarioDAO.ListarTodos().ToList();
        }
    }
}
