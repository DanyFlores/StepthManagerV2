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
    public class TipoUsuario_Datos
    {

        public void ObtenerPermisosXTipoUsuario(TipoUsuario Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_PermisiosXIDTipoUsuario", Datos.IDTipoUsuario);
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                        Datos.TablaDatos = Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarPermisosXIDUsuario(TipoUsuario Datos)
        {
            try
            {
                //object[] Parametros = { Datos.IDEmpleado, Datos.TablaDatos, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_set_PermisosXIDTIpoUsuario",
                     new SqlParameter("@Opcion", Datos.Opcion),
                     new SqlParameter("@IDTipoUsuario", Datos.IDTipoUsuario),
                     new SqlParameter("@Descripcion", Datos.Descripcion),
                     new SqlParameter("@Tabla", Datos.TablaDatos),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario));
                if (Result != null)
                {
                    int IDRegistro = 0;
                    if (int.TryParse(Result.ToString(), out IDRegistro))
                    {
                        if (IDRegistro > 0)
                        {
                            Datos.Completado = true;
                            Datos.IDTipoUsuario = IDRegistro;
                        }
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
