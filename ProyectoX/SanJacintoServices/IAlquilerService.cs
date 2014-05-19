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
    public interface IAlquilerService
    {
        [OperationContract]
        [FaultContract(typeof(ValidationException))]
        Alquiler registrarAlquiler(Alquiler objAlquiler, int intCodigoAuto, int intCodigoUsuario);

        [OperationContract]
        Alquiler obtenerAlquiler(int intCodigoAlquiler);

        [OperationContract]
        List<Alquiler> listaAlquileres();
    }
}
