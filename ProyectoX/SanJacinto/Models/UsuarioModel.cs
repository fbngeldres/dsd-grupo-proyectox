using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanJacinto.Models
{
    public class UsuarioModel
    {
        public int Codigo { get; set; }

        public string Apellidos { get; set; }
        
        public string Nombres { get; set; }
        
        public string Telefono { get; set; }
        
        public string Licencia { get; set; }
        
        public string Dni { get; set; }
        
        public int Codigo_rol { get; set; }
        
        public string Correo { get; set; }
        
        public string Clave { get; set; }

        public string Error { get; set; }
    }
}