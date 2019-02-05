using CreativaSL.Dll.StephManager.Datos;
using CreativaSL.Dll.StephManager.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class ReporteVentasXSucursal_Negocio
    {
       /// <summary>
       /// Método para Generar Reporte De Ventas Por Sucursal con detalle de Ventas Por Caja
       /// </summary>
       /// <param name="Conexion"></param>
       /// <param name="FechaInicio"></param>
       /// <param name="FechaFin"></param>
       /// <param name="IDUsuario"></param>
       /// <param name="IDSucursal"></param>
       /// <returns></returns>
        public int GenerarReporteVentasXSucursal(string Conexion, DateTime FechaInicio, DateTime FechaFin, string IDUsuario, string IDSucursal)
        {
            try
            {
                ReporteVentasXSucursal_Datos Datos = new ReporteVentasXSucursal_Datos();
                return Datos.GenerarReporteVentasXSucursalVentasXCaja(Conexion, FechaInicio, FechaFin, IDUsuario, IDSucursal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Método para Generar Reporte De Ventas Por Sucursal con detalle de formas de pago
        /// </summary>
        /// <param name="Conexion"></param>
        /// <param name="FechaInicio"></param>
        /// <param name="FechaFin"></param>
        /// <param name="IDReporte"></param>
        /// <param name="IDSucursal"></param>
        /// <returns></returns>
        public int GenerarReporteVentasXSucursalXFormasPago(string Conexion, DateTime FechaInicio, DateTime FechaFin, int IDReporte, string IDSucursal)
        {
            try
            {
                ReporteVentasXSucursal_Datos Datos = new ReporteVentasXSucursal_Datos();
                return Datos.GenerarReporteVentasXSucursalFormasPago(Conexion, FechaInicio, FechaFin, IDReporte, IDSucursal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Obtener detalles del reporte de ventas por sucursal
        /// </summary>
        /// <param name="Conexion"></param>
        /// <param name="IDReporte"></param>
        /// <returns></returns>
        public ReportesVentaXSucursal ObtenerDetalleReporteVentasXSucursal(string Conexion, int IDReporte)
        {
            try
            {
                ReporteVentasXSucursal_Datos Datos = new ReporteVentasXSucursal_Datos();
                return Datos.ObtenerDetalleReportesVentasXSucursal(Conexion, IDReporte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Obtener el Reporte de ventas por sucursal
        /// </summary>
        /// <param name="Conexion"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public List<ReportesVentaXSucursal> ObtenerReporteVentasXSucursal(string Conexion, DateTime fecha)
        {
            try
            {
                ReporteVentasXSucursal_Datos Datos = new ReporteVentasXSucursal_Datos();
                return Datos.ObtenerReporteVentasXSucursal(Conexion, fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
