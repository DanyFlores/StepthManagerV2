using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class ReporteComprasCliente
    {
        public ReporteComprasCliente()
        {
            IDReporte = 0;
            FechaInicio = DateTime.MinValue;
            FechaFin = DateTime.MinValue;
            IDCliente = string.Empty;
            Nombre = string.Empty;
            Completo = false;
            Detalle = new List<ReporteComprasClienteDetalle>();
        }
        /// <summary>
        /// Identificador del reporte
        /// </summary>
        public int IDReporte { get; set; }
        /// <summary>
        /// Identificador del cliente del que se requiere reporte
        /// </summary>
        public string IDCliente { get; set; }
        /// <summary>
        /// Nombre del cliente
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Fecha de Inicio del Reporte Solicitado
        /// </summary>
        public DateTime FechaInicio { get; set; }
        /// <summary>
        /// Fecha de Termino del Reporte Solicitado
        /// </summary>
        public DateTime FechaFin { get; set; }
        /// <summary>
        /// Verifica si se completo la tarea
        /// </summary>
        public bool Completo { get; set; }
        /// <summary>
        /// Lista con los detalles del reporte
        /// </summary>
        public List<ReporteComprasClienteDetalle> Detalle { get; set; }
    }
}
