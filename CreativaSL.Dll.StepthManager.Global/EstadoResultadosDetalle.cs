using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class EstadoResultadosDetalle
    {
        /// <summary>
        /// Inicializa las propiedades con valores predeterminados
        /// </summary>
        public EstadoResultadosDetalle()
        {
            IDRubro = -1;
            TipoGasto = string.Empty;
            IDSubRubro = string.Empty;
            Categoria = string.Empty;
            MontoMensual = -1;
            MontoAnual = -1;
            Porcentaje = -1;
        }
        /// <summary>
        /// Identificador del rubro o tipo de movimiento a representar en el reporte
        /// </summary>
        public int IDRubro { get; set; }
        /// <summary>
        /// Descripción del tipo de movimiento
        /// </summary>
        public string TipoGasto { get; set; }
        /// <summary>
        /// Identificador de la Categoría del movimiento a representar en el reporte
        /// </summary>
        public string IDSubRubro { get; set; }
        /// <summary>
        /// Descripción de la categoría del movimiento
        /// </summary>
        public string Categoria { get; set; }
        /// <summary>
        /// Monto mensual por categoría
        /// </summary>
        public decimal MontoMensual { get; set; }
        /// <summary>
        /// Monto acumulado anual por categoría
        /// </summary>
        public decimal MontoAnual { get; set; }
        /// <summary>
        /// Porcentaje del monto mensual respecto al monto anual
        /// </summary>
        public decimal Porcentaje { get; set; }
    }
}
