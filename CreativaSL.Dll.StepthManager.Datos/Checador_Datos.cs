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
    public class Checador_Datos
    {

        public void JustificarRegistroAsistencia(Checador Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDRegistro, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_JustificarRegistro", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    Datos.Opcion = Resultado;
                    Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerRegistrosXIDEmpleado(Checador Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDEmpleado, Datos.FechaChecador };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_RegistrosXEmpleadoXFecha", Parametros);
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

        public void ObtenerResumenChecador(Checador Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.FechaChecador, Datos.IDSucursal };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ResumenChecadoXFechaXSucursal", Parametros);
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



        public void Checar(Checador Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDEmpleado, Datos.IDTipoRegistro, Datos.FechaChecador, Datos.Motivo, Datos.DispChecador, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_A_NuevoRegistro", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado != 0)
                    {
                        Datos.Completado = true;
                        Datos.Opcion = Resultado;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void ObtenerHorariosXFecha(Checador Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDEmpleado, Datos.FechaInicio, Datos.FechaFin };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_HorarioXEmpleado", Parametros);
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


    }
}
