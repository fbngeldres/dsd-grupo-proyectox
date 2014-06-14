using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SanJacintoServices.Dominio
{
    [DataContract]
    public class AutoReporte
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string Marca { get; set; }
        [DataMember]
        public string Modelo { get; set; }
        [DataMember]
        public decimal Precio { get; set; }
        [DataMember]
        public string Categoria { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string Placa { get; set; }
        [DataMember]
        public string Imagen { get; set; }
        [DataMember]
        public int veces { get; set; }
    }
}