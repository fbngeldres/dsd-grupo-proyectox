using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanJacinto.Models
{
    public class ModeloModel
    {
        public int Codigo { get; set; }

        public string Descripcion { get; set; }

        public MarcaModel Marca { get; set; }
    }
}