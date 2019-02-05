using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
   public class ReporteConsumoMaterial
    {
        public ReporteConsumoMaterial()
        {
            IDReporte = 0;
            FechaInicio = DateTime.MinValue;
            FechaFin = DateTime.MinValue;
            Completo = false;
            Sucursal = "";
            Detalle = new List<ReporteConsumoMaterialDetalle>();
        }
        public string id_sucursal { get; set; }
        /// <summary>
        /// Identificador del Reporte
        /// </summary>
        public int IDReporte { get; set; }
        /// <summary>
        /// Sucursal de la cual el reporte fue generado
        /// </summary>
        public string Sucursal { get; set; }
        /// <summary>
        /// Fecha de inicio del reporte
        /// </summary>
        public DateTime FechaInicio { get; set; }
        /// <summary>
        /// Fecha de finalizacion del reporte
        /// </summary>
        public DateTime FechaFin { get; set; }
        /// <summary>
        /// Indica si las operaciones se completaron con exito
        /// </summary>
        public bool Completo { get; set; }
        /// <summary>
        /// Lista con la informacio del cuerpo del reporte
        /// </summary>
        public List<ReporteConsumoMaterialDetalle> Detalle { get; set; }
    }
}
