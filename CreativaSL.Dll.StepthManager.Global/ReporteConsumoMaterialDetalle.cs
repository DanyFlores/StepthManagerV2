using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class ReporteConsumoMaterialDetalle
    {
        /// <summary>
        /// Tipo de consumo de material
        /// </summary>
        public int Tipo { get; set; }
        /// <summary>
        /// IDSucursal o IDEmpleado
        /// </summary>
        public string IDGeneral { get; set; }
        /// <summary>
        /// Nombre del empleado o sucursal que consumio el producto
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Id del material que se consumio
        /// </summary>
        public string IDProducto { get; set; }
        /// <summary>
        /// Nombre del material que se consumio
        /// </summary>
        public string NombreProducto { get; set; }
        /// <summary>
        /// Clave del material consumido
        /// </summary>
        public string Clave { get; set; }
        /// <summary>
        /// Fecha la cual el material fue utilizado
        /// </summary>
        public DateTime Fecha { get; set; }
        /// <summary>
        /// Indica si el material fue consumido durante un trabajo
        /// </summary>
        public bool Produccion { get; set; }
        /// <summary>
        /// Indica si el material se encuentra asociado a una metrica
        /// </summary>
        public bool CumpleMetrica { get; set; }
        /// <summary>
        /// Indica si al material se le asocio con la imagen de una metrica
        /// </summary>
        public string ImagenMetrica { get; set; }
    }
}
