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
        public string Descripcion { get; set; }
        [DataMember]
        public string Entidad { get; set; }
        [DataMember]
        public string Field1 { get; set; }
        [DataMember]
        public string Field2 { get; set; }
    }
}