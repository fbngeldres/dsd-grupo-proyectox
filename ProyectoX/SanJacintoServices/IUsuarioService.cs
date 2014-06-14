using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SanJacintoServices.Dominio;
using SOAPServices.Dominio;

namespace SanJacintoServices
{  
    [ServiceContract]
    public interface IUsuarioService
    {
        [FaultContract(typeof(ValidationException))]
        [OperationContract]
        Usuario CrearUsuario(string apellidos, string nombres, string telefono, string licencia, string dni, int codigo_rol,
                             string correo, string clave);
        [OperationContract]
        Usuario ObtenerUsuario(int codigo);

        [OperationContract]
        Usuario ModificarUsuario(int codigo, string apellidos, string nombres, string telefono, string licencia, string dni, int codigo_rol,
                                 string correo, string clave);
        [FaultContract(typeof(ValidationException))]
        [OperationContract]
        void EliminarUsuario(int codigo);

        [OperationContract]
        List<Usuario> ListarUsuarios();

        [OperationContract]
        Usuario AutenticarUsuario(string correo, string clave);

        [OperationContract]
        Usuario ObtenerUsuarioPorCorreo(string correo);
    }
}
