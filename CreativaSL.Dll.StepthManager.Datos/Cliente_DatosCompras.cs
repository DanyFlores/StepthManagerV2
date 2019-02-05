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
    public class Cliente_DatosCompras
    {
        public List<Cliente> ObtenerComboClientes(Cliente Datos)
        {
            try
            {
                List<Cliente> Lista = new List<Cliente>();
                Cliente Item;
                SqlDataReader dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboCatClientes", Datos.IncluirSelect);

                while (dr.Read())
                {
                    Item = new Cliente();
                    Item.IDCliente = !dr.IsDBNull(dr.GetOrdinal("IDCliente")) ? dr.GetString(dr.GetOrdinal("IDCliente")) : string.Empty;
                    Item.Nombre = !dr.IsDBNull(dr.GetOrdinal("Nombre")) ? dr.GetString(dr.GetOrdinal("Nombre")).ToUpper() : string.Empty;
                    Lista.Add(Item);
                }
                dr.Close();
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
