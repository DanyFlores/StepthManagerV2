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
    public class NotificacionSistemas_Datos
    {
        public void ObtenerNotificaciones(NotificacionesSistemas Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_NotificacionesSistemas", Datos.IDSucursal);
                Datos.TablaNotificaciones = new DataTable();
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                        Datos.TablaNotificaciones = Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ActualizarNotificacionVisto(NotificacionesSistemas Datos)
        {
            try
            {
                object[] Parametro = { Datos.IDSucursal, Datos.Visto, Datos.IDTipoNotificacion, Datos.IDUsuario };
                SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_set_NotificacionesSistemaVisto", Parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
