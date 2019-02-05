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
    public class Compra_Datos
    {
        
        public void ACCompras(Compra Datos)
        {
            try
            {
                Datos.Completado = false;
                int Resultado = 0;
                SqlDataReader dr = SqlHelper.ExecuteReader(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_ac_Compras",
                     new SqlParameter("@NuevoRegistro", Datos.NuevoRegistro),
                     new SqlParameter("@IDCompra", Datos.IDCompra),
                     new SqlParameter("@IDProveedor", Datos.IDProveedor),
                     new SqlParameter("@IDSucursal", Datos.IDSucursal),
                     new SqlParameter("@RazonSocial", Datos.RazonSocial),
                     new SqlParameter("@RFC", Datos.RFC),
                     new SqlParameter("@DomicilioFisc", Datos.DomicilioFiscal),
                     new SqlParameter("@NumFactura", Datos.NumFactura),
                     new SqlParameter("@RegimenFiscal", Datos.RegimenFiscal),
                     new SqlParameter("@FolioFiscal", Datos.FolioFiscal),
                     new SqlParameter("@NoSerieCertSAT", Datos.NoSerieCertSAT),
                     new SqlParameter("@FechaHoraCert", Datos.FechaHoraCertificacion),
                     new SqlParameter("@NoSerieCertEms", Datos.NoSerieCertEmisor),
                     new SqlParameter("@FechaEmision", Datos.FechaEmision),
                     new SqlParameter("@LugarExp", Datos.LugarExpedicion),
                     new SqlParameter("@Subtotal", Datos.Subtotal),
                     new SqlParameter("@Descuento", Datos.Descuento),
                     new SqlParameter("@Iva", Datos.Iva),
                     new SqlParameter("@Total", Datos.Total),
                     new SqlParameter("@TotalLetras", Datos.TotalLetras),
                     new SqlParameter("@TablaProductos", Datos.TablaProductos),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                while (dr.Read())
                {
                    Resultado = !dr.IsDBNull(dr.GetOrdinal("Resultado")) ? dr.GetInt32(dr.GetOrdinal("Resultado")) : 0;
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.IDCompra = dr.GetString(dr.GetOrdinal("IDCompra"));
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

        public void ACComprasMobiliario(Compra Datos)
        {
            try
            {
                Datos.Completado = false;
                int Resultado = 0;
                SqlDataReader dr = SqlHelper.ExecuteReader(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_ac_ComprasMobiliario",
                     new SqlParameter("@NuevoRegistro", Datos.NuevoRegistro),
                     new SqlParameter("@IDCompra", Datos.IDCompra),
                     new SqlParameter("@IDProveedor", Datos.IDProveedor),
                     new SqlParameter("@IDSucursal", Datos.IDSucursal),
                     new SqlParameter("@RazonSocial", Datos.RazonSocial),
                     new SqlParameter("@RFC", Datos.RFC),
                     new SqlParameter("@DomicilioFisc", Datos.DomicilioFiscal),
                     new SqlParameter("@NumFactura", Datos.NumFactura),
                     new SqlParameter("@RegimenFiscal", Datos.RegimenFiscal),
                     new SqlParameter("@FolioFiscal", Datos.FolioFiscal),
                     new SqlParameter("@NoSerieCertSAT", Datos.NoSerieCertSAT),
                     new SqlParameter("@FechaHoraCert", Datos.FechaHoraCertificacion),
                     new SqlParameter("@NoSerieCertEms", Datos.NoSerieCertEmisor),
                     new SqlParameter("@FechaEmision", Datos.FechaEmision),
                     new SqlParameter("@LugarExp", Datos.LugarExpedicion),
                     new SqlParameter("@Subtotal", Datos.Subtotal),
                     new SqlParameter("@Descuento", Datos.Descuento),
                     new SqlParameter("@Iva", Datos.Iva),
                     new SqlParameter("@Total", Datos.Total),
                     new SqlParameter("@TotalLetras", Datos.TotalLetras),
                     new SqlParameter("@TablaMobiliario", Datos.TablaProductos),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                while (dr.Read())
                {
                    Resultado = !dr.IsDBNull(dr.GetOrdinal("Resultado")) ? dr.GetInt32(dr.GetOrdinal("Resultado")) : 0;
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.IDCompra = dr.GetString(dr.GetOrdinal("IDCompra"));
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


        public void CancelarCompra(Compra Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_CancelarCompra", Datos.IDCompra, Datos.IDUsuario);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CancelarCompraMobiliario(Compra Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_CancelarCompraMobiliario", Datos.IDCompra, Datos.IDUsuario);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerComprasPendientes(Compra Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ComprasPendientes", Datos.Todos, Datos.IDEstatusCompra, Datos.IDSucursal);
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

        public void ObtenerComprasMobiliarioPendientes(Compra Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ComprasMobiliarioPendientes", Datos.Todos, Datos.IDEstatusCompra, Datos.IDSucursal);
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


        public void ObtenerComprasPendientesBusq(Compra Datos)
        {
            try
            {
                object[] Parametros = { Datos.BusqFecha, Datos.BusqNumFactura, Datos.BusqProveedor, Datos.FechaEmision, Datos.NumFactura, Datos.IDProveedor, Datos.IDEstatusCompra, Datos.IDSucursal };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ComprasPendientesBusq", Parametros);
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

        public void ObtenerComprasMobiliarioPendientesBusq(Compra Datos)
        {
            try
            {
                object[] Parametros = { Datos.BusqFecha, Datos.BusqNumFactura, Datos.BusqProveedor, Datos.FechaEmision, Datos.NumFactura, Datos.IDProveedor, Datos.IDEstatusCompra, Datos.IDSucursal };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ComprasMobiliarioPendientesBusq", Parametros);
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


        public Compra ObtenerDatosCompra(Compra Datos)
        {
            try
            {
                Compra DatosGuardados = new Compra();
                DatosGuardados.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CompraDatosDetalle", Datos.IDCompra);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        if (Ds.Tables[0] != null)
                        {
                            DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                            while (Dr.Read())
                            {
                                DatosGuardados.IDCompra = Datos.IDCompra;
                                DatosGuardados.IDProveedor = !Dr.IsDBNull(Dr.GetOrdinal("IDProveedor")) ? Dr.GetString(Dr.GetOrdinal("IDProveedor")) : string.Empty;
                                DatosGuardados.RazonSocial = !Dr.IsDBNull(Dr.GetOrdinal("RazonSocial")) ? Dr.GetString(Dr.GetOrdinal("RazonSocial")) : string.Empty;
                                DatosGuardados.RFC = !Dr.IsDBNull(Dr.GetOrdinal("RFC")) ? Dr.GetString(Dr.GetOrdinal("RFC")) : string.Empty;
                                DatosGuardados.DomicilioFiscal = !Dr.IsDBNull(Dr.GetOrdinal("DomicilioFiscal")) ? Dr.GetString(Dr.GetOrdinal("DomicilioFiscal")) : string.Empty;
                                DatosGuardados.NumFactura = !Dr.IsDBNull(Dr.GetOrdinal("NumFactura")) ? Dr.GetString(Dr.GetOrdinal("NumFactura")) : string.Empty;
                                DatosGuardados.RegimenFiscal = !Dr.IsDBNull(Dr.GetOrdinal("RegimenFiscal")) ? Dr.GetString(Dr.GetOrdinal("RegimenFiscal")) : string.Empty;
                                DatosGuardados.FolioFiscal = !Dr.IsDBNull(Dr.GetOrdinal("FolioFiscal")) ? Dr.GetString(Dr.GetOrdinal("FolioFiscal")) : string.Empty;
                                DatosGuardados.NoSerieCertSAT = !Dr.IsDBNull(Dr.GetOrdinal("NoSerieCertSAT")) ? Dr.GetString(Dr.GetOrdinal("NoSerieCertSAT")) : string.Empty;
                                DatosGuardados.FechaHoraCertificacion = !Dr.IsDBNull(Dr.GetOrdinal("FechaHoraCert")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaHoraCert")) : DateTime.Today;
                                DatosGuardados.NoSerieCertEmisor = !Dr.IsDBNull(Dr.GetOrdinal("NoSerieCertEmisor")) ? Dr.GetString(Dr.GetOrdinal("NoSerieCertEmisor")) : string.Empty;
                                DatosGuardados.FechaEmision = !Dr.IsDBNull(Dr.GetOrdinal("FechaEmision")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaEmision")) : DateTime.Today;
                                DatosGuardados.LugarExpedicion = !Dr.IsDBNull(Dr.GetOrdinal("LugarExpedicion")) ? Dr.GetString(Dr.GetOrdinal("LugarExpedicion")) : string.Empty;
                                DatosGuardados.Subtotal = !Dr.IsDBNull(Dr.GetOrdinal("Subtotal")) ? Dr.GetDecimal(Dr.GetOrdinal("Subtotal")) : 0;
                                DatosGuardados.Descuento = !Dr.IsDBNull(Dr.GetOrdinal("Descuento")) ? Dr.GetDecimal(Dr.GetOrdinal("Descuento")) : 0;
                                DatosGuardados.Iva = !Dr.IsDBNull(Dr.GetOrdinal("Iva")) ? Dr.GetDecimal(Dr.GetOrdinal("Iva")) : 0;
                                DatosGuardados.Total = !Dr.IsDBNull(Dr.GetOrdinal("Total")) ? Dr.GetDecimal(Dr.GetOrdinal("Total")) : 0;
                                DatosGuardados.TotalLetras = !Dr.IsDBNull(Dr.GetOrdinal("TotalLetras")) ? Dr.GetString(Dr.GetOrdinal("TotalLetras")) : string.Empty;
                            }
                            Dr.Close();
                        }
                        if (Ds.Tables[1] != null)
                        {
                            List<Producto> Lista = new List<Producto>();
                            Producto Item;
                            DataTableReader Dr = Ds.Tables[1].CreateDataReader();
                            while (Dr.Read())
                            {
                                Item = new Producto();
                                Item.IDProducto = !Dr.IsDBNull(Dr.GetOrdinal("IDProducto")) ? Dr.GetString(Dr.GetOrdinal("IDProducto")) : string.Empty;
                                Item.IDUnidadMedida = !Dr.IsDBNull(Dr.GetOrdinal("IDUnidadMedida")) ? Dr.GetInt32(Dr.GetOrdinal("IDUnidadMedida")) : 0;
                                Item.UnidadMedidaDesc = !Dr.IsDBNull(Dr.GetOrdinal("UnidadMedida")) ? Dr.GetString(Dr.GetOrdinal("UnidadMedida")) : string.Empty;
                                Item.Clave = !Dr.IsDBNull(Dr.GetOrdinal("FolioProducto")) ? Dr.GetString(Dr.GetOrdinal("FolioProducto")) : string.Empty;
                                Item.NombreProducto = !Dr.IsDBNull(Dr.GetOrdinal("NombreProducto")) ? Dr.GetString(Dr.GetOrdinal("NombreProducto")) : string.Empty;
                                Item.Cantidad = (int)( !Dr.IsDBNull(Dr.GetOrdinal("NombreProducto")) ? Dr.GetDecimal(Dr.GetOrdinal("Cantidad")) : 0);
                                Item.PrecioCompra = !Dr.IsDBNull(Dr.GetOrdinal("PrecioUnitario")) ? Dr.GetDecimal(Dr.GetOrdinal("PrecioUnitario")) : 0;
                                Item.Subtotal = !Dr.IsDBNull(Dr.GetOrdinal("Subtotal")) ? Dr.GetDecimal(Dr.GetOrdinal("Subtotal")) : 0;
                                Item.Descuento = !Dr.IsDBNull(Dr.GetOrdinal("DescuentoUnitario")) ? Dr.GetDecimal(Dr.GetOrdinal("DescuentoUnitario")) : 0;
                                Item.DescuentoTotal = !Dr.IsDBNull(Dr.GetOrdinal("Descuento")) ? Dr.GetDecimal(Dr.GetOrdinal("Descuento")) : 0;
                                Item.Iva = !Dr.IsDBNull(Dr.GetOrdinal("IvaUnitario")) ? Dr.GetDecimal(Dr.GetOrdinal("IvaUnitario")) : 0;
                                Item.IvaTotal = !Dr.IsDBNull(Dr.GetOrdinal("Iva")) ? Dr.GetDecimal(Dr.GetOrdinal("Iva")) : 0;
                                Item.Total = !Dr.IsDBNull(Dr.GetOrdinal("Total")) ? Dr.GetDecimal(Dr.GetOrdinal("Total")) : 0;
                                Lista.Add(Item);
                            }
                            DatosGuardados.ListaProductos = Lista;
                            Dr.Close();
                        }
                        DatosGuardados.Completado = true;
                    }
                }
                return DatosGuardados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Compra ObtenerDatosCompraMobiliario(Compra Datos)
        {
            try
            {
                Compra DatosGuardados = new Compra();
                DatosGuardados.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CompraMobiliarioDatosDetalle", Datos.IDCompra);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        if (Ds.Tables[0] != null)
                        {
                            DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                            while (Dr.Read())
                            {
                                DatosGuardados.IDCompra = Datos.IDCompra;
                                DatosGuardados.IDProveedor = !Dr.IsDBNull(Dr.GetOrdinal("IDProveedor")) ? Dr.GetString(Dr.GetOrdinal("IDProveedor")) : string.Empty;
                                DatosGuardados.RazonSocial = !Dr.IsDBNull(Dr.GetOrdinal("RazonSocial")) ? Dr.GetString(Dr.GetOrdinal("RazonSocial")) : string.Empty;
                                DatosGuardados.RFC = !Dr.IsDBNull(Dr.GetOrdinal("RFC")) ? Dr.GetString(Dr.GetOrdinal("RFC")) : string.Empty;
                                DatosGuardados.DomicilioFiscal = !Dr.IsDBNull(Dr.GetOrdinal("DomicilioFiscal")) ? Dr.GetString(Dr.GetOrdinal("DomicilioFiscal")) : string.Empty;
                                DatosGuardados.NumFactura = !Dr.IsDBNull(Dr.GetOrdinal("NumFactura")) ? Dr.GetString(Dr.GetOrdinal("NumFactura")) : string.Empty;
                                DatosGuardados.RegimenFiscal = !Dr.IsDBNull(Dr.GetOrdinal("RegimenFiscal")) ? Dr.GetString(Dr.GetOrdinal("RegimenFiscal")) : string.Empty;
                                DatosGuardados.FolioFiscal = !Dr.IsDBNull(Dr.GetOrdinal("FolioFiscal")) ? Dr.GetString(Dr.GetOrdinal("FolioFiscal")) : string.Empty;
                                DatosGuardados.NoSerieCertSAT = !Dr.IsDBNull(Dr.GetOrdinal("NoSerieCertSAT")) ? Dr.GetString(Dr.GetOrdinal("NoSerieCertSAT")) : string.Empty;
                                DatosGuardados.FechaHoraCertificacion = !Dr.IsDBNull(Dr.GetOrdinal("FechaHoraCert")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaHoraCert")) : DateTime.Today;
                                DatosGuardados.NoSerieCertEmisor = !Dr.IsDBNull(Dr.GetOrdinal("NoSerieCertEmisor")) ? Dr.GetString(Dr.GetOrdinal("NoSerieCertEmisor")) : string.Empty;
                                DatosGuardados.FechaEmision = !Dr.IsDBNull(Dr.GetOrdinal("FechaEmision")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaEmision")) : DateTime.Today;
                                DatosGuardados.LugarExpedicion = !Dr.IsDBNull(Dr.GetOrdinal("LugarExpedicion")) ? Dr.GetString(Dr.GetOrdinal("LugarExpedicion")) : string.Empty;
                                DatosGuardados.Subtotal = !Dr.IsDBNull(Dr.GetOrdinal("Subtotal")) ? Dr.GetDecimal(Dr.GetOrdinal("Subtotal")) : 0;
                                DatosGuardados.Descuento = !Dr.IsDBNull(Dr.GetOrdinal("Descuento")) ? Dr.GetDecimal(Dr.GetOrdinal("Descuento")) : 0;
                                DatosGuardados.Iva = !Dr.IsDBNull(Dr.GetOrdinal("Iva")) ? Dr.GetDecimal(Dr.GetOrdinal("Iva")) : 0;
                                DatosGuardados.Total = !Dr.IsDBNull(Dr.GetOrdinal("Total")) ? Dr.GetDecimal(Dr.GetOrdinal("Total")) : 0;
                                DatosGuardados.TotalLetras = !Dr.IsDBNull(Dr.GetOrdinal("TotalLetras")) ? Dr.GetString(Dr.GetOrdinal("TotalLetras")) : string.Empty;
                            }
                            Dr.Close();
                        }
                        if (Ds.Tables[1] != null)
                        {
                            List<Mobiliario> Lista = new List<Mobiliario>();
                            Mobiliario Item;
                            DataTableReader Dr = Ds.Tables[1].CreateDataReader();
                            while (Dr.Read())
                            {
                                Item = new Mobiliario();
                                Item.IDMobiliario = !Dr.IsDBNull(Dr.GetOrdinal("IDMobiliario")) ? Dr.GetString(Dr.GetOrdinal("IDMobiliario")) : string.Empty;
                                Item.Codigo = !Dr.IsDBNull(Dr.GetOrdinal("Codigo")) ? Dr.GetString(Dr.GetOrdinal("Codigo")) : string.Empty;
                                Item.Descripcion = !Dr.IsDBNull(Dr.GetOrdinal("Descripcion")) ? Dr.GetString(Dr.GetOrdinal("Descripcion")) : string.Empty;
                                Item.Cantidad = !Dr.IsDBNull(Dr.GetOrdinal("Cantidad")) ? Dr.GetInt32(Dr.GetOrdinal("Cantidad")) : 0;
                                Item.Precio = !Dr.IsDBNull(Dr.GetOrdinal("PrecioUnitario")) ? Dr.GetDecimal(Dr.GetOrdinal("PrecioUnitario")) : 0;
                                Item.Subtotal = !Dr.IsDBNull(Dr.GetOrdinal("Subtotal")) ? Dr.GetDecimal(Dr.GetOrdinal("Subtotal")) : 0;
                                Item.DescuentoUnitario = !Dr.IsDBNull(Dr.GetOrdinal("DescuentoUnitario")) ? Dr.GetDecimal(Dr.GetOrdinal("DescuentoUnitario")) : 0;
                                Item.Descuento = !Dr.IsDBNull(Dr.GetOrdinal("Descuento")) ? Dr.GetDecimal(Dr.GetOrdinal("Descuento")) : 0;
                                Item.IvaUnitario = !Dr.IsDBNull(Dr.GetOrdinal("IvaUnitario")) ? Dr.GetDecimal(Dr.GetOrdinal("IvaUnitario")) : 0;
                                Item.Iva = !Dr.IsDBNull(Dr.GetOrdinal("Iva")) ? Dr.GetDecimal(Dr.GetOrdinal("Iva")) : 0;
                                Item.Total = !Dr.IsDBNull(Dr.GetOrdinal("Total")) ? Dr.GetDecimal(Dr.GetOrdinal("Total")) : 0;
                                Lista.Add(Item);
                            }
                            DatosGuardados.ListaMobiliario = Lista;
                            Dr.Close();
                        }
                        DatosGuardados.Completado = true;
                    }
                }
                return DatosGuardados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Compra ObtenerDatosCompraDetalle(Compra Datos)
        {
            try
            {
                Compra DatosGuardados = new Compra();
                DatosGuardados.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ComprasDetalle", Datos.IDCompra);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        if (Ds.Tables[0] != null)
                        {
                            DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                            while (Dr.Read())
                            {
                                DatosGuardados.IDCompra = Datos.IDCompra;
                                DatosGuardados.IDProveedor = !Dr.IsDBNull(Dr.GetOrdinal("Proveedor")) ? Dr.GetString(Dr.GetOrdinal("Proveedor")) : string.Empty;
                                DatosGuardados.RazonSocial = !Dr.IsDBNull(Dr.GetOrdinal("RazonSocial")) ? Dr.GetString(Dr.GetOrdinal("RazonSocial")) : string.Empty;
                                DatosGuardados.RFC = !Dr.IsDBNull(Dr.GetOrdinal("RFC")) ? Dr.GetString(Dr.GetOrdinal("RFC")) : string.Empty;
                                DatosGuardados.DomicilioFiscal = !Dr.IsDBNull(Dr.GetOrdinal("DomicilioFiscal")) ? Dr.GetString(Dr.GetOrdinal("DomicilioFiscal")) : string.Empty;
                                DatosGuardados.NumFactura = !Dr.IsDBNull(Dr.GetOrdinal("NumFactura")) ? Dr.GetString(Dr.GetOrdinal("NumFactura")) : string.Empty;
                                DatosGuardados.RegimenFiscal = !Dr.IsDBNull(Dr.GetOrdinal("RegimenFiscal")) ? Dr.GetString(Dr.GetOrdinal("RegimenFiscal")) : string.Empty;
                                DatosGuardados.FolioFiscal = !Dr.IsDBNull(Dr.GetOrdinal("FolioFiscal")) ? Dr.GetString(Dr.GetOrdinal("FolioFiscal")) : string.Empty;
                                DatosGuardados.NoSerieCertSAT = !Dr.IsDBNull(Dr.GetOrdinal("NoSerieCertSAT")) ? Dr.GetString(Dr.GetOrdinal("NoSerieCertSAT")) : string.Empty;
                                DatosGuardados.FechaHoraCertificacion = !Dr.IsDBNull(Dr.GetOrdinal("FechaHoraCert")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaHoraCert")) : DateTime.Today;
                                DatosGuardados.NoSerieCertEmisor = !Dr.IsDBNull(Dr.GetOrdinal("NoSerieCertEmisor")) ? Dr.GetString(Dr.GetOrdinal("NoSerieCertEmisor")) : string.Empty;
                                DatosGuardados.FechaEmision = !Dr.IsDBNull(Dr.GetOrdinal("FechaEmision")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaEmision")) : DateTime.Today;
                                DatosGuardados.LugarExpedicion = !Dr.IsDBNull(Dr.GetOrdinal("LugarExpedicion")) ? Dr.GetString(Dr.GetOrdinal("LugarExpedicion")) : string.Empty;
                                DatosGuardados.Subtotal = !Dr.IsDBNull(Dr.GetOrdinal("Subtotal")) ? Dr.GetDecimal(Dr.GetOrdinal("Subtotal")) : 0;
                                DatosGuardados.Descuento = !Dr.IsDBNull(Dr.GetOrdinal("Descuento")) ? Dr.GetDecimal(Dr.GetOrdinal("Descuento")) : 0;
                                DatosGuardados.Iva = !Dr.IsDBNull(Dr.GetOrdinal("Iva")) ? Dr.GetDecimal(Dr.GetOrdinal("Iva")) : 0;
                                DatosGuardados.Total = !Dr.IsDBNull(Dr.GetOrdinal("Total")) ? Dr.GetDecimal(Dr.GetOrdinal("Total")) : 0;
                                DatosGuardados.TotalLetras = !Dr.IsDBNull(Dr.GetOrdinal("TotalLetras")) ? Dr.GetString(Dr.GetOrdinal("TotalLetras")) : string.Empty;
                            }
                            Dr.Close();
                        }
                        if (Ds.Tables[1] != null)
                        {
                            DatosGuardados.TablaProductos = Ds.Tables[1];
                        }
                        DatosGuardados.Completado = true;
                    }
                }
                return DatosGuardados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Compra ObtenerDatosCompraMobiliarioDetalle(Compra Datos)
        {
            try
            {
                Compra DatosGuardados = new Compra();
                DatosGuardados.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ComprasMobiliarioDetalle", Datos.IDCompra);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        if (Ds.Tables[0] != null)
                        {
                            DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                            while (Dr.Read())
                            {
                                DatosGuardados.IDCompra = Datos.IDCompra;
                                DatosGuardados.IDProveedor = !Dr.IsDBNull(Dr.GetOrdinal("Proveedor")) ? Dr.GetString(Dr.GetOrdinal("Proveedor")) : string.Empty;
                                DatosGuardados.RazonSocial = !Dr.IsDBNull(Dr.GetOrdinal("RazonSocial")) ? Dr.GetString(Dr.GetOrdinal("RazonSocial")) : string.Empty;
                                DatosGuardados.RFC = !Dr.IsDBNull(Dr.GetOrdinal("RFC")) ? Dr.GetString(Dr.GetOrdinal("RFC")) : string.Empty;
                                DatosGuardados.DomicilioFiscal = !Dr.IsDBNull(Dr.GetOrdinal("DomicilioFiscal")) ? Dr.GetString(Dr.GetOrdinal("DomicilioFiscal")) : string.Empty;
                                DatosGuardados.NumFactura = !Dr.IsDBNull(Dr.GetOrdinal("NumFactura")) ? Dr.GetString(Dr.GetOrdinal("NumFactura")) : string.Empty;
                                DatosGuardados.RegimenFiscal = !Dr.IsDBNull(Dr.GetOrdinal("RegimenFiscal")) ? Dr.GetString(Dr.GetOrdinal("RegimenFiscal")) : string.Empty;
                                DatosGuardados.FolioFiscal = !Dr.IsDBNull(Dr.GetOrdinal("FolioFiscal")) ? Dr.GetString(Dr.GetOrdinal("FolioFiscal")) : string.Empty;
                                DatosGuardados.NoSerieCertSAT = !Dr.IsDBNull(Dr.GetOrdinal("NoSerieCertSAT")) ? Dr.GetString(Dr.GetOrdinal("NoSerieCertSAT")) : string.Empty;
                                DatosGuardados.FechaHoraCertificacion = !Dr.IsDBNull(Dr.GetOrdinal("FechaHoraCert")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaHoraCert")) : DateTime.Today;
                                DatosGuardados.NoSerieCertEmisor = !Dr.IsDBNull(Dr.GetOrdinal("NoSerieCertEmisor")) ? Dr.GetString(Dr.GetOrdinal("NoSerieCertEmisor")) : string.Empty;
                                DatosGuardados.FechaEmision = !Dr.IsDBNull(Dr.GetOrdinal("FechaEmision")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaEmision")) : DateTime.Today;
                                DatosGuardados.LugarExpedicion = !Dr.IsDBNull(Dr.GetOrdinal("LugarExpedicion")) ? Dr.GetString(Dr.GetOrdinal("LugarExpedicion")) : string.Empty;
                                DatosGuardados.Subtotal = !Dr.IsDBNull(Dr.GetOrdinal("Subtotal")) ? Dr.GetDecimal(Dr.GetOrdinal("Subtotal")) : 0;
                                DatosGuardados.Descuento = !Dr.IsDBNull(Dr.GetOrdinal("Descuento")) ? Dr.GetDecimal(Dr.GetOrdinal("Descuento")) : 0;
                                DatosGuardados.Iva = !Dr.IsDBNull(Dr.GetOrdinal("Iva")) ? Dr.GetDecimal(Dr.GetOrdinal("Iva")) : 0;
                                DatosGuardados.Total = !Dr.IsDBNull(Dr.GetOrdinal("Total")) ? Dr.GetDecimal(Dr.GetOrdinal("Total")) : 0;
                                DatosGuardados.TotalLetras = !Dr.IsDBNull(Dr.GetOrdinal("TotalLetras")) ? Dr.GetString(Dr.GetOrdinal("TotalLetras")) : string.Empty;
                            }
                            Dr.Close();

                        }
                        if (Ds.Tables[1] != null)
                        {
                            DatosGuardados.TablaProductos = Ds.Tables[1];
                        }
                        DatosGuardados.Completado = true;
                    }
                }
                return DatosGuardados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ProcesarCompra(Compra Datos)
        {
            try
            {
                Datos.Completado = false;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "Produccion.spCSLDB_set_ProcesarCompra", Datos.IDCompra, Datos.IDUsuario);
                while (Dr.Read())
                {
                    Datos.Resultado = !Dr.IsDBNull(Dr.GetOrdinal("Resultado")) ? Dr.GetInt32(Dr.GetOrdinal("Resultado")) : 0;
                    if (Datos.Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                    else if (Datos.Resultado == -1)
                    {
                        Datos.MensajeError = !Dr.IsDBNull(Dr.GetOrdinal("MensajeError")) ? Dr.GetString(Dr.GetOrdinal("MensajeError")) : string.Empty;
                    }
                }
                Dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ProcesarCompraMobiliario(Compra Datos)
        {
            try
            {
                Datos.Completado = false;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_set_ProcesarCompraMobiliario", Datos.IDCompra, Datos.IDUsuario);
                while (Dr.Read())
                {
                    Datos.Resultado = !Dr.IsDBNull(Dr.GetOrdinal("Resultado")) ? Dr.GetInt32(Dr.GetOrdinal("Resultado")) : 0;
                    if (Datos.Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                    else if (Datos.Resultado == -1)
                    {
                        Datos.MensajeError = !Dr.IsDBNull(Dr.GetOrdinal("MensajeError")) ? Dr.GetString(Dr.GetOrdinal("MensajeError")) : string.Empty;
                    }
                }
                Dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerPagosCompraMobiliario(Compra Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_PagosCompraMobiliario", Datos.IDCompra);
                Datos.TablaDatos = new DataTable();
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                    {
                        Datos.Completado = true;
                        Datos.TablaDatos = Ds.Tables[0];
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerPagosCompra(Compra Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_PagosCompra", Datos.IDCompra);
                Datos.TablaDatos = new DataTable();
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                    {
                        Datos.Completado = true;
                        Datos.TablaDatos = Ds.Tables[0];
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ACPagosCompraMobiliario(PagoCompra Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDPagoCompra, Datos.IDCompra, Datos.MontoPago, 
                                        Datos.FechaPago, Datos.IDCajaXSucursal, Datos.IDUsuario};
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_AC_PagosComprasMobiliario", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ACPagosCompra(PagoCompra Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDPagoCompra, Datos.IDCompra, Datos.MontoPago, 
                                        Datos.FechaPago, Datos.IDCajaXSucursal, Datos.IDUsuario};
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_AC_PagosCompras", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CancelarPagoCompraMobiliario(PagoCompra Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPagoCompra, Datos.IDCajaXSucursal, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_CancelarPagoCompraMobiliario", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CancelarPagoCompra(PagoCompra Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPagoCompra, Datos.IDCajaXSucursal, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_CancelarPagoCompra", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
