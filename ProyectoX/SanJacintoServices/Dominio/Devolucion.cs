using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SanJacintoServices.Dominio
{
    [DataContract]
    public class Devoluciones
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public DateTime FechaDevolucion { get; set; }
        [DataMember]
        public decimal Penalidad { get; set; }
        [DataMember]
        public decimal Igv { get; set; }
        [DataMember]
        public decimal MontoTotal { get; set; }
    }
}