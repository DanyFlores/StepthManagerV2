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
    public class Mobiliario_Datos
    {
        public void ACCatMobiliario(Mobiliario Datos)
        {
            try
            {
                Datos.Completado = false;
                int Resultado = 0;
                SqlDataReader dr = SqlHelper.ExecuteReader(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_ac_CatMobiliario",
                     new SqlParameter("@NuevoRegistro", Datos.NuevoRegistro),
                     new SqlParameter("@IDMobiliario", Datos.IDMobiliario),
                     new SqlParameter("@Codigo", Datos.Codigo),
                     new SqlParameter("@Descripcion", Datos.Descripcion),
                     new SqlParameter("@Marca", Datos.Marca),
                     new SqlParameter("@Modelo", Datos.Modelo),
                     new SqlParameter("@TablaProveedor", Datos.TablaDatos),
                     new SqlParameter("@IDTipoMobiliario", Datos.IDTipoMobiliario),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                while (dr.Read())
                {
                    Resultado = !dr.IsDBNull(dr.GetOrdinal("Resultado")) ? dr.GetInt32(dr.GetOrdinal("Resultado")) : 0;
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.IDMobiliario = dr.GetString(dr.GetOrdinal("IDMobiliario"));
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
        public void EliminarMobiliario(Mobiliario Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_del_EliminarMobiliario", Datos.IDMobiliario, Datos.IDUsuario);
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
        public void ObtenerCatMobiliario(Mobiliario Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatMobiliario", Datos.BuscarTodos, Datos.IDSucursal);
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

        public void ObtenerCatMobiliarioBusqueda(Mobiliario Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatMobiliarioBusqueda", Datos.BuscarTodos, Datos.Descripcion, Datos.IDSucursal);
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

        public void ObtenerBusquedaMobiliario(Mobiliario Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_MobiliarioBusqueda", Datos.Descripcion, Datos.IDProveedor);
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

        public List<Proveedor> ObtenerProveedorXIDMobiliario(Mobiliario Datos)
        {
            try
            {
                List<Proveedor> Lista = new List<Proveedor>();
                Proveedor Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ProveedorXMobiliario", Datos.IDMobiliario);
                while (Dr.Read())
                {
                    Item = new Proveedor();
                    Item.IDProductoXProveedor = Dr.IsDBNull(Dr.GetOrdinal("IDMobiliarioXProveedor")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDMobiliarioXProveedor"));
                    Item.IDProveedor = Dr.IsDBNull(Dr.GetOrdinal("IDProveedor")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDProveedor"));
                    Item.RazonSocial = Dr.IsDBNull(Dr.GetOrdinal("RazonSocial")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("RazonSocial"));
                    Item.CostoUltimo = Dr.IsDBNull(Dr.GetOrdinal("UltimoCosto")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("UltimoCosto"));
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

        public List<Proveedor> ObtenerProveedoresDisponiblesXIDMobiliario(Mobiliario Datos)
        {
            try
            {
                List<Proveedor> Lista = new List<Proveedor>();
                Proveedor Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_CatProveedoresDispXIDMobiliario", Datos.IDMobiliario);
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

        public void ObtenerBusquedaMobiliario_Res(Mobiliario Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_MobiliarioBusqueda_Res", Datos.Descripcion);
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

        public void ObtenerMobiliarioAsignadoXIDSuc(Mobiliario Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_MobiliarioAsignadoPorSucursal", Datos.IDSucursal);
                Datos.TablaDatos = new DataTable();
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                    {
                        Datos.TablaDatos = Ds.Tables[0];
                        Datos.Completado = true;
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BajaMobiliario(Mobiliario Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_BajaMobiliario", Datos.IDMobiliarioXSucursal, Datos.IDUsuario);
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


        public void TransferenciaMobiliario(Mobiliario Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_TransferenciaMobiliario", Datos.IDMobiliarioXSucursal, Datos.IDSucursalDestino, Datos.IDUsuario);
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
    }
}
