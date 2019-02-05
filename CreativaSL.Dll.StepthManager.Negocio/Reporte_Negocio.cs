using CreativaSL.Dll.StephManager.Datos;
using CreativaSL.Dll.StephManager.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Reporte_Negocio
    {
        public object[] ObtenerReporteMaterialesProduccion(Sucursal _datos)
        {
            try
            {
                Reporte_Datos repDatos = new Reporte_Datos();
                return repDatos.ObtenerReporteMaterialesProduccion(_datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ReporteServiciosRealizados> ObtenerReporteServiciosRealizados(string Conexion, DateTime FechaInicio, DateTime FechaFin)
        {
            try
            {
                Reporte_Datos Datos = new Reporte_Datos();
                return Datos.ObtenerReporteServiciosRealizados(Conexion, FechaInicio, FechaFin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Método para obtener el reporte de consumo de material
        /// </summary>
        /// <param name="Conexion">Cadena de conexión a la BD</param>
        /// <param name="IDSucursal">Identificador de la sucursal a la que se generará el reporte</param>
        /// <param name="FechaInicio">Fecha de inicio del período</param>
        /// <param name="FechaFin">Fecha de término del período</param>
        /// <returns>Retorna una lista con el detalle de consumo de material de la sucursal seleccionada.</returns>
        public List<ReporteConsumoMaterialDetalle> ObtenerReporteConsumoMaterial(string Conexion, string IDSucursal, DateTime FechaInicio, DateTime FechaFin)
        {
            try
            {
                Reporte_Datos Datos = new Reporte_Datos();
                return Datos.ObtenerReporteConsumoMaterial(Conexion, IDSucursal, FechaInicio, FechaFin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Genera el Reporte de Productos Vendidos
        /// </summary>
        /// <param name="Conexion"></param>
        /// <param name="FechaInicio"></param>
        /// <param name="FechaFin"></param>
        /// <param name="IDUsuario"></param>
        /// <returns></returns>
        public int GenerarReporteProductosVendidos(string Conexion, DateTime FechaInicio, DateTime FechaFin, string IDUsuario)
        {
            try
            {
                Reporte_Datos Datos = new Reporte_Datos();
                return Datos.GenerarReporteProductosVendidos(Conexion, FechaInicio, FechaFin, IDUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Obtiene del datalle de Reporte Porductos Vendidos por IdReporte
        /// </summary>
        /// <param name="Conexion"></param>
        /// <param name="IDReporte"></param>
        /// <returns></returns>
        public ReporteProductosVendidos ObtenerDetalleReporteProductosVendidos(string Conexion, int IDReporte)
        {
            try
            {
                Reporte_Datos Datos = new Reporte_Datos();
                return Datos.ObtenerDetalleReporteProductosVendidos(Conexion, IDReporte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Obtiene el reporte de Porductos Vendidos por Fecha
        /// </summary>
        /// <param name="Conexion"></param>
        /// <param name="Fecha"></param>
        /// <returns></returns>
        public List<ReporteProductosVendidos> ObtenerReportesProductosVendidos(string Conexion, DateTime Fecha)
        {
            try
            {
                Reporte_Datos Datos = new Reporte_Datos();
                return Datos.ObtenerReportesProductosVendidos(Conexion, Fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Obtiene el reporte del promedio del tiempo de los servicios
        /// </summary>
        /// <param name="Conexion"></param>
        /// <returns></returns>
        public List<ReporteTiempoServicios> ObtenerReporteTiempoServicio()
        {
            try
            {
                Reporte_Datos Datos1 = new Reporte_Datos();
                return Datos1.ObtenerReporteTiempoServicio(Comun.Conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //TrabajosRealizados
        public int GenerarReporteTrabajosRealizados(string Conexion, DateTime FechaInicio, DateTime FechaFin, string IDUsuario)
        {
            try
            {
                Reporte_Datos Datos = new Reporte_Datos();
                return Datos.GenerarReporteTrabajosRealizados(Conexion, FechaInicio, FechaFin, IDUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ReporteTrabajosRealizados ObtenerDetalleReporteTrabajosRealizados(string Conexion, int IDReporte)
        {
            try
            {
                Reporte_Datos Datos = new Reporte_Datos();
                return Datos.ObtenerDetalleReporteTrabajosRealizados(Conexion, IDReporte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ReporteTrabajosRealizados> ObtenerReportesTrabajosRealizados(string Conexion)
        {
            try
            {
                Reporte_Datos Datos = new Reporte_Datos();
                return Datos.ObtenerReporteTrabajosRealizados(Conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public List<ReporteMobiliarioXSucursal> ObtenerReporteMobiliarioAsignadoPorSucursal(string Conexion, string IDSucursal)
        {
            try
            {
                Reporte_Datos Datos = new Reporte_Datos();
                return Datos.ObtenerReporteMobiliarioAsignadoPorSucursal(Conexion, IDSucursal);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EstadoResultados ObtenerDetalleEstadoResultados(string Conexion, int IDReporte)
        {
            try
            {
                Reporte_Datos Datos = new Reporte_Datos();
                return Datos.ObtenerDetalleEstadoResultados(Conexion, IDReporte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<EstadoResultados> ObtenerGridReporteER(string Conexion, int IDMes, int Anio)
        {
            try
            {
                Reporte_Datos Datos = new Reporte_Datos();
                return Datos.ObtenerGridReporteER(Conexion, IDMes, Anio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GenerarReporteEstadoResultados(string Conexion, EstadoResultados _Datos, string IDUsuario)
        {
            try
            {
                Reporte_Datos Datos = new Reporte_Datos();
                return Datos.GenerarReporteEstadoResultados(Conexion, _Datos, IDUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Mes> ObtenerComboMeses(string Conexion)
        {
            try
            {
                try
                {
                    Reporte_Datos Datos = new Reporte_Datos();
                    return Datos.ObtenerComboMeses(Conexion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
