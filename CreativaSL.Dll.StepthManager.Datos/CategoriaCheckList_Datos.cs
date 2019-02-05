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
    public class CategoriaCheckList_Datos
    {
        public List<CategoriaCheckList> LlenarComboCategoriaCheckList(CategoriaCheckList Datos)
        {
            try
            {
                List<CategoriaCheckList> Lista = new List<CategoriaCheckList>();
                CategoriaCheckList Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboCategoriaCheck", Datos.IncluirSelect, Datos.IDCheckList);
                while (Dr.Read())
                {
                    Item = new CategoriaCheckList();
                    Item.IDCategoriaChe = Dr.IsDBNull(Dr.GetOrdinal("IDCategoriaCheck")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDCategoriaCheck"));
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

        public void ABCCategoriaActividades(CategoriaCheckList Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDCategoriaChe, Datos.Descripcion.ToUpper(), Datos.IDCheckList, Datos.Orden, Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_CatCategoriaCheckListACT", parametros);
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
