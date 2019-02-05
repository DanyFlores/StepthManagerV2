using CreativaSL.Dll.StephManager.Datos;
using CreativaSL.Dll.StephManager.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Reporte_NegocioComprasCliente
    {
        /// <summary>
        /// Método para Generar un reporte de las compras que ha echo un cliente
        /// </summary>
        /// <param name="Conexion">Cadena de conexión a la BD</param>
        /// <param name="FechaInicio">Fecha de inicio del período</param>
        /// <param name="FechaFin">Fecha de término del período</param>
        /// <param name="IDCliente">Identificador del Cliente</param>
        /// <param name="IDUsuario">Identificador del Usuario</param>
        /// <returns>Retorna el identificador del reporte seleccionado.</returns>
        public int GenerarReporteComprasCliente(string Conexion, DateTime FechaInicio, DateTime FechaFin, string IDCliente, string IDUsuario)
        {
            try
            {
                Reporte_DatosComprasCliente Datos = new Reporte_DatosComprasCliente();
                return Datos.GenerarReporteComprasCliente(Conexion, FechaInicio, FechaFin, IDCliente, IDUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para obtener el detalle del reporte elegido
        /// </summary>
        /// <param name="Conexion">Cadena de conexión a la BD</param>
        /// <param name="IDReporte">ID del Reporte al que se quiere acceder</param>
        /// <returns>Retorna una lista con el detalle del reporte seleccionado.</returns>
        public ReporteComprasCliente ObtenerDetalleReporteComprasCliente(string Conexion, int IDReporte)
        {
            try
            {
                Reporte_DatosComprasCliente Datos = new Reporte_DatosComprasCliente();
                return Datos.ObtenerDetalleReporteComprasCliente(Conexion, IDReporte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para obtener las compras echas por el cliente
        /// </summary>
        /// <param name="Conexion">Cadena de conexión a la BD</param>
        /// <param name="Fecha">Filtro para buscar los reportes realizados entre dos fechas</param>
        /// <returns>Retorna una lista con el IDReporte, la fecha de Inicio y la fecha de termino</returns>
        public List<ReporteComprasCliente> ObtenerReporteComprasCliente(string Conexion, DateTime Fecha)
        {
            try
            {
                Reporte_DatosComprasCliente Datos = new Reporte_DatosComprasCliente();
                return Datos.ObtenerReporteComprasCliente(Conexion, Fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
