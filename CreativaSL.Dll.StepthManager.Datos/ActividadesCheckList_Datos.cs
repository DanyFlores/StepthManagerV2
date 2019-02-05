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
    public class ActividadesCheckList_Datos
    {
        public void ObtenerCatActividadChechList(ActividadesCheckList Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatActividadesChechList", Datos.BuscarTodos, Datos.IDCheckList);
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
        public void ObtenerCheckListActividaBusqueda(ActividadesCheckList Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatActividadesChechListBusqueda", Datos.BuscarTodos, Datos.Descripcion, Datos.IDCheckList);
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

        public void ABCActividadCheckList(ActividadesCheckList Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDActividades, Datos.IDCategoriaChe, Datos.Orden, Datos.Descripcion.ToUpper(), Datos.IDCheckList, Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_CatActividadCheckList", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    int ID = 0;
                    if (int.TryParse(Resultado.ToString(), out ID))
                    {
                        if (ID > 0)
                        {
                            Datos.Completado = true;
                            Datos.IDCategoriaChe = ID;
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
