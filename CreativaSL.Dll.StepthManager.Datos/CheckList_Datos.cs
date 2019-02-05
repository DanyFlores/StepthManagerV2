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
    public class CheckList_Datos
    {
        public List<TipoChechkList> LlenarComboTipoCheckList(TipoChechkList Datos)
        {
            try
            {
                List<TipoChechkList> Lista = new List<TipoChechkList>();
                TipoChechkList Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboTipoCheckList", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new TipoChechkList();
                    Item.IDTipoCheckList = Dr.IsDBNull(Dr.GetOrdinal("IDTipoChechList")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDTipoChechList"));
                    Item.Descripcion = Dr.IsDBNull(Dr.GetOrdinal("Descripcion")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Descripcion"));
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

        public void ObtenerCatChechList(ChechkList Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatChechList", Datos.BuscarTodos);
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

        public void ObtenerCheckListBusqueda(ChechkList Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatChechListBusqueda", Datos.BuscarTodos, Datos.Titulo);
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

        public void ABCCheckList(ChechkList Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDCheckList, Datos.Titulo.ToUpper(), Datos.IDTipoCheckList, Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_CatCheCkList", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    if (!string.IsNullOrEmpty(Resultado.ToString()))
                    {
                        Datos.Completado = true;
                        Datos.IDCheckList = Resultado.ToString();
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
