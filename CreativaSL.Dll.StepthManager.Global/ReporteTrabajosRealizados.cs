using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class ReporteTrabajosRealizados
    {
        public ReporteTrabajosRealizados()
        {
            IDReporte = 0;
            FechaInicio = DateTime.MinValue;
            FechaFin = DateTime.MinValue;
            Completo = false;
            Detalle = new List<ReporteTrabajosRealizadosDetalle>();
        }
        /// <summary>
        /// IDReporte
        /// </summary>
        public int IDReporte { get; set; }
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
        /// Lista de los Trabajos Realizados
        /// </summary>
        public List<ReporteTrabajosRealizadosDetalle> Detalle { get; set; }
    }
}