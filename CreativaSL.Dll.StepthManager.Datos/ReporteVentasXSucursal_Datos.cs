using CreativaSL.Dll.StephManager.Global;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Datos
{
    public class ReporteVentasXSucursal_Datos
    {
        #region MÉTODOS
        /// <summary>
        /// Método para G
        /// Generar reporte Ventas Por sucursal con detalle de ventas por caja
        /// </summary>
        /// <param name="Conexion"></param>
        /// <param name="FechaInicio"></param>
        /// <param name="FechaFin"></param>
        /// <param name="IDUsuario"></param>
        /// <param name="IDSucursal"></param>
        /// <returns></returns>
        public int GenerarReporteVentasXSucursalVentasXCaja(string Conexion, DateTime FechaInicio, DateTime FechaFin, string IDUsuario, string IDSucursal)
        {
            try
            {
                int IDReporte = -1;
                object[] Parametros = { FechaInicio, FechaFin, IDUsuario, IDSucursal };
                object Result = SqlHelper.ExecuteScalar(Conexion, "Reportes.spCSLDB_set_GenerarReporteVentasXSucursalVentasXCaja", Parametros);
                if (Result != null)
                {
                    int.TryParse(Result.ToString(), out IDReporte);
                }
                return IDReporte;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Generar reporte Ventas Por sucursal con detalle de Formas de Pago
        /// </summary>
        /// <param name="Conexion"></param>
        /// <param name="FechaInicio"></param>
        /// <param name="FechaFin"></param>
        /// <param name="IDReporte"></param>
        /// <param name="IDSucursal"></param>
        /// <returns></returns>
        public int GenerarReporteVentasXSucursalFormasPago(string Conexion, DateTime FechaInicio, DateTime FechaFin, int IDReporte, string IDSucursal)
        {
            try
            {
                //int IDReporte = -1;
                object[] Parametros = { FechaInicio, FechaFin, IDReporte, IDSucursal};
                object Result = SqlHelper.ExecuteScalar(Conexion, "Reportes.spCSLDB_set_GenerarReporteVentasXSucursalXFormasPago", Parametros);
                if (Result != null)
                {
                    int.TryParse(Result.ToString(), out IDReporte);
                }
                return IDReporte;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// obtener reporte Ventas Por sucursal con detalle de ventas por caja
        /// </summary>
        /// <param name="Conexion"></param>
        /// <param name="IDReporte"></param>
        /// <returns></returns>
        public ReportesVentaXSucursal ObtenerDetalleReportesVentasXSucursal(string Conexion, int IDReporte)
        {
            try
            {
                ReportesVentaXSucursal Resultado = new ReportesVentaXSucursal();
                DataSet Ds = SqlHelper.ExecuteDataset(Conexion, "Reportes.spCSLDB_get_ReporteVentasXSucursalXID", IDReporte);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 3)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Resultado.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("FechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaInicio")) : DateTime.MinValue;
                            Resultado.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("FechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaFin")) : DateTime.MinValue;
                            Resultado.NombreSucursal = !Dr.IsDBNull(Dr.GetOrdinal("NombreSucursal")) ? Dr.GetString(Dr.GetOrdinal("NombreSucursal")) : string.Empty;
                            break;
                        }
                        Dr.Close();

                        List<ReporteVentasXSucursalDetalleVentasXCaja> Lista1 = new List<ReporteVentasXSucursalDetalleVentasXCaja>();
                        ReporteVentasXSucursalDetalleVentasXCaja Item;
                        DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        while (Dr2.Read())
                        {
                            Item = new ReporteVentasXSucursalDetalleVentasXCaja();
                            Item.FechaInicio = !Dr2.IsDBNull(Dr2.GetOrdinal("FechaInicio")) ? Dr2.GetDateTime(Dr2.GetOrdinal("FechaInicio")) : DateTime.MinValue;
                            Item.NombreCompleto = !Dr2.IsDBNull(Dr2.GetOrdinal("NombreCompleto")) ? Dr2.GetString(Dr2.GetOrdinal("NombreCompleto")) : string.Empty;
                            Item.TotalCobros = !Dr2.IsDBNull(Dr2.GetOrdinal("TotalCobros")) ? Dr2.GetDecimal(Dr2.GetOrdinal("TotalCobros")) :0;
                           
                            
                            Lista1.Add(Item);
                        }
                        Dr2.Close();

                        List<ReporteVentasXSucursalDetalleXFormasPago> Lista2 = new List<ReporteVentasXSucursalDetalleXFormasPago>();
                        ReporteVentasXSucursalDetalleXFormasPago Item2;
                        DataTableReader Dr3 = Ds.Tables[2].CreateDataReader();
                        while (Dr3.Read())
                        {
                            Item2 = new ReporteVentasXSucursalDetalleXFormasPago();
                            Item2.Descripcion = !Dr3.IsDBNull(Dr3.GetOrdinal("Descripcion")) ? Dr3.GetString(Dr3.GetOrdinal("Descripcion")) : string.Empty;                            
                            Item2.Monto = !Dr3.IsDBNull(Dr3.GetOrdinal("Monto")) ? Dr3.GetDecimal(Dr3.GetOrdinal("Monto")) : 0;
                            Lista2.Add(Item2);
                        }
                        Dr2.Close();

                        Resultado.Detalle1 = Lista1;
                        Resultado.Detalle2 = Lista2;
                        Resultado.Completo = true;
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       /// <summary>
       /// Otener el reporte de Ventas por Sucursal
       /// </summary>
       /// <param name="Conexion"></param>
       /// <param name="Fecha"></param>
       /// <returns></returns>
        public List<ReportesVentaXSucursal> ObtenerReporteVentasXSucursal(string Conexion, DateTime Fecha)
        {
            try
            {
                List<ReportesVentaXSucursal> Lista = new List<ReportesVentaXSucursal>();
                ReportesVentaXSucursal Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Reportes.spCSLDB_get_ReporteVentasXSucursal", Fecha);
                while (Dr.Read())
                {
                    Item = new ReportesVentaXSucursal();
                    Item.IDReporte = !Dr.IsDBNull(Dr.GetOrdinal("IDReporte")) ? Dr.GetInt32(Dr.GetOrdinal("IDReporte")) : 0;
                    Item.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("FechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaInicio")) : DateTime.MinValue;
                    Item.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("FechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaFin")) : DateTime.MinValue;
                    Item.NombreSucursal = !Dr.IsDBNull(Dr.GetOrdinal("NombreSucursal")) ? Dr.GetString(Dr.GetOrdinal("NombreSucursal")) : string.Empty;
                    Lista.Add(Item);
                }
                Dr.Close();
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
    

