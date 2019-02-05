using CreativaSL.Dll.StephManager.Datos;
using CreativaSL.Dll.StephManager.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
   public class ReporteGarantiasNegocio
    {
        /// <summary>
        /// Metodo que realiza un llamada a la clase de datos para generar el reporte
        /// </summary>
        /// <param name="Conexion">Conexion con la BD</param>
        /// <param name="FechaInicio">Inicio de los datos del reporte</param>
        /// <param name="FechaFin">fin de los datos del reporte</param>
        /// <param name="IDUsuario">Identificador del usuario que geero el reporte</param>
        /// <returns></returns>
        public int GenerarReporteGarantias(string Conexion, DateTime FechaInicio, DateTime FechaFin, string IDUsuario)
        {
            try
            {
                ReporteGarantias_Datos Datos = new ReporteGarantias_Datos();
                return Datos.GenerarReporteGarantias(Conexion, FechaInicio, FechaFin, IDUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Obtiene los datos especificows del reporte dependiedo de su id
        /// </summary>
        /// <param name="Conexion">Conexion con la BD</param>
        /// <param name="IDReporte">Id del reporte del que se obtedra sus datos</param>
        /// <returns></returns>
        public ReporteGarantias ObtenerDetalleReporteGarantias(string Conexion, int IDReporte)
        {
            try
            {
                ReporteGarantias_Datos Datos = new ReporteGarantias_Datos();
                return Datos.ObtenerDetalleReporteGarantias(Conexion, IDReporte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Obtiene datos geerales de los reportes que ha sido generados
        /// </summary>
        /// <param name="Conexion">Conexion de la BD</param>
        /// <returns></returns>
        public List<ReporteGarantias> ObtenerReportesGarantias(string Conexion)
        {
            try
            {
                ReporteGarantias_Datos Datos = new ReporteGarantias_Datos();
                return Datos.ObtenerReportesGarantias(Conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Efectua una busqueda del reporte mediante una fecha especificada
        /// </summary>
        /// <param name="Conexion">Conexion de la BD</param>
        /// <param name="Fecha"></param>
        /// <returns></returns>
        public List<ReporteGarantias> BuscarReportesGarantias(string Conexion,DateTime Fecha)
        {
            try
            {
                ReporteGarantias_Datos Datos = new ReporteGarantias_Datos();
                return Datos.BuscarReportesGarantias(Conexion,Fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
