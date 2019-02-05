using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class ReporteComprasPorProveedor
    {
        
        public ReporteComprasPorProveedor()
        {
            IDReporte = 0;
            FechaInicio = DateTime.MinValue;
            FechaFin = DateTime.MinValue;
            Completo = false;
            Detalle = new List<ReporteComprasPorProveedorDetalle>();
            DetalleMob = new List<ReporteComprasPorProveedorDetalle>();
        }
        /// <summary>
        /// identificador del reporte
        /// </summary>
        public int IDReporte { get; set; }

        /// <summary>
        /// fecha incio del reporte
        /// </summary>
        public DateTime FechaInicio { get; set; }
        /// <summary>
        /// fecha fin del reporte
        /// </summary>
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// bandera de confirmacion para saber si se completo bien
        /// </summary>
        public bool Completo { get; set; }

        /// <summary>
        /// Lista de Las compras por provedor con sus atributos detalle
        /// </summary>
        public List<ReporteComprasPorProveedorDetalle> Detalle { get; set; }

        /// <summary>
        /// Lista de Las compras por provedor de mobiliario con sus atributos detalle
        /// </summary>
        public List<ReporteComprasPorProveedorDetalle> DetalleMob { get; set; }

    }
}
