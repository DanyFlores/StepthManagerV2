using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSL.Dll.StephManager.Datos
{
    public class Caja_Datos
    {
        public void AsignarCajaMac(Caja Datos)
        {
            try
            {
                Datos.Completado = false;
                object [] Parametros = { Datos.Opcion, Datos.IDCajaCat, Datos.Mac, Datos.NombreCaja, Datos.IDSucursal };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_CajaMac", Parametros);
                if (Resultado != null)
                {
                    int Result = 0;
                    if (int.TryParse(Resultado.ToString(), out Result))
                    {
                        Datos.Resultado = Result;
                        if (Datos.Resultado >= 1)
                        {
                            Datos.Completado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GuardarAperturaCaja(Caja Datos)
        {
            try
            {
                object [] Parametros = { Datos.IDCaja, Datos.IDCajaCat,
                                       Datos.IDSucursal, Datos.Apertura,
                                       Datos.IDUsuario};
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_AperturaCaja", Parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    int Aux = 0;
                    if (int.TryParse(Resultado.ToString(), out Aux))
                    {
                        if(Aux > 0)
                            Datos.Completado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Caja> LlenarComboCatCajas(Caja Datos)
        {
            try
            {
                List<Caja> Lista = new List<Caja>();
                Caja Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboCatCajas", Datos.Opcion);
                while (Dr.Read())
                {
                    Item = new Caja();
                    Item.IDCajaCat = Dr.IsDBNull(Dr.GetOrdinal("IDCajaCat")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDCajaCat"));
                    Item.CajaCat = Dr.IsDBNull(Dr.GetOrdinal("CajaCat")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("CajaCat"));
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
