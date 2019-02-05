using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class TransferenciaMateriales
    {
        public TransferenciaMateriales()
        {
            this.Conexion = string.Empty;
            this.Empleado = string.Empty;
            this.Observaciones = string.Empty;
            this.IDEmpleado = string.Empty;
            this.IDEmpleadoDestino = string.Empty;
            this.EmpleadoDestino = string.Empty;
            this.Fecha = DateTime.MinValue;
            this.Opcion =0;
        }
        public DateTime Fecha { get; set; }
        public string Conexion { get; set; }
        public int Opcion { get; set; }
        public int IDTransferencia { get; set; }
        public string IDEmpleado { get; set; }
        public string IDEmpleadoDestino { get; set; }
        public string Empleado { get; set; }
        public string EmpleadoDestino { get; set; }
        public string Observaciones { get; set; }


    }
    

}
