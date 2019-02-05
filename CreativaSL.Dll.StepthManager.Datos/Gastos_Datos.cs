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
    public class Gastos_Datos
    {
        public void ObtenerCatGastos(Gastos Datos)
        {
            try
            {
                Datos.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_GatosXIDSucursalXFechaMag", Datos.IDSucursal, Datos.FechaGasto);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        Datos.Completado = true;
                        Datos.TablaDatos = Ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Rubro> ObtenerComboRubros(Rubro Datos)
        {
            try
            {
                List<Rubro> Lista = new List<Rubro>();
                Rubro Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboCatRubros", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new Rubro();
                    Item.IDRubro = Dr.GetInt32(Dr.GetOrdinal("IDRubro"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
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

        public List<Subrubro> ObtenerComboSubrubros(Subrubro Datos)
        {
            try
            {
                List<Subrubro> Lista = new List<Subrubro>();
                Subrubro Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboCatSubrubros", Datos.IncluirSelect, Datos.IDRubro);
                while (Dr.Read())
                {
                    Item = new Subrubro();
                    Item.IDSubrubro = Dr.GetString(Dr.GetOrdinal("IDSubrubro"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
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

        public void ACCatGastos(Gastos Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.Opcion, Datos.IDGasto, Datos.IDSucursal, Datos.FechaGasto, Datos.Monto, Datos.IDRubro, Datos.IDSubrubro, Datos.Observaciones, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_Gastos", Parametros);
                if (Result != null)
                {
                    if (!string.IsNullOrEmpty(Result.ToString()))
                    {
                        Datos.Completado = true;
                        Datos.IDGasto = Result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarGasto(Gastos Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_del_CatGastosXIDGasto", Datos.IDGasto, Datos.IDUsuario);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
