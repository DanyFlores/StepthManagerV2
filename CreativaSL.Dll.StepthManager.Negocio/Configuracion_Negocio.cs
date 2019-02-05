using CreativaSL.Dll.StephManager.Datos;
using CreativaSL.Dll.StephManager.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Configuracion_Negocio
    {
        public Configuracion ObtenerDatosConfiguracion(string Conexion)
        {
            try
            {
                Configuracion_Datos CD = new Configuracion_Datos();
                return CD.ObtenerDatosConfiguracion(Conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GuardarDatosConfiguracion(Configuracion Datos)
        {
            try
            {
                Configuracion_Datos CN = new Configuracion_Datos();
                CN.GuardarDatosConfiguracion(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Configuracion ObtenerLogoImagen(string Conexion)
        {
            try
            {
                Configuracion_Datos CN = new Configuracion_Datos();
                return CN.ObtenerLogoImagen(Conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void LogoActualizado(Configuracion Datos)
        {
            try
            {
                Configuracion_Datos CN = new Configuracion_Datos();
                CN.LogoActualizado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void EsFechaCorte(Configuracion Datos)
        {
            try
            {
                Configuracion_Datos CD = new Configuracion_Datos();
                CD.EsFechaCorte(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EjecutarCorte(Configuracion Datos)
        {
            try
            {
                Configuracion_Datos CD = new Configuracion_Datos();
                CD.EjecutarCorte(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
