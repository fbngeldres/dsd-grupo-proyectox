using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanJacintoServices.Persistencia
{
    public class ConexionUtil
    {
        public static string ObtenerCadena()
        {
            return "Data Source=(local);Initial Catalog=BD_SANJACINTO;Integrated Security=SSPI;";
        }
    }
}