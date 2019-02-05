using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Data.SqlTypes;
using System.IO;

namespace CreativaSL.Dll.StephManager.Datos
{
    public class ActividadesOpcionesCheckList_Datos
    {
        public void ObtenerCatActividadOpcionesChechList(ActividadOpcionesCheckList Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatActividadesOpcionesChechList", Datos.BuscarTodos, Datos.IDCheckList);
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

        public void ABCActividadOpcionCheckList(ActividadOpcionesCheckList Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDActividadOpciones, Datos.Descripcion.ToUpper(), Datos.Valor, Datos.IDCheckList, Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_CatActividadOpcionesCheckList", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    int ID = 0;
                    if (int.TryParse(Resultado.ToString(), out ID))
                    {
                        if (ID > 0)
                        {
                            Datos.Completado = true;
                            Datos.IDActividadOpciones = ID;
                        }
                        else
                        {
                            Datos.Resultado = ID;
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
