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
    public class CheckListResultado_Datos
    {
        public void ObtenerCatChechListResul(ChechkListResultado Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatChechListResultado", Datos.BuscarTodos, Datos.IDCheckList);
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

        public List<ChechkListResultado> ObtenerCheckListDetalle(ChechkListResultado Datos)
        {
            try
            {
                List<ChechkListResultado> Lista = new List<ChechkListResultado>();
                ChechkListResultado Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_CheckListRespuesta", Datos.IDResultado, Datos.IDCheckList);

                while (Dr.Read())
                {
                    Item = new ChechkListResultado();
                    Item.IDCheckList = Dr.GetString(Dr.GetOrdinal("IDCheckList"));
                    Item.IDActvidadCheck = Dr.GetInt32(Dr.GetOrdinal("IDActividadCheck"));
                    Item.IDCategoriaCheck = Dr.GetInt32(Dr.GetOrdinal("IDCategoriaCheck"));
                    Item.IDActividadOpciones = Dr.GetInt32(Dr.GetOrdinal("IDActividadOpciones"));
                    Item.IDOpcionSeleccionado = Dr.GetInt32(Dr.GetOrdinal("IDOpcionSeleccionada"));
                    Item.NombreActividad = Dr.GetString(Dr.GetOrdinal("NombreActividad"));
                    Item.OrdenActividad = Dr.GetInt32(Dr.GetOrdinal("OrdenActividad"));
                    Item.NombreCategoria = Dr.GetString(Dr.GetOrdinal("NombreCategoria"));
                    Item.OrdenCategoria = Dr.GetInt32(Dr.GetOrdinal("OrdenCategoria"));
                    Item.Responsable = Dr.GetString(Dr.GetOrdinal("OpcionDesc"));
                    Item.Observaciones = Dr.GetString(Dr.GetOrdinal("Observaciones"));
                    Item.Seguimiento = Dr.GetString(Dr.GetOrdinal("Seguimiento"));
                    long Aux = Dr.GetInt64(Dr.GetOrdinal("NumFila"));
                    Item.Titulo = Aux.ToString();
                    Item.Opcion = (int)Aux;
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

        public List<ChechkListResultado> ObtenerCheckListDetalleActivadad(ChechkListResultado Datos)
        {
            try
            {
                List<ChechkListResultado> Lista = new List<ChechkListResultado>();
                ChechkListResultado Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_CheckListActividadDetalle", Datos.IDCheckList);

                while (Dr.Read())
                {
                    Item = new ChechkListResultado();
                    Item.IDCheckList = Dr.GetString(Dr.GetOrdinal("IDCheckList"));
                    Item.IDActvidadCheck = Dr.GetInt32(Dr.GetOrdinal("IDActividadCheck"));
                    Item.IDCategoriaCheck = Dr.GetInt32(Dr.GetOrdinal("IDCategoriaCheck"));
                    Item.IDActividadOpciones = Dr.GetInt32(Dr.GetOrdinal("IDActividadOpciones"));
                    Item.NombreActividad = Dr.GetString(Dr.GetOrdinal("NombreActividad"));
                    Item.OrdenActividad = Dr.GetInt32(Dr.GetOrdinal("OrdenActividad"));
                    Item.NombreCategoria = Dr.GetString(Dr.GetOrdinal("NombreCategoria"));
                    Item.OrdenCategoria = Dr.GetInt32(Dr.GetOrdinal("OrdenCategoria"));
                    Item.Responsable = Dr.GetString(Dr.GetOrdinal("OpcionDesc"));
                    long Aux = Dr.GetInt64(Dr.GetOrdinal("NumFila"));
                    Item.Titulo = Aux.ToString();
                    Item.Opcion = (int)Aux;
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
