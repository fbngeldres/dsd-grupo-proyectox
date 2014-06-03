﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SanJacintoRESTServices.Dominio;
using SanJacintoRESTServices.Persistencia;
using System.Net;

namespace SanJacintoRESTServices
{
    
    public class AutosServices : IAutosServices
    {
        private AutoDAO autoDAO = null;
        private AutoDAO AutoDAO
        {
            get
            {
                if (autoDAO == null)
                    autoDAO = new AutoDAO();
                return autoDAO;
            }
        }

        public Auto CrearAuto(Auto autoACrear)
        {
            Auto auto = AutoDAO.buscarAutoUnico(autoACrear.Placa);

            if (auto != null)
            {
                throw new WebFaultException<string>(
                            Constantes.ERROR_PLACA_EN_USO_MODIFICAR, HttpStatusCode.InternalServerError);
            }

            return AutoDAO.Crear(autoACrear);
        }

        public Auto ObtenerAuto(string  codigo)
        {
            int cod = Convert.ToInt32(codigo);
            return AutoDAO.Obtener(cod);
        }

        public Auto ModificarAuto(Auto autoAModificar)
        {
            Auto auto = AutoDAO.buscarAutoUnico(autoAModificar.Placa);

            if (auto != null)
            {
                throw new WebFaultException<string>(Constantes.ERROR_PLACA_MODIFICAR, HttpStatusCode.InternalServerError);
            }else if(auto.Estado.Codigo != 1)
            {
                throw new WebFaultException<string>(Constantes.ERROR_PLACA_EN_USO_MODIFICAR, HttpStatusCode.InternalServerError);
            }
            return AutoDAO.Modificar(autoAModificar);
        }

        public void EliminarAuto(string codigoAutoAEliminar)
        {
            Auto autoExistente = new Auto();
            autoExistente = AutoDAO.Obtener(Int32.Parse(codigoAutoAEliminar));

            if (autoExistente == null)
            {
                throw new WebFaultException<string>(Constantes.ERROR_PLACA_ELIMINAR, HttpStatusCode.InternalServerError);
            }
            else if (autoExistente.Estado.Codigo != 1)
            {
                throw new WebFaultException<string>(Constantes.ERROR_PLACA_EN_USO_ELIMINAR, HttpStatusCode.InternalServerError);
            }

            AutoDAO.Eliminar(autoExistente);
        }

        public List<Auto> ListarAuto()
        {
            return AutoDAO.listarAutosHabilitados();
        }


        public List<Marca> ListarMarcas()
        {
            return AutoDAO.obtenerMarcas();
        }

        public List<Categoria> ListarCategorias()
        {
            return AutoDAO.obtenerCategorias();
        }

        public List<Modelo> ListarModelos()
        {
            return AutoDAO.obtenerModelos();
        }
    }
}
