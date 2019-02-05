using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class ReporteComprasClienteDetalle
    {
        public ReporteComprasClienteDetalle()
        {
            FolioVenta = string.Empty;
            NombreSucursal = string.Empty;
            FechaVenta = DateTime.MinValue;
            Servicios = string.Empty;
            Total = 0;
        }
        /// <summary>
        /// Folio de las Vemtas
        /// </summary>
        public string FolioVenta { get; set; }
        /// <summary>
        /// Nombre de la sucursal
        /// </summary>
        public string NombreSucursal { get; set; }
        /// <summary>
        /// Fecha de la venta
        /// </summary>
        public DateTime FechaVenta { get; set; }
        /// <summary>
        /// Servicio que se realizo
        /// </summary>
        public string Servicios { get; set; }
        /// <summary>
        /// Total
        /// </summary>
        public decimal Total { get; set; }
    }
}

