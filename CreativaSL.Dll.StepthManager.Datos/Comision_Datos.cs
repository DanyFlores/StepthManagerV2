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
    public class Comision_Datos
    {
        public List<Comision> ObtenerComisionesXIDCategoria(Comision Datos)
        {
            try
            {
                List<Comision> Lista = new List<Comision>();
                Comision Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ReglasComisionXIDCategoria", Datos.IDCategoria);
                while (Dr.Read())
                {
                    Item = new Comision();
                    Item.IDComisionXCategoria = Dr.GetString(Dr.GetOrdinal("IDComisionXCat"));
                    Item.IDProducto = Dr.GetString(Dr.GetOrdinal("IDProducto"));
                    Item.ProductoDesc = Dr.GetString(Dr.GetOrdinal("NombreProducto"));
                    Item.IDTipoComision = Dr.GetInt32(Dr.GetOrdinal("IDTipoComision"));
                    Item.TipoComisionDesc = Dr.GetString(Dr.GetOrdinal("TipoComision"));
                    Item.EsPorcentaje = Dr.GetBoolean(Dr.GetOrdinal("EsPorcentaje"));
                    Item.Porcentaje = Dr.GetDecimal(Dr.GetOrdinal("Porcentaje"));
                    Item.Monto = Dr.GetDecimal(Dr.GetOrdinal("Monto"));
                    Item.IDCategoria = Dr.GetString(Dr.GetOrdinal("IDCategoria"));
                    Item.CategoriaDesc = Dr.GetString(Dr.GetOrdinal("CategoriaDesc"));
                    Item.IDPuesto = Dr.GetInt32(Dr.GetOrdinal("IDPuesto"));
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

        public List<Comision> ObtenerComisionesXEmpleado(Comision Datos)
        {
            try
            {
                List<Comision> Lista = new List<Comision>();
                Comision Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ReglasComisionXNombreEmpleado", Datos.NombreEmpleado);
                while (Dr.Read())
                {
                    Item = new Comision();
                    Item.IDComisionXCategoria = Dr.GetString(Dr.GetOrdinal("IDComisionXCat"));
                    Item.IDProducto = Dr.GetString(Dr.GetOrdinal("IDProducto"));
                    Item.ProductoDesc = Dr.GetString(Dr.GetOrdinal("NombreProducto"));
                    Item.IDEmpleado = Dr.GetString(Dr.GetOrdinal("IDEmpleado"));
                    Item.NombreEmpleado = Dr.GetString(Dr.GetOrdinal("NombreEmpledo"));
                    Item.IDTipoComision = Dr.GetInt32(Dr.GetOrdinal("IDTipoComision"));
                    Item.TipoComisionDesc = Dr.GetString(Dr.GetOrdinal("TipoComision"));
                    Item.EsPorcentaje = Dr.GetBoolean(Dr.GetOrdinal("EsPorcentaje"));
                    Item.Porcentaje = Dr.GetDecimal(Dr.GetOrdinal("Porcentaje"));
                    Item.Monto = Dr.GetDecimal(Dr.GetOrdinal("Monto"));
                    Item.IDCategoria = Dr.GetString(Dr.GetOrdinal("IDCategoria"));
                    Item.CategoriaDesc = Dr.GetString(Dr.GetOrdinal("CategoriaDesc"));
                    Item.IDPuesto = Dr.GetInt32(Dr.GetOrdinal("IDPuesto"));
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

        public List<Comision> ObtenerComboTipoComision(Comision Datos)
        {
            try
            {
                List<Comision> Lista = new List<Comision>();
                Comision Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboTipoComision", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new Comision();
                    Item.IDTipoComision = Dr.GetInt32(Dr.GetOrdinal("IDTipoComision"));
                    Item.TipoComisionDesc = Dr.GetString(Dr.GetOrdinal("TipoComisionDesc"));                    
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

        public void ACReglasComision(Comision Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDComisionXCategoria, Datos.EsPorcentaje, Datos.IDCategoria,
                                        Datos.IDProducto, Datos.IDTipoComision, Datos.Monto, Datos.Porcentaje, Datos.IDUsuario};
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_ac_ReglasComision", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                    Datos.Resultado = Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarReglasComision(Comision Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDComisionXCategoria, Datos.IDUsuario};
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_del_ReglaComision", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                    Datos.Resultado = Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void ObtenerResumenComisiones(Comision Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ResumenComision", Datos.BuscarTodos);
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

        public void ObtenerResumenComisionesBusq(Comision Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ResumenComisionBusq", Datos.Folio);
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

        public void ObtenerComisionesXRango(Comision Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ComisionesPorRango", Datos.IDSucursal, Datos.FechaInicio, Datos.FechaFin);
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

        public void AResumenComision(Comision Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_set_ResumenComisiones",
                     new SqlParameter("@IDSucursal", Datos.IDSucursal),
                     new SqlParameter("@FechaInicio", Datos.FechaInicio),
                     new SqlParameter("@FechaFin", Datos.FechaFin),
                     new SqlParameter("@TablaComision", Datos.TablaDatos),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                    Datos.Resultado = Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerReporteComisiones(Comision Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_RptComisiones", Datos.IDResumenComision);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 3)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Datos.Folio = Dr.GetString(Dr.GetOrdinal("Folio"));
                            Datos.IDSucursal = Dr.GetString(Dr.GetOrdinal("NombreSucursal"));
                            Datos.FechaInicio = Dr.GetDateTime(Dr.GetOrdinal("FechaInicio"));
                            Datos.FechaFin = Dr.GetDateTime(Dr.GetOrdinal("FechaFin"));
                        }
                        Dr.Close();

                        List<Comision> Lista01 = new List<Comision>();
                        Comision Item01;
                        DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        while (Dr2.Read())
                        {
                            Item01 = new Comision();
                            Item01.FechaInicio = Dr2.GetDateTime(Dr2.GetOrdinal("Fecha"));
                            Item01.NombreEmpleado = Dr2.GetString(Dr2.GetOrdinal("Nombre"));
                            Item01.Total = Dr2.GetDecimal(Dr2.GetOrdinal("TotalVenta"));
                            Item01.Monto = Dr2.GetDecimal(Dr2.GetOrdinal("Total"));
                            Lista01.Add(Item01);
                        }
                        Dr2.Close();
                        Datos.ListaComisiones = Lista01;

                        List<Comision> Lista02 = new List<Comision>();
                        Comision Item02;
                        DataTableReader Dr3 = Ds.Tables[2].CreateDataReader();
                        while (Dr3.Read())
                        {
                            Item02 = new Comision();
                            Item02.TipoComisionDesc = Dr3.GetString(Dr3.GetOrdinal("TipoComision"));
                            Item02.Monto = Dr3.GetDecimal(Dr3.GetOrdinal("Total"));
                            Lista02.Add(Item02);
                        }
                        Datos.ListaTiposComision = Lista02;
                        Dr3.Close();
                        Datos.Completado = true;
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
