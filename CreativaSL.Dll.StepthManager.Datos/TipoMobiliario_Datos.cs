using CreativaSL.Dll.StephManager.Global;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Datos
{
    public class TipoMobiliario_Datos
    {

        public List<TipoMobiliario> LlenarComboTipoMobiliario(TipoMobiliario Datos)
        {
            try
            {
                List<TipoMobiliario> Lista = new List<TipoMobiliario>();
                TipoMobiliario Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboMoviliario_Tipo", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new TipoMobiliario();
                    Item.IDTipoMobiliario = !Dr.IsDBNull(Dr.GetOrdinal("IDTipoMobiliario")) ? Dr.GetString(Dr.GetOrdinal("IDTipoMobiliario")) : string.Empty;
                    Item.Descripcion = !Dr.IsDBNull(Dr.GetOrdinal("TipoMobiliario")) ? Dr.GetString(Dr.GetOrdinal("TipoMobiliario")) : string.Empty;
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
