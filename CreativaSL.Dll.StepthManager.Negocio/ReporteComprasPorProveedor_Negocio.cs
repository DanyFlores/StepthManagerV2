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
    public class ReporteComprasPorProveedor_Negocio
    {
        public int GenerarReporteComprasPorProveedor(string Conexion, DateTime FechaInicio, DateTime FechaFin, string IDUsuario)
        {
            try
            {
                ReporteComprasPorProveedor_Datos Datos = new ReporteComprasPorProveedor_Datos();
                return Datos.GenerarReporteComprasPorProveedor(Conexion, FechaInicio, FechaFin, IDUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ReporteComprasPorProveedor ObtenerDetalleReporteComprasPorProveedor(string Conexion, int IDReporte)
        {
            try
            {
                ReporteComprasPorProveedor_Datos Datos = new ReporteComprasPorProveedor_Datos();
                return Datos.ObtenerDetalleReporteComprasPorProveedor(Conexion, IDReporte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ReporteComprasPorProveedor> ObtenerReportesComprasPorProveedor(string Conexion)
        {
            try
            {
                ReporteComprasPorProveedor_Datos Datos = new ReporteComprasPorProveedor_Datos();
                return Datos.ObtenerReportesComprasPorProveedor(Conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ReporteComprasPorProveedor> ObtenerReporteComprasPorProveedorBusqueda(string Conexion, DateTime Fecha)
        {
            try
            {
                ReporteComprasPorProveedor_Datos Datos = new ReporteComprasPorProveedor_Datos();
                return Datos.ObtenerReporteComprasPorProveedorBusqueda(Conexion,Fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
