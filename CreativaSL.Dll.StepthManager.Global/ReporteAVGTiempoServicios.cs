using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class ReporteAVGTiempoServicios
    {
        public ReporteAVGTiempoServicios()
        {
            IDEmpleado = string.Empty;
            Empleado = string.Empty;
            IDProducto = string.Empty;
            Servicio = string.Empty;
            TiempoAVG = string.Empty;
            Listado = new List<ReporteAVGTiempoServicios>();
        }
        /// <summary>
        /// Identificador de empleado
        /// </summary>
        public string  IDEmpleado { get; set; }
        /// <summary>
        /// Nombre del empleado
        /// </summary>
        public String Empleado { get; set; }
        /// <summary>
        /// Identificador del producto
        /// </summary>
        public string IDProducto { get; set; }
        /// <summary>
        /// Nombre del Servicio
        /// </summary>
        public string Servicio { get; set; }
        /// <summary>
        /// Promedio del tiempo del servicio
        /// </summary>
        public string TiempoAVG { get; set; }
        /// <summary>
        /// Lista donde se guardan todos los atributos
        /// </summary>
        public List<ReporteAVGTiempoServicios> Listado { get; set; }
    }
}
