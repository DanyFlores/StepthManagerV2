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
    public class Reporte_DatosTrabajosRealizados
    {
        /// <summary>
        /// Método para Generar un reporte de los Trabajos realizados
        /// </summary>
        /// <param name="Conexion">Cadena de conexión a la BD</param>
        /// <param name="FechaInicio">Fecha de inicio del período</param>
        /// <param name="FechaFin">Fecha de término del período</param>
        /// <param name="IDUsuario">Identificador del Usuario</param>
        /// <returns>Retorna el identificador del reporte seleccionado.</returns>
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

        /// <summary>
        /// Método para obtener el detalle de los trabajos realizados
        /// </summary>
        /// <param name="Conexion">Cadena de conexión a la BD</param>
        /// <param name="IDReporte">ID del Reporte al que se quiere acceder</param>
        /// <returns>Retorna una lista con el detalle del trabajo realizado seleccionado.</returns>
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

        /// <summary>
        /// Método para obtener los trabajos realizados
        /// </summary>
        /// <param name="Conexion">Cadena de conexión a la BD</param>
        /// <param name="Fecha">Filtro para buscar los reportes realizados entre dos fechas</param>
        /// <returns>Retorna una lista con el IDReporte, la fecha de Inicio y la fecha de termino</returns>
        public List<ReporteTrabajosRealizados> ObtenerReporteTrabajosRealizados(string Conexion, DateTime Fecha)
        {
            try
            {
                List<ReporteTrabajosRealizados> Lista = new List<ReporteTrabajosRealizados>();
                ReporteTrabajosRealizados Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Reportes.spCSLDB_get_ReporteTrabajosRealizados", Fecha);
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
       
    }
}

