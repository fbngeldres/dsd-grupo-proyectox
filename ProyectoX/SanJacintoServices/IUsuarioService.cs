using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SanJacintoServices.Dominio;

namespace SanJacintoServices
{  
    [ServiceContract]
    public interface IUsuarioService
    {
        [OperationContract]
        Usuario CrearUsuario(string apellidos, string nombres, string telefono, string licencia, string dni, string correo);
        [OperationContract]
        Usuario ObtenerUsuario(int codigo);
        [OperationContract]
        Usuario ModificarUsuario(int codigo, string telefono, string correo);
        [OperationContract]
        void EliminarUsuario(int codigo);
        [OperationContract]
        List<Usuario> ListarUsuarios();
    }
}
