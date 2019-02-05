using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class ReporteProductosVendidosDetalle
    {
        public ReporteProductosVendidosDetalle()
        {
            IDSucursal = string.Empty;
            Sucursal = string.Empty;
            IDProducto = string.Empty;
            Clave = string.Empty;
            Producto = string.Empty;
            Cantidad = 0;
        }

        /// <summary>
        /// Identificador de sucursal
        /// </summary>
        public string IDSucursal { get; set; }
        /// <summary>
        /// Nombre de Sucursal
        /// </summary>
        public string Sucursal { get; set; }
        /// <summary>
        /// Identificador de Producto
        /// </summary>
        public string IDProducto { get; set; }
        /// <summary>
        /// Clave
        /// </summary>
        public string Clave { get; set; }
        /// <summary>
        /// Nombre de Producto
        /// </summary>
        public string Producto { get; set; }
        /// <summary>
        /// Cantidad
        /// </summary>
        public decimal Cantidad { get; set; }
    }
}
