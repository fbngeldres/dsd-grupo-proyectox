using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SanJacintoServices.Persistencia;
using SanJacintoServices.Dominio;
using SOAPServices.Dominio;

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

        public Usuario CrearUsuario(string apellidos, string nombres, string telefono, string licencia, string dni, int codigo_rol, string correo, string clave)
        {
                Usuario usuarioExistente = null;
                usuarioExistente = UsuarioDAO.ObtenerPorDni(dni);

                if (usuarioExistente == null)
                {
                    Usuario usuarioACrear = new Usuario()
                    {
                        Apellidos = apellidos,
                        Nombres = nombres,
                        Telefono = telefono,
                        Licencia = licencia,
                        Dni = dni,
                        Codigo_rol = codigo_rol,
                        Correo = correo,
                        Clave = clave
                    };
                    return UsuarioDAO.Crear(usuarioACrear);
                }
                else
                {
                    throw new FaultException<ValidationException>(new ValidationException { ValidationError = "Error, DNI existente" },
                    new FaultReason("Validation Failed"));
                }
        }

        public Usuario ObtenerUsuario(int codigo)
        {
            return UsuarioDAO.Obtener(codigo);
        }

        public Usuario ModificarUsuario(int codigo, string apellidos, string nombres, string telefono, string licencia, 
                                        string dni, int codigo_rol, string correo, string clave)
        {
            Usuario usuarioAModificar = new Usuario() 
            {
                Codigo = codigo,
                Apellidos = apellidos,
                Nombres = nombres,
                Telefono = telefono,
                Licencia = licencia,
                Dni = dni,
                Codigo_rol = codigo_rol,
                Correo = correo,
                Clave = clave
            };

            return UsuarioDAO.Modificar(usuarioAModificar);
        }

        public void EliminarUsuario(int codigo)
        {
            try
            {
                int alquilerActivo = 0;
                alquilerActivo = UsuarioDAO.AlquilerActivo(codigo);
                if (alquilerActivo == 0)
                {
                    Usuario usuarioExistente = new Usuario();
                    usuarioExistente = UsuarioDAO.Obtener(codigo);
                    UsuarioDAO.Eliminar(usuarioExistente);
                }
                else
                {
                    throw new FaultException<ValidationException>(new ValidationException 
                    { ValidationError = "“Error, el usuario tiene un alquiler en curso" },
                    new FaultReason("Validation Failed"));                    
                }
            }
            catch (Exception)
            { }
            
        }

        public List<Usuario> ListarUsuarios()
        {
            return UsuarioDAO.ListarTodos().ToList();
        }


        public Usuario AutenticarUsuario(string correo, string clave)
        {
            return UsuarioDAO.obtenerUsuarioLogeado(correo, clave);
        }
    }
}
