using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanJacinto.Models
{
    public class AlquilerModel
    {
        public int Codigo { get; set; }

        public decimal Costo { get; set; }

        public decimal CostoAdicional { get; set; }

        public decimal Igv { get; set; }

        public decimal MontoTotal { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public int CantidadDias { get; set; }

        public string Accesorios { get; set; }

        public AutoModel Auto { get; set; }

        public UsuarioModel Usuario { get; set; }
    }
}