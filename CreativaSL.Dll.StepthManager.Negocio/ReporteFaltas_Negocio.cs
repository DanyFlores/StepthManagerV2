using CreativaSL.Dll.StephManager.Datos;
using CreativaSL.Dll.StephManager.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    /// <summary>
    /// Puentes para la capa de negocio
    /// </summary>
    public class ReporteFaltas_Negocio
    {
        public int GenerarReporteFaltas(string Conexion, DateTime FechaInicio, DateTime FechaFin, string IDUsuario)
        {
            try
            {
                ReporteFaltas_Datos Datos = new ReporteFaltas_Datos();
                return Datos.GenerarReporteFaltas(Conexion, FechaInicio, FechaFin, IDUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ReporteFaltas ObtenerDetalleReporteFaltas(string Conexion, int IDReporte)
        {
            try
            {
                ReporteFaltas_Datos Datos = new ReporteFaltas_Datos();
                return Datos.ObtenerDetalleReporteFaltas(Conexion, IDReporte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
            
        public List<ReporteFaltas> ObtenerReportesFaltas(string Conexion)
        {
            try
            {
                ReporteFaltas_Datos Datos = new ReporteFaltas_Datos();
                return Datos.ObtenerReportesFaltas(Conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ReporteFaltas> ObtenerReporteFaltasBusqueda(string Conexion, DateTime Fecha)
        {
            try
            {
                ReporteFaltas_Datos Datos = new ReporteFaltas_Datos();
                return Datos.ObtenerReporteFaltasBusqueda(Conexion, Fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
