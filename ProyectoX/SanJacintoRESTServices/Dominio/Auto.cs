using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SanJacintoRESTServices.Dominio
{
    [DataContract]
    public class Auto
    {
        [DataMember]
        public int codigo { get; set; }
        
        [DataMember]
        public int marca { get; set; }

        [DataMember]
        public int modelo { get; set; }

        [DataMember]
        public decimal  precio { get; set; }

        [DataMember]
        public int categoria  { get; set; }

        [DataMember]
        public int estado { get; set; }

        [DataMember]
        public string  placa { get; set; }       

        [DataMember]
        public string  imagen { get; set; }
        

    }
}