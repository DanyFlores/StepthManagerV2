using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class ReporteTiempoServicios
    {
        public ReporteTiempoServicios()
        {
            IDEmpleado = string.Empty;
            Empleado = string.Empty;
            IDProducto = string.Empty;
            Servicio = string.Empty;
            TiempoAVG = string.Empty;
            Listado = new List<ReporteTiempoServicios>();
        }
        /// <summary>
        /// Idetificador del Empleado
        /// </summary>
        public string IDEmpleado { get; set; }
        /// <summary>
        /// omre del empleado
        /// </summary>
        public string Empleado { get; set; }
        /// <summary>
        /// Idetificador del Producto
        /// </summary>
        public string IDProducto { get; set; }
        /// <summary>
        /// Nombre del Servicio
        /// </summary>
        public string Servicio { get; set; }
        /// <summary>
        /// Promedio del Tiempo del servicio
        /// </summary>
        public string TiempoAVG { get; set; }
        /// <summary>
        /// Lista que guarda todos los parámetros
        /// </summary>
        public List<ReporteTiempoServicios> Listado { get; set; }
    }
}


