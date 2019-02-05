using CreativaSL.Dll.StephManager.Datos;
using CreativaSL.Dll.StephManager.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Home_Negocio
    {
        public void HomeGridProductosServicios(Home Datos)
        {
            try
            {
                Home_Datos PD = new Home_Datos();
                PD.HomeGridProductosServicios(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void HomeGridIncidencias(Home Datos)
        {
            try
            {
                Home_Datos PD = new Home_Datos();
                PD.HomeGridIncidencias(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void HomeGridResumenVentas(Home Datos)
        {
            try
            {
                Home_Datos PD = new Home_Datos();
                PD.HomeGridResumenVentas(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void HomeGridOcupacion(Home Datos)
        {
            try
            {
                Home_Datos PD = new Home_Datos();
                PD.HomeGridOcupacion(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
