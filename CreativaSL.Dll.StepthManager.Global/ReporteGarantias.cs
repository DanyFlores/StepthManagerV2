using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
   public class ReporteGarantias
    {
        
        /// <summary>
        /// Fecha en la cual termina el historico del reporte
        /// </summary>
        public DateTime FechaFin { get; set; }
        /// <summary>
        /// Fecha e la cual inicia el historico del reporte
        /// </summary>
        public DateTime FechaInicio { get; set; }
        /// <summary>
        /// Identiicador unico del reporte
        /// </summary>
        public int Id_reporte { get; set; }
        /// <summary>
        /// Fecha en la que se aplico la garantia
        /// </summary>
        public DateTime Fecha { get; set; }
        /// <summary>
        /// ID de la sucursal donde se aplico la garantia
        /// </summary>
        public string Id_sucursal { get; set; }
        /// <summary>
        /// Nombbre de la sucursal donde se hizo valida la garantia
        /// </summary>
        public string NombreSucursal { get; set; }
        /// <summary>
        /// Nombre del empleado que valida la garantia
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Costo de la validacion de la garantia
        /// </summary>
        public decimal Total { get; set; }
        /// <summary>
        /// Empleado que aplico la garantia
        /// </summary>
        public string NombreCompleto { get; set; }
        /// <summary>
        /// Oservacion sobre la validacion de la garantia
        /// </summary>
        public string Observaciones { get; set; }
        /// <summary>
        /// Empleado que hizo valida la garantias
        /// </summary>
        public string EmpleadoAplica { get; set; }
        /// <summary>
        /// Lista encapsulada para metodos de respuesta de la BD
        /// </summary>
        public List<ReporteGarantias> Detalle { get; set; }
        /// <summary>
        /// Booleano de control para las operaciones de consulta de la BD
        /// </summary>
        public bool Completado { get; set; }
    }
}
