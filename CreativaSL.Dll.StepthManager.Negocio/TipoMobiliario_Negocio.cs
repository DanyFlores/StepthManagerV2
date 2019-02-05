using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class TipoMobiliario_Negocio
    {
        public List<TipoMobiliario> LlenarComboTipoMobiliario(TipoMobiliario Datos)
        {
            try
            {
                TipoMobiliario_Datos PD = new TipoMobiliario_Datos();
                return PD.LlenarComboTipoMobiliario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
