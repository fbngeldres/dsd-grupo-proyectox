using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SanJacintoServices.Persistencia;
using SanJacintoServices.Dominio;

namespace SanJacintoServices
{
    public class ReportingServices : IReportingServices
    {
        private ReporteDAO reporteDAO = null;
        private ReporteDAO ReporteDAO
        {
            get
            {
                if (reporteDAO == null)
                    reporteDAO = new ReporteDAO();
                return reporteDAO;
            }
        }

        public List<AutoReporte> listarAutosMasAlquilados(DateTime fecIni, DateTime fecFin)
        {
            List<Alquiler> alquileres = ReporteDAO.listarAutosMasAlquilados(fecIni, fecFin);

            Dictionary<int, AutoReporte> contador = new Dictionary<int, AutoReporte>();
            List<AutoReporte> listaAutoReporte = new List<AutoReporte>();
            AutoReporte autoReporte = null;
            foreach (Alquiler a in alquileres)
            {
                if (contador.ContainsKey(a.Auto.Codigo)){
                    contador[a.Auto.Codigo].veces = contador[a.Auto.Codigo].veces + 1;
                } else
                {
                    autoReporte = new AutoReporte()
                    {
                        Categoria = a.Auto.Categoria.Descripcion,
                        Codigo = a.Auto.Codigo,
                        Estado = a.Auto.Estado.Descripcion,
                        Imagen = a.Auto.Imagen,
                        Marca = a.Auto.Marca.Descripcion,
                        Modelo = a.Auto.Modelo.Descripcion,
                        Placa = a.Auto.Placa,
                        Precio = a.Auto.Precio,
                        veces = 1
                    };
                    contador.Add(a.Auto.Codigo, autoReporte);
                }
            }



            foreach (KeyValuePair<int, AutoReporte> entry in contador)
            {
                listaAutoReporte.Add(entry.Value);
            }

            return listaAutoReporte;
        }
    }
}
