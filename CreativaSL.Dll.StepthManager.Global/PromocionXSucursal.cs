using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class PromocionXSucursal
    {
        public int IDPromocion { get; set; }
        public string IDSucursal { get; set; }
        public string NombreSucursal { get; set; }
        public decimal Precio { get; set; }
        public DataTable TablaPrecios { get; set; }
    }
}
