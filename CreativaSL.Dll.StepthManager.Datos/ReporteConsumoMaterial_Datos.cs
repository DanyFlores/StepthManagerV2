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
    public class ReporteConsumoMaterial_Datos
    {
        /// <summary>
        /// Metodo para generar el reporte del consumo de material
        /// </summary>
        /// <param name="Conexion">Conexion de la BD</param>
        /// <param name="FechaInicio">Fecha de inicio del reporte</param>
        /// <param name="FechaFin">Fecha en la que inaliza los datos del reporte</param>
        /// <param name="IDUsuario">Identiicados del usuario que realiza esta operacion</param>
        /// <returns></returns>
        public int GenerarReporteConsumoMaterial(string Conexion, DateTime FechaInicio, DateTime FechaFin, string IDUsuario,string id_sucursal)
        {
            try
            {
                int IDReporte = -1;
                object[] Parametros = { FechaInicio, FechaFin, id_sucursal,IDUsuario};
                object Result = SqlHelper.ExecuteScalar(Conexion, "Reportes.spCSLDB_set_GenerarReporteConsumoMaterial", Parametros);
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
        /// Metodo con el cual se obtiene la infor referente a un reporte especifico
        /// </summary>
        /// <param name="Conexion">Cadena de conexion con la base de datos</param>
        /// <param name="IDReporte">identiicaador del reporte</param>
        /// <returns></returns>
        public ReporteConsumoMaterial ObtenerDetalleReporteConsumoMaterial(string Conexion, int IDReporte)
        {
            try
            {
                ReporteConsumoMaterial Resultado = new ReporteConsumoMaterial();
                DataSet Ds = SqlHelper.ExecuteDataset(Conexion, "Reportes.spCSLDB_get_ReporteConsumoMaterialXID", IDReporte);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Resultado.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("fechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaInicio")) : DateTime.MinValue;
                            Resultado.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("fechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaFin")) : DateTime.MinValue;
                            Resultado.Sucursal = !Dr.IsDBNull(Dr.GetOrdinal("Sucursal")) ? Dr.GetString(Dr.GetOrdinal("Sucursal")) : string.Empty;
                            break;
                        }
                        Dr.Close();

                        List<ReporteConsumoMaterialDetalle> Lista = new List<ReporteConsumoMaterialDetalle>();
                        ReporteConsumoMaterialDetalle Item;
                        DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        while (Dr2.Read())
                        {
                            Item = new ReporteConsumoMaterialDetalle();
                            Item.Tipo= !Dr2.IsDBNull(Dr2.GetOrdinal("Tipo")) ? Dr2.GetInt32(Dr2.GetOrdinal("Tipo")) :0;
                            Item.IDGeneral = !Dr2.IsDBNull(Dr2.GetOrdinal("IDGeneral")) ? Dr2.GetString(Dr2.GetOrdinal("IDGeneral")) : string.Empty;
                            Item.Nombre = !Dr2.IsDBNull(Dr2.GetOrdinal("Nombre")) ? Dr2.GetString(Dr2.GetOrdinal("Nombre")) : string.Empty;
                            Item.IDProducto = !Dr2.IsDBNull(Dr2.GetOrdinal("IDProducto")) ? Dr2.GetString(Dr2.GetOrdinal("IDProducto")) : string.Empty;
                            Item.NombreProducto = !Dr2.IsDBNull(Dr2.GetOrdinal("Producto")) ? Dr2.GetString(Dr2.GetOrdinal("Producto")) : string.Empty;
                            Item.Clave = !Dr2.IsDBNull(Dr2.GetOrdinal("Clave")) ? Dr2.GetString(Dr2.GetOrdinal("Clave")) : string.Empty;
                            Item.Fecha = !Dr2.IsDBNull(Dr2.GetOrdinal("Fecha")) ? Dr2.GetDateTime(Dr2.GetOrdinal("Fecha")) : DateTime.MinValue;
                            Item.Produccion = !Dr2.IsDBNull(Dr2.GetOrdinal("Produccion")) ? Dr2.GetBoolean(Dr2.GetOrdinal("Produccion")) : false;
                            Item.CumpleMetrica = !Dr2.IsDBNull(Dr2.GetOrdinal("CumpleMetrica")) ? Dr2.GetBoolean(Dr2.GetOrdinal("CumpleMetrica")) : false;
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
        /// Metodo que obtiene todos los reportes que han sido generados
        /// </summary>
        /// <param name="Conexion">Cadena de conecxion con la base de datos</param>
        /// <returns></returns>
        public List<ReporteConsumoMaterial> ObtenerReportesConsumoMaterial(string Conexion)
        {
            try
            {
                List<ReporteConsumoMaterial> Lista = new List<ReporteConsumoMaterial>();
                ReporteConsumoMaterial Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Reportes.spCSLDB_get_ReporteConsumoMaterial");
                while (Dr.Read())
                {
                    Item = new ReporteConsumoMaterial();
                    Item.IDReporte = !Dr.IsDBNull(Dr.GetOrdinal("Id_reporte")) ? Dr.GetInt32(Dr.GetOrdinal("Id_reporte")) : 0;
                    Item.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("FechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaInicio")) : DateTime.MinValue;
                    Item.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("FechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaFin")) : DateTime.MinValue;
                    Item.Sucursal = !Dr.IsDBNull(Dr.GetOrdinal("Sucursal")) ? Dr.GetString(Dr.GetOrdinal("Sucursal")) : String.Empty;
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
        /// Metodo que efectua la busqueda del reporte especidficado
        /// </summary>
        /// <param name="Conexion">Coexion con la BD</param>
        /// <param name="Busqueda">Fecha de busqueda del reporte generado</param>
        /// <returns></returns>
        public List<ReporteConsumoMaterial> BuscarReportesConsumoMaterial(string Conexion,DateTime busqueda)
        {
            try
            {
                List<ReporteConsumoMaterial> Lista = new List<ReporteConsumoMaterial>();
                ReporteConsumoMaterial Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Reportes.spCSLDB_get_ReporteConsumoMaterialSearchGrid", busqueda);
                while (Dr.Read())
                {
                    Item = new ReporteConsumoMaterial();
                    Item.IDReporte = !Dr.IsDBNull(Dr.GetOrdinal("IDReporte")) ? Dr.GetInt32(Dr.GetOrdinal("IDReporte")) : 0;
                    Item.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("FechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaInicio")) : DateTime.MinValue;
                    Item.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("FechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaFin")) : DateTime.MinValue;
                    Item.Sucursal= !Dr.IsDBNull(Dr.GetOrdinal("Sucursal")) ? Dr.GetString(Dr.GetOrdinal("Sucursal")) : String.Empty;
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
        /// Metodo que obtiene la sucursles
        /// </summary>
        /// <param name="Conexion">Conexio con la BD</param>
        /// <returns></returns>
        public List<ReporteConsumoMaterial> LlenarComboSucursales(string Conexion)
        {
            try
            {
                List<ReporteConsumoMaterial> Lista = new List<ReporteConsumoMaterial>();
                ReporteConsumoMaterial Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "[spCSLDB_get_ComboCatSucursales]", 1);
                while (Dr.Read())
                {
                    Item = new ReporteConsumoMaterial();
                    Item.id_sucursal = !Dr.IsDBNull(Dr.GetOrdinal("IDSucursal")) ? Dr.GetString(Dr.GetOrdinal("IDSucursal")) : string.Empty;
                    Item.Sucursal = !Dr.IsDBNull(Dr.GetOrdinal("NombreSucursal")) ? Dr.GetString(Dr.GetOrdinal("NombreSucursal")) : string.Empty;
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
