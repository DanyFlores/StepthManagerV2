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
    public class Usuario_Datos
    {

        public void ABCUsuario(Usuario Datos)
        {
            try
            {
                SqlDataReader Resultado = SqlHelper.ExecuteReader(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_abc_CatEmpleado",
                     new SqlParameter("@Opcion", Datos.Opcion),
                     new SqlParameter("@IDEmpleado", Datos.IDEmpleado),
                     new SqlParameter("@IDTipoUsuario", Datos.IDTipoUsuario),
                     new SqlParameter("@IDPuesto", Datos.IDPuesto),
                     new SqlParameter("@IDCategoria", Datos.IDCategoriaPuesto),
                     new SqlParameter("@IDSucursalActual", Datos.IDSucursalActual),
                     new SqlParameter("@AbrirCaja", Datos.AbrirCaja),
                     new SqlParameter("@Nombre", Datos.Nombre),
                     new SqlParameter("@ApellidoPat", Datos.ApellidoPat),
                     new SqlParameter("@ApellidoMat", Datos.ApellidoMat),
                     new SqlParameter("@DirCalle", Datos.DirCalle),
                     new SqlParameter("@DirColonia", Datos.DirColonia),
                     new SqlParameter("@DirNumero", Datos.DirNumero),
                     new SqlParameter("@TablaUsuarioSucursal", Datos.TablaUsuarioSucursal),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                Datos.Completado = false;
                if (Resultado != null)
                {
                    if (!string.IsNullOrEmpty(Resultado.ToString()))
                    {
                        Datos.Completado = true;
                        Datos.IDEmpleado = Resultado.ToString();
                    }
                }
                Resultado.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AsignarHuellaXIDEmpleado(Usuario Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDEmpleado, Datos.BufferHuella, Datos.HuellaString, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_HuellaXIDEmpleado", Parametros);
                Datos.Completado = false;
                if (Result != null)
                {
                    int Aux = 0;
                    int.TryParse(Result.ToString(), out Aux);
                    if (Aux == 1)
                        Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerUsuario(Usuario Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatEmpleado", Datos.BuscarTodos);
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
        
        
        public void ObtenerUsuarioBusqueda(Usuario Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatEmpleadoBusqueda", Datos.BuscarTodos, Datos.Nombre);
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

        public void ObtenerComboCatTipoUsuario(TipoUsuario Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ComboCatTipoUsuario");
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

        public void ObtenerHuellaDigitalXIDEmpleado(Usuario Datos)
        {
            try
            {
                Datos.Completado = false;
                object Imagen = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_get_HuellaXIDEmpleado", Datos.IDEmpleado);
                if (Imagen != null)
                {
                    Datos.BufferHuella = (byte[])Imagen;
                    Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerHuellasDigitales(Usuario Datos)
        {
            try
            {
                Datos.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatEmpleadosHuella");
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        Datos.TablaDatos = Ds.Tables[0];
                        Datos.Completado = true;
                    }
                }
                //List<Usuario> Lista = new List<Usuario>();
                //Usuario Item;
                //Datos.TablaDatos = new DataTable();
                //Datos.TablaDatos.Columns.Add("huellaDigital", typeof(byte[]));
                //SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_CatEmpleadosHuella");
                //while (Dr.Read())
                //{
                //    //if(!Datos.Completado)
                //    //    Datos.Completado = true;

                //    //byte[] Buffer = (byte[])Dr.GetValue(Dr.GetOrdinal("huellaDigital"));
                //    //Datos.TablaDatos.Rows.Add(Buffer);
                //    Item = new Usuario();
                //    Item.BufferHuella = (byte[])Dr.GetValue(Dr.GetOrdinal("huellaDigital"));
                //    Lista.Add(Item);
                //}
                //return Lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Sucursal> ObtenerSucursal(Usuario Datos)
        {
            try
            {
                List<Sucursal> Lista = new List<Sucursal>();
                Sucursal Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_CatSursalesUsuario", Datos.IDEmpleado);
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

        public List<Sucursal> ObtenerSucursalXIDEmpleado(Usuario Datos)
        {
            try
            {
                List<Sucursal> Lista = new List<Sucursal>();
                Sucursal Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_UsuarioXSucursal", Datos.IDEmpleado);
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

        public void ABCCuentaUsuario(Usuario Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDEmpleado, Datos.CuentaUsuario, Datos.Password, Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_CuentaUsuario", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    if (!string.IsNullOrEmpty(Resultado.ToString()))
                    {
                        Datos.Completado = true;
                        Datos.IDEmpleado = Resultado.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> LlenarComboCatEmpleados(Usuario Datos)
        {
            try
            {
                List<Usuario> Lista = new List<Usuario>();
                Usuario Item;
                object[] Parametros = {Datos.IncluirSelect, Datos.IDSucursalActual};
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboEmpleadosXIDSucursal", Parametros);
                while (Dr.Read())
                {
                    Item = new Usuario();
                    Item.IDEmpleado = Dr.IsDBNull(Dr.GetOrdinal("IDEmpleado")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDEmpleado"));
                    Item.Nombre = Dr.IsDBNull(Dr.GetOrdinal("NombreEmpleado")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("NombreEmpleado"));
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

        public List<Usuario> LlenarComboCatEmpleadosCita(Usuario Datos)
        {
            try
            {
                List<Usuario> Lista = new List<Usuario>();
                Usuario Item;
                object[] Parametros = { Datos.IncluirSelect, Datos.IDSucursalActual };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboEmpleadosXIDSucursalCita", Parametros);
                while (Dr.Read())
                {
                    Item = new Usuario();
                    Item.IDEmpleado = Dr.IsDBNull(Dr.GetOrdinal("IDEmpleado")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDEmpleado"));
                    Item.Nombre = Dr.IsDBNull(Dr.GetOrdinal("NombreEmpleado")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("NombreEmpleado"));
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

        public List<MotivoBaja> LlenarComboMotivoBaja(MotivoBaja Datos)
        {
            try
            {
                List<MotivoBaja> Lista = new List<MotivoBaja>();
                MotivoBaja Item;
                object[] Parametros = { Datos.IncluirSelect };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboMotivosBaja", Parametros);
                while (Dr.Read())
                {
                    Item = new MotivoBaja();
                    Item.IDMotivoBaja = Dr.IsDBNull(Dr.GetOrdinal("IDMotivoBaja")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDMotivoBaja"));
                    Item.Descripcion = Dr.IsDBNull(Dr.GetOrdinal("Motivo")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Motivo"));
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

        public List<TipoNomina> LlenarComboTipoNomina(TipoNomina Datos)
        {
            try
            {
                List<TipoNomina> Lista = new List<TipoNomina>();
                TipoNomina Item;
                object[] Parametros = { Datos.IncluirSelect };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboTipoNomina", Parametros);
                while (Dr.Read())
                {
                    Item = new TipoNomina();
                    Item.IDTipoNomina = Dr.IsDBNull(Dr.GetOrdinal("IDTipoNomina")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDTipoNomina"));
                    Item.Descripcion = Dr.IsDBNull(Dr.GetOrdinal("TipoNomina")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("TipoNomina"));
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

        public void AltaNominal(Usuario Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDEmpleado, Datos.IDTipoNomina, Datos.IDPuesto, Datos.IDCategoriaPuesto, Datos.SueldoBase, Datos.IDUsuario  };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_AltaNominal", Parametros);
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

        public void BajaNominal(Usuario Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDEmpleado, Datos.IDMotivoBaja, Datos.ComentariosBaja, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_BajaNominal", Parametros);
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

        public void ObtenerHistorialLaboral(Usuario Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_HistorialLaboral", Datos.IDEmpleado);
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

        public void ObtenerPermisosXIDUsuario(Usuario Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_PermisiosXIDUsuario", Datos.IDEmpleado);
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                        Datos.TablaDatos = Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarPermisosXIDUsuario(Usuario Datos)
        {
            try
            {
                //object[] Parametros = { Datos.IDEmpleado, Datos.TablaDatos, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_set_PermisosXIDEmpleado",
                     new SqlParameter("@IDEmpleado", Datos.IDEmpleado),
                     new SqlParameter("@Tabla", Datos.TablaDatos),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario));
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



        public void AsignarCategoria(Usuario Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDEmpleado, Datos.IDPuesto, Datos.IDCategoriaPuesto, Datos.SueldoBase, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_ActualizarCategoriaXIDEmpleado", Parametros);
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
        public void ABVacacionesEmpleado(Usuario Datos)
        {
            try
            {
                object[] Parametros = { Datos.Opcion, Datos.IDVacaciones, Datos.IDEmpleado, Datos.FechaInicio, Datos.FechaFin, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_ab_Nomina_Vacaciones", Parametros);
                Datos.Completado = false;
                if (Result != null)
                {
                    int Aux = 0;
                    int.TryParse(Result.ToString(), out Aux);
                    if (Aux == 1)
                        Datos.Completado = true;
                    else
                        Datos.Resultado = Aux;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerNominaVaciones(Usuario Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_Nomina_Vacaciones", Datos.BuscarTodos, Datos.IDEmpleado);
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
    }
}
