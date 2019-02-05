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
    public class Promocion_Datos
    {
        public List<Promocion> ObtenerPromociones(string Conexion, string Busqueda)
        {
            try
            {
                List<Promocion> Lista = new List<Promocion>();
                Promocion Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Produccion.spCSLDB_get_Promociones", Busqueda);
                while (Dr.Read())
                {
                    Item = new Promocion();
                    Item.IDPromocion = !Dr.IsDBNull(Dr.GetOrdinal("IDPromocion")) ? Dr.GetInt32(Dr.GetOrdinal("IDPromocion")) : 0;
                    Item.NombrePromocion = !Dr.IsDBNull(Dr.GetOrdinal("NombrePromocion")) ? Dr.GetString(Dr.GetOrdinal("NombrePromocion")) : string.Empty;
                    Item.IDEstatus = !Dr.IsDBNull(Dr.GetOrdinal("IDEstatus")) ? Dr.GetInt32(Dr.GetOrdinal("IDEstatus")) : 0;
                    Item.Estatus = !Dr.IsDBNull(Dr.GetOrdinal("Estatus")) ? Dr.GetString(Dr.GetOrdinal("Estatus")) : string.Empty;
                    Item.Dias = !Dr.IsDBNull(Dr.GetOrdinal("DiasSemana")) ? Dr.GetString(Dr.GetOrdinal("DiasSemana")) : string.Empty;
                    Item.Sucursales = !Dr.IsDBNull(Dr.GetOrdinal("Sucursales")) ? Dr.GetString(Dr.GetOrdinal("Sucursales")) : string.Empty;
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

        public Promocion ObtenerDetallePromocion(string Conexion, int IDPromocion)
        {
            try
            {
                Promocion Resultado = new Promocion();
                DataSet Ds = SqlHelper.ExecuteDataset(Conexion, "Produccion.spCSLDB_get_DetallePromocionModificar", IDPromocion);
                if(Ds != null)
                {
                    if(Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while(Dr.Read())
                        {
                            Resultado.IDPromocion = IDPromocion;
                            Resultado.NombrePromocion = !Dr.IsDBNull(Dr.GetOrdinal("NombreProducto")) ? Dr.GetString(Dr.GetOrdinal("NombreProducto")) : string.Empty;
                            Resultado.Lunes = !Dr.IsDBNull(Dr.GetOrdinal("Lunes")) ? Dr.GetBoolean(Dr.GetOrdinal("Lunes")) : false;
                            Resultado.Martes = !Dr.IsDBNull(Dr.GetOrdinal("Martes")) ? Dr.GetBoolean(Dr.GetOrdinal("Martes")) : false;
                            Resultado.Miercoles = !Dr.IsDBNull(Dr.GetOrdinal("Miercoles")) ? Dr.GetBoolean(Dr.GetOrdinal("Miercoles")) : false;
                            Resultado.Jueves = !Dr.IsDBNull(Dr.GetOrdinal("Jueves")) ? Dr.GetBoolean(Dr.GetOrdinal("Jueves")) : false;
                            Resultado.Viernes = !Dr.IsDBNull(Dr.GetOrdinal("Viernes")) ? Dr.GetBoolean(Dr.GetOrdinal("Viernes")) : false;
                            Resultado.Sabado = !Dr.IsDBNull(Dr.GetOrdinal("Sabado")) ? Dr.GetBoolean(Dr.GetOrdinal("Sabado")) : false;
                            Resultado.Domingo = !Dr.IsDBNull(Dr.GetOrdinal("Domingo")) ? Dr.GetBoolean(Dr.GetOrdinal("Domingo")) : false;
                        }
                        Dr.Close();

                        List<Sucursal> Lista = new List<Sucursal>();
                        Sucursal Item;
                        DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        while (Dr2.Read())
                        {
                            Item = new Sucursal();
                            Item.IDSucursal = !Dr2.IsDBNull(Dr2.GetOrdinal("IDSucursal")) ? Dr2.GetString(Dr2.GetOrdinal("IDSucursal")) : string.Empty;
                            Item.NombreSucursal = !Dr2.IsDBNull(Dr2.GetOrdinal("NombreSucursal")) ? Dr2.GetString(Dr2.GetOrdinal("NombreSucursal")) : string.Empty;
                            Item.Seleccionado = !Dr2.IsDBNull(Dr2.GetOrdinal("Seleccionado")) ? Dr2.GetBoolean(Dr2.GetOrdinal("Seleccionado")) : false;
                            Lista.Add(Item);
                        }
                        Dr2.Close();
                        Resultado.ListaSucursales = Lista;
                    }
                }
                return Resultado;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Sucursal> ObtenerSucursalesPromocion(string Conexion)
        {
            try
            {
                List<Sucursal> Lista = new List<Sucursal>();
                Sucursal Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Produccion.spCSLDB_get_SucursalesPromocion");
                while(Dr.Read())
                {
                    Item = new Sucursal();
                    Item.IDSucursal = !Dr.IsDBNull(Dr.GetOrdinal("IDSucursal")) ? Dr.GetString(Dr.GetOrdinal("IDSucursal")) : string.Empty;
                    Item.NombreSucursal = !Dr.IsDBNull(Dr.GetOrdinal("NombreSucursal")) ? Dr.GetString(Dr.GetOrdinal("NombreSucursal")) : string.Empty;
                    Item.Seleccionado = !Dr.IsDBNull(Dr.GetOrdinal("Seleccionado")) ? Dr.GetBoolean(Dr.GetOrdinal("Seleccionado")) : false;
                    Lista.Add(Item);
                }
                Dr.Close();
                return Lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarPromocion(string Conexion, int IDPromocion, string IDUsuario)
        {
            try
            {
                object[] Parametros = { IDPromocion, IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Conexion, "Produccion.spCSLDB_del_EliminarPromocion", Parametros);
                if(Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    return (Resultado == 1);
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool CambiarEstatusPromocion(string Conexion, int IDPromocion, string IDUsuario)
        {
            try
            {
                object[] Parametros = { IDPromocion, IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Conexion, "Produccion.spCSLDB_set_CambiarEstatusPromocion", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    return (Resultado == 1);
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ModificarPromocion(string Conexion, Promocion Datos, string IDUsuario)
        {
            try
            {
                object Result = SqlHelper.ExecuteScalar(Conexion, CommandType.StoredProcedure, "Produccion.spCSLDB_c_Promocion",
                    new SqlParameter("@IDPromocion", Datos.IDPromocion), new SqlParameter("@NombrePromo", Datos.NombrePromocion), new SqlParameter("@Lunes", Datos.Lunes),
                    new SqlParameter("@Martes", Datos.Martes), new SqlParameter("@Miercoles", Datos.Miercoles), new SqlParameter("@Jueves", Datos.Jueves),
                    new SqlParameter("@Viernes", Datos.Viernes), new SqlParameter("@Sabado", Datos.Sabado), new SqlParameter("@Domingo", Datos.Domingo), 
                    new SqlParameter("@TablaSucursal", Datos.TablaSucursales), new SqlParameter("@IDUsuario", IDUsuario));
                int Resultado = 0;
                if(Result != null)
                {
                    int.TryParse(Result.ToString(), out Resultado);
                }
                return Resultado;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int AgregarPromocion(string Conexion, Promocion Datos, string IDUsuario)
        {
            try
            {
                object Result = SqlHelper.ExecuteScalar(Conexion, CommandType.StoredProcedure, "Produccion.spCSLDB_ac_Promociones",
                    new SqlParameter("@NombrePromo", Datos.NombrePromocion), new SqlParameter("@Lunes", Datos.Lunes),
                    new SqlParameter("@Martes", Datos.Martes), new SqlParameter("@Miercoles", Datos.Miercoles), new SqlParameter("@Jueves", Datos.Jueves),
                    new SqlParameter("@Viernes", Datos.Viernes), new SqlParameter("@Sabado", Datos.Sabado), new SqlParameter("@Domingo", Datos.Domingo),
                    new SqlParameter("@TablaServicios", Datos.TablaServicios), new SqlParameter("@TablaSucursal", Datos.TablaSucursales), new SqlParameter("@IDUsuario", IDUsuario));
                int Resultado = 0;
                if (Result != null)
                {
                    int.TryParse(Result.ToString(), out Resultado);
                }
                return Resultado;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<PromocionXSucursal> ObtenerPreciosXSucursalPromocion(string Conexion, int IDPromocion)
        {
            try
            {
                List<PromocionXSucursal> Lista = new List<PromocionXSucursal>();
                PromocionXSucursal Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Produccion.spCSLDB_get_PrecioSucursalesXIDPromocion", IDPromocion);
                while(Dr.Read())
                {
                    Item = new PromocionXSucursal();
                    Item.IDSucursal = !Dr.IsDBNull(Dr.GetOrdinal("IDSucursal")) ? Dr.GetString(Dr.GetOrdinal("IDSucursal")) : string.Empty;
                    Item.NombreSucursal = !Dr.IsDBNull(Dr.GetOrdinal("NombreSucursal")) ? Dr.GetString(Dr.GetOrdinal("NombreSucursal")) : string.Empty;
                    Item.Precio = !Dr.IsDBNull(Dr.GetOrdinal("Precio")) ? Dr.GetDecimal(Dr.GetOrdinal("Precio")) : 0;
                    Lista.Add(Item);
                }
                Dr.Close();
                return Lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<PromocionServicios> ObtenerPreciosServicioXIDSucIDPromocion(string Conexion, int IDPromocion, string IDSucursal)
        {
            try
            {
                List<PromocionServicios> Lista = new List<PromocionServicios>();
                PromocionServicios Item;
                object[] Parametros = { IDPromocion, IDSucursal };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Produccion.spCSLDB_get_PreciosXSucursalPromocion", Parametros);
                while (Dr.Read())
                {
                    Item = new PromocionServicios();
                    Item.IDPromocionDetalle = !Dr.IsDBNull(Dr.GetOrdinal("IDPromocionDetalle")) ? Dr.GetInt32(Dr.GetOrdinal("IDPromocionDetalle")) : 0;
                    Item.IDServicio = !Dr.IsDBNull(Dr.GetOrdinal("IDServicio")) ? Dr.GetString(Dr.GetOrdinal("IDServicio")) : string.Empty;
                    Item.Servicio = !Dr.IsDBNull(Dr.GetOrdinal("NombreServicio")) ? Dr.GetString(Dr.GetOrdinal("NombreServicio")) : string.Empty;
                    Item.Precio = !Dr.IsDBNull(Dr.GetOrdinal("Precio")) ? Dr.GetDecimal(Dr.GetOrdinal("Precio")) : 0;
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

        public int ActualizarPreciosXIDPromocionXIDSucursal(string Conexion, PromocionXSucursal Datos, string IDUsuario)
        {
            try
            {
                object Result = SqlHelper.ExecuteScalar(Conexion, CommandType.StoredProcedure, "Produccion.spCSLDB_set_PrecioXSucursalPromocion",
                                new SqlParameter("@IDPromocion", Datos.IDPromocion), new SqlParameter("@IDSucursal", Datos.IDSucursal),
                                new SqlParameter("@TablaPrecios", Datos.TablaPrecios), new SqlParameter("@IDUsuario", IDUsuario));
                int Resultado = 0;
                if(Result != null)
                {
                    int.TryParse(Result.ToString(), out Resultado);
                }
                return Resultado;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
