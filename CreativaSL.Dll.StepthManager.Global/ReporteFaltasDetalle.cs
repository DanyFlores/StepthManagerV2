using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class ReporteFaltasDetalle
    {
        public ReporteFaltasDetalle()
        {
            this.IDSucursal = string.Empty;
            this.Sucursal = string.Empty;
            this.IDEmpleado = string.Empty;
            this.Empleado = string.Empty;
            this.Fecha = DateTime.MinValue;
        }

        /// <summary>
        /// identificador de la sucursal 
        /// </summary>
        public string IDSucursal { get; set; }

        /// <summary>
        /// Nombre de la sucursal
        /// </summary>
        public string Sucursal { get; set; }

        /// <summary>
        /// identificador del empleado
        /// </summary>
        public string IDEmpleado { get; set; }

        /// <summary>
        /// Nombre del empleado
        /// </summary>
        public string Empleado { get; set; }

        /// <summary>
        /// Fecha de la falta reportada
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Estatus del registro de entrada
        /// </summary>
        public string EstatusEntrada { get; set; }

        /// <summary>
        /// Estatus del registro de salida
        /// </summary>
        public string EstatusSalida { get; set; }
    }
}
