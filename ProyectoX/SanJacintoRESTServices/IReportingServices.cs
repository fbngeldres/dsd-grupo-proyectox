using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using SanJacintoRESTServices.Dominio;

namespace SanJacintoRESTServices
{
    
    [ServiceContract]
    public interface IReportingServices
    {

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Autos", ResponseFormat = WebMessageFormat.Json)]
        List<Auto> ListarAuto();
        //List<Alquiler> ListarAlquileres();

      

    }
}
