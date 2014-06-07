using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SanJacintoRESTServices.Dominio
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
        [DataMember]
        public Auto Auto { get; set; }
        [DataMember]
        public Usuario Usuario { get; set; }
        [DataMember]
        public DateTime FechaInicio { get; set; }
        [DataMember]
        public DateTime FechaFin { get; set; }
        [DataMember]
        public int CantidadDias { get; set; }
        [DataMember]
        public string Accesorios { get; set; }

    }
}