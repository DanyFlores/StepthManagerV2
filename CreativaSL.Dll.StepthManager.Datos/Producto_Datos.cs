using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;

namespace CreativaSL.Dll.StephManager.Datos
{
    public class Producto_Datos
    {

        public void ABCCatProductos(Producto Datos)
        {
            try
            {
                Datos.Completado = false;
                int Resultado = 0;
                SqlDataReader dr = SqlHelper.ExecuteReader(Datos.Conexion, CommandType.StoredProcedure, "Produccion.spCSLDB_abc_CatProductos",
                     new SqlParameter("@Opcion", Datos.Opcion),
                     new SqlParameter("@IDProducto", Datos.IDProducto),
                     new SqlParameter("@IDTipoProducto", Datos.IDTipoProducto),
                     new SqlParameter("@IDFamilia", Datos.IDFamilia),
                     new SqlParameter("@IDUnidadMedida", Datos.IDUnidadMedida),
                     new SqlParameter("@Clave", Datos.Clave),
                     new SqlParameter("@NumInventario", Datos.NumInventario),
                     new SqlParameter("@Nombre", Datos.NombreProducto),
                     new SqlParameter("@IDTipoUso", Datos.IDTipoUso),
                     new SqlParameter("@IDMetrica", Datos.IDMetrica),
                     new SqlParameter("@CantidadMetrica", Datos.CantidadMetrica),
                     new SqlParameter("@MargenError", Datos.MargenError),
                     new SqlParameter("@PrecioNormal", Datos.PrecioNormal),
                     new SqlParameter("@Descripcion", Datos.Descripcion),
                     new SqlParameter("@AplicaIVA", Datos.AplicaIVA),
                     new SqlParameter("@AplicaPrecioMay", Datos.AplicaPrecioMayoreo),
                     new SqlParameter("@PrecioMayoreo", Datos.PrecioMayoreo),
                     new SqlParameter("@CantidadMayoreo", Datos.CantidadMayoreo),
                     new SqlParameter("@AplicaPrecioTemp", Datos.AplicaPrecioTemporada),
                     new SqlParameter("@PrecioTemp", Datos.PrecioTemporada),
                     new SqlParameter("@FechaInicioTemp", Datos.FechaInicioTemp),
                     new SqlParameter("@FechaFinTemp", Datos.FechaFinTemp),
                     new SqlParameter("@AplicaPrecioEsp", Datos.AplicaPrecioEspecial),
                     new SqlParameter("@PrecioEspecial", Datos.PrecioEspecial),
                     new SqlParameter("@LunesPrecioEsp", Datos.PrecioEspecialLunes),
                     new SqlParameter("@MartesPrecioEsp", Datos.PrecioEspecialMartes),
                     new SqlParameter("@MiercolesPrecioEsp", Datos.PrecioEspecialMiercoles),
                     new SqlParameter("@JuevesPrecioEsp", Datos.PrecioEspecialJueves),
                     new SqlParameter("@ViernesPrecioEsp", Datos.PrecioEspecialViernes),
                     new SqlParameter("@SabadoPrecioEsp", Datos.PrecioEspecialSabado),
                     new SqlParameter("@DomingoPrecioEsp", Datos.PrecioEspecialDomingo),

                     new SqlParameter("@RequiereStock", Datos.RequiereStock),
                     new SqlParameter("@StockMaximo", Datos.StockMaximo),
                     new SqlParameter("@StockMinimo", Datos.StockMinimo),

                     new SqlParameter("@UrlImagen", Datos.UrlImagen),
                     new SqlParameter("@Imagen", Datos.Imagen),
                     new SqlParameter("@TablaProveedor", Datos.TablaProveedores),
                     new SqlParameter("@TablaMonedero", Datos.TablaMonederos),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                while (dr.Read())
                {
                    Resultado = !dr.IsDBNull(dr.GetOrdinal("Resultado")) ? dr.GetInt32(dr.GetOrdinal("Resultado")) : 0;
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.IDProducto = dr.GetString(dr.GetOrdinal("IDProducto"));
                        Datos.UrlImagen = Datos.IDProducto + ".JPG";
                    }
                    else
                    {
                        Datos.Completado = false;
                        Datos.Resultado = Resultado;
                        Datos.MensajeError = dr.GetString(dr.GetOrdinal("Mensaje"));
                    }
                    break;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatProductos(Producto Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatProductos", Datos.BuscarTodos);
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
        
        public void ObtenerCatProductosBusqueda(Producto Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatProductosBusqueda", Datos.BuscarTodos, Datos.NombreProducto);
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

        public void ObtenerCatTipoMonederoXIDProducto(TipoMonedero Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_MonederoXProducto", Datos.IDProducto);
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

        public Producto ObtenerDatosProductoXID(Producto Datos)
        {
            try
            {
                Producto DatosResultado = new Producto();
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "Produccion.spCSLDB_get_ProductoDetalleXID", Datos.IDProducto);
                while (Dr.Read())
                {
                    DatosResultado.IDProducto = Datos.IDProducto;
                    DatosResultado.IDTipoProducto = Dr.IsDBNull(Dr.GetOrdinal("IDTipoProducto")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDTipoProducto"));
                    DatosResultado.IDFamilia = Dr.IsDBNull(Dr.GetOrdinal("IDFamilia")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDFamilia"));
                    DatosResultado.IDUnidadMedida = Dr.IsDBNull(Dr.GetOrdinal("IDUnidadMedida")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDUnidadMedida"));
                    DatosResultado.Clave = Dr.IsDBNull(Dr.GetOrdinal("Clave")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Clave"));
                    DatosResultado.NumInventario = Dr.IsDBNull(Dr.GetOrdinal("NumInventario")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("NumInventario"));
                    DatosResultado.NombreProducto = Dr.IsDBNull(Dr.GetOrdinal("Nombre")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Nombre"));
                    DatosResultado.IDTipoUso = Dr.IsDBNull(Dr.GetOrdinal("IDTipoUso")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDTipoUso"));
                    DatosResultado.IDMetrica = Dr.IsDBNull(Dr.GetOrdinal("IDMetrica")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDMetrica"));
                    DatosResultado.CantidadMetrica = Dr.IsDBNull(Dr.GetOrdinal("CantidadMetrica")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("CantidadMetrica"));
                    DatosResultado.MargenError = Dr.IsDBNull(Dr.GetOrdinal("MargenError")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("MargenError"));
                    DatosResultado.PrecioNormal = Dr.IsDBNull(Dr.GetOrdinal("PrecioNormal")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("PrecioNormal"));
                    DatosResultado.Descripcion = Dr.IsDBNull(Dr.GetOrdinal("Descripcion")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    DatosResultado.AplicaIVA = Dr.IsDBNull(Dr.GetOrdinal("AplicaIVA")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaIVA"));
                    DatosResultado.AplicaPrecioMayoreo = Dr.IsDBNull(Dr.GetOrdinal("AplicaPrecioMayoreo")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaPrecioMayoreo"));
                    DatosResultado.PrecioMayoreo = Dr.IsDBNull(Dr.GetOrdinal("PrecioMayoreo")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("PrecioMayoreo"));
                    DatosResultado.CantidadMayoreo = Dr.IsDBNull(Dr.GetOrdinal("CantidadMayoreo")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("CantidadMayoreo"));
                    DatosResultado.AplicaPrecioTemporada = Dr.IsDBNull(Dr.GetOrdinal("AplicaPrecioTemporada")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaPrecioTemporada"));
                    DatosResultado.PrecioTemporada = Dr.IsDBNull(Dr.GetOrdinal("PrecioTemporada")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("PrecioTemporada"));
                    DatosResultado.FechaInicioTemp = Dr.IsDBNull(Dr.GetOrdinal("FechaInicioTemporada")) ? DateTime.Today : Dr.GetDateTime(Dr.GetOrdinal("FechaInicioTemporada"));
                    DatosResultado.FechaFinTemp = Dr.IsDBNull(Dr.GetOrdinal("FechaFinTemporada")) ? DateTime.Today : Dr.GetDateTime(Dr.GetOrdinal("FechaFinTemporada"));
                    DatosResultado.AplicaPrecioEspecial = Dr.IsDBNull(Dr.GetOrdinal("AplicaPrecioEspecial")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaPrecioEspecial"));
                    DatosResultado.PrecioEspecial = Dr.IsDBNull(Dr.GetOrdinal("PrecioEspecial")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("PrecioEspecial"));
                    DatosResultado.PrecioEspecialLunes = Dr.IsDBNull(Dr.GetOrdinal("AplicaLunes")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaLunes"));
                    DatosResultado.PrecioEspecialMartes = Dr.IsDBNull(Dr.GetOrdinal("AplicaMartes")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaMartes"));
                    DatosResultado.PrecioEspecialMiercoles = Dr.IsDBNull(Dr.GetOrdinal("AplicaMiercoles")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaMiercoles"));
                    DatosResultado.PrecioEspecialJueves = Dr.IsDBNull(Dr.GetOrdinal("AplicaJueves")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaJueves"));
                    DatosResultado.PrecioEspecialViernes = Dr.IsDBNull(Dr.GetOrdinal("AplicaViernes")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaViernes"));
                    DatosResultado.PrecioEspecialSabado = Dr.IsDBNull(Dr.GetOrdinal("AplicaSabado")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaSabado"));
                    DatosResultado.PrecioEspecialDomingo = Dr.IsDBNull(Dr.GetOrdinal("AplicaDomingo")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaDomingo"));
                    DatosResultado.UrlImagen = Dr.IsDBNull(Dr.GetOrdinal("UrlImagen")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("UrlImagen"));

                    DatosResultado.RequiereStock = !Dr.IsDBNull(Dr.GetOrdinal("RequiereStock")) ? Dr.GetBoolean(Dr.GetOrdinal("RequiereStock")) : false;
                    DatosResultado.StockMaximo = !Dr.IsDBNull(Dr.GetOrdinal("StockMaximo")) ? Dr.GetDecimal(Dr.GetOrdinal("StockMaximo")) : 0;
                    DatosResultado.StockMaximo = !Dr.IsDBNull(Dr.GetOrdinal("StockMinimo")) ? Dr.GetDecimal(Dr.GetOrdinal("StockMinimo")) : 0;
                    break;
                }
                Dr.Close();
                return DatosResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Proveedor> ObtenerProveedoresDisponiblesXIDProducto(Producto Datos)
        {
            try
            {
                List<Proveedor> Lista = new List<Proveedor>();
                Proveedor Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_CatProveedoresDispXIDProducto", Datos.IDProducto);
                while (Dr.Read())
                {
                    Item = new Proveedor();
                    Item.IDProveedor = Dr.IsDBNull(Dr.GetOrdinal("IDProveedor")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDProveedor"));
                    Item.RazonSocial = Dr.IsDBNull(Dr.GetOrdinal("RazonSocial")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("RazonSocial"));
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

        public List<Proveedor> ObtenerProveedorXIDProducto(Producto Datos)
        {
            try
            {
                List<Proveedor> Lista = new List<Proveedor>();
                Proveedor Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ProveedorXProducto", Datos.IDProducto);
                while (Dr.Read())
                {
                    Item = new Proveedor();
                    Item.IDProductoXProveedor = Dr.IsDBNull(Dr.GetOrdinal("IDProductoXProveedor")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDProductoXProveedor"));
                    Item.IDProveedor = Dr.IsDBNull(Dr.GetOrdinal("IDProveedor")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDProveedor"));
                    Item.RazonSocial = Dr.IsDBNull(Dr.GetOrdinal("RazonSocial")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("RazonSocial"));
                    Item.CostoUltimo = Dr.IsDBNull(Dr.GetOrdinal("UltimoCosto")) ? 0: Dr.GetDecimal(Dr.GetOrdinal("UltimoCosto"));
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

        public void ObtenerBusquedaProductosServicios(Producto Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_BusquedaProductosServicios", Datos.Opcion, Datos.NombreProducto, Datos.IDProveedor, Datos.IDSucursal);
                Datos.TablaDatos = new DataTable();
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                        Datos.TablaDatos = Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDatosProductoCompraXID(Producto Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDProducto, Datos.IDProveedor };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_DatosProductoCompraXID", Parametros);
                while (Dr.Read())
                {
                    Datos.IDUnidadMedida = Dr.IsDBNull(Dr.GetOrdinal("IDUnidadMedida")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDUnidadMedida"));
                    Datos.UnidadMedidaDesc = Dr.IsDBNull(Dr.GetOrdinal("UnidadMedida")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("UnidadMedida"));
                    Datos.UltimoCosto = Dr.IsDBNull(Dr.GetOrdinal("UltimoCosto")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("UltimoCosto"));
                }
                Dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerProductosInventario(Producto Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Produccion.spCSLDB_get_InventarioProductosXSuc", Datos.IDSucursal, Datos.NombreProducto);
                Datos.TablaDatos = new DataTable();
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                        Datos.TablaDatos = Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerProductosInventarioMatriz(Producto Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Produccion.spCSLDB_get_InventarioProductosMatriz", Datos.IDSucursal);
                Datos.TablaDatos = new DataTable();
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                        Datos.TablaDatos = Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AInventarioEXCEL(Producto Datos)
        {
            try
            {
                int Resultado = 0;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, CommandType.StoredProcedure, "Produccion.spCSLDB_a_InventarioExcel",
                     new SqlParameter("@IDSucursal", Datos.IDSucursal),
                     new SqlParameter("@ImportarExcel", Datos.ImportarExcel),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                while (Dr.Read())
                {
                    Resultado = !Dr.IsDBNull(Dr.GetOrdinal("Resultado")) ? Dr.GetInt32(Dr.GetOrdinal("Resultado")) : 0;
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                    else
                    {
                        Datos.Completado = false;
                        Datos.Resultado = Resultado;
                    }
                    break;
                }
                Dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        //** Tarjetas de regalo **//

        public void ACTarjetasRegalo(Producto Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDProducto, Datos.Clave, Datos.NombreProducto, Datos.PrecioNormal, Datos.Imagen, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "Produccion.spCSLDB_get_ACTarjetasRegalo", Parametros);
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

        public void ObtenerCatTarjetasRegalo(Producto Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatTarjetasRegalo", Datos.BuscarTodos);
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

        public void ObtenerCatTarjetasRegaloBusqueda(Producto Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatTarjetasRegaloBusq", Datos.BuscarTodos, Datos.Clave);
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

        public void EliminarTarjetasRegalo(Producto Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDProducto, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_del_EliminarTarjetaRegalo", Parametros);
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


        public void EnviarTarjetasRegalo(Producto Datos, string IDSucursalMatriz)
        {
            try
            {
                object[] Parametros = { Datos.IDProducto, Datos.IDSucursal, IDSucursalMatriz, Datos.Cantidad, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "Produccion.spCSLDB_set_EnviarTarjetasRegalo", Parametros);
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
        public void ObtenerCatProductosStockMinimo(Producto Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatProductosStockMinimo", Datos.IDSucursal, Datos.BuscarTodos);
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

        public void ObtenerCatProductosStockMaximo(Producto Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatProductosStockMaximo", Datos.IDSucursal, Datos.BuscarTodos);
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


        public Producto ObtenerPreciosXIDSucursal(Producto Datos)
        {
            try
            {
                Producto Resultado = new Producto();
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "Produccion.spCSLDB_get_PreciosXIDSucXIDProd", Datos.IDProducto, Datos.IDSucursal);
                while(Dr.Read())
                {
                    Resultado.IDProducto = !Dr.IsDBNull(Dr.GetOrdinal("IDProducto")) ? Dr.GetString(Dr.GetOrdinal("IDProducto")) : string.Empty;
                    Resultado.PrecioNormal = Dr.IsDBNull(Dr.GetOrdinal("PrecioNormal")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("PrecioNormal"));
                    Resultado.AplicaPrecioMayoreo = Dr.IsDBNull(Dr.GetOrdinal("AplicaPrecioMayoreo")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaPrecioMayoreo"));
                    Resultado.PrecioMayoreo = Dr.IsDBNull(Dr.GetOrdinal("PrecioMayoreo")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("PrecioMayoreo"));
                    Resultado.CantidadMayoreo = Dr.IsDBNull(Dr.GetOrdinal("CantidadMayoreo")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("CantidadMayoreo"));
                    Resultado.AplicaPrecioTemporada = Dr.IsDBNull(Dr.GetOrdinal("AplicaPrecioTemporada")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaPrecioTemporada"));
                    Resultado.PrecioTemporada = Dr.IsDBNull(Dr.GetOrdinal("PrecioTemporada")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("PrecioTemporada"));
                    Resultado.FechaInicioTemp = Dr.IsDBNull(Dr.GetOrdinal("FechaInicioTemporada")) ? DateTime.Today : Dr.GetDateTime(Dr.GetOrdinal("FechaInicioTemporada"));
                    Resultado.FechaFinTemp = Dr.IsDBNull(Dr.GetOrdinal("FechaFinTemporada")) ? DateTime.Today : Dr.GetDateTime(Dr.GetOrdinal("FechaFinTemporada"));
                    Resultado.AplicaPrecioEspecial = Dr.IsDBNull(Dr.GetOrdinal("AplicaPrecioEspecial")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaPrecioEspecial"));
                    Resultado.PrecioEspecial = Dr.IsDBNull(Dr.GetOrdinal("PrecioEspecial")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("PrecioEspecial"));
                    Resultado.PrecioEspecialLunes = Dr.IsDBNull(Dr.GetOrdinal("AplicaLunes")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaLunes"));
                    Resultado.PrecioEspecialMartes = Dr.IsDBNull(Dr.GetOrdinal("AplicaMartes")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaMartes"));
                    Resultado.PrecioEspecialMiercoles = Dr.IsDBNull(Dr.GetOrdinal("AplicaMiercoles")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaMiercoles"));
                    Resultado.PrecioEspecialJueves = Dr.IsDBNull(Dr.GetOrdinal("AplicaJueves")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaJueves"));
                    Resultado.PrecioEspecialViernes = Dr.IsDBNull(Dr.GetOrdinal("AplicaViernes")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaViernes"));
                    Resultado.PrecioEspecialSabado = Dr.IsDBNull(Dr.GetOrdinal("AplicaSabado")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaSabado"));
                    Resultado.PrecioEspecialDomingo = Dr.IsDBNull(Dr.GetOrdinal("AplicaDomingo")) ? false : Dr.GetBoolean(Dr.GetOrdinal("AplicaDomingo"));
                    break;
                }
                Dr.Close();
                return Resultado;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool GuardarPrecioXIDSucursal(Producto Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDProducto, Datos.IDSucursal, Datos.PrecioNormal,
                                        Datos.AplicaPrecioMayoreo, Datos.PrecioMayoreo, Datos.CantidadMayoreo,
                                        Datos.AplicaPrecioTemporada, Datos.PrecioTemporada, Datos.FechaInicioTemp,
                                        Datos.FechaFinTemp, Datos.AplicaPrecioEspecial, Datos.PrecioEspecial,
                                        Datos.PrecioEspecialLunes, Datos.PrecioEspecialMartes, Datos.PrecioEspecialMiercoles,
                                        Datos.PrecioEspecialJueves, Datos.PrecioEspecialViernes, Datos.PrecioEspecialSabado,
                                        Datos.PrecioEspecialDomingo, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "Produccion.spCSLDB_set_PreciosXSucursal", Parametros);
                if(Result!= null)
                {
                    int Resultado = 0;
                    if(int.TryParse(Result.ToString(), out Resultado))
                    {
                        return Resultado == 1;
                    }
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
