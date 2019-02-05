using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class EstadoResultados
    {
        /// <summary>
        /// Inicializa las propiedades con valores predeterminados
        /// </summary>
        public EstadoResultados()
        {
            IDReporte = -1;
            Sucursal = string.Empty;
            MesDesc = string.Empty;
            Anio = -1;
            Completado = false;
            Detalle = new List<EstadoResultadosDetalle>();
        }

        /// <summary>
        /// Identificador del reporte
        /// </summary>
        public int IDReporte { get; set; }
        /// <summary>
        /// Sucursal para la que se genera el reporte
        /// </summary>
        public string Sucursal { get; set; }
        /// <summary>
        /// IDentificador del mes
        /// </summary>
        public int IDMes { get; set; }
        /// <summary>
        /// Mes en el que se genera el reporte
        /// </summary>
        public string MesDesc { get; set; }
        /// <summary>
        /// Año en el que se genera el reporte
        /// </summary>
        public int Anio { get; set; }
        public decimal IngresoMensual { get; set; }
        public decimal IngresoAnual { get; set; }
        public decimal CostoVentasMensual { get; set; }
        public decimal CostoVentasAnual { get; set; }
        public decimal ComisionMensual { get; set; }
        public decimal ComisionAnual { get; set; }
        public decimal ImpuestoMensual { get; set; }
        public decimal ImpuestoAnual { get; set; }
        public DateTime FechaReporte { get; set; }
        /// <summary>
        /// Indica si se completó el proceso de lectura de datos al obtener el detalle
        /// </summary>
        public bool Completado { get; set; }
        /// <summary>
        /// Detalle del reporte de Estado de resultados
        /// </summary>
        public List<EstadoResultadosDetalle> Detalle { get; set; }
    }
}
