using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class ReporteMaterialesProduccion
    {
        /// <summary>
        /// Identificador de la sucursal a la que pertenece el Empleado
        /// </summary>
        public string IDSucursal { get; set; }
        /// <summary>
        /// Nombre de la sucursal
        /// </summary>
        public string NombreSucursal { get; set; }
        /// <summary>
        /// Identificador del empleado al que pertenece el material
        /// </summary>
        public string IDEmpleado { get; set; }
        /// <summary>
        /// Nombre del empleado
        /// </summary>
        public string NombreEmpleado { get; set; }
        /// <summary>
        /// Código de barras del producto 
        /// </summary>
        public string ClaveProducto { get; set; }
        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string NombreProducto { get; set; }
        /// <summary>
        /// Cantidad de producto en producción
        /// </summary>
        public int Cantidad { get; set; }
        
    }
}
