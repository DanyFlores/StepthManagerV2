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
    public class Proveedor_Datos
    {

        public List<Proveedor> LlenarComboProveedores(Proveedor Datos)
        {
            try
            {
                List<Proveedor> Lista = new List<Proveedor>();
                Proveedor Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboCatProveedores", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new Proveedor();
                    Item.IDProveedor = !Dr.IsDBNull(Dr.GetOrdinal("IDProveedor")) ? Dr.GetString(Dr.GetOrdinal("IDProveedor")) : string.Empty;
                    Item.NombreComercial = !Dr.IsDBNull(Dr.GetOrdinal("NombreComercial")) ? Dr.GetString(Dr.GetOrdinal("NombreComercial")) : string.Empty;
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
        
        public List<Proveedor> LlenarComboProveedoresMobiliario(Proveedor Datos)
        {
            try
            {
                List<Proveedor> Lista = new List<Proveedor>();
                Proveedor Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboCatProveedoresMobiliario", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new Proveedor();
                    Item.IDProveedor = !Dr.IsDBNull(Dr.GetOrdinal("IDProveedor")) ? Dr.GetString(Dr.GetOrdinal("IDProveedor")) : string.Empty;
                    Item.NombreComercial = !Dr.IsDBNull(Dr.GetOrdinal("NombreComercial")) ? Dr.GetString(Dr.GetOrdinal("NombreComercial")) : string.Empty;
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
        public void ObtenerDatosFiscalesXProveedor(Proveedor Datos)
        {
            try
            {
                Datos.Completado = false;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_DatosFiscalesXIDProveedor", Datos.IDProveedor);
                while (Dr.Read())
                {
                    if (!Datos.Completado)
                    {
                        Datos.RFC = !Dr.IsDBNull(Dr.GetOrdinal("RFC")) ? Dr.GetString(Dr.GetOrdinal("RFC")) : string.Empty;
                        Datos.Direccion = !Dr.IsDBNull(Dr.GetOrdinal("DomicilioFiscal")) ? Dr.GetString(Dr.GetOrdinal("DomicilioFiscal")) : string.Empty;
                        Datos.RazonSocial = !Dr.IsDBNull(Dr.GetOrdinal("RazonSocial")) ? Dr.GetString(Dr.GetOrdinal("RazonSocial")) : string.Empty;
                        Datos.RegimenFiscal = !Dr.IsDBNull(Dr.GetOrdinal("RegimenFiscal")) ? Dr.GetString(Dr.GetOrdinal("RegimenFiscal")) : string.Empty;
                        Datos.Completado = true;
                        break;
                    }
                }
                Dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
