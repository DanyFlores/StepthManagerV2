using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
   public class ReporteTrabajosRealizadosDetalle
    {
        public ReporteTrabajosRealizadosDetalle()
        {
            IDSucursal = string.Empty;
            Sucursal = string.Empty;
            IDEmpleado = string.Empty;
            NombreEmpleado = string.Empty;
            IDServicio = string.Empty;
            NombreServicio = string.Empty;
            CantidadServicios = 0;
        }
        /// <summary>
        /// Identificador de la sucursal del trabajo realizado
        /// </summary>
        public string IDSucursal { get; set; }
        /// <summary>
        /// Nombre de la sucursal del trabajo realizado
        /// </summary>
        public string Sucursal { get; set; }
        /// <summary>
        /// Identificador del Empleado que realizo el trabajo
        /// </summary>
        public string IDEmpleado { get; set; }
        /// <summary>
        /// Nombre del Empleado que realizo el trabajo
        /// </summary>
        public string NombreEmpleado { get; set; }
        /// <summary>
        /// Identificador del servicio que realizo
        /// </summary>
        public string IDServicio { get; set; }
        /// <summary>
        /// Nombre del servicio realizado
        /// </summary>
        public string NombreServicio { get; set; }
        /// <summary>
        /// Cantidad de servicios realizados
        /// </summary>
        public int CantidadServicios { get; set; }

    }
}
