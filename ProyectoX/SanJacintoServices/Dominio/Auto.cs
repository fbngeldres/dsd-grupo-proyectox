using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SanJacintoServices.Dominio
{
    [DataContract]
    public class Auto
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string Categoria { get; set; }
        [DataMember]
        public string Marca { get; set; }
        [DataMember]
        public string Modelo { get; set; }
        [DataMember]
        public decimal Precio { get; set; }
        [DataMember]
        public int Tipo { get; set; }
        [DataMember]
        public int Estado { get; set; }
        [DataMember]
        public string Placa { get; set; }
    }
}