using CreativaSL.Dll.StephManager.Datos;
using CreativaSL.Dll.StephManager.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Reporte_NegocioMonedero
    {
        /// <summary>
        /// Método para generar el reporte de trabajos realizados
        /// </summary>
        /// <param name="Conexion">Cadena de conexión a la BD</param>
        /// <param name="FechaInicio">Fecha de inicio del período</param>
        /// <param name="FechaFin">Fecha de término del período</param>
        /// <param name="IDUsuario">Identificador del usuraio</param>
        /// <returns>Retorna el identificador del reporte seleccionado.</returns>
        public int GenerarReporteMonedero(string Conexion, DateTime FechaInicio, DateTime FechaFin, string IDUsuario)
        {
            try
            {
                Reporte_DatosMonedero Datos = new Reporte_DatosMonedero();
                return Datos.GenerarReporteMonedero(Conexion, FechaInicio, FechaFin, IDUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para obtener el detalle de los trabajos realizados
        /// </summary>
        /// <param name="Conexion">Cadena de conexión a la BD</param>
        /// <param name="IDReporte">ID del Reporte al que se quiere acceder</param>
        /// <returns>Retorna una lista con el detalle del trabajo realizado seleccionado.</returns>
        public ReporteMonedero ObtenerDetalleReporteMonedero(string Conexion, int IDReporte)
        {
            try
            {
                Reporte_DatosMonedero Datos = new Reporte_DatosMonedero();
                return Datos.ObtenerDetalleReporteMonedero(Conexion, IDReporte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para obtener los trabajos realizados
        /// </summary>
        /// <param name="Conexion">Cadena de conexión a la BD</param>
        /// <param name="Fecha">Filtro para buscar los reportes realizados entre dos fechas</param>
        /// <returns>Retorna una lista con el IDReporte, la fecha de Inicio y la fecha de termino</returns>
        public List<ReporteMonedero> ObtenerReportesMonedero(string Conexion, DateTime fecha)
        {
            try
            {
                Reporte_DatosMonedero Datos = new Reporte_DatosMonedero();
                return Datos.ObtenerReporteMonedero(Conexion, fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
