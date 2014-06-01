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
        public int Codigo { get; set; }

        [DataMember]
        public int Marca { get; set; }

        [DataMember]
        public int Modelo { get; set; }

        [DataMember]
        public decimal Precio { get; set; }

        [DataMember]
        public int Categoria { get; set; }

        [DataMember]
        public int Estado { get; set; }

        [DataMember]
        public string Placa { get; set; }

        [DataMember]
        public string Imagen { get; set; }


    }
}