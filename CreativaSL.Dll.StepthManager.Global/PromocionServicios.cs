using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class PromocionServicios
    {
        public int IDPromocion { get; set; }
        public int IDPromocionDetalle { get; set; }
        public string IDServicio { get; set; }
        public string Servicio { get; set; }
        public decimal Precio { get; set; }
    }
}
