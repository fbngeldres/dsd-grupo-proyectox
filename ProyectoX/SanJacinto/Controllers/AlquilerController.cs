using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SanJacinto.Models;

namespace SanJacinto.Controllers
{
    public class AlquilerController : Controller
    {
        public ActionResult CrearAlquiler() 
        {
            return View();
        }

        public ActionResult RegistrarAlquiler(AlquilerModel alquiler)
        {
            wsAlquiler.AlquilerServiceClient miAlquiler = new wsAlquiler.AlquilerServiceClient();
            wsAlquiler.Alquiler objAlquiler = new wsAlquiler.Alquiler();
            objAlquiler.Costo = 1000;
            objAlquiler.CostoAdicional = 100;
            objAlquiler.CantidadDias = 7;
            objAlquiler.Accesorios = "Silla de Bebe";

            objAlquiler = miAlquiler.registrarAlquiler(objAlquiler, 1, 1);

            AutoModel autoModel = new AutoModel()
            {
                Placa = objAlquiler.Auto.Placa
            };

            UsuarioModel usuarioModel = new UsuarioModel()
            {
                Nombres = objAlquiler.Usuario.Nombres,
                Apellidos = objAlquiler.Usuario.Apellidos
            };

            AlquilerModel alquilerModel = new AlquilerModel()
            {
                Costo = objAlquiler.Costo,
                CostoAdicional = objAlquiler.CostoAdicional,
                Auto = autoModel,
                Usuario = usuarioModel
            };

            return View(alquilerModel);
        }
    }
}
