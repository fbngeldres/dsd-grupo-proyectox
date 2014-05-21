using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanJacinto.Models
{
    public class AutoModel
    {
        public int Codigo { get; set; }

        public MarcaModel Marca { get; set; }

        public ModeloModel Modelo { get; set; }
 
        public decimal Precio { get; set; }

        public int Tipo { get; set; }

        public EstadoModel Estado { get; set; }

        public string Placa { get; set; }

        public string Imagen { get; set; }
    }
}