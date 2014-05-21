﻿using System;
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
            AlquilerModel nuevoAlquiler = new AlquilerModel();

            AutoModel autoModel = new AutoModel();
            autoModel.Precio = 230;

            nuevoAlquiler.Auto = autoModel;

            return View(nuevoAlquiler);
        }

        public ActionResult RegistrarAlquiler(AlquilerModel aq)
        {
            wsAlquiler.AlquilerServiceClient miAlquiler = new wsAlquiler.AlquilerServiceClient();
            wsAlquiler.Alquiler objAlquiler = new wsAlquiler.Alquiler();
            objAlquiler.Costo = 1000;
            objAlquiler.CostoAdicional = 100;
            objAlquiler.CantidadDias = aq.CantidadDias;
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

        public ActionResult ListarAlquileres()
        {
            wsAlquiler.AlquilerServiceClient miAlquiler = new wsAlquiler.AlquilerServiceClient();
            List<wsAlquiler.Alquiler> listaAlquileres = miAlquiler.listaAlquileres().ToList();

            AlquilerModel alquilerModel;
            List<AlquilerModel> listaAlquilerModel = new List<AlquilerModel>();
            foreach (var item in listaAlquileres)
            {
                AutoModel auto = new AutoModel();
                //auto.Marca = "Audi R8";

                alquilerModel = new AlquilerModel();
                alquilerModel.Auto = auto;
                alquilerModel.Costo = item.Costo;
                alquilerModel.CostoAdicional = item.CostoAdicional;
                alquilerModel.Accesorios = item.Accesorios;
                alquilerModel.CantidadDias = item.CantidadDias;
                alquilerModel.FechaInicio = item.FechaInicio;
                listaAlquilerModel.Add(alquilerModel);
            }

            return View(listaAlquilerModel);
        }

        public ActionResult CrearAlquiler234()
        {
            
            return View();
        }

        private string retornarMarca(string p)
        {
            if(p.Equals("1")){
                return "Audi R8";
            } else {
                return "Kia Rio";
            }
        }
    }
    
    public class ParametrosProyecto : MasterParameters
    {
        public String id { get; set; }
        public int txtDias { get; set; }
    }
}
