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
    public class Sucursal_Datos
    {
        public List<Sucursal> LlenarComboCatSucursales(Sucursal Datos)
        {
            try
            {
                List<Sucursal> Lista = new List<Sucursal>();
                Sucursal Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboCatSucursales", Datos.Opcion);
                while (Dr.Read())
                {
                    Item = new Sucursal();
                    Item.IDSucursal = Dr.IsDBNull(Dr.GetOrdinal("IDSucursal")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDSucursal"));
                    Item.NombreSucursal = Dr.IsDBNull(Dr.GetOrdinal("NombreSucursal")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("NombreSucursal"));
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

        public List<Sucursal> LlenarComboCatSucursalesPuntoDeVenta(Sucursal Datos)
        {
            try
            {
                List<Sucursal> Lista = new List<Sucursal>();
                Sucursal Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboCatSucursalesPV", Datos.Opcion);
                while (Dr.Read())
                {
                    Item = new Sucursal();
                    Item.IDSucursal = Dr.IsDBNull(Dr.GetOrdinal("IDSucursal")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDSucursal"));
                    Item.NombreSucursal = Dr.IsDBNull(Dr.GetOrdinal("NombreSucursal")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("NombreSucursal"));
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
