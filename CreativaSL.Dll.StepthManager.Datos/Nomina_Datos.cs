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
    public class Nomina_Datos
    {

        public void ObtenerEmpleadosNomina(Nomina Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_EmpleadosNomina", Datos.IDTipoNomina);
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

        public void ObtenerConceptosNominaXIDEmpleado(Nomina Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ConceptosNomina", Datos.IDEmpleado, Datos.IDTipoNomina);
                Datos.TablaDatos = new DataTable();
                if (ds != null)
                {
                    if (ds.Tables.Count == 2)
                    {
                        Datos.TablaConceptosFijos = ds.Tables[0];
                        Datos.TablaConceptosVariables = ds.Tables[1];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerConceptosFijosXIDEmpleado(Nomina Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ConceptosFijosNomina", Datos.IDEmpleado, Datos.IDTipoNomina);
                Datos.TablaDatos = new DataTable();
                if (ds != null)
                {
                    if (ds.Tables.Count == 1)
                    {
                        Datos.TablaConceptosFijos = ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerConceptosVariablesXIDEmpleado(Nomina Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ConceptosVariablesNomina", Datos.IDEmpleado, Datos.IDTipoNomina);
                Datos.TablaDatos = new DataTable();
                if (ds != null)
                {
                    if (ds.Tables.Count == 1)
                    {
                        Datos.TablaConceptosVariables = ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Nomina> ObtenerComboConceptosNomina(Nomina Datos)
        {
            try
            {
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboConceptosNomina", Datos.IncluirSelect);
                List<Nomina> Lista = new List<Nomina>();
                Nomina Item;
                while (Dr.Read())
                {
                    Item = new Nomina();
                    Item.IDConcepto = Dr.GetInt32(Dr.GetOrdinal("IDConcepto"));
                    Item.ConceptoNomina = Dr.GetString(Dr.GetOrdinal("Concepto"));
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

        public void AgregarConceptoNomina(Nomina Datos)
        {
            try
            {
                object[] Parametros = { Datos.EsFijo, Datos.IDEmpleado, Datos.IDTipoNomina, Datos.IDConcepto, Datos.Monto, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_AgregarConcepto", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                    Datos.Resultado = Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void QuitarConceptoNomina(Nomina Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDConceptoNomina, Datos.EsFijo, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_QuitarConceptoNomina", Parametros);
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

        public void ObtenerNominas(Nomina Datos)
        {
            try
            {
                object[] Parametros = { Datos.EsBusqueda, Datos.BandBusqFechas, Datos.ClaveNomina, Datos.FechaInicio, Datos.FechaFin};
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ObtenerNominas", Parametros);
                if (Ds != null)
                {
                    if (Ds.Tables.Count > 0)
                    {
                        Datos.TablaDatos = Ds.Tables[0];
                        Datos.Completado = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GenerarNomina(Nomina Datos)
        {
            try
            {
                object[] Parametros = { Datos.FechaInicio, Datos.FechaFin, Datos.IDTipoNomina, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_GenerarNomina", Parametros);
                if (Result != null)
                {
                    //int Resultado = 0;
                    //int.TryParse(Result.ToString(), out Resultado);
                    //if(Resultado == 1)
                    //{
                    //    Datos.Completado = true;
                    //}
                    if(!string.IsNullOrEmpty(Result.ToString()))
                    {
                        Datos.Completado = true;
                        Datos.IDNomina = Result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerReporteNominaSaldos(Nomina Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDNomina};
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_RptNominaSaldos", Parametros);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 3)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Datos.ClaveNomina = Dr.GetString(Dr.GetOrdinal("ClaveNomina"));
                            Datos.FechaInicio = Dr.GetDateTime(Dr.GetOrdinal("FechaInicio"));
                            Datos.FechaFin = Dr.GetDateTime(Dr.GetOrdinal("FechaFin"));
                            Datos.DiasPeriodo = Dr.GetInt32(Dr.GetOrdinal("DiasPeriodo"));
                            Datos.TipoNomina = Dr.GetString(Dr.GetOrdinal("TipoNomina"));
                            Datos.PeriodoFechas = "Del " + Datos.FechaInicio.ToShortDateString() + " al " + Datos.FechaFin.ToShortDateString();
                        }
                        Dr.Close();

                        DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        List<Nomina> Lista = new List<Nomina>();
                        Nomina Item;
                        while (Dr2.Read())
                        {
                            Item = new Nomina();
                            Item.NombreEmpleado = Dr2.GetString(Dr2.GetOrdinal("Empleado"));
                            Item.Percepciones = Dr2.GetDecimal(Dr2.GetOrdinal("Percepciones"));
                            Item.Deducciones = Dr2.GetDecimal(Dr2.GetOrdinal("Deducciones"));
                            Item.Total = Dr2.GetDecimal(Dr2.GetOrdinal("Total"));
                            Lista.Add(Item);
                        }
                        Dr2.Close();
                        Datos.ListaNomina = Lista;

                        DataTableReader Dr3 = Ds.Tables[2].CreateDataReader();
                        List<Nomina> Lista02 = new List<Nomina>();
                        Nomina Item02;
                        while (Dr3.Read())
                        {
                            Item02 = new Nomina();
                            Item02.IDEmpleado = Dr3.GetString(Dr3.GetOrdinal("IDEmpleado"));
                            Item02.NombreEmpleado = Dr3.GetString(Dr3.GetOrdinal("Empleado"));
                            Item02.ConceptoNomina = Dr3.GetString(Dr3.GetOrdinal("Concepto"));
                            Item02.IDConcepto = Dr3.GetInt32(Dr3.GetOrdinal("ClaveConcepto"));
                            Item02.Monto = Dr3.GetDecimal(Dr3.GetOrdinal("Monto"));
                            Item02.Simbolo = Dr3.GetString(Dr3.GetOrdinal("Simbolo"));
                            Lista02.Add(Item02);
                        }
                        Datos.ListaConceptos = Lista02;
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


        public void ObtenerReporteNominaDetalle(Nomina Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDNomina };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_RptNominaDetalle", Parametros);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Datos.ClaveNomina = Dr.GetString(Dr.GetOrdinal("ClaveNomina"));
                            Datos.FechaInicio = Dr.GetDateTime(Dr.GetOrdinal("FechaInicio"));
                            Datos.FechaFin = Dr.GetDateTime(Dr.GetOrdinal("FechaFin"));
                            Datos.DiasPeriodo = Dr.GetInt32(Dr.GetOrdinal("DiasPeriodo"));
                            Datos.TipoNomina = Dr.GetString(Dr.GetOrdinal("TipoNomina"));
                            Datos.PeriodoFechas = "Del " + Datos.FechaInicio.ToShortDateString() + " al " + Datos.FechaFin.ToShortDateString();
                        }
                        Dr.Close();
                        DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        List<Nomina> Lista = new List<Nomina>();
                        Nomina Item;
                        while (Dr2.Read())
                        {
                            Item = new Nomina();
                            Item.NombreEmpleado = Dr2.GetString(Dr2.GetOrdinal("Empleado"));
                            Item.DiasLaborados = Dr2.GetInt32(Dr2.GetOrdinal("DiasLaborados"));
                            Item.DiasDescanso = Dr2.GetInt32(Dr2.GetOrdinal("DiasDescanso"));
                            Item.Faltas = Dr2.GetInt32(Dr2.GetOrdinal("Faltas"));
                            Item.DiasDescuentoFaltas = Dr2.GetInt32(Dr2.GetOrdinal("DiasDescuentoFaltas"));
                            Item.Retardos = Dr2.GetInt32(Dr2.GetOrdinal("Retardos"));
                            Item.FaltasRetardo = Dr2.GetInt32(Dr2.GetOrdinal("FaltasRetardos"));
                            Item.DiasDescuentoRetardos = Dr2.GetInt32(Dr2.GetOrdinal("DiasDescuentoRetardos"));
                            Item.DiasDescuentoTotales = Dr2.GetInt32(Dr2.GetOrdinal("DiasDescuentoTotales"));
                            Item.DiasFestivos = Dr2.GetInt32(Dr2.GetOrdinal("DiasFestivos"));
                            Item.DiasDomingo = Dr2.GetInt32(Dr2.GetOrdinal("DiasDomingo"));
                            Item.DiasVacaciones = Dr2.GetInt32(Dr2.GetOrdinal("DiasVacaciones"));
                            Lista.Add(Item);
                        }
                        Datos.ListaNomina = Lista;
                        Dr2.Close();
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
