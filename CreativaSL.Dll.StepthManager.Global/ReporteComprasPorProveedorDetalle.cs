using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class ReporteComprasPorProveedorDetalle
    {
        public ReporteComprasPorProveedorDetalle()
        {

            IDProveedor = string.Empty;
            Proveedor = string.Empty;
            Total = 0.0M;
            
        }
        /// <summary>
        /// identificador del provedor
        /// </summary>
        public string IDProveedor { get; set; }
        
        /// <summary>
        /// Nombre del provedor
        /// </summary>
        public string Proveedor { get; set; }
       
        /// <summary>
        /// Total de las compras
        /// </summary>
        public decimal Total { get; set; }
    }
}
