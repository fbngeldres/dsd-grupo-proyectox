using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SanJacintoRESTServices.Dominio
{
    [DataContract]
    public class Usuario
    {
        

        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string Apellidos { get; set; }
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Licencia { get; set; }
        [DataMember]
        public string Dni { get; set; }
        [DataMember]
        public int Codigo_rol { get; set; }
        [DataMember]
        public string Correo { get; set; }
        [DataMember]
        public string Clave { get; set; }

    }
}