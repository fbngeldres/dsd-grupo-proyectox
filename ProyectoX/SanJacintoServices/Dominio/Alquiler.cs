using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SanJacintoServices.Dominio
{
    [DataContract]
    public class Alquiler
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public decimal Costo { get; set; }
        [DataMember]
        public decimal CostoAdicional { get; set; }
        [DataMember]
        public decimal Igv { get; set; }
        [DataMember]
        public decimal MontoTotal { get; set; }

    }
}