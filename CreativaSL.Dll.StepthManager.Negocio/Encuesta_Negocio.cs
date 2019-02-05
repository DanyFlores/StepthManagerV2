using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Encuesta_Negocio
    {

        public void ACEncuestas(Encuesta Datos)
        {
            try
            {
                Encuesta_Datos ED = new Encuesta_Datos();
                ED.ACEncuestas(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarEncuesta(Encuesta Datos)
        {
            try
            {
                Encuesta_Datos ED = new Encuesta_Datos();
                ED.EliminarEncuesta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TipoEncuesta> LlenarComboTipoEncuesta(TipoEncuesta Datos)
        {
            try
            {
                Encuesta_Datos ED = new Encuesta_Datos();
                return ED.LlenarComboTipoEncuesta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TipoPregunta> LlenarComboTipoPregunta(TipoPregunta Datos)
        {
            try
            {
                Encuesta_Datos ED = new Encuesta_Datos();
                return ED.LlenarComboTipoPregunta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerEncuestas(Encuesta Datos)
        {
            try
            {
                Encuesta_Datos ED = new Encuesta_Datos();
                ED.ObtenerEncuestas(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void ObtenerEncuestasTab(Encuesta Datos)
        {
            try
            {
                Encuesta_Datos ED = new Encuesta_Datos();
                ED.ObtenerEncuestasTab(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerEncuestasTabBusqueda(Encuesta Datos)
        {
            try
            {
                Encuesta_Datos ED = new Encuesta_Datos();
                ED.ObtenerEncuestasTabBusqueda(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Encuesta ObtenerDetalleEncuestaXID(Encuesta Datos)
        {
            try
            {
                Encuesta_Datos ED = new Encuesta_Datos();
                return ED.ObtenerDetalleEncuestaXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ActivarEncuesta(Encuesta Datos)
        {
            try
            {
                Encuesta_Datos ED = new Encuesta_Datos();
                ED.ActivarEncuesta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SuspenderEncuesta(Encuesta Datos)
        {
            try
            {
                Encuesta_Datos ED = new Encuesta_Datos();
                ED.SuspenderEncuesta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int NotificacionesEncuestas(Encuesta Datos)
        {
            try
            {
                Encuesta_Datos ED = new Encuesta_Datos();
                return ED.EnviarNotificacionEncuestas(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
