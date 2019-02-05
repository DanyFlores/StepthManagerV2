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
    public class ReporteGarantias_Datos
    {

        public int GenerarReporteGarantias(string Conexion, DateTime FechaInicio, DateTime FechaFin, string IDUsuario)
        {
            try
            {
                int IDReporte = -1;
                object[] Parametros = { FechaInicio, FechaFin, IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Conexion, "Reportes.spCSLDB_set_GenerarReporteGarantias", Parametros);
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

        public ReporteGarantias ObtenerDetalleReporteGarantias(string Conexion, int IDReporte)
        {
            try
            {
                ReporteGarantias Resultado = new ReporteGarantias();
                DataSet Ds = SqlHelper.ExecuteDataset(Conexion, "Reportes.spCSLDB_get_ReporteGarantiasXID", IDReporte);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Resultado.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("fechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaInicio")) : DateTime.MinValue;
                            Resultado.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("fechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaFin")) : DateTime.MinValue;
                            break;
                        }
                        Dr.Close();

                        List<ReporteGarantias> Lista = new List<ReporteGarantias>();
                        ReporteGarantias Item;
                        DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        while (Dr2.Read())
                        {
                            Item = new ReporteGarantias();
                            Item.Fecha = !Dr2.IsDBNull(Dr2.GetOrdinal("fecha")) ? Dr2.GetDateTime(Dr2.GetOrdinal("fecha")) : DateTime.MinValue;
                            Item.Id_sucursal = !Dr2.IsDBNull(Dr2.GetOrdinal("id_sucursal")) ? Dr2.GetString(Dr2.GetOrdinal("id_sucursal")) : string.Empty;
                            Item.NombreSucursal = !Dr2.IsDBNull(Dr2.GetOrdinal("nombreSucursal")) ? Dr2.GetString(Dr2.GetOrdinal("nombreSucursal")) : string.Empty;
                            Item.NombreCompleto = !Dr2.IsDBNull(Dr2.GetOrdinal("nombreCompleto")) ? Dr2.GetString(Dr2.GetOrdinal("nombreCompleto")) : string.Empty;
                            Item.Observaciones = !Dr2.IsDBNull(Dr2.GetOrdinal("observaciones")) ? Dr2.GetString(Dr2.GetOrdinal("observaciones")) : string.Empty;
                            Item.Nombre = !Dr2.IsDBNull(Dr2.GetOrdinal("nombre")) ? Dr2.GetString(Dr2.GetOrdinal("nombre")) : string.Empty;
                            Item.Total = !Dr2.IsDBNull(Dr2.GetOrdinal("total")) ? Dr2.GetDecimal(Dr2.GetOrdinal("total")) : 0;
                            Item.EmpleadoAplica = !Dr2.IsDBNull(Dr2.GetOrdinal("empleadoAplica")) ? Dr2.GetString(Dr2.GetOrdinal("empleadoAplica")) : string.Empty;
                            
                            Lista.Add(Item);
                        }
                        Dr2.Close();

                        Resultado.Detalle = Lista;
                        Resultado.Completado= true;
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ReporteGarantias> ObtenerReportesGarantias(string Conexion)
        {
            try
            {
                List<ReporteGarantias> Lista = new List<ReporteGarantias>();
                ReporteGarantias Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Reportes.spCSLDB_get_ReporteGarantias");
                while (Dr.Read())
                {
                    Item = new ReporteGarantias();
                    Item.Id_reporte = !Dr.IsDBNull(Dr.GetOrdinal("Id_reporte")) ? Dr.GetInt32(Dr.GetOrdinal("Id_reporte")) : 0;
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
        public List<ReporteGarantias> BuscarReportesGarantias(string Conexion,DateTime Fecha)
        {
            try
            {
                List<ReporteGarantias> Lista = new List<ReporteGarantias>();
                ReporteGarantias Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Reportes.spCSLDB_get_ReporteGarantiasSearchGrid", Fecha);
                while (Dr.Read())
                {
                    Item = new ReporteGarantias();
                    Item.Id_reporte = !Dr.IsDBNull(Dr.GetOrdinal("Id_reporte")) ? Dr.GetInt32(Dr.GetOrdinal("Id_reporte")) : 0;
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
