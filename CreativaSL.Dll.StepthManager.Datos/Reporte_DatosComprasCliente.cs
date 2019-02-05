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
    public class Reporte_DatosComprasCliente
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
        public int GenerarReporteComprasCliente(string Conexion, DateTime FechaInicio, DateTime FechaFin,string IDCliente, string IDUsuario)
        {
            try
            {
                int IDReporte = -1;
                object[] Parametros = { FechaInicio, FechaFin, IDCliente, IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Conexion, "Reportes.spCSLDB_set_GenerarReporteComprasCliente", Parametros);
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
        /// Método para obtener el detalle del reporte elegido
        /// </summary>
        /// <param name="Conexion">Cadena de conexión a la BD</param>
        /// <param name="IDReporte">ID del Reporte al que se quiere acceder</param>
        /// <returns>Retorna una lista con el detalle del reporte seleccionado.</returns>
        public ReporteComprasCliente ObtenerDetalleReporteComprasCliente(string Conexion, int IDReporte)
        {
            try
            {
                ReporteComprasCliente Resultado = new ReporteComprasCliente();
                DataSet Ds = SqlHelper.ExecuteDataset(Conexion, "Reportes.spCSLDB_get_ReporteComprasClienteXID", IDReporte);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            
                            Resultado.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("FechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaInicio")) : DateTime.MinValue;
                            Resultado.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("FechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaFin")) : DateTime.MinValue;
                            Resultado.IDCliente = !Dr.IsDBNull(Dr.GetOrdinal("IDCliente")) ? Dr.GetString(Dr.GetOrdinal("IDCliente")) : string.Empty;
                            Resultado.Nombre = !Dr.IsDBNull(Dr.GetOrdinal("Nombre")) ? Dr.GetString(Dr.GetOrdinal("Nombre")) : string.Empty;
                            break;
                        }
                        Dr.Close();

                        List<ReporteComprasClienteDetalle> Lista = new List<ReporteComprasClienteDetalle>();
                        ReporteComprasClienteDetalle Item;
                        DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        while (Dr2.Read())
                        {
                            Item = new ReporteComprasClienteDetalle();
                            Item.FolioVenta = !Dr2.IsDBNull(Dr2.GetOrdinal("FolioVenta")) ? Dr2.GetString(Dr2.GetOrdinal("FolioVenta")) : string.Empty;
                            Item.NombreSucursal = !Dr2.IsDBNull(Dr2.GetOrdinal("NombreSucursal")) ? Dr2.GetString(Dr2.GetOrdinal("NombreSucursal")) : string.Empty;
                            Item.FechaVenta = !Dr2.IsDBNull(Dr2.GetOrdinal("FechaVenta")) ? Dr2.GetDateTime(Dr2.GetOrdinal("FechaVenta")) : DateTime.MinValue;
                            Item.Servicios = !Dr2.IsDBNull(Dr2.GetOrdinal("Servicios")) ? Dr2.GetString(Dr2.GetOrdinal("Servicios")) : string.Empty;
                            Item.Total = !Dr2.IsDBNull(Dr2.GetOrdinal("Total")) ? Dr2.GetDecimal(Dr2.GetOrdinal("Total")) : 0;
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
        /// Método para obtener las compras echas por el cliente
        /// </summary>
        /// <param name="Conexion">Cadena de conexión a la BD</param>
        /// <param name="Fecha">Filtro para buscar los reportes realizados entre dos fechas</param>
        /// <returns>Retorna una lista con el IDReporte, la fecha de Inicio y la fecha de termino</returns>
        public List<ReporteComprasCliente> ObtenerReporteComprasCliente(string Conexion, DateTime Fecha)
        {
            try
            {
                List<ReporteComprasCliente> Lista = new List<ReporteComprasCliente>();
                ReporteComprasCliente Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Reportes.spCSLDB_get_ReporteComprasCliente", Fecha);
                while (Dr.Read())
                {
                    Item = new ReporteComprasCliente();
                    Item.IDReporte = !Dr.IsDBNull(Dr.GetOrdinal("IDReporte")) ? Dr.GetInt32(Dr.GetOrdinal("IDReporte")) : 0;
                    Item.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("FechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaInicio")) : DateTime.MinValue;
                    Item.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("FechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaFin")) : DateTime.MinValue;
                    Item.IDCliente = !Dr.IsDBNull(Dr.GetOrdinal("IDCliente")) ? Dr.GetString(Dr.GetOrdinal("IDCliente")) : string.Empty;
                    Item.Nombre = !Dr.IsDBNull(Dr.GetOrdinal("Nombre")) ? Dr.GetString(Dr.GetOrdinal("Nombre")).ToUpper() : string.Empty;
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
