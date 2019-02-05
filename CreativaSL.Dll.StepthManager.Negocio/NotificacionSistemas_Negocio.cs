using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class NotificacionesSistemas_Negocio
    {
        
        public void ObtenerNotificaciones(NotificacionesSistemas Datos)
        {
            try
            {
                NotificacionSistemas_Datos NSD = new NotificacionSistemas_Datos();
                NSD.ObtenerNotificaciones(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ActualizarNotificacionVisto(NotificacionesSistemas NS)
        {
            try
            {
                NotificacionSistemas_Datos NSD = new NotificacionSistemas_Datos();
                NSD.ActualizarNotificacionVisto(NS);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
