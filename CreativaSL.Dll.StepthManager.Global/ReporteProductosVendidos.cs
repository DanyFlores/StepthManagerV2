using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class ReporteProductosVendidos
    {

        public ReporteProductosVendidos()
        {
            IDReporte = 0;
            FechaInicio = DateTime.MinValue;
            FechaFin = DateTime.MinValue;
            Completo = false;
            Detalle = new List<ReporteProductosVendidosDetalle>();
        }
        /// <summary>
        /// Identificador del Reporte
        /// </summary>
        public int IDReporte { get; set; }
        /// <summary>
        /// Fechade Inicio
        /// </summary>
        public DateTime FechaInicio { get; set; }
        /// <summary>
        /// Fecha de termino
        /// </summary>
        public DateTime FechaFin { get; set; }
        /// <summary>
        /// Identificador de completado de llenado 
        /// </summary>
        public bool Completo { get; set; }
        /// <summary>
        /// Lista donde guarda todos los parametros recibidos
        /// </summary>
        public List<ReporteProductosVendidosDetalle> Detalle { get; set; }
    }
}
