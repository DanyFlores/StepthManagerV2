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
    public class Pedido_Datos
    {
        public List<PedidoDetalle> ObtenerComboClavesProduccion(PedidoDetalle Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDSucursal, Datos.IDEmpleado, Datos.IDProducto };
                List<PedidoDetalle> Lista = new List<PedidoDetalle>();
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboProductosProduccion", Parametros);
                PedidoDetalle Item;
                while (Dr.Read())
                {
                    Item = new PedidoDetalle();
                    Item.IDAsignacion = Dr.GetString(Dr.GetOrdinal("IDAsignacion"));
                    Item.ClaveProduccion = Dr.GetString(Dr.GetOrdinal("Clave"));
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

        public void ACPedidos(Pedido Datos)
        {
            try
            {
                int Resultado = 0;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_ac_Pedidos",
                     new SqlParameter("@NuevoRegistro", Datos.NuevoRegistro),
                     new SqlParameter("@IDPedido", Datos.IDPedido),
                     new SqlParameter("@IDSucursal", Datos.IDSucursal),
                     new SqlParameter("@TablaPedidoDetalle", Datos.TablaDatos),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                while (Dr.Read())
                {
                    Resultado = !Dr.IsDBNull(Dr.GetOrdinal("Resultado")) ? Dr.GetInt32(Dr.GetOrdinal("Resultado")) : 0;
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.IDPedido = Dr.GetString(Dr.GetOrdinal("IDPedido"));
                    }
                    else
                    {
                        Datos.Completado = false;
                        Datos.Resultado = Resultado;
                        Datos.MensajeError = Dr.GetString(Dr.GetOrdinal("Mensaje"));
                    }
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerPedidos(Pedido Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDEstatus, Datos.Completo, Datos.BuscarTodos };
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_PedidosPendientes", Parametros);
                Datos.TablaDatos = new DataTable();
                if (ds != null)
                    if (ds.Tables.Count == 1)
                        Datos.TablaDatos = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerPedidosTab(Pedido Datos)
        {
            try
            {
                object[] Parametros = { Datos.Opcion, Datos.BuscarTodos };
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Produccion.spCSLDB_get_PedidosTab", Parametros);
                Datos.TablaDatos = new DataTable();
                if (ds != null)
                    if (ds.Tables.Count == 1)
                        Datos.TablaDatos = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerPedidosTabBusq(Pedido Datos)
        {
            try
            {
                object[] Parametros = { Datos.Opcion, Datos.BuscarTodos, Datos.FolioPedido };
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Produccion.spCSLDB_get_PedidosTabBusq", Parametros);
                Datos.TablaDatos = new DataTable();
                if (ds != null)
                    if (ds.Tables.Count == 1)
                        Datos.TablaDatos = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PedidoDetalle> ObtenerDetallePedidoClaves(Pedido Datos)
        {
            try
            {
                List<PedidoDetalle> Lista = new List<PedidoDetalle>();
                PedidoDetalle Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_PedidoDetalleXID", Datos.IDPedido);
                while (Dr.Read())
                {
                    Item = new PedidoDetalle();
                    Item.IDPedidoDetalle = Dr.GetString(Dr.GetOrdinal("IDPedidoDetalle"));
                    Item.IDProducto = Dr.GetString(Dr.GetOrdinal("IDProducto"));
                    Item.ClaveProducto = Dr.GetString(Dr.GetOrdinal("Clave"));
                    Item.NombreProducto = Dr.GetString(Dr.GetOrdinal("NombreProducto"));
                    Item.Cantidad = Dr.GetDecimal(Dr.GetOrdinal("Cantidad"));
                    Item.IDEmpleado = Dr.GetString(Dr.GetOrdinal("IDEmpleado"));
                    Item.NombreEmpleado = Dr.GetString(Dr.GetOrdinal("NombreEmpleado"));
                    Item.IDAsignacion = Dr.GetString(Dr.GetOrdinal("IDAsignacion"));
                    Item.ClaveProduccion = Dr.GetString(Dr.GetOrdinal("ClaveProduccion"));
                    Item.Completo = Dr.GetBoolean(Dr.GetOrdinal("Completo"));
                    Item.CantidadSurtida = Dr.GetDecimal(Dr.GetOrdinal("CantidadSurtida"));
                    Item.CantidadPendiente = Item.Cantidad - Item.CantidadSurtida;
                    Item.CantidadASurtir = Item.CantidadPendiente;
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

        public List<PedidoDetalle> ObtenerDetallePedido(Pedido Datos)
        {
            try
            {
                List<PedidoDetalle> Lista = new List<PedidoDetalle>();
                PedidoDetalle Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "Produccion.spCSLDB_get_PedidoDetalleXID", Datos.IDPedido);
                while (Dr.Read())
                {
                    Item = new PedidoDetalle();
                    Item.IDPedidoDetalle = Dr.GetString(Dr.GetOrdinal("IDPedidoDetalle"));
                    Item.IDProducto = Dr.GetString(Dr.GetOrdinal("IDProducto"));
                    Item.ClaveProducto = Dr.GetString(Dr.GetOrdinal("Clave"));
                    Item.NombreProducto = Dr.GetString(Dr.GetOrdinal("NombreProducto"));
                    Item.Cantidad = Dr.GetDecimal(Dr.GetOrdinal("Cantidad"));
                    Item.Completo = Dr.GetBoolean(Dr.GetOrdinal("Completo"));
                    Item.CantidadSurtida = Dr.GetDecimal(Dr.GetOrdinal("CantidadSurtida"));
                    Item.CantidadPendiente = (Item.Cantidad > Item.CantidadSurtida) ? Item.Cantidad - Item.CantidadSurtida : 0;
                    Item.CantidadASurtir = Item.CantidadPendiente;
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

        public PedidoDetalle ObtenerPedidoDetalleComparativo(string IDPedido, string IDProducto, string Conexion)
        {
            try
            {
                PedidoDetalle Datos = new PedidoDetalle();
                Datos.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Conexion, "Produccion.spCSLDB_get_PedidoDetalleComparativo", IDPedido, IDProducto);
                if(Ds != null)
                {
                    if(Ds.Tables.Count == 1)
                    {
                        Datos.Completado = true;
                        Datos.TablaDatos = Ds.Tables[0];
                    }
                }
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SurtirPedido(Pedido Datos)
        {
            try
            {
                int Resultado = 0;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, CommandType.StoredProcedure, "Produccion.spCSLDB_set_SurtirPedido",
                     new SqlParameter("@IDPedido", Datos.IDPedido),
                     new SqlParameter("@IDSucursalMatriz", Datos.IDSucursal),
                     new SqlParameter("@TablaCant", Datos.TablaDatos),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                if (Ds != null)
                {
                    if (Ds.Tables.Count > 0)
                    {
                        int.TryParse(Ds.Tables[0].Rows[0][0].ToString(), out Resultado);
                        if (Resultado == 1)
                            Datos.Completado = true;
                        else
                        {
                            if (Resultado == -1)
                            {
                                if (Ds.Tables.Count == 2)
                                {
                                    Datos.TablaDatos = Ds.Tables[1];
                                }
                            }
                            Datos.Resultado = Resultado;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public void ObtenerMaterialesCapacitacion(Pedido Datos)
        {
            try
            {
                Datos.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_MaterialesCapacitacion", Datos.BuscarTodos, Datos.IDSucursal);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        Datos.Completado = true;
                        Datos.TablaDatos = Ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerMaterialesCapacitacionBusq(Pedido Datos)
        {
            try
            {
                Datos.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_MaterialesCapacitacionBusq", Datos.BuscarTodos, Datos.IDSucursal, Datos.TextoBusqueda);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        Datos.Completado = true;
                        Datos.TablaDatos = Ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarMaterialCapacitacion(PedidoDetalle Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDSucursal, Datos.IDProducto, Datos.Cantidad, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_NuevoProductoCapacitacion", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                    Datos.Resultado = Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReemplazoClaveProductoSuc(PedidoDetalle Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDSucursal, Datos.IDAsignacion, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_ReemplazarClaveProduccionSuc", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                    Datos.Resultado = Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void FinalizarPedido(Pedido Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "Produccion.spCSLDB_set_FinalizarPedido", Datos.IDPedido, Datos.IDUsuario);
                if(Result != null)
                {
                    int Resultado = 0;
                    if(int.TryParse(Result.ToString(), out Resultado))
                    {
                        Datos.Completado = (Resultado == 1);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarProducto(PedidoDetalle Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDPedido, Datos.IDProducto, Datos.IDUsuario };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "Produccion.spCSLDB_set_AgregarProductoPedidoAdmin", Parametros);
                //object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "Produccion.spCSLDB_set_AgregarProductoPedidoAdmin", Parametros);
                //if(Result!= null)
                //{
                //    int Resultado = 0;
                //    if(int.TryParse(Result.ToString(), out Resultado))
                //    {
                //        Datos.Completado = (Resultado == 1);
                //        Datos.Resultado = Resultado;
                //    }
                //}
                while (Dr.Read())
                {
                    int Resultado = !Dr.IsDBNull(Dr.GetOrdinal("Resultado")) ? Dr.GetInt32(Dr.GetOrdinal("Resultado")) : 0;
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.Resultado = Resultado;
                        Datos.IDPedidoDetalle = !Dr.IsDBNull(Dr.GetOrdinal("IDPedidoDetalle")) ? Dr.GetString(Dr.GetOrdinal("IDPedidoDetalle")) : string.Empty;
                    }
                }
                Dr.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
