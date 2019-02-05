using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class ReporteMonederoDetalle
    {
        public ReporteMonederoDetalle()
        {
            IDTransaccion = 0;
            Descripcion = string.Empty;
            Resta = false;
            Monto = 0;
        }

        /// <summary>
        /// IDTransaccion
        /// </summary>
        public int IDTransaccion { get; set; }
        /// <summary>
        /// Descripsion de la Transaccion
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Resta
        /// </summary>
        public bool Resta { get; set; }
        /// <summary>
        /// Monto Total
        /// </summary>
        public decimal Monto { get; set; }
        
    }
}