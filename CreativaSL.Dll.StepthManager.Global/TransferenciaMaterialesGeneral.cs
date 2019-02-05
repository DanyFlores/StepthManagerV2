using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class TransferenciaMaterialesGeneral
    {
        public TransferenciaMaterialesGeneral()
        {
            IDTransferencia = 0;
            Completo = false;
            Detalle = new List<TransferenciaMaterialesDetalle>();
        }
        /// <summary>
        /// Empleado Origen de la transferencia
        /// </summary>
        public string EmpleadoO { get; set; }

        /// <summary>
        /// Empleado Destino de la transferencia
        /// </summary>
        public string EmpleadoD { get; set; }

        /// <summary>
        /// Identificador del reporte
        /// </summary>
        public int IDTransferencia { get; set; }
       

        /// <summary>
        /// bandera de confrmacion si todo salio bien
        /// </summary>
        public bool Completo { get; set; }

        /// <summary>
        /// Lista de las Transferencias con sus atributos detalle
        /// </summary>
        public List<TransferenciaMaterialesDetalle> Detalle { get; set; }
    }
   
}
