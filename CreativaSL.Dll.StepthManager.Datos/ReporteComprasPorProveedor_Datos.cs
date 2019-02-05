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
    public class ReporteComprasPorProveedor_Datos
    {
        /// <summary>
        /// Realiza el reporte de compras por provedor y devuelve el id del reporte generado
        /// </summary>
        /// <param name="Conexion"> Conexcion a la base de datos</param>
        /// <param name="FechaInicio"> Fecha inicio del reporte</param>
        /// <param name="FechaFin"> Fecha fin del reporte</param>
        /// <param name="IDUsuario">Identificador del usuario que esta haciendo la operacion</param>
        /// <returns></returns>
        public int GenerarReporteComprasPorProveedor(string Conexion, DateTime FechaInicio, DateTime FechaFin, string IDUsuario)
        {
            try
            {
                int IDReporte = -1;
                object[] Parametros = { FechaInicio, FechaFin, IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Conexion, "Reportes.spCSLDB_set_GenerarReporteComprasProveedor", Parametros);
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
        /// Se obtiene El reporte completo por medio del identificador del reporte
        /// </summary>
        /// <param name="Conexion"> Conexion a la base de datos</param>
        /// <param name="IDReporte"> Identificador del reporte</param>
        /// <returns></returns>
        public ReporteComprasPorProveedor ObtenerDetalleReporteComprasPorProveedor(string Conexion, int IDReporte)
        {
            try
            {
                ReporteComprasPorProveedor Resultado = new ReporteComprasPorProveedor();
                DataSet Ds = SqlHelper.ExecuteDataset(Conexion, "Reportes.spCSLDB_get_ReporteComprasProveedorXID", IDReporte);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 3)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Resultado.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("FechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaInicio")) : DateTime.MinValue;
                            Resultado.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("FechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaFin")) : DateTime.MinValue;
                            break;
                        }
                        Dr.Close();

                        List<ReporteComprasPorProveedorDetalle> Lista = new List<ReporteComprasPorProveedorDetalle>();
                        ReporteComprasPorProveedorDetalle Item;
                        DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        while (Dr2.Read())
                        {
                            Item = new ReporteComprasPorProveedorDetalle();
                            Item.IDProveedor = !Dr2.IsDBNull(Dr2.GetOrdinal("IDProveedor")) ? Dr2.GetString(Dr2.GetOrdinal("IDProveedor")) : string.Empty;
                            Item.Proveedor = !Dr2.IsDBNull(Dr2.GetOrdinal("Proveedor")) ? Dr2.GetString(Dr2.GetOrdinal("Proveedor")) : string.Empty;
                            Item.Total = !Dr2.IsDBNull(Dr2.GetOrdinal("Total")) ? Dr2.GetDecimal(Dr2.GetOrdinal("Total")) : 0;
                            Lista.Add(Item);
                        }
                        Dr2.Close();

                        List<ReporteComprasPorProveedorDetalle> ListaMob = new List<ReporteComprasPorProveedorDetalle>();
                        ReporteComprasPorProveedorDetalle ItemMob;
                        DataTableReader Dr3 = Ds.Tables[2].CreateDataReader();
                        while (Dr3.Read())
                        {
                            ItemMob = new ReporteComprasPorProveedorDetalle();
                            ItemMob.IDProveedor = !Dr3.IsDBNull(Dr3.GetOrdinal("IDProveedor")) ? Dr3.GetString(Dr3.GetOrdinal("IDProveedor")) : string.Empty;
                            ItemMob.Proveedor = !Dr3.IsDBNull(Dr3.GetOrdinal("Proveedor")) ? Dr3.GetString(Dr3.GetOrdinal("Proveedor")) : string.Empty;
                            ItemMob.Total = !Dr3.IsDBNull(Dr3.GetOrdinal("Total")) ? Dr3.GetDecimal(Dr3.GetOrdinal("Total")) : 0;
                            ListaMob.Add(ItemMob);
                        }
                        Dr3.Close();

                        Resultado.Detalle = Lista;
                        Resultado.DetalleMob = ListaMob;
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
        /// obtiene todos los reportes generados previamente
        /// </summary>
        /// <param name="Conexion"></param>
        /// <returns></returns>
        public List<ReporteComprasPorProveedor> ObtenerReportesComprasPorProveedor(string Conexion)
        {
            try
            {
                List<ReporteComprasPorProveedor> Lista = new List<ReporteComprasPorProveedor>();
                ReporteComprasPorProveedor Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Reportes.spCSLDB_get_ReporteComprasProveedorGrid");
                while (Dr.Read())
                {
                    Item = new ReporteComprasPorProveedor();
                    Item.IDReporte = !Dr.IsDBNull(Dr.GetOrdinal("IDReporte")) ? Dr.GetInt32(Dr.GetOrdinal("IDReporte")) : 0;
                    Item.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("FechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaInicio")) : DateTime.MinValue;
                    Item.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("FechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaFin")) : DateTime.MinValue;
                    Lista.Add(Item);
                }
                Dr.Close();
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }// 

        /// <summary>
        /// obtiene todos los reportes generados previamente y que son filtrados por la busqueda
        /// </summary>
        /// <param name="Conexion"></param>
        /// <param name="Fecha"></param>
        /// <returns></returns>
        public List<ReporteComprasPorProveedor> ObtenerReporteComprasPorProveedorBusqueda(string Conexion, DateTime Fecha)
        {
            try
            {
                List<ReporteComprasPorProveedor> Lista = new List<ReporteComprasPorProveedor>();
                ReporteComprasPorProveedor Item;
                object[] Parametros = { Fecha };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Reportes.spCSLDB_get_ReporteComprasProveedorSearchGrid", Parametros);
                while (Dr.Read())
                {
                    Item = new ReporteComprasPorProveedor();
                    Item.IDReporte = !Dr.IsDBNull(Dr.GetOrdinal("IDReporte")) ? Dr.GetInt32(Dr.GetOrdinal("IDReporte")) : 0;
                    Item.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("FechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaInicio")) : DateTime.MinValue;
                    Item.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("FechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaFin")) : DateTime.MinValue;
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
    }
}
