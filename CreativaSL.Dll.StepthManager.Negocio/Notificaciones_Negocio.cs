using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Notificaciones_Negocio
    {
        public int Notificaciones(Notificaciones Datos)
        {
            try
            {
                Notificaciones_Datos ND = new Notificaciones_Datos();
                return ND.EnviarNotificacionIndividuales(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerNotificaciones(Notificaciones Datos)
        {
            try
            {
                Notificaciones_Datos ND = new Notificaciones_Datos();
                ND.ObtenerNotificaciones(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerNotificacionesBusqueda(Notificaciones Datos)
        {
            try
            {
                Notificaciones_Datos ND = new Notificaciones_Datos();
                ND.ObtenerNotificacionesBusqueda(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EliminarNotificaciones(Notificaciones Datos)
        {
            try
            {
                Notificaciones_Datos ND = new Notificaciones_Datos();
                ND.EliminarNotificaciones(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerReenvioNotificacion(Notificaciones Datos)
        {
            try
            {
                Notificaciones_Datos ND = new Notificaciones_Datos();
                ND.ObtenerReenvioNotificaciones(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
