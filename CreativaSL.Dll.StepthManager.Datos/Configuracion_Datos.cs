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
    public class Configuracion_Datos
    {
        public Configuracion ObtenerDatosConfiguracion(string Conexion)
        {
            try
            {
                Configuracion Datos = new Configuracion();
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "spCSLDB_get_Configuracion");
                while (Dr.Read())
                {
                    Datos.Completado = true;
                    Datos.RazonSocial = Dr.IsDBNull(Dr.GetOrdinal("RazonSocial")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("RazonSocial"));
                    Datos.NombreComercial = Dr.IsDBNull(Dr.GetOrdinal("NombreComercial")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("NombreComercial"));
                    Datos.Eslogan = Dr.IsDBNull(Dr.GetOrdinal("Eslogan")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Eslogan"));
                    Datos.RegimenFiscal = Dr.IsDBNull(Dr.GetOrdinal("RegimenFiscal")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("RegimenFiscal"));
                    Datos.DomicilioFiscal = Dr.IsDBNull(Dr.GetOrdinal("DomicilioFiscal")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("DomicilioFiscal"));
                    Datos.RFC = Dr.IsDBNull(Dr.GetOrdinal("RFC")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("RFC"));
                    Datos.Representante = Dr.IsDBNull(Dr.GetOrdinal("RepresentanteLegal")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("RepresentanteLegal"));
                    Datos.UrlLogo = Dr.IsDBNull(Dr.GetOrdinal("UrlLogo")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("UrlLogo"));
                    Datos.PorcentajeIva = Dr.IsDBNull(Dr.GetOrdinal("PorcentajeIva")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("PorcentajeIva"));
                    Datos.BandFecha01 = Dr.IsDBNull(Dr.GetOrdinal("BandFechaCorte01")) ? false : Dr.GetBoolean(Dr.GetOrdinal("BandFechaCorte01"));
                    Datos.BandFecha02 = Dr.IsDBNull(Dr.GetOrdinal("BandFechaCorte02")) ? false : Dr.GetBoolean(Dr.GetOrdinal("BandFechaCorte02"));
                    Datos.BandFecha03 = Dr.IsDBNull(Dr.GetOrdinal("BandFechaCorte03")) ? false : Dr.GetBoolean(Dr.GetOrdinal("BandFechaCorte03"));
                    Datos.Fecha01 = Dr.IsDBNull(Dr.GetOrdinal("FechaCorte01")) ? DateTime.Today : Dr.GetDateTime(Dr.GetOrdinal("FechaCorte01"));
                    Datos.Fecha02 = Dr.IsDBNull(Dr.GetOrdinal("FechaCorte02")) ? DateTime.Today : Dr.GetDateTime(Dr.GetOrdinal("FechaCorte02"));
                    Datos.Fecha03 = Dr.IsDBNull(Dr.GetOrdinal("FechaCorte03")) ? DateTime.Today : Dr.GetDateTime(Dr.GetOrdinal("FechaCorte03"));
                    Datos.TextoGarantia = Dr.IsDBNull(Dr.GetOrdinal("TextoGarantia")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("TextoGarantia"));
                    Datos.PagoDiasFestivos = Dr.IsDBNull(Dr.GetOrdinal("PagoDiasFestivos")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("PagoDiasFestivos"));
                    Datos.FaltasRetardos = Dr.IsDBNull(Dr.GetOrdinal("FaltasRetardos")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("FaltasRetardos"));
                    Datos.PagoDiasVacaciones = Dr.IsDBNull(Dr.GetOrdinal("PagoDiasVacaciones")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("PagoDiasVacaciones"));
                    Datos.TextoTicket = Dr.IsDBNull(Dr.GetOrdinal("TextoTicket")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("TextoTicket"));
                    Datos.PagoDiasDomingo = Dr.IsDBNull(Dr.GetOrdinal("PagoDiasDomingo")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("PagoDiasDomingo"));
                    Datos.DescCumpleaños = Dr.IsDBNull(Dr.GetOrdinal("PorcDesc")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("PorcDesc"));
                }
                Dr.Close();
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GuardarDatosConfiguracion(Configuracion Datos)
        {
            try
            {
                object[] Parametros = { Datos.RazonSocial, Datos.NombreComercial, Datos.Eslogan, Datos.DomicilioFiscal, 
                                       Datos.RegimenFiscal, Datos.RFC, Datos.Representante, Datos.BandLogo, Datos.UrlLogo, 
                                       Datos.BufferImagen, Datos.PorcentajeIva, Datos.BandFecha01, Datos.BandFecha02, 
                                       Datos.BandFecha03, Datos.Fecha01, Datos.Fecha02, Datos.Fecha03, Datos.TextoGarantia,
                                       Datos.PagoDiasFestivos, Datos.PagoDiasVacaciones, Datos.PagoDiasDomingo, Datos.TextoTicket, 
                                       Datos.FaltasRetardos,  Datos.DescCumpleaños, Datos.IDUsuario};
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_Configuracion", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Configuracion ObtenerLogoImagen(string Conexion)
        {
            try
            {
                Configuracion Datos = new Configuracion();
                object Result = SqlHelper.ExecuteScalar(Conexion, "spCSLDB_get_LogoBuffer");
                if (Result != null)
                {
                    Datos.Completado = true;
                    Datos.BufferImagen = (byte[]) Result;
                }
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LogoActualizado(Configuracion Datos)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(Datos.Conexion, "spCSLDB_set_LogoActualizado", Datos.IDSucursal, Comun.IDProyecto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EsFechaCorte(Configuracion Datos)
        {
            try
            {
                bool Band = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_get_VerificarFechaCorte");
                if (Result != null)
                {
                    bool.TryParse(Result.ToString(), out Band);
                }
                Datos.EsFechaCorte = Band;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EjecutarCorte(Configuracion Datos)
        {
            try
            {
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_EjecutarCorteMonedero", Datos.IDUsuario);
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

    }
}
