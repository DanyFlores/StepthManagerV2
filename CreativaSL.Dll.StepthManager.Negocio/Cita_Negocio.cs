using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Cita_Negocio
    {
        public void CancelarCita(Cita Datos)
        {
            try
            {
                Cita_Datos CD = new Cita_Datos();
                CD.CancelarCita(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ConcluirCita(Cita Datos)
        {
            try
            {
                Cita_Datos CD = new Cita_Datos();
                CD.ConcluirCita(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertarNuevaCita(Cita Datos)
        {
            try
            {
                Cita_Datos CD = new Cita_Datos();
                CD.InsertarNuevaCita(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertarNuevaCitaNotificacion(Cita Datos)
        {
            try
            {
                Cita_Datos CD = new Cita_Datos();
                CD.InsertarCitaEnviarNotificacion(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerCitasBusqueda(Cita Datos)
        {
            try
            {
                Cita_Datos CD = new Cita_Datos();
                CD.ObtenerCitasBusqueda(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCitasPendientesDiaActual(Cita Datos)
        {
            try
            {
                Cita_Datos CD = new Cita_Datos();
                CD.ObtenerCitasPendientesDiaActual(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cita> ObtenerHorarioEmpleado(Cita Datos)
        {
            try
            {
                Cita_Datos CD = new Cita_Datos();
                return CD.ObtenerHorarioEmpleado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cita ObtenerDatosCitasDetalle(Cita Datos)
        {
            try
            {
                Cita_Datos CD = new Cita_Datos();
                return CD.ObtenerDatosCitaDetalle(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
