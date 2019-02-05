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
    public class MobiliarioResguardo_Datos
    {
        public MobiliarioResguardo ObtenerExistentes(MobiliarioResguardo Datos)
        {
            try
            {
                MobiliarioResguardo Resultado = new MobiliarioResguardo();
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ExistenciaMobiliario", Datos.IDMobiliario,  Datos.IDSucursal);
                while (Dr.Read())
                {
                    Resultado.Existencia = !Dr.IsDBNull(Dr.GetOrdinal("Existencia")) ? Dr.GetInt32(Dr.GetOrdinal("Existencia")) : 0;
                }
                Dr.Close();
                return Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ACMobiliarioResguardo(MobiliarioResguardo Datos)
        {
            try
            {
                int Resultado = 0;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_ac_MobiliarioResguardo",
                     new SqlParameter("@NuevoRegistro", Datos.NuevoRegistro),
                     new SqlParameter("@IDMobiliarioResguardo", Datos.IDMobiliarioResguardo),
                     new SqlParameter("@IDSucursal", Datos.IDSucursal),
                     new SqlParameter("@IDSucursalEquipo", Datos.IDSucursalEquipo),
                     new SqlParameter("@TablaMobiliarioResguardo", Datos.TablaMobiliarioResguardo),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                while (Dr.Read())
                {
                    Resultado = !Dr.IsDBNull(Dr.GetOrdinal("Resultado")) ? Dr.GetInt32(Dr.GetOrdinal("Resultado")) : 0;
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.IDMobiliarioResguardo = Dr.GetString(Dr.GetOrdinal("IDMobiliarioResguardo"));
                    }
                    else
                    {
                        Datos.Completado = false;
                        Datos.Resultado = Resultado;
                        Datos.MensajeError = Dr.GetString(Dr.GetOrdinal("Mensaje"));
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

        public void ObtenerCatMobiliarioResguardo(MobiliarioResguardo Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_MobiliarioReguardo", Datos.BuscarTodos);
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

        public void EliminarMobiliarioResguardo(MobiliarioResguardo Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_del_EliminarMobiliarioResguardo", Datos.IDMobiliarioResguardo, Datos.IDUsuario);
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

        public List<MobiliarioResguardo> ObtenerDetalleMobiliarioResguardo(MobiliarioResguardo Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDMobiliarioResguardo };
                List<MobiliarioResguardo> Lista = new List<MobiliarioResguardo>();
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_Mobiliario_Detalle", Parametros);
                MobiliarioResguardo Item;
                while (Dr.Read())
                {
                    Item = new MobiliarioResguardo();
                    Item.IDMobiliarioResguardo = Dr.GetString(Dr.GetOrdinal("IDMobiliarioResguardo"));
                    Item.IDSucursal = Dr.GetString(Dr.GetOrdinal("IDSucursal"));
                    Item.IDStatusMobiliario = Dr.GetInt32(Dr.GetOrdinal("Estatus"));
                    Item.IDMobiliarioDetalle = Dr.GetString(Dr.GetOrdinal("IDMobiliarioDetalle"));
                    Item.IDMobiliario = Dr.GetString(Dr.GetOrdinal("IDMobiliario"));
                    Item.Codigo = Dr.GetString(Dr.GetOrdinal("Codigo"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.Marca = Dr.GetString(Dr.GetOrdinal("Marca"));
                    Item.Modelo = Dr.GetString(Dr.GetOrdinal("Modelo"));
                    Item.Cantidad = Dr.GetInt32(Dr.GetOrdinal("Cantidad"));
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

        public MobiliarioResguardo ObtenerDetalleMobiliarios(MobiliarioResguardo Datos)
        {
            try
            {
                MobiliarioResguardo DatosGuardados = new MobiliarioResguardo();
                DatosGuardados.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_Mobiliario_Detalle", Datos.IDMobiliarioResguardo);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        if (Ds.Tables[0] != null)
                        {
                            DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                            while (Dr.Read())
                            {
                                DatosGuardados.IDMobiliarioResguardo = Datos.IDMobiliarioResguardo;
                                DatosGuardados.IDSucursal = !Dr.IsDBNull(Dr.GetOrdinal("IDSucursal")) ? Dr.GetString(Dr.GetOrdinal("IDSucursal")) : string.Empty;
                                DatosGuardados.IDStatusMobiliario = (int)(!Dr.IsDBNull(Dr.GetOrdinal("Estatus")) ? Dr.GetInt32(Dr.GetOrdinal("Estatus")) : 0);
                            }
                            Dr.Close();
                        }
                        if (Ds.Tables[1] != null)
                        {
                            List<MobiliarioResguardo> Lista = new List<MobiliarioResguardo>();
                            MobiliarioResguardo Item;
                            DataTableReader Dr = Ds.Tables[1].CreateDataReader();
                            while (Dr.Read())
                            {
                                Item = new MobiliarioResguardo();
                                Item.IDMobiliarioDetalle = !Dr.IsDBNull(Dr.GetOrdinal("IDMobiliarioDetalle")) ? Dr.GetString(Dr.GetOrdinal("IDMobiliarioDetalle")) : string.Empty;
                                Item.IDMobiliario = !Dr.IsDBNull(Dr.GetOrdinal("IDMobiliario")) ? Dr.GetString(Dr.GetOrdinal("IDMobiliario")) : string.Empty;
                                Item.Codigo = !Dr.IsDBNull(Dr.GetOrdinal("Codigo")) ? Dr.GetString(Dr.GetOrdinal("Codigo")) : string.Empty;
                                Item.Descripcion = !Dr.IsDBNull(Dr.GetOrdinal("Descripcion")) ? Dr.GetString(Dr.GetOrdinal("Descripcion")) : string.Empty;
                                Item.Marca = !Dr.IsDBNull(Dr.GetOrdinal("Marca")) ? Dr.GetString(Dr.GetOrdinal("Marca")) : string.Empty;
                                Item.Modelo = !Dr.IsDBNull(Dr.GetOrdinal("Modelo")) ? Dr.GetString(Dr.GetOrdinal("Modelo")) : string.Empty;
                                Item.Cantidad = (int)(!Dr.IsDBNull(Dr.GetOrdinal("Cantidad")) ? Dr.GetInt32(Dr.GetOrdinal("Cantidad")) : 0);
                                Lista.Add(Item);
                            }
                            DatosGuardados.ListaMobiliarioDetalle = Lista;
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

        public void EnviarMobiliarioResguardo(MobiliarioResguardo Datos)
        {
            try
            {
               
                int Resultado = 0;
                SqlDataReader Ds = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_set_EnviarMobiliarioResguardo", Datos.IDMobiliarioResguardo, Datos.IDUsuario);
                while (Ds.Read())
                {
                    Resultado = !Ds.IsDBNull(Ds.GetOrdinal("Resultado")) ? Ds.GetInt32(Ds.GetOrdinal("Resultado")) : 0;
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                    else
                    {
                        Datos.Completado = false;
                        Datos.Resultado = Resultado;
                        Datos.IDMobiliarioResguardo = Ds.GetString(Ds.GetOrdinal("IDMobiliarioResguardo"));
                        Datos.Descripcion = Ds.GetString(Ds.GetOrdinal("Descripicon"));
                    }
                    break;
                }
                Ds.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatMobiliarioResguaardoBusqueda(MobiliarioResguardo Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_MobiliarioReguardoBusqueda", Datos.BuscarTodos, Datos.FolioResguardo);
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

        public List<Mobiliario> ObtenerMobiliarioResguardoDetalle(MobiliarioResguardo Datos)
        {
            try
            {
                List<Mobiliario> Lista = new List<Mobiliario>();
                Mobiliario Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_RptCartaResguardo", Datos.IDMobiliarioResguardo);
                while (Dr.Read())
                {
                    Item = new Mobiliario();
                    Item.TipoMobiliarioDescripcion = Dr.GetString(Dr.GetOrdinal("TipoMobiliarioDesc"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("MobiliarioDesc"));
                    Item.Marca = Dr.GetString(Dr.GetOrdinal("Marca"));
                    Item.Cantidad = Dr.GetInt32(Dr.GetOrdinal("Cantidad"));
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
