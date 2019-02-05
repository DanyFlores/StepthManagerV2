using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Servicio_Negocio
    {
        public void ABCCatServicio(Servicio Datos)
        {
            try
            {
                Servicio_Datos SD = new Servicio_Datos();
                SD.ABCCatServicio(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatServicio(Servicio Datos)
        {
            try
            {
                Servicio_Datos SD = new Servicio_Datos();
                SD.ObtenerCatServicios(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Producto> ObtenerProductoDisponiblesXIDServicio(Servicio Datos)
        {
            try
            {
                Servicio_Datos SD = new Servicio_Datos();
                return SD.ObtenerProductosDisponiblesXIDServicio(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Producto> ObtenerProductoXIDServicio(Servicio Datos)
        {
            try
            {
                Servicio_Datos SD = new Servicio_Datos();
                return SD.ObtenerProductoXIDServicio(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Servicio ObtenerDatosServicioXID(Servicio Datos)
        {
            try
            {
                Servicio_Datos SD = new Servicio_Datos();
                return SD.ObtenerDatosServicioXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerCatServicioBusqueda(Servicio Datos)
        {
            try
            {
                Servicio_Datos SD = new Servicio_Datos();
                SD.ObtenerCatServicioBusqueda(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Servicio> LlenarComboCatServicios(Servicio Datos)
        {
            try
            {
                Servicio_Datos SD = new Servicio_Datos();
                return SD.LlenarComboCatServicios(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
