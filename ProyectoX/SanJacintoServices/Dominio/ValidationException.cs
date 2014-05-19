using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SOAPServices.Dominio
{
    [DataContract]
    public class ValidationException
    {
        [DataMember]
        public string ValidationError { get; set; }
    }
}