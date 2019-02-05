using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class ReporteMobiliarioXSucursal
    {

        public ReporteMobiliarioXSucursal()
        {
            IDSucursal = string.Empty;
            NombreSucursal = string.Empty;
            IDMobiliario = string.Empty;
            Codigo = string.Empty;
            Mobiliario = string.Empty;
            Marca = string.Empty;
            Modelo = string.Empty;
            NumSerie = string.Empty;
            FechaAsigncion = DateTime.MinValue;
        }
        /// <summary>
        /// Identificador de la sucursal
        /// </summary>
        public string IDSucursal { get; set; }

        /// <summary>
        /// Nombre de la sucursal
        /// </summary>
        public string NombreSucursal { get; set; }

        /// <summary>
        /// Identificador del mobiliario
        /// </summary>
        public string IDMobiliario { get; set; }

        /// <summary>
        /// Codigo del mobiliario
        /// </summary>
        public string Codigo { get; set; }
        
        /// <summary>
        /// Nombre del mobiliario
        /// </summary>
        public string Mobiliario { get; set; }
        
        /// <summary>
        /// Marca del mobiliario
        /// </summary>
        public string Marca { get; set; }
        
        /// <summary>
        /// Modelo del mobiliario
        /// </summary>
        public string Modelo { get; set; }
        
        /// <summary>
        /// Número de serie del mobiliario
        /// </summary>
        public string NumSerie { get; set; }

        /// <summary>
        /// Fecha en que se asigno el mobiliario
        /// </summary>
        public DateTime FechaAsigncion { get; set; }

        /// <summary>
        /// Bandera de proceso completado
        /// </summary>
        public bool Completado { get; set; }

        /// <summary>
        /// Lista de detalle del reporte
        /// </summary>
        public List<ReporteMobiliarioXSucursal> Detalle { get; set; }

    }
}
