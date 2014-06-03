using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SanJacintoRESTServices.Dominio;

namespace SanJacintoRESTServices
{
    
    [ServiceContract]
    public interface IAutosServices
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Autos", ResponseFormat = WebMessageFormat.Json)]
        Auto CrearAuto(Auto autoACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Autos/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        Auto ObtenerAuto(string codigo);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Autos", ResponseFormat = WebMessageFormat.Json)]
        Auto ModificarAuto(Auto autoAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Autos/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarAuto(string codigo);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Autos", ResponseFormat = WebMessageFormat.Json)]
        List<Auto> ListarAuto();

       
      
    }
}
