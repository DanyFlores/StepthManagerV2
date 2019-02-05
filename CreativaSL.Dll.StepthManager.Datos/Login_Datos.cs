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
    public class Login_Datos
    {

        public void IniciarDatos(DatosIniciales Datos)
        {
            try
            {
                object [] Parametros = {Datos.RazonSocial, Datos.NombreSucursal, Datos.CuentaUsuario, Datos.Password, Datos.IDProyecto};
                SqlHelper.ExecuteNonQuery(Datos.Conexion, "spCSLDB_set_ConfiguracionInicial", Parametros);
                Datos.Completado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsNewSystem(string Conexion)
        {
            try
            {
                bool Band = false;
                object Result = SqlHelper.ExecuteScalar(Conexion, "spCSLDB_get_IsNewSystem");
                if (Result != null)
                {
                    bool.TryParse(Result.ToString(), out Band);
                }
                return Band;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ValidarUsuario(Usuario Datos)
        {
            try
            {
                object[] Parametros = { Datos.CuentaUsuario, Datos.Password, Comun.MACAddress, Comun.IDProyecto };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Usuarios.spCSLDB_Login", Parametros);
                Datos.Completado = false;
                if (Ds != null)
                {
                    if (Ds.Tables.Count > 0)
                    {
                        if (Ds.Tables[0] != null)
                        {
                            DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                            if (Dr.HasRows)
                            {
                                while (Dr.Read() && !Datos.Completado)
                                {
                                    Datos.Completado = true;
                                    Datos.Resultado = Dr.IsDBNull(Dr.GetOrdinal("Resultado")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("Resultado"));
                                    if (Datos.Resultado == 1)
                                    {
                                        Comun.IDUsuario = Dr.IsDBNull(Dr.GetOrdinal("IDUsuario")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDUsuario"));
                                        Comun.NombreUsuario = Dr.IsDBNull(Dr.GetOrdinal("NombreUsuario")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("NombreUsuario"));
                                        Comun.ApellidoPatUsuario = Dr.IsDBNull(Dr.GetOrdinal("ApellidoPaterno")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("ApellidoPaterno"));
                                        Comun.ApellidoMatUsuario = Dr.IsDBNull(Dr.GetOrdinal("ApellidoMaterno")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("ApellidoMaterno"));
                                        Comun.IDTipoUsuario = Dr.IsDBNull(Dr.GetOrdinal("IDTipoUsuario")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDTipoUsuario"));
                                        Comun.IDSucursalCaja = Dr.IsDBNull(Dr.GetOrdinal("IDSucursal")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDSucursal"));
                                        Datos.CrearIDCaja = Dr.IsDBNull(Dr.GetOrdinal("CrearIDCaja")) ? false : Dr.GetBoolean(Dr.GetOrdinal("CrearIDCaja"));
                                        Comun.IDCaja = Dr.IsDBNull(Dr.GetOrdinal("IDCaja")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDCaja"));
                                        Comun.IDCajaCat = Dr.IsDBNull(Dr.GetOrdinal("IDCatCaja")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDCatCaja"));
                                        Comun.Impresora = Dr.IsDBNull(Dr.GetOrdinal("Impresora")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Impresora"));
                                        Comun.CuentaUsuario = Dr.IsDBNull(Dr.GetOrdinal("UsuarioCuenta")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("UsuarioCuenta"));
                                        Comun.RazonSocial = Dr.IsDBNull(Dr.GetOrdinal("RazonSocial")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("RazonSocial"));
                                        Comun.RFC = Dr.IsDBNull(Dr.GetOrdinal("RFC")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("RFC"));
                                        Comun.Direccion = Dr.IsDBNull(Dr.GetOrdinal("Direccion")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Direccion"));
                                        Comun.DomicilioFiscal = Dr.IsDBNull(Dr.GetOrdinal("DomicilioFiscal")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("DomicilioFiscal"));
                                        Comun.Eslogan = Dr.IsDBNull(Dr.GetOrdinal("Eslogan")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Eslogan"));
                                        Comun.RegimenFiscal = Dr.IsDBNull(Dr.GetOrdinal("RegimenFiscal")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("RegimenFiscal"));
                                        Comun.NombreComercial = Dr.IsDBNull(Dr.GetOrdinal("NombreComercial")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("NombreComercial"));
                                        Comun.UrlLogo = Dr.IsDBNull(Dr.GetOrdinal("UrlLogo")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("UrlLogo"));
                                        Comun.CajaAbierta = Dr.IsDBNull(Dr.GetOrdinal("CajaAbierta")) ? false : Dr.GetBoolean(Dr.GetOrdinal("CajaAbierta"));
                                        Comun.FaltaLogo = Dr.IsDBNull(Dr.GetOrdinal("FaltaLogo")) ? false : Dr.GetBoolean(Dr.GetOrdinal("FaltaLogo"));
                                        if (Ds.Tables.Count > 1)
                                        {
                                            if (Ds.Tables[1] != null)
                                            {
                                                Comun.TablaPermisos = Ds.Tables[1];
                                            }
                                        }
                                    }
                                }
                            }
                            Dr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede obtener la información: " + ex.Message);
            }
        }

    }
}
