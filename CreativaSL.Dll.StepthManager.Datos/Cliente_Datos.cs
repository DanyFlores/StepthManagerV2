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
    public class Cliente_Datos
    {
        public void ABCCatClientes(Cliente Datos)
        {
            try
            {
                Datos.Completado = false;
                int Resultado = 0;
                SqlDataReader dr = SqlHelper.ExecuteReader(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_abc_CatClientes",
                     new SqlParameter("@Opcion", Datos.Opcion),
                     new SqlParameter("@IDCliente", Datos.IDCliente),
                     new SqlParameter("@Nombre", Datos.Nombre),
                     new SqlParameter("@ApellidoPat", Datos.ApellidoPat),
                     new SqlParameter("@ApellidoMat", Datos.ApellidoMat),
                     new SqlParameter("@IDGenero", Datos.IDGenero),
                     new SqlParameter("@FechaNac", Datos.FechaNac),
                     new SqlParameter("@Correo", Datos.Correo),
                     new SqlParameter("@Telefono", Datos.Telefono),
                     new SqlParameter("@Observaciones", Datos.Observaciones),
                     new SqlParameter("@Recomendaciones", Datos.Recomendaciones),
                     new SqlParameter("@Padecimientos", Datos.TablaPadecimientos),
                     new SqlParameter("@TagsInteres", Datos.TablaTagsInteres),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                while (dr.Read())
                {
                    Resultado = !dr.IsDBNull(dr.GetOrdinal("Resultado")) ? dr.GetInt32(dr.GetOrdinal("Resultado")) : 0;
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.IDCliente = dr.GetString(dr.GetOrdinal("IDCliente"));
                        Datos.Correo = dr.GetString(dr.GetOrdinal("Correo"));
                        Datos.Password = dr.GetString(dr.GetOrdinal("PasswordAux"));
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

        public void AsignarMonederoCliente(Cliente Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDCliente, Datos.IDTarjeta, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_AsignarMonederoCliente", Parametros);
                Datos.Completado = false;
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

        public void ObtenerBusquedaClientes(Cliente Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_BusquedaClientes", Datos.Nombre);
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

        public void ObtenerCatClientes(Cliente Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatClientes", Datos.BuscarTodos);
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

        public void ObtenerCatClientesBusqueda(Cliente Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatClientesBusqueda", Datos.BuscarTodos, Datos.Nombre);
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

        public List<TagInteres> ObtenerCatTagInteresXIDCliente(TagInteres Datos)
        {
            try
            {
                List<TagInteres> Lista = new List<TagInteres>();
                TagInteres Item;
                SqlDataReader dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_CatTagsInteresXIDCliente", Datos.IDCliente.Trim());
                while (dr.Read())
                {
                    Item = new TagInteres();
                    Item.IDTagInteres = !dr.IsDBNull(dr.GetOrdinal("IDTagInteres")) ? dr.GetString(dr.GetOrdinal("IDTagInteres")): string.Empty;
                    Item.Descripcion = !dr.IsDBNull(dr.GetOrdinal("Descripcion")) ? dr.GetString(dr.GetOrdinal("Descripcion")) : string.Empty;
                    Item.Seleccionado = !dr.IsDBNull(dr.GetOrdinal("Seleccionado")) ? dr.GetBoolean(dr.GetOrdinal("Seleccionado")) : false;
                    Lista.Add(Item);
                }
                dr.Close();
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TarjetaMonedero> ObtenerCatTarjetasDisponibles(TarjetaMonedero Datos)
        {
            try
            {
                List<TarjetaMonedero> Lista = new List<TarjetaMonedero>();
                TarjetaMonedero Item;
                SqlDataReader dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_TarjetasMonederoDisponibles");
                while (dr.Read())
                {
                    Item = new TarjetaMonedero();
                    Item.IDTarjeta = !dr.IsDBNull(dr.GetOrdinal("IDTarjeta")) ? dr.GetString(dr.GetOrdinal("IDTarjeta")) : string.Empty;
                    Item.Folio = !dr.IsDBNull(dr.GetOrdinal("Folio")) ? dr.GetString(dr.GetOrdinal("Folio")) : string.Empty;
                    Item.IDTipoMonedero = !dr.IsDBNull(dr.GetOrdinal("IDTipoMonedero")) ? dr.GetInt32(dr.GetOrdinal("IDTipoMonedero")) : 0;
                    Item.TipoMonederoDesc = !dr.IsDBNull(dr.GetOrdinal("TipoMonedero")) ? dr.GetString(dr.GetOrdinal("TipoMonedero")) : string.Empty;
                    Lista.Add(Item);
                }
                dr.Close();
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Padecimiento> ObtenerCatPadecimientosXIDCliente(Padecimiento Datos)
        {
            try
            {
                List<Padecimiento> Lista = new List<Padecimiento>();
                Padecimiento Item;
                SqlDataReader dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_CatPadecimientosXIDCliente", Datos.IDCliente.Trim());
                while (dr.Read())
                {
                    Item = new Padecimiento();
                    Item.IDPadecimientoXCliente = !dr.IsDBNull(dr.GetOrdinal("IDPadecimientoXCliente")) ? dr.GetString(dr.GetOrdinal("IDPadecimientoXCliente")) : string.Empty;
                    Item.IDPadecimiento = !dr.IsDBNull(dr.GetOrdinal("IDPadecimiento")) ? dr.GetString(dr.GetOrdinal("IDPadecimiento")) : string.Empty;
                    Item.Descripcion = !dr.IsDBNull(dr.GetOrdinal("Descripcion")) ? dr.GetString(dr.GetOrdinal("Descripcion")) : string.Empty;
                    Item.Seleccionado = !dr.IsDBNull(dr.GetOrdinal("Seleccionado")) ? dr.GetBoolean(dr.GetOrdinal("Seleccionado")) : false;
                    Lista.Add(Item);
                }
                dr.Close();
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cliente> ObtenerComboClientes(Cliente Datos)
        {
            try
            {
                List<Cliente> Lista = new List<Cliente>();
                Cliente Item;
                SqlDataReader dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboCatClientes", Datos.IncluirSelect);
                while (dr.Read())
                {
                    Item = new Cliente();
                    Item.IDCliente = !dr.IsDBNull(dr.GetOrdinal("IDCliente")) ? dr.GetString(dr.GetOrdinal("IDCliente")) : string.Empty;
                    Item.Nombre = !dr.IsDBNull(dr.GetOrdinal("Nombre")) ? dr.GetString(dr.GetOrdinal("Nombre")) : string.Empty;
                    Lista.Add(Item);
                }
                dr.Close();
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CambiarFolioTarjetaMonedero(TarjetaMonedero Datos)
        {
            try
            {
                int Resultado = 0;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_FolioTarjeta", Datos.IDTarjeta, Datos.IDCliente, Datos.Folio, Datos.IDUsuario);
                if (Result != null)
                {
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                }
                Datos.Opcion = Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaldoTarjetaMonedero(TarjetaMonedero Datos)
        {
            try
            {
                int Resultado = 0;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_SaldoMonederoTarjeta", Datos.IDTarjeta, Datos.IDCliente, Datos.Saldo, Datos.IDUsuario);
                if (Result != null)
                {
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                }
                Datos.Opcion = Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cliente ObtenerHistorialCita(Cliente Datos)
        {
            try
            {
                Cliente DatosGuardados = new Cliente();
                DatosGuardados.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CitaXIDCliente", Datos.IDCliente);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        if (Ds.Tables[0] != null)
                        {
                            List<Cliente> Lista = new List<Cliente>();
                            Cliente Item;
                            DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                            while (Dr.Read())
                            {
                                Item = new Cliente();
                                Item.IDCita = !Dr.IsDBNull(Dr.GetOrdinal("IDCita")) ? Dr.GetString(Dr.GetOrdinal("IDCita")) : string.Empty;
                                Item.IDCliente = !Dr.IsDBNull(Dr.GetOrdinal("IDCliente")) ? Dr.GetString(Dr.GetOrdinal("IDCliente")) : string.Empty;
                                Item.IDSucursal = !Dr.IsDBNull(Dr.GetOrdinal("IDSucursal")) ? Dr.GetString(Dr.GetOrdinal("IDSucursal")) : string.Empty;
                                Item.IDServicio = !Dr.IsDBNull(Dr.GetOrdinal("IDServicio")) ? Dr.GetString(Dr.GetOrdinal("IDServicio")) : string.Empty;
                                Item.NombreSucursal = !Dr.IsDBNull(Dr.GetOrdinal("NombreSucursal")) ? Dr.GetString(Dr.GetOrdinal("NombreSucursal")) : string.Empty;
                                Item.NombreServicio = !Dr.IsDBNull(Dr.GetOrdinal("NombreServicio")) ? Dr.GetString(Dr.GetOrdinal("NombreServicio")) : string.Empty;
                                Item.Observaciones = !Dr.IsDBNull(Dr.GetOrdinal("Observaciones")) ? Dr.GetString(Dr.GetOrdinal("Observaciones")) : string.Empty;
                                Item.IDEmpleado = !Dr.IsDBNull(Dr.GetOrdinal("IDEmpleado")) ? Dr.GetString(Dr.GetOrdinal("IDEmpleado")) : string.Empty;
                                Item.NombreEmpleado = !Dr.IsDBNull(Dr.GetOrdinal("NombreEmpleado")) ? Dr.GetString(Dr.GetOrdinal("NombreEmpleado")) : string.Empty;
                                Lista.Add(Item);
                            }
                            DatosGuardados.ListaHistClientes = Lista;
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

        public Cliente ObtenerHistorialCompra(Cliente Datos)
        {
            try
            {
                Cliente DatosGuardados = new Cliente();
                DatosGuardados.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CompraXIDCliente", Datos.IDCliente);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        if (Ds.Tables[0] != null)
                        {
                            List<Cliente> Lista = new List<Cliente>();
                            Cliente Item;
                            DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                            while (Dr.Read())
                            {
                                Item = new Cliente();
                                Item.IDVenta = !Dr.IsDBNull(Dr.GetOrdinal("IDVenta")) ? Dr.GetString(Dr.GetOrdinal("IDVenta")) : string.Empty;
                                Item.IDCliente = !Dr.IsDBNull(Dr.GetOrdinal("IDCliente")) ? Dr.GetString(Dr.GetOrdinal("IDCliente")) : string.Empty;
                                Item.IDSucursal = !Dr.IsDBNull(Dr.GetOrdinal("IDSucursal")) ? Dr.GetString(Dr.GetOrdinal("IDSucursal")) : string.Empty;
                                Item.FolioVenta = !Dr.IsDBNull(Dr.GetOrdinal("FolioVenta")) ? Dr.GetString(Dr.GetOrdinal("FolioVenta")) : string.Empty;
                                Item.NombreSucursal = !Dr.IsDBNull(Dr.GetOrdinal("NombreSucursal")) ? Dr.GetString(Dr.GetOrdinal("NombreSucursal")) : string.Empty;
                                Item.Total = !Dr.IsDBNull(Dr.GetOrdinal("Total")) ? Dr.GetDecimal(Dr.GetOrdinal("Total")) : 0;
                                Item.IDTipoVenta = !Dr.IsDBNull(Dr.GetOrdinal("IDTIpoVenta")) ? Dr.GetInt32(Dr.GetOrdinal("IDTIpoVenta")) : 0;
                                Item.TipoVenta = !Dr.IsDBNull(Dr.GetOrdinal("TipoVenta")) ? Dr.GetString(Dr.GetOrdinal("TipoVenta")) : string.Empty;
                                Lista.Add(Item);
                            }
                            DatosGuardados.ListaHistClientes = Lista;
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

        public Cliente ObtenerHistorialSucursal(Cliente Datos)
        {
            try
            {
                Cliente DatosGuardados = new Cliente();
                DatosGuardados.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_HistorialSucursaleXIDCliente", Datos.IDCliente);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        if (Ds.Tables[0] != null)
                        {
                            List<Cliente> Lista = new List<Cliente>();
                            Cliente Item;
                            DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                            while (Dr.Read())
                            {
                                Item = new Cliente();
                                Item.IDSucursal = !Dr.IsDBNull(Dr.GetOrdinal("IDSucursal")) ? Dr.GetString(Dr.GetOrdinal("IDSucursal")) : string.Empty;
                                Item.NombreSucursal = !Dr.IsDBNull(Dr.GetOrdinal("NombreSucursal")) ? Dr.GetString(Dr.GetOrdinal("NombreSucursal")) : string.Empty;
                                Item.VisitasVentas = !Dr.IsDBNull(Dr.GetOrdinal("VisitasVentas")) ? Dr.GetInt32(Dr.GetOrdinal("VisitasVentas")) : 0;
                                Lista.Add(Item);
                            }
                            DatosGuardados.ListaHistClientes = Lista;
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
    }
}
