using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Caja_Negocio
    {

        public void AsignarCajaMac(Caja Datos)
        {
            try
            {
                Caja_Datos CD = new Caja_Datos();
                CD.AsignarCajaMac(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GuardarAperturaCaja(Caja Datos)
        {
            try
            {
                Caja_Datos CD = new Caja_Datos();
                CD.GuardarAperturaCaja(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Caja> LlenarComboCatCajas(Caja Datos)
        {
            try
            {
                Caja_Datos CD = new Caja_Datos();
                return CD.LlenarComboCatCajas(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
