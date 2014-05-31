using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Web.Mvc;

namespace SanJacinto.Models
{

    public class AutoModel
    {
        public int Codigo { get; set; }

        public int Marca { get; set; }

        public int Modelo { get; set; }

        public decimal PrecioMinimo { get; set; }

        public decimal PrecioMaximo { get; set; }

        public int Categoria { get; set; }

        public int Estado { get; set; }

        public string Placa { get; set; }

        public string Imagen { get; set; }

        //Listas de categorias, marcas y modelos
        public List<SelectListItem> lstCategorias { get; set; }
        public List<SelectListItem> lstMarcas { get; set; }
        public List<SelectListItem> lstModelos { get; set; }

        public string MarcaDesc { get; set; }

        public string ModeloDesc { get; set; }

        public string CategoriaDesc { get; set; }

        public string EstadoDesc { get; set; }
    }

}