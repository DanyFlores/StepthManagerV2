using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class ComprasCliente
    {
        public string Folio { get; set; }
        public string Sucursal { get; set; }
        public DateTime Fecha { get; set; }
        public string Servicios { get; set; }
        public decimal Total { get; set; }
    }
}
