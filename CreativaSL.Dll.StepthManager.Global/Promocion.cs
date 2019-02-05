using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Promocion
    {
        public int IDPromocion { get; set; }
        public string NombrePromocion { get; set; }
        public int IDEstatus { get; set; }
        public string Estatus { get; set; }
        public bool Lunes { get; set; }
        public bool Martes { get; set; }
        public bool Miercoles { get; set; }
        public bool Jueves { get; set; }
        public bool Viernes { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }
        public string Sucursales { get; set; }
        public string Dias { get; set; }
        public List<Sucursal> ListaSucursales { get; set; }
        public DataTable TablaSucursales { get; set; }
        public DataTable TablaServicios { get; set; }
    }
}
