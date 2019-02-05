using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class ReportesVentaXSucursal
    {
        public ReportesVentaXSucursal()
        {
            IDReporte = 0;
            FechaInicio = DateTime.MinValue;
            FechaFin = DateTime.MinValue;
            IDSucursal = string.Empty;
            NombreSucursal = string.Empty;
            Completo = false;
            Detalle1 = new List<ReporteVentasXSucursalDetalleVentasXCaja>();
            Detalle2 = new List<ReporteVentasXSucursalDetalleXFormasPago>();
        }
        /// <summary>
        /// Identificador del reporte
        /// </summary>
        public int IDReporte { get; set; }
        /// <summary>
        /// Fecha de inicio
        /// </summary>
        public DateTime FechaInicio { get; set; }
        /// <summary>
        /// Fecha de termino
        /// </summary>
        public DateTime FechaFin { get; set; }
        /// <summary>
        /// Identificador de sucursal
        /// </summary>
        public string IDSucursal { get; set; }
        /// <summary>
        /// NomreSucursal
        /// </summary>
        public string NombreSucursal { get; set; }
        /// <summary>
        /// Verifica si se completo la tarea
        /// </summary>
        public bool Completo { get; set; }
        /// <summary>
        /// Lista de Ventas por Caja detalle
        /// </summary>
        public List<ReporteVentasXSucursalDetalleVentasXCaja> Detalle1 { get; set; }
        /// <summary>
        /// Lista de Formas de pago detalle
        /// </summary>
        public List<ReporteVentasXSucursalDetalleXFormasPago> Detalle2 { get; set; }
    }
}
