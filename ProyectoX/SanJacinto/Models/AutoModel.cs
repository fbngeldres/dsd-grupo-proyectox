using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SanJacinto.Models
{
    [DataContract]
    public class AutoModel
    {
        [DataMember]
        public int Codigo { get; set; }

        [DataMember]
        public MarcaModel Marca { get; set; }

        [DataMember]
        public ModeloModel Modelo { get; set; }

        [DataMember]
        public decimal Precio { get; set; }

        [DataMember]
        public int Tipo { get; set; }

        public EstadoModel Estado { get; set; }

        [DataMember]
        public string Placa { get; set; }

        [DataMember]
        public string Imagen { get; set; }
    }
}