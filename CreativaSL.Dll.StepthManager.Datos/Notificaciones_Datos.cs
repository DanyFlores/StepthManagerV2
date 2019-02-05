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
    public class Notificaciones_Datos
    {

        public int EnviarNotificacionIndividuales(Notificaciones datos)
        {
            try
            {
                int Resultado = 0;
                DataSet Ds = SqlHelper.ExecuteDataset(datos.Conexion, CommandType.StoredProcedure, "spCSLDB_abc_NotificacionesIndividualesGrupales",
                    //new SqlParameter("@Opcion", datos.Opcion),
                new SqlParameter("@IDNotificacion", datos.IDNotificaciones),
                new SqlParameter("@IDTipoNotificacion", datos.IDTipoNotificaciones),
                new SqlParameter("@IdNivelEntrega", datos.IDNivelEntrega),
                new SqlParameter("@NombreNotificacion", datos.NombreNotificaciones),
                new SqlParameter("@TextoNotificacion", datos.DescripcionNotificacion),
                new SqlParameter("@Descripcion", datos.Descripcion),
                new SqlParameter("@IndividualGrupo", datos.IndividualGrupo),
                new SqlParameter("@IDCliente", datos.IDCliente),
                new SqlParameter("@EnviarNotificacion", datos.EnviarNotificacion),
                new SqlParameter("@Usuario", datos.IDUsuario));
                if (Ds != null)
                {
                    if (Ds.Tables.Count > 0)
                    {
                        int.TryParse(Ds.Tables[0].Rows[0][0].ToString(), out Resultado);
                        if (Resultado == 1)
                        {
                            if (Ds.Tables.Count == 2)
                            {
                                datos.Completado = true;
                                datos.tablaNotificaciones = Ds.Tables[1];
                            }
                        }
                        else if (Resultado == -1)
                        {
                            if (Ds.Tables.Count == 2)
                            {
                                datos.Completado = false;
                                datos.tablaNotificaciones = Ds.Tables[1];
                            }
                            datos.Resultado = Resultado;
                        }
                        else if (Resultado == 0)
                        {
                            if (Ds.Tables.Count == 2)
                            {
                                datos.Completado = false;
                                datos.tablaNotificaciones = Ds.Tables[1];
                            }
                            datos.Resultado = Resultado;
                        }
                    }
                }
                return datos.Resultado = Resultado;
                //datos.tablaNotificaciones = dt.Tables[1];
                //datos.Completado = true;
                //return Convert.ToInt32(dt.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerNotificaciones(Notificaciones Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_Notificaciones", Datos.Todos);
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
        public void ObtenerNotificacionesBusqueda(Notificaciones Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_NotificacionesBusqueda", Datos.Todos, Datos.BusqFechas, Datos.BusqNotificaciones,
                                                      Datos.Descripcion, Datos.FechaBusq, Datos.FechaBusq2);
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

        public void EliminarNotificaciones(Notificaciones Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_del_NotificacionesEliminar", Datos.IDNotificaciones, Datos.IDUsuario);
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

        public void ObtenerReenvioNotificaciones(Notificaciones Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_NotificacionReenviar", Datos.IDNotificaciones, Datos.IDUsuario);
                Datos.TablaDatos = new DataTable();
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                        Datos.tablaNotificaciones = Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
