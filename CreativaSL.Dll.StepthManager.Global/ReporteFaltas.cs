using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    
    public class ReporteFaltas
    {

        public ReporteFaltas()
        {
            IDReporte = 0;
            FechaInicio = DateTime.MinValue;
            FechaFin = DateTime.MinValue;
            Completo = false;
            Detalle = new List<ReporteFaltasDetalle>();
        }
        /// <summary>
        /// Identificador del reporte
        /// </summary>
        public int IDReporte { get; set; }

        /// <summary>
        /// fecha de inicio del reporte
        /// </summary>
        public DateTime FechaInicio { get; set; }
        
        /// <summary>
        /// fecha fin del reporte
        /// </summary>
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// bandera de confrmacion si todo salio bien
        /// </summary>
        public bool Completo { get; set; }

        /// <summary>
        /// Lista de las faltas con sus atributos detalle
        /// </summary>
        public List<ReporteFaltasDetalle> Detalle { get; set; }
    }
}
