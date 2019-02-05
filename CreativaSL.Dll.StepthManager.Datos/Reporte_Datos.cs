using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using CreativaSL.Dll.StephManager.Global;
using System.Data.SqlClient;

namespace CreativaSL.Dll.StephManager.Datos
{
    public class Reporte_Datos
    {
        public object[] ObtenerReporteMaterialesProduccion(Sucursal _datos)
        {
            try
            {
                List<ReporteMaterialesProduccion> Lista01 = new List<ReporteMaterialesProduccion>();
                List<ReporteMaterialesProduccion> Lista02 = new List<ReporteMaterialesProduccion>();
                DataSet ds = SqlHelper.ExecuteDataset(_datos.Conexion, "spCSLDB_get_ReporteMaterialesProduccion", _datos.IDSucursal);
                if (ds != null)
                {
                    if (ds.Tables.Count == 2)
                    {
                        DataTableReader dr = ds.Tables[0].CreateDataReader();                        
                        ReporteMaterialesProduccion Item01;
                        while (dr.Read())
                        {
                            Item01 = new ReporteMaterialesProduccion();
                            Item01.IDSucursal = dr.GetString(dr.GetOrdinal("id_sucursal"));
                            Item01.NombreSucursal = dr.GetString(dr.GetOrdinal("nombreSucursal"));
                            Item01.ClaveProducto = dr.GetString(dr.GetOrdinal("clave"));
                            Item01.NombreProducto = dr.GetString(dr.GetOrdinal("nombre"));
                            Item01.Cantidad = dr.GetInt32(dr.GetOrdinal("Cantidad"));
                            Lista01.Add(Item01);
                        }
                        dr.Close();
                        DataTableReader dr2 = ds.Tables[1].CreateDataReader();
                        
                        ReporteMaterialesProduccion Item02;
                        while (dr2.Read())
                        {
                            Item02 = new ReporteMaterialesProduccion();
                            Item02.IDSucursal = dr2.GetString(dr2.GetOrdinal("id_sucursal"));
                            Item02.NombreSucursal = dr2.GetString(dr2.GetOrdinal("nombreSucursal"));
                            Item02.IDEmpleado = dr2.GetString(dr2.GetOrdinal("id_sucursal"));
                            Item02.NombreEmpleado = dr2.GetString(dr2.GetOrdinal("Empleado"));
                            Item02.ClaveProducto = dr2.GetString(dr2.GetOrdinal("clave"));
                            Item02.NombreProducto = dr2.GetString(dr2.GetOrdinal("nombre"));
                            Item02.Cantidad = dr2.GetInt32(dr2.GetOrdinal("Cantidad"));
                            Lista02.Add(Item02);
                        }
                        dr2.Close();
                    }
                }
                object[] Resultado = { Lista01, Lista02 };
                return Resultado;
                
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
                object[] Parametros = { FechaInicio, FechaFin };
                List<ReporteServiciosRealizados> Lista = new List<ReporteServiciosRealizados>();
                ReporteServiciosRealizados Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Reportes.spCSLDB_get_ReporteTrabajosRealizados", Parametros);
                while (Dr.Read())
                {
                    Item = new ReporteServiciosRealizados();
                    Item.IDSucursal = !Dr.IsDBNull(Dr.GetOrdinal("IDSucursal")) ? Dr.GetString(Dr.GetOrdinal("IDSucursal")) : string.Empty;
                    Item.NombreSucursal = !Dr.IsDBNull(Dr.GetOrdinal("NombreSucursal")) ? Dr.GetString(Dr.GetOrdinal("NombreSucursal")) : string.Empty;
                    Item.IDEmpleado = !Dr.IsDBNull(Dr.GetOrdinal("IDEmpleado")) ? Dr.GetString(Dr.GetOrdinal("IDEmpleado")) : string.Empty;
                    Item.NombreEmpleado = !Dr.IsDBNull(Dr.GetOrdinal("NombreEmpleado")) ? Dr.GetString(Dr.GetOrdinal("NombreEmpleado")) : string.Empty;
                    Item.IDServicio = !Dr.IsDBNull(Dr.GetOrdinal("IDServicio")) ? Dr.GetString(Dr.GetOrdinal("IDServicio")) : string.Empty;
                    Item.NombreServicio = !Dr.IsDBNull(Dr.GetOrdinal("NombreServicio")) ? Dr.GetString(Dr.GetOrdinal("NombreServicio")) : string.Empty;
                    Item.Cantidad = !Dr.IsDBNull(Dr.GetOrdinal("CantidadServicios")) ? Dr.GetInt32(Dr.GetOrdinal("CantidadServicios")) : 0;
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
                object[] Parametros = { IDSucursal, FechaInicio, FechaFin };
                List<ReporteConsumoMaterialDetalle> Lista = new List<ReporteConsumoMaterialDetalle>();
                ReporteConsumoMaterialDetalle Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Reportes.spCSLDB_get_ReporteConsumoMaterial", Parametros);
                while (Dr.Read())
                {
                    Item = new ReporteConsumoMaterialDetalle();                    
                    Item.Tipo = !Dr.IsDBNull(Dr.GetOrdinal("Tipo")) ? Dr.GetInt32(Dr.GetOrdinal("Tipo")) : 0;
                    Item.IDGeneral = !Dr.IsDBNull(Dr.GetOrdinal("IDGeneral")) ? Dr.GetString(Dr.GetOrdinal("IDGeneral")) : string.Empty;
                    Item.Nombre = !Dr.IsDBNull(Dr.GetOrdinal("Nombre")) ? Dr.GetString(Dr.GetOrdinal("Nombre")) : string.Empty;
                    Item.IDProducto = !Dr.IsDBNull(Dr.GetOrdinal("IDProducto")) ? Dr.GetString(Dr.GetOrdinal("IDProducto")) : string.Empty;
                    Item.NombreProducto = !Dr.IsDBNull(Dr.GetOrdinal("Producto")) ? Dr.GetString(Dr.GetOrdinal("Producto")) : string.Empty;
                    Item.Clave = !Dr.IsDBNull(Dr.GetOrdinal("Clave")) ? Dr.GetString(Dr.GetOrdinal("Clave")) : string.Empty;
                    Item.Fecha = !Dr.IsDBNull(Dr.GetOrdinal("Fecha")) ? Dr.GetDateTime(Dr.GetOrdinal("Fecha")) : DateTime.MinValue;
                    Item.Produccion = !Dr.IsDBNull(Dr.GetOrdinal("Produccion")) ? Dr.GetBoolean(Dr.GetOrdinal("Produccion")) : false;
                    Item.CumpleMetrica = !Dr.IsDBNull(Dr.GetOrdinal("CumpleMetrica")) ? Dr.GetBoolean(Dr.GetOrdinal("CumpleMetrica")) : false;
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
        


        public int GenerarReporteProductosVendidos(string Conexion, DateTime FechaInicio, DateTime FechaFin, string IDUsuario)
        {
            try
            {
                int IDReporte = -1;
                object[] Parametros = { FechaInicio, FechaFin, IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Conexion, "Reportes.spCSLDB_set_GenerarReporteProductosVendidos", Parametros);
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
        /// Obtiene el detalle del reporte de productos vendidos por ID
        /// </summary>
        /// <param name="Conexion"></param>
        /// <param name="IDReporte"></param>
        /// <returns></returns>        
        public ReporteProductosVendidos ObtenerDetalleReporteProductosVendidos(string Conexion, int IDReporte)
        {
            try
            {
                ReporteProductosVendidos Resultado = new ReporteProductosVendidos();
                DataSet Ds = SqlHelper.ExecuteDataset(Conexion, "Reportes.spCSLDB_get_ReporteProductosVendidosXID", IDReporte);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Resultado.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("FechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaInicio")) : DateTime.MinValue;
                            Resultado.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("FechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaFin")) : DateTime.MinValue;
                            break;
                        }
                        Dr.Close();

                        List<ReporteProductosVendidosDetalle> Lista = new List<ReporteProductosVendidosDetalle>();
                        ReporteProductosVendidosDetalle Item;
                        DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        while (Dr2.Read())
                        {
                            Item = new ReporteProductosVendidosDetalle();
                            Item.IDSucursal = !Dr2.IsDBNull(Dr2.GetOrdinal("IDSucursal")) ? Dr2.GetString(Dr2.GetOrdinal("IDSucursal")) : string.Empty;
                            Item.Sucursal = !Dr2.IsDBNull(Dr2.GetOrdinal("Sucursal")) ? Dr2.GetString(Dr2.GetOrdinal("Sucursal")) : string.Empty;
                            Item.IDProducto = !Dr2.IsDBNull(Dr2.GetOrdinal("IDProducto")) ? Dr2.GetString(Dr2.GetOrdinal("IDProducto")) : string.Empty;
                            Item.Clave = !Dr2.IsDBNull(Dr2.GetOrdinal("Clave")) ? Dr2.GetString(Dr2.GetOrdinal("Clave")) : string.Empty;
                            Item.Producto = !Dr2.IsDBNull(Dr2.GetOrdinal("Producto")) ? Dr2.GetString(Dr2.GetOrdinal("Producto")) : string.Empty;
                            Item.Cantidad = !Dr2.IsDBNull(Dr2.GetOrdinal("Cantidad")) ? Dr2.GetDecimal(Dr2.GetOrdinal("Cantidad")) : 0;
                            Lista.Add(Item);
                        }
                        Dr2.Close();

                        Resultado.Detalle = Lista;
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
        /// Obtiene el reporte de productos vendidos
        /// </summary>
        /// <param name="Conexion"></param>
        /// <param name="Fecha"></param>
        /// <returns></returns>
        public List<ReporteProductosVendidos> ObtenerReportesProductosVendidos(string Conexion, DateTime Fecha)
        {
            try
            {
                List<ReporteProductosVendidos> Lista = new List<ReporteProductosVendidos>();
                ReporteProductosVendidos Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Reportes.spCSLDB_get_ReportesProductosVendidos", Fecha);
                while (Dr.Read())
                {
                    Item = new ReporteProductosVendidos();
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

        //Trabajos Realizados
        public int GenerarReporteTrabajosRealizados(string Conexion, DateTime FechaInicio, DateTime FechaFin, string IDUsuario)
        {
            try
            {
                int IDReporte = -1;
                object[] Parametros = { FechaInicio, FechaFin, IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Conexion, "Reportes.spCSLDB_set_GenerarReporteTrabajosRealizados", Parametros);
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

        public ReporteTrabajosRealizados ObtenerDetalleReporteTrabajosRealizados(string Conexion, int IDReporte)
        {
            try
            {
                ReporteTrabajosRealizados Resultado = new ReporteTrabajosRealizados();
                DataSet Ds = SqlHelper.ExecuteDataset(Conexion, "Reportes.spCSLDB_get_ReporteTrabajosRealizadosXID", IDReporte);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Resultado.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("FechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaInicio")) : DateTime.MinValue;
                            Resultado.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("FechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaFin")) : DateTime.MinValue;
                            break;
                        }
                        Dr.Close();

                        List<ReporteTrabajosRealizadosDetalle> Lista = new List<ReporteTrabajosRealizadosDetalle>();
                        ReporteTrabajosRealizadosDetalle Item;
                        DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        while (Dr2.Read())
                        {
                            Item = new ReporteTrabajosRealizadosDetalle();
                            Item.IDSucursal = !Dr2.IsDBNull(Dr2.GetOrdinal("IDSucursal")) ? Dr2.GetString(Dr2.GetOrdinal("IDSucursal")) : string.Empty;
                            Item.Sucursal = !Dr2.IsDBNull(Dr2.GetOrdinal("Sucursal")) ? Dr2.GetString(Dr2.GetOrdinal("Sucursal")) : string.Empty;
                            Item.IDEmpleado = !Dr2.IsDBNull(Dr2.GetOrdinal("IDEmpleado")) ? Dr2.GetString(Dr2.GetOrdinal("IDEmpleado")) : string.Empty;
                            Item.NombreEmpleado = !Dr2.IsDBNull(Dr2.GetOrdinal("NombreEmpleado")) ? Dr2.GetString(Dr2.GetOrdinal("NombreEmpleado")) : string.Empty;
                            Item.IDServicio = !Dr2.IsDBNull(Dr2.GetOrdinal("IDServicio")) ? Dr2.GetString(Dr2.GetOrdinal("IDServicio")) : string.Empty;
                            Item.NombreServicio = !Dr2.IsDBNull(Dr2.GetOrdinal("NombreServicio")) ? Dr2.GetString(Dr2.GetOrdinal("NombreServicio")) : string.Empty;
                            Item.CantidadServicios = !Dr2.IsDBNull(Dr2.GetOrdinal("CantidadServicios")) ? Dr2.GetInt32(Dr2.GetOrdinal("CantidadServicios")) : 0;
                            Lista.Add(Item);
                        }
                        Dr2.Close();

                        Resultado.Detalle = Lista;
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

        public List<ReporteTrabajosRealizados> ObtenerReporteTrabajosRealizados(string Conexion)
        {
            try
            {
                List<ReporteTrabajosRealizados> Lista = new List<ReporteTrabajosRealizados>();
                ReporteTrabajosRealizados Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Reportes.spCSLDB_get_ReportesTrabajosRealizados");
                while (Dr.Read())
                {
                    Item = new ReporteTrabajosRealizados();
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
        /// <summary>
        /// Método para obtener el reporte del tiempo de servicios
        /// </summary>
        /// <param name="Conexion"></param>
        /// <returns></returns>
        public List<ReporteTiempoServicios> ObtenerReporteTiempoServicio(string Conexion)
        {
            try
            {
                List<ReporteTiempoServicios> Lista = new List<ReporteTiempoServicios>();
                ReporteTiempoServicios Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Reportes.spCSLDB_get_ReporteAGVTiempoServicios");
                while (Dr.Read())
                {
                    Item = new ReporteTiempoServicios();
                    Item.IDEmpleado = !Dr.IsDBNull(Dr.GetOrdinal("IDEmpleado")) ? Dr.GetString(Dr.GetOrdinal("IDEmpleado")) : string.Empty;
                    Item.Empleado = !Dr.IsDBNull(Dr.GetOrdinal("Empleado")) ? Dr.GetString(Dr.GetOrdinal("Empleado")) : string.Empty;
                    Item.IDProducto = !Dr.IsDBNull(Dr.GetOrdinal("IDProducto")) ? Dr.GetString(Dr.GetOrdinal("IDProducto")) : string.Empty;
                    Item.Servicio = !Dr.IsDBNull(Dr.GetOrdinal("Servicio")) ? Dr.GetString(Dr.GetOrdinal("Servicio")) : string.Empty;
                    Item.TiempoAVG = !Dr.IsDBNull(Dr.GetOrdinal("TiempoAVG")) ? Dr.GetString(Dr.GetOrdinal("TiempoAVG")) : string.Empty;
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
        /// <summary>
        /// Método para obtener el mobiliario por sucursal
        /// </summary>
        /// <param name="Conexion">Cadena de conexion a la BD</param>
        /// <param name="IDSucursal">Identificador de la sucursal</param>
        /// <returns>Retorna una lista de tipo ReporteMobiliarioXSucursal</returns>
        public List<ReporteMobiliarioXSucursal> ObtenerReporteMobiliarioAsignadoPorSucursal(string  Conexion, string IDSucursal)
        {
            try
            {
                List<ReporteMobiliarioXSucursal> Lista = new List<ReporteMobiliarioXSucursal>();
                ReporteMobiliarioXSucursal Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Reportes.spCSLDB_get_ReporteMobiliarioAsignadoPorSucursal", IDSucursal);
                while (Dr.Read())
                {
                    Item = new ReporteMobiliarioXSucursal();
                    Item.IDSucursal = !Dr.IsDBNull(Dr.GetOrdinal("IDSucursal")) ? Dr.GetString(Dr.GetOrdinal("IDSucursal")) : string.Empty;
                    Item.NombreSucursal = !Dr.IsDBNull(Dr.GetOrdinal("NombreSucursal")) ? Dr.GetString(Dr.GetOrdinal("NombreSucursal")) : string.Empty;
                    Item.IDMobiliario = !Dr.IsDBNull(Dr.GetOrdinal("IDMobiliario")) ? Dr.GetString(Dr.GetOrdinal("IDMobiliario")) : string.Empty;
                    Item.Codigo = !Dr.IsDBNull(Dr.GetOrdinal("Codigo")) ? Dr.GetString(Dr.GetOrdinal("Codigo")) : string.Empty;
                    Item.Mobiliario = !Dr.IsDBNull(Dr.GetOrdinal("MobiliarioDesc")) ? Dr.GetString(Dr.GetOrdinal("MobiliarioDesc")) : string.Empty;
                    Item.Marca = !Dr.IsDBNull(Dr.GetOrdinal("Marca")) ? Dr.GetString(Dr.GetOrdinal("Marca")) : string.Empty;
                    Item.Modelo = !Dr.IsDBNull(Dr.GetOrdinal("Modelo")) ? Dr.GetString(Dr.GetOrdinal("Modelo")) : string.Empty;
                    Item.NumSerie = !Dr.IsDBNull(Dr.GetOrdinal("NumSerie")) ? Dr.GetString(Dr.GetOrdinal("NumSerie")) : string.Empty;
                    Item.FechaAsigncion = !Dr.IsDBNull(Dr.GetOrdinal("FechaAsignacion")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaAsignacion")) : DateTime.MinValue;
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
        public EstadoResultados ObtenerDetalleEstadoResultados(string Conexion, int IDReporte)
        {
            try
            {
                EstadoResultados Reporte = new EstadoResultados();
                DataSet Ds = SqlHelper.ExecuteDataset(Conexion, "Reportes.spCSLDB_get_DetalleEstadoResultados", IDReporte);
                if (Ds.Tables.Count == 2)
                {
                    DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                    while (Dr.Read())
                    {
                        Reporte.Sucursal = !Dr.IsDBNull(Dr.GetOrdinal("Sucursal")) ? Dr.GetString(Dr.GetOrdinal("Sucursal")) : string.Empty;
                        Reporte.MesDesc = !Dr.IsDBNull(Dr.GetOrdinal("Mes")) ? Dr.GetString(Dr.GetOrdinal("Mes")) : string.Empty;
                        Reporte.Anio = !Dr.IsDBNull(Dr.GetOrdinal("Year")) ? Dr.GetInt32(Dr.GetOrdinal("Year")) : 0;
                        Reporte.IngresoMensual = !Dr.IsDBNull(Dr.GetOrdinal("IngresoMensual")) ? Dr.GetDecimal(Dr.GetOrdinal("IngresoMensual")) : 0;
                        Reporte.IngresoAnual = !Dr.IsDBNull(Dr.GetOrdinal("IngresoAnual")) ? Dr.GetDecimal(Dr.GetOrdinal("IngresoAnual")) : 0;
                        Reporte.CostoVentasMensual = !Dr.IsDBNull(Dr.GetOrdinal("CostoVentasMensual")) ? Dr.GetDecimal(Dr.GetOrdinal("CostoVentasMensual")) : 0;
                        Reporte.CostoVentasAnual = !Dr.IsDBNull(Dr.GetOrdinal("CostoVentasAnual")) ? Dr.GetDecimal(Dr.GetOrdinal("CostoVentasAnual")) : 0;
                        Reporte.ComisionMensual = !Dr.IsDBNull(Dr.GetOrdinal("ComisionMensual")) ? Dr.GetDecimal(Dr.GetOrdinal("ComisionMensual")) : 0;
                        Reporte.ComisionAnual = !Dr.IsDBNull(Dr.GetOrdinal("ComisionAnual")) ? Dr.GetDecimal(Dr.GetOrdinal("ComisionAnual")) : 0;
                        Reporte.ImpuestoMensual = !Dr.IsDBNull(Dr.GetOrdinal("ImpuestoMensual")) ? Dr.GetDecimal(Dr.GetOrdinal("ImpuestoMensual")) : 0;
                        Reporte.ImpuestoAnual = !Dr.IsDBNull(Dr.GetOrdinal("ImpuestoAnual")) ? Dr.GetDecimal(Dr.GetOrdinal("ImpuestoAnual")) : 0;
                        break;
                    }
                    Dr.Close();
                    

                    DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                    List<EstadoResultadosDetalle> Lista = new List<EstadoResultadosDetalle>();
                    EstadoResultadosDetalle Item;
                    while (Dr2.Read())
                    {
                        Item = new EstadoResultadosDetalle();
                        Item.IDRubro = !Dr2.IsDBNull(Dr2.GetOrdinal("IDTipoGasto")) ? Dr2.GetInt32(Dr2.GetOrdinal("IDTipoGasto")) : 0;
                        Item.TipoGasto = !Dr2.IsDBNull(Dr2.GetOrdinal("TipoGasto")) ? Dr2.GetString(Dr2.GetOrdinal("TipoGasto")) : string.Empty;
                        Item.IDSubRubro = !Dr2.IsDBNull(Dr2.GetOrdinal("IDCategoria")) ? Dr2.GetString(Dr2.GetOrdinal("IDCategoria")) : string.Empty;
                        Item.Categoria = !Dr2.IsDBNull(Dr2.GetOrdinal("Categoria")) ? Dr2.GetString(Dr2.GetOrdinal("Categoria")) : string.Empty;
                        Item.MontoMensual = !Dr2.IsDBNull(Dr2.GetOrdinal("MontoMensual")) ? Dr2.GetDecimal(Dr2.GetOrdinal("MontoMensual")) : 0;
                        Item.MontoAnual = !Dr2.IsDBNull(Dr2.GetOrdinal("MontoAnual")) ? Dr2.GetDecimal(Dr2.GetOrdinal("MontoAnual")) : 0;
                        Item.Porcentaje = !Dr2.IsDBNull(Dr2.GetOrdinal("Porcentaje")) ? Dr2.GetDecimal(Dr2.GetOrdinal("Porcentaje")) : 0;
                        Lista.Add(Item);
                    }
                    Reporte.Detalle = Lista;
                    Dr2.Close();
                }
                return Reporte;
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
                List<EstadoResultados> Lista = new List<EstadoResultados>();
                EstadoResultados Item;
                object[] Parametros = { IDMes, Anio };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Reportes.spCSLDB_get_ReportesEstadoResultados", Parametros);
                while(Dr.Read())
                {
                    Item = new EstadoResultados();
                    Item.IDReporte = !Dr.IsDBNull(Dr.GetOrdinal("IDReporte")) ? Dr.GetInt32(Dr.GetOrdinal("IDReporte")) : 0;
                    Item.Sucursal = !Dr.IsDBNull(Dr.GetOrdinal("Sucursal")) ? Dr.GetString(Dr.GetOrdinal("Sucursal")) : string.Empty;
                    Item.Anio = !Dr.IsDBNull(Dr.GetOrdinal("Anio")) ? Dr.GetInt32(Dr.GetOrdinal("Anio")) : 0;
                    Item.MesDesc = !Dr.IsDBNull(Dr.GetOrdinal("Mes")) ? Dr.GetString(Dr.GetOrdinal("Mes")) : string.Empty;
                    Item.FechaReporte = !Dr.IsDBNull(Dr.GetOrdinal("FechaReporte")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaReporte")) : DateTime.MinValue;
                    Lista.Add(Item);
                }
                Dr.Close();
                return Lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int GenerarReporteEstadoResultados(string Conexion, EstadoResultados _Datos, string IDUsuario)
        {
            try
            {
                object[] Parametros = { _Datos.Sucursal, _Datos.IDMes, _Datos.Anio, _Datos.ImpuestoMensual, _Datos.ImpuestoAnual, IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Conexion, "Reportes.spCSLDB_set_GenerarEstadosResultados", Parametros);
                if(Result != null)
                {
                    int IDReporte = 0;
                    if (int.TryParse(Result.ToString(), out IDReporte))
                        return IDReporte;
                }
                return -1;
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
                List<Mes> Lista = new List<Mes>();
                Mes Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Reportes.spCSLDB_get_ComboMeses");
                while(Dr.Read())
                {
                    Item = new Mes();
                    Item.IDMes = !Dr.IsDBNull(Dr.GetOrdinal("IDMes")) ? Dr.GetInt32(Dr.GetOrdinal("IDMes")) : 0;
                    Item.MesDesc = !Dr.IsDBNull(Dr.GetOrdinal("MesDesc")) ? Dr.GetString(Dr.GetOrdinal("MesDesc")) : string.Empty;
                    Lista.Add(Item);
                }
                Dr.Close();
                return Lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
