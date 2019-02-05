using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class ReporteVentasXSucursalDetalleXFormasPago
    {
        public ReporteVentasXSucursalDetalleXFormasPago()
        {
            Descripcion = string.Empty;
            Monto = 0;
        }
        /// <summary>
        /// Método de Pago
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Monto a pagar
        /// </summary>
        public decimal Monto { get; set; }

    }
}
