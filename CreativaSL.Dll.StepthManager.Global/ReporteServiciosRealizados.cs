using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class ReporteServiciosRealizados
    {
        /// <summary>
        /// Identificador de la sucursal en la que se realizan los servicios
        /// </summary>
        public string IDSucursal { get; set; }
        /// <summary>
        /// Nombre de la sucursal
        /// </summary>
        public string NombreSucursal { get; set; }
        /// <summary>
        /// Identificador del empleado que realizó los servicios
        /// </summary>
        public string IDEmpleado { get; set; }
        /// <summary>
        /// Nombre del empleado
        /// </summary>
        public string NombreEmpleado { get; set; }
        /// <summary>
        /// Identificador del servicio realizado
        /// </summary>
        public string IDServicio { get; set; }
        /// <summary>
        /// Nombre del servicio realizado
        /// </summary>
        public string NombreServicio { get; set; }
        /// <summary>
        /// Cantidad de servicios realizados
        /// </summary>
        public int Cantidad { get; set; }
    }
}
