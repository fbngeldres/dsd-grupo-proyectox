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
    public interface IAutoService
    {
        [OperationContract]
        List<Marca> listarMarcas();

        [OperationContract]
        List<Modelo> listarModelos();

        [OperationContract]
        List<Categoria> listarCategorias();

        [OperationContract]
        List<Auto> listarResultadoAutos(string placa, int marca, int modelo, decimal precioMin, decimal precioMax, int categoria);

        [OperationContract]
        Auto obtenerAuto(int intCodigoAuto);
    }
}
