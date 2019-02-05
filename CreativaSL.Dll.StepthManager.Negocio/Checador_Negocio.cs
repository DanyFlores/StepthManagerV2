using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Checador_Negocio
    {
        public void JustificarRegistroAsistencia(Checador Datos)
        {
            try
            {
                Checador_Datos CD = new Checador_Datos();
                CD.JustificarRegistroAsistencia(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerRegistrosXIDEmpleado(Checador Datos)
        {
            try
            {
                Checador_Datos CD = new Checador_Datos();
                CD.ObtenerRegistrosXIDEmpleado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerResumenChecador(Checador Datos)
        {
            try
            {
                Checador_Datos CD = new Checador_Datos();
                CD.ObtenerResumenChecador(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Checar(Checador Datos)
        {
            try
            {
                Checador_Datos CD = new Checador_Datos();
                CD.Checar(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerHorariosXFecha(Checador Datos)
        {
            try
            {
                Checador_Datos CD = new Checador_Datos();
                CD.ObtenerHorariosXFecha(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
