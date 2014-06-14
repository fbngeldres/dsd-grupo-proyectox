using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanJacinto.Models
{
    public class ReporteModel
    {
        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public string FechaInicioCadena { get; set; }

        public string FechaFinCadena { get; set; }
    }
}