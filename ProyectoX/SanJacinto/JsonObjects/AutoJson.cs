using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SanJacinto.JsonObjects
{
    public class AutoJson
    {
        public int Codigo { get; set; }

        public Marca Marca { get; set; }

        public Modelo Modelo { get; set; }

        public decimal Precio { get; set; }

        public Categoria Categoria { get; set; }

        public Estado Estado { get; set; }

        public string Placa { get; set; }

        public string Imagen { get; set; }
    }

    public class Categoria
    {
        public int Codigo { get; set; }

        public string Descripcion { get; set; }
    }

    public class Modelo
    {
        public int Codigo { get; set; }

        public string Descripcion { get; set; }

        public Marca Marca { get; set; }
    }

    public class Marca
    {
        public int Codigo { get; set; }

        public string Descripcion { get; set; }
    }

    public class Estado
    {
        public int Codigo { get; set; }

        public string Descripcion { get; set; }
    }
}
