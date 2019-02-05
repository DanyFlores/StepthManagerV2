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
    public class TransferenciaMateriales_Datos
    {


        public List<TransferenciaMateriales> LlenarComboEmpleado(TransferenciaMateriales Datos)
        {
            try
            {
                List<TransferenciaMateriales> Lista = new List<TransferenciaMateriales>();
                TransferenciaMateriales Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboEmpleados", Datos.Opcion);
                while (Dr.Read())
                {
                    Item = new TransferenciaMateriales();
                    Item.IDEmpleado = Dr.IsDBNull(Dr.GetOrdinal("IDEmpleado")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDEmpleado"));
                    Item.Empleado = Dr.IsDBNull(Dr.GetOrdinal("NombreEmpleado")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("NombreEmpleado"));
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

        public int GenerarTransferencia(string Conexion, string empleadoOrigen, string empleadoDestino, string observaciones, string IDUsuario)
        {
            try
            {
                int IDReporte = -1;
                object[] Parametros = { empleadoOrigen, empleadoDestino, observaciones, IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Conexion, "Produccion.spCSLDB_set_TransferenciaMaterialesZM", Parametros);
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

        public List<TransferenciaMateriales> ObtenerTransferenciaMateriales(string Conexion)
        {
            try
            {
                List<TransferenciaMateriales> Lista = new List<TransferenciaMateriales>();
                TransferenciaMateriales Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Produccion.spCSLDB_get_TransferenciaMaterialesGrid");
                while (Dr.Read())
                {
                    Item = new TransferenciaMateriales();
                    Item.IDTransferencia = !Dr.IsDBNull(Dr.GetOrdinal("IDTransferencia")) ? Dr.GetInt32(Dr.GetOrdinal("IDTransferencia")) : 0;
                    Item.Empleado = !Dr.IsDBNull(Dr.GetOrdinal("NombreOrigen")) ? Dr.GetString(Dr.GetOrdinal("NombreOrigen")) : string.Empty;
                    Item.EmpleadoDestino = !Dr.IsDBNull(Dr.GetOrdinal("NombreDestino")) ? Dr.GetString(Dr.GetOrdinal("NombreDestino")) : string.Empty;
                    Item.Fecha = !Dr.IsDBNull(Dr.GetOrdinal("Fecha")) ? Dr.GetDateTime(Dr.GetOrdinal("Fecha")) : DateTime.MinValue;
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

        public TransferenciaMaterialesGeneral ObtenerDetalleReporteTransferenciaMateriales(string Conexion, int IDReporte)
        {
            try
            {
                TransferenciaMaterialesGeneral Resultado = new TransferenciaMaterialesGeneral();
                DataSet Ds = SqlHelper.ExecuteDataset(Conexion, "Produccion.spCSLDB_get_TransferenciaMaterialesXID", IDReporte);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        
                        List<TransferenciaMaterialesDetalle> Lista = new List<TransferenciaMaterialesDetalle>();
                        TransferenciaMaterialesDetalle Item;
                        DataTableReader Dr2 = Ds.Tables[0].CreateDataReader();
                        while (Dr2.Read())
                        {

                            Item = new TransferenciaMaterialesDetalle();
                            Item.FechaInicio = !Dr2.IsDBNull(Dr2.GetOrdinal("FechaInicio")) ? Dr2.GetDateTime(Dr2.GetOrdinal("FechaInicio")) : DateTime.MinValue;
                            Item.Producto = !Dr2.IsDBNull(Dr2.GetOrdinal("Producto")) ? Dr2.GetString(Dr2.GetOrdinal("Producto")) : string.Empty;
                            Item.Clave = !Dr2.IsDBNull(Dr2.GetOrdinal("Clave")) ? Dr2.GetString(Dr2.GetOrdinal("Clave")) : string.Empty;
                            Item.CantidadMetrica = !Dr2.IsDBNull(Dr2.GetOrdinal("CantidadMetrica")) ? Dr2.GetInt32(Dr2.GetOrdinal("CantidadMetrica")) : 0;
                            Item.TipoMetrica = !Dr2.IsDBNull(Dr2.GetOrdinal("TipoMetrica")) ? Dr2.GetString(Dr2.GetOrdinal("TipoMetrica")) : string.Empty;
                            Item.CantidadUsos = !Dr2.IsDBNull(Dr2.GetOrdinal("CantidadUsos")) ? Dr2.GetInt32(Dr2.GetOrdinal("CantidadUsos")) : 0;
                            Item.Consumo = !Dr2.IsDBNull(Dr2.GetOrdinal("Consumo")) ? Dr2.GetInt32(Dr2.GetOrdinal("Consumo")) : 0;
                            Item.DiasTranscurridos = !Dr2.IsDBNull(Dr2.GetOrdinal("DiasTranscurridos")) ? Dr2.GetInt32(Dr2.GetOrdinal("DiasTranscurridos")) : 0;

                            Lista.Add(Item);
                        }
                        Dr2.Close();
                        Resultado.Detalle = Lista;
                    }
                   
                }
                
                TransferenciaMaterialesGeneral var = ObtenerTransferenciaMaterialesGeneral(Conexion, IDReporte);
                Resultado.EmpleadoO = var.EmpleadoO;
                Resultado.EmpleadoD = var.EmpleadoD;
                return Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TransferenciaMaterialesGeneral ObtenerTransferenciaMaterialesGeneral(string Conexion,int IDReporte)
        {
            try
            {

                TransferenciaMaterialesGeneral Resultado = new TransferenciaMaterialesGeneral();
                DataSet Ds = SqlHelper.ExecuteDataset(Conexion, "Produccion.spCSLDB_get_TransferenciaMaterialesGeneralXID", IDReporte);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {

                            Resultado.EmpleadoO = !Dr.IsDBNull(Dr.GetOrdinal("NombreOrigen")) ? Dr.GetString(Dr.GetOrdinal("NombreOrigen")) : string.Empty;
                            Resultado.EmpleadoD = !Dr.IsDBNull(Dr.GetOrdinal("NombreDestino")) ? Dr.GetString(Dr.GetOrdinal("NombreDestino")) : string.Empty;

                        }
                        Dr.Close();

                    }
                }
                return Resultado;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<TransferenciaMateriales> ObtenerTransferenciaMaterialesBusqueda(string Conexion, DateTime Fecha)
        {
            try
            {
                //
                DateTime fechalimite = DateTime.MinValue;
                fechalimite = fechalimite.AddDays((double)Fecha.Day);
                fechalimite = fechalimite.AddMonths(Fecha.Month - 1);
                fechalimite = fechalimite.AddYears(Fecha.Year - 1);

                List<TransferenciaMateriales> Lista = new List<TransferenciaMateriales>();
                TransferenciaMateriales Item;
                object[] Parametros = { Fecha, fechalimite  };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Produccion.spCSLDB_get_TransferenciaMaterialesGridSearch", Parametros);
                while (Dr.Read())
                {
                    Item = new TransferenciaMateriales();
                    Item.IDTransferencia = !Dr.IsDBNull(Dr.GetOrdinal("IDTransferencia")) ? Dr.GetInt32(Dr.GetOrdinal("IDTransferencia")) : 0;
                    Item.Empleado = !Dr.IsDBNull(Dr.GetOrdinal("NombreOrigen")) ? Dr.GetString(Dr.GetOrdinal("NombreOrigen")) : string.Empty;
                    Item.EmpleadoDestino = !Dr.IsDBNull(Dr.GetOrdinal("NombreDestino")) ? Dr.GetString(Dr.GetOrdinal("NombreDestino")) : string.Empty;
                    Item.Fecha = !Dr.IsDBNull(Dr.GetOrdinal("Fecha")) ? Dr.GetDateTime(Dr.GetOrdinal("Fecha")) : DateTime.MinValue;
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
