using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class ReporteVentasXSucursalDetalleVentasXCaja
    {
        public ReporteVentasXSucursalDetalleVentasXCaja()
        {
            NombreCompleto = string.Empty;
            FechaInicio = DateTime.MinValue;
            TotalCobros = 0;  
            
        }
        /// <summary>
        /// Nombre del empleado
        /// </summary>
        public string NombreCompleto { get; set; }
        /// <summary>
        /// Fecha de inicio
        /// </summary>
        public DateTime FechaInicio { get; set; }
        /// <summary>
        /// Total de Cobros
        /// </summary>
        public decimal TotalCobros { get; set; }
        
    }
}
