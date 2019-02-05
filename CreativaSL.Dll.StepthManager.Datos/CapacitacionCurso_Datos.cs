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
    public class CapacitacionCurso_Datos
    {


        public void ABCCapacitacionCurso(CapacitacionCurso Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDCapacitacion, Datos.IDCurso, Datos.IDInstructor, Datos.Lugar,
                                        Datos.FechaInicioCurso, Datos.FechaFinCurso, Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_CapacitaionCurso", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    if (!string.IsNullOrEmpty(Resultado.ToString()))
                    {
                        Datos.Completado = true;
                        Datos.IDCapacitacion = Resultado.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void ABCInscripcionCurso(CapacitacionCurso Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDInscripcion, Datos.IDEmpleado, Datos.IDCurso, Datos.IDCapacitacion,
                                        Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_IncripcionCurso", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    if (!string.IsNullOrEmpty(Resultado.ToString()))
                    {
                        Datos.Completado = true;
                        Datos.IDInscripcion = Resultado.ToString();
                        if (Datos.IDInscripcion == Convert.ToString(1))
                        {
                            Datos.Completado = true;
                            Datos.IDInscripcion = Resultado.ToString();
                        }
                        else if (Datos.IDInscripcion == Convert.ToString(0))
                        {
                            Datos.Completado = false;
                            Datos.MensajeError = "El Empleado ya Existe";
                        }
                    }
                }
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

        public void ObtenerCursosCreados(CapacitacionCurso Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CursosCreados", Datos.Todos, Datos.IDStatusCursos);
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

        public void ObtenerCursosCreadosBusq(CapacitacionCurso Datos)
        {
            try
            {
                object[] Parametros = { Datos.BusqFecha, Datos.BusqProveedor, Datos.FechaBus,  Datos.IDCurso, Datos.IDStatusCursos };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CursosCreadaBusq", Parametros);
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

        public void ActivarCurso(CapacitacionCurso Datos)
        {
            try
            {
                Datos.Completado = false;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_set_ActivarCurso", Datos.IDCapacitacion, Datos.IDUsuario);
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ConcluirCurso(CapacitacionCurso Datos)
        {
            try
            {
                Datos.Completado = false;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_set_ConcluirCurso", Datos.IDCapacitacion, Datos.IDUsuario);
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

        public void ObtenerLlegarGribParticipante(CapacitacionCurso Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDCapacitacion};
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_InscritosCursos", Parametros);
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

        public void ObtenerTemasSubTemas(CapacitacionCurso Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = {Datos.IDEmpleado, Datos.IDCapacitacion };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_TemasSubtemasCursos", Parametros);
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

        public void ABCCalificaciones(CapacitacionCurso Datos)
        {
            try
            {
                Datos.Completado = false;
                int Resultado = 0;
                SqlDataReader dr = SqlHelper.ExecuteReader(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_abc_CalificacionesEmpleados",
                     new SqlParameter("@Opcion", Datos.Opcion),
                     new SqlParameter("@IDCalificacion", Datos.IDCalificacion),
                     new SqlParameter("@IDEmpleado", Datos.IDEmpleado),
                     new SqlParameter("@IDVenta", Datos.IDVenta),
                     new SqlParameter("@IDCapacitacion", Datos.IDCapacitacion),
                     new SqlParameter("@TablaCalificaciones", Datos.TablaCalificaciones),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                while (dr.Read())
                {
                    // Resultado = !dr.IsDBNull(dr.GetOrdinal("Resultado")) ? dr.GetInt32(dr.GetOrdinal("Resultado")) : 0;
                    if (Resultado == 0)
                    {
                        Datos.Completado = true;
                        Datos.IDEmpleado = dr.GetString(dr.GetOrdinal("IDEmpleado"));
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
    }
}
