using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Data.SqlTypes;
using System.IO;

namespace CreativaSL.Dll.StephManager.Datos
{
    public class Vales_Datos 
    {

        public void ActivarVale(Vales Datos)
        {
            try
            {
                int Resultado = 0;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_set_ActivarVale",
                new SqlParameter("@IDVale", Datos.IDVale),
                new SqlParameter("@IDUsuario", Datos.IDUsuario));
                if (Ds != null)
                {
                    if (Ds.Tables.Count > 0)
                    {
                        int.TryParse(Ds.Tables[0].Rows[0][0].ToString(), out Resultado);
                        if (Resultado == 1)
                        {
                            if (Ds.Tables.Count == 2)
                            {
                                Datos.Completado = true;
                                Datos.tablaNotificaciones = Ds.Tables[1];
                            }
                            Datos.Opcion = Resultado;
                        }
                        else if (Resultado == -1)
                        {
                            Datos.Completado = false;
                        }
                        else if (Resultado == 0)
                        {
                            Datos.Completado = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //public void ActivarVale(Vales Datos)
        //{
        //    try
        //    {
        //        Datos.Completado = false;
        //        object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_ActivarVale", Datos.IDVale, Datos.IDUsuario);
        //        if (Result != null)
        //        {
        //            int Resultado = 0;
        //            int.TryParse(Result.ToString(), out Resultado);
        //            if (Resultado == 1)
        //                Datos.Completado = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public void ReActivarVale(Vales Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDVale, Datos.CantLimite, Datos.FechaInicio, Datos.FechaFin, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_ReactivarVale", Parametros);
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

        public void EliminarVale(Vales Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_EliminarVale", Datos.IDVale, Datos.IDUsuario);
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

        public void SuspenderVale(Vales Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_SuspenderVale", Datos.IDVale, Datos.IDUsuario);
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

        public void ABCVales(Vales Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDVale, Datos.IDTipoVale, Datos.Nombre, Datos.Folio, Datos.CantLimite,
                                        Datos.Monto, Datos.Porcentaje, Datos.Abierto, Datos.RangoFechas, Datos.FechaInicio,
                                        Datos.FechaFin, Datos.Lunes, Datos.Martes, Datos.Miercoles, Datos.Jueves,
                                        Datos.Viernes, Datos.Sabado, Datos.Domingo, Datos.CantRequeridad, Datos.CantGratis, Datos.CantidadRequeridaNxN, 
                                        Datos.CantidadGratisNxN, Datos.IDProductoNxN,Datos.IDProductoRequerido, Datos.IDProductoGratis, Datos.IDUsuario };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_abc_Vales",
                                     new SqlParameter("@Opcion", Datos.Opcion),
                                     new SqlParameter("@IDVale", Datos.IDVale),
                                     new SqlParameter("@IDTipoVale", Datos.IDTipoVale),
                                     new SqlParameter("@Nombre", Datos.Nombre),
                                     new SqlParameter("@Folio", Datos.Folio),
                                     new SqlParameter("@CantidadLimite", Datos.CantLimite),
                                     new SqlParameter("@Monto", Datos.Monto),
                                     new SqlParameter("@Porcentaje", Datos.Porcentaje),
                                     new SqlParameter("@Abierto", Datos.Abierto),
                                     new SqlParameter("@RangoFechas", Datos.RangoFechas),
                                     new SqlParameter("@FechaInicio", Datos.FechaInicio),
                                     new SqlParameter("@FechaFin", Datos.FechaFin),
                                     new SqlParameter("@Lunes", Datos.Lunes),
                                     new SqlParameter("@Martes", Datos.Martes),
                                     new SqlParameter("@Miercoles", Datos.Miercoles),
                                     new SqlParameter("@Jueves", Datos.Jueves),
                                     new SqlParameter("@Viernes", Datos.Viernes),
                                     new SqlParameter("@Sabado", Datos.Sabado),
                                     new SqlParameter("@Domingo", Datos.Domingo),
                                     new SqlParameter("@CantRequeridad", Datos.CantRequeridad),
                                     new SqlParameter("@CantGratis", Datos.CantGratis),
                                     new SqlParameter("@CantRequeridaNxN", Datos.CantidadRequeridaNxN),
                                     new SqlParameter("@CantGratisNxN", Datos.CantidadGratisNxN),
                                     new SqlParameter("@IDProductoNxN", Datos.IDProductoNxN),
                                     new SqlParameter("@IDProductoRequeridoMxN", Datos.IDProductoRequerido),
                                     new SqlParameter("@IDProductoGratisMxN", Datos.IDProductoGratis),
                                     new SqlParameter("@TablaProductos", Datos.TablaDatos),
                                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                Datos.Completado = false;
                while (Dr.Read())
                {
                    Datos.Resultado = Dr.IsDBNull(Dr.GetOrdinal("Resultado")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("Resultado"));
                    if (Datos.Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.IDVale = Dr.IsDBNull(Dr.GetOrdinal("IDVale")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDVale"));
                    }
                }
                Dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerVales(Vales Datos)
        {
            try
            {
                object[] Parametros = { Datos.BuscarTodos, Datos.TabVales };
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_Vales", Parametros);
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

        public void ObtenerValesBusqueda(Vales Datos)
        {
            try
            {
                object[] Parametros = { Datos.BuscarTodos, Datos.TabVales, Datos.Nombre };
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ValesBusqueda", Parametros);
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

        public Vales ObtenerValeDetalle(Vales Datos)
        {
            try
            {
                Vales Resultado = new Vales();
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ValesDetalle", Datos.IDVale);
                if(Ds!= null)
                {
                    if(Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Resultado.IDVale = !Dr.IsDBNull(Dr.GetOrdinal("id_vale")) ? Dr.GetString(Dr.GetOrdinal("id_vale")) : string.Empty;
                            Resultado.IDTipoVale = !Dr.IsDBNull(Dr.GetOrdinal("id_tipoVale")) ? Dr.GetInt32(Dr.GetOrdinal("id_tipoVale")) : 0;
                            Resultado.IDEstatusVale = !Dr.IsDBNull(Dr.GetOrdinal("id_estatusVale")) ? Dr.GetInt32(Dr.GetOrdinal("id_estatusVale")) : 0;
                            Resultado.Nombre = !Dr.IsDBNull(Dr.GetOrdinal("Titulo")) ? Dr.GetString(Dr.GetOrdinal("Titulo")) : string.Empty;
                            Resultado.Folio = !Dr.IsDBNull(Dr.GetOrdinal("folio")) ? Dr.GetString(Dr.GetOrdinal("folio")) : string.Empty;
                            Resultado.CantLimite = !Dr.IsDBNull(Dr.GetOrdinal("cantLimite")) ? Dr.GetInt32(Dr.GetOrdinal("cantLimite")) : 0;
                            Resultado.Abierto = !Dr.IsDBNull(Dr.GetOrdinal("abierto")) ? Dr.GetBoolean(Dr.GetOrdinal("abierto")) : false;
                            Resultado.RequierePeriodo = !Dr.IsDBNull(Dr.GetOrdinal("rangoFechas")) ? Dr.GetBoolean(Dr.GetOrdinal("rangoFechas")) : false;
                            switch (Resultado.IDTipoVale)
                            {
                                case 1:
                                case 2:
                                    Resultado.Monto = !Dr.IsDBNull(Dr.GetOrdinal("monto")) ? Dr.GetDecimal(Dr.GetOrdinal("monto")) : 0;
                                    Resultado.Porcentaje = !Dr.IsDBNull(Dr.GetOrdinal("porcentaje")) ? Dr.GetDecimal(Dr.GetOrdinal("porcentaje")) : 0;
                                    if (Resultado.RequierePeriodo)
                                    {
                                        Resultado.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("fechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaInicio")) : DateTime.Today;
                                        Resultado.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("fechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaFin")) : DateTime.Today;
                                    }
                                    else
                                    {
                                        Resultado.Lunes = !Dr.IsDBNull(Dr.GetOrdinal("lunes")) ? Dr.GetBoolean(Dr.GetOrdinal("lunes")) : false;
                                        Resultado.Martes = !Dr.IsDBNull(Dr.GetOrdinal("martes")) ? Dr.GetBoolean(Dr.GetOrdinal("martes")) : false;
                                        Resultado.Miercoles = !Dr.IsDBNull(Dr.GetOrdinal("miercoles")) ? Dr.GetBoolean(Dr.GetOrdinal("miercoles")) : false;
                                        Resultado.Jueves = !Dr.IsDBNull(Dr.GetOrdinal("jueves")) ? Dr.GetBoolean(Dr.GetOrdinal("jueves")) : false;
                                        Resultado.Viernes = !Dr.IsDBNull(Dr.GetOrdinal("viernes")) ? Dr.GetBoolean(Dr.GetOrdinal("viernes")) : false;
                                        Resultado.Sabado = !Dr.IsDBNull(Dr.GetOrdinal("sabado")) ? Dr.GetBoolean(Dr.GetOrdinal("sabado")) : false;
                                        Resultado.Domingo = !Dr.IsDBNull(Dr.GetOrdinal("domingo")) ? Dr.GetBoolean(Dr.GetOrdinal("domingo")) : false;
                                    }
                                    break;
                                case 3:
                                    string IDProductoNXN = !Dr.IsDBNull(Dr.GetOrdinal("id_productoRequerido")) ? Dr.GetString(Dr.GetOrdinal("id_productoRequerido")) : string.Empty;
                                    string NombreProductoNXN = !Dr.IsDBNull(Dr.GetOrdinal("ProductoN")) ? Dr.GetString(Dr.GetOrdinal("ProductoN")) : string.Empty;
                                    Resultado.ProductoRequerido = new Producto { IDProducto = IDProductoNXN, NombreProducto = NombreProductoNXN };
                                    Resultado.CantidadRequeridaNxN = !Dr.IsDBNull(Dr.GetOrdinal("cantRequerida")) ? Dr.GetInt32(Dr.GetOrdinal("cantRequerida")) : 0;
                                    Resultado.CantidadGratisNxN = !Dr.IsDBNull(Dr.GetOrdinal("cantGratis")) ? Dr.GetInt32(Dr.GetOrdinal("cantGratis")) : 0;
                                    if (Resultado.RequierePeriodo)
                                    {
                                        Resultado.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("fechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaInicio")) : DateTime.Today;
                                        Resultado.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("fechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaFin")) : DateTime.Today;
                                    }
                                    else
                                    {
                                        Resultado.Lunes = !Dr.IsDBNull(Dr.GetOrdinal("lunes")) ? Dr.GetBoolean(Dr.GetOrdinal("lunes")) : false;
                                        Resultado.Martes = !Dr.IsDBNull(Dr.GetOrdinal("martes")) ? Dr.GetBoolean(Dr.GetOrdinal("martes")) : false;
                                        Resultado.Miercoles = !Dr.IsDBNull(Dr.GetOrdinal("miercoles")) ? Dr.GetBoolean(Dr.GetOrdinal("miercoles")) : false;
                                        Resultado.Jueves = !Dr.IsDBNull(Dr.GetOrdinal("jueves")) ? Dr.GetBoolean(Dr.GetOrdinal("jueves")) : false;
                                        Resultado.Viernes = !Dr.IsDBNull(Dr.GetOrdinal("viernes")) ? Dr.GetBoolean(Dr.GetOrdinal("viernes")) : false;
                                        Resultado.Sabado = !Dr.IsDBNull(Dr.GetOrdinal("sabado")) ? Dr.GetBoolean(Dr.GetOrdinal("sabado")) : false;
                                        Resultado.Domingo = !Dr.IsDBNull(Dr.GetOrdinal("domingo")) ? Dr.GetBoolean(Dr.GetOrdinal("domingo")) : false;
                                    }
                                    break;
                                case 4:
                                    string IDProductoM = !Dr.IsDBNull(Dr.GetOrdinal("id_productoRequerido")) ? Dr.GetString(Dr.GetOrdinal("id_productoRequerido")) : string.Empty;
                                    string NombreProductoM = !Dr.IsDBNull(Dr.GetOrdinal("ProductoM")) ? Dr.GetString(Dr.GetOrdinal("ProductoM")) : string.Empty;
                                    string IDProductoN = !Dr.IsDBNull(Dr.GetOrdinal("id_productoGratis")) ? Dr.GetString(Dr.GetOrdinal("id_productoGratis")) : string.Empty;
                                    string NombreProductoN = !Dr.IsDBNull(Dr.GetOrdinal("ProductoN")) ? Dr.GetString(Dr.GetOrdinal("ProductoN")) : string.Empty;
                                    Resultado.ProductoRequerido = new Producto { IDProducto = IDProductoM, NombreProducto = NombreProductoM };
                                    Resultado.CantRequeridad = !Dr.IsDBNull(Dr.GetOrdinal("cantRequerida")) ? Dr.GetInt32(Dr.GetOrdinal("cantRequerida")) : 0;
                                    Resultado.ProductoGratis = new Producto { IDProducto = IDProductoN, NombreProducto = NombreProductoN };
                                    Resultado.CantGratis = !Dr.IsDBNull(Dr.GetOrdinal("cantGratis")) ? Dr.GetInt32(Dr.GetOrdinal("cantGratis")) : 0;
                                    if (Resultado.RequierePeriodo)
                                    {
                                        Resultado.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("fechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaInicio")) : DateTime.Today;
                                        Resultado.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("fechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaFin")) : DateTime.Today;
                                    }
                                    else
                                    {
                                        Resultado.Lunes = !Dr.IsDBNull(Dr.GetOrdinal("lunes")) ? Dr.GetBoolean(Dr.GetOrdinal("lunes")) : false;
                                        Resultado.Martes = !Dr.IsDBNull(Dr.GetOrdinal("martes")) ? Dr.GetBoolean(Dr.GetOrdinal("martes")) : false;
                                        Resultado.Miercoles = !Dr.IsDBNull(Dr.GetOrdinal("miercoles")) ? Dr.GetBoolean(Dr.GetOrdinal("miercoles")) : false;
                                        Resultado.Jueves = !Dr.IsDBNull(Dr.GetOrdinal("jueves")) ? Dr.GetBoolean(Dr.GetOrdinal("jueves")) : false;
                                        Resultado.Viernes = !Dr.IsDBNull(Dr.GetOrdinal("viernes")) ? Dr.GetBoolean(Dr.GetOrdinal("viernes")) : false;
                                        Resultado.Sabado = !Dr.IsDBNull(Dr.GetOrdinal("sabado")) ? Dr.GetBoolean(Dr.GetOrdinal("sabado")) : false;
                                        Resultado.Domingo = !Dr.IsDBNull(Dr.GetOrdinal("domingo")) ? Dr.GetBoolean(Dr.GetOrdinal("domingo")) : false;
                                    }
                                    break;
                            }
                        }
                        DataTable TablaAUx = Ds.Tables[1];
                        DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        List<Producto> Lista = new List<Producto>();
                        Producto Item;
                        while (Dr2.Read())
                        {
                            Item = new Producto();
                            Item.IDProducto = Dr2.GetString(Dr2.GetOrdinal("IDProducto"));
                            Item.Clave = Dr2.GetString(Dr2.GetOrdinal("Clave"));
                            Item.NombreProducto = Dr2.GetString(Dr2.GetOrdinal("NombreProducto"));
                            Lista.Add(Item);
                        }
                        Resultado.ListaProductos = Lista;
                        Dr.Close();
                        Dr2.Close();
                    }

                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TipoVales> ObtenerComboTipoVale(TipoVales Datos)
        {
            try
            {
                List<TipoVales> Lista = new List<TipoVales>();
                TipoVales Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboTipoVale", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new TipoVales();
                    Item.IDTipoVale = Dr.IsDBNull(Dr.GetOrdinal("IDTipoVale")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDTipoVale"));
                    Item.Descripcion = Dr.IsDBNull(Dr.GetOrdinal("Descripcion")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.Porcentaje = Dr.IsDBNull(Dr.GetOrdinal("Porcentaje")) ? false : Dr.GetBoolean(Dr.GetOrdinal("Porcentaje"));
                    Item.Monto = Dr.IsDBNull(Dr.GetOrdinal("Monto")) ? false : Dr.GetBoolean(Dr.GetOrdinal("Monto"));
                    Item.NxN = Dr.IsDBNull(Dr.GetOrdinal("NxN")) ? false : Dr.GetBoolean(Dr.GetOrdinal("NxN"));
                    Item.NxM = Dr.IsDBNull(Dr.GetOrdinal("NxM")) ? false : Dr.GetBoolean(Dr.GetOrdinal("NxM"));
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

        public List<Producto> ObtenerComboCatProducto(Producto Datos)
        {
            try
            {
                List<Producto> Lista = new List<Producto>();
                Producto Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboCatProducto", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new Producto();
                    Item.IDProducto = Dr.IsDBNull(Dr.GetOrdinal("IDProducto")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDProducto"));
                    Item.NombreProducto = Dr.IsDBNull(Dr.GetOrdinal("Nombre")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Nombre"));
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

        public List<Vales> ObtenerCorreosClientes(Vales datos)
        {
            try
            {
                object[] parametros = { datos.IDVale };
                List<Vales> lista = new List<Vales>();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.Conexion, "spCSLDB_get_ValesXClientesCorreos", parametros);
                while (dr.Read())
                {
                    var item = new Vales();
                    item.Correo = dr["CorreoElectronico"].ToString();
                    item.AsusntoVales = dr["NombreVale"].ToString();
                    lista.Add(item);
                }
                dr.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EnviarVale(Vales Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_EnviarVale", Datos.IDVale, Datos.IDUsuario);
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
        public void ABCClientesXVales(Vales Datos)
        {
            try
            {
                object[] parametros = {Datos.IDValesXClientes, Datos.IDVale, Datos.IDCliente,
                                        Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_Vale_ValeXCliente", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    if (!string.IsNullOrEmpty(Resultado.ToString()))
                    {
                        Datos.Completado = true;
                        Datos.IDValesXClientes = Resultado.ToString();
                        if (Datos.IDValesXClientes == Convert.ToString(1))
                        {
                            Datos.Completado = true;
                            Datos.IDValesXClientes = Resultado.ToString();
                        }
                        else if (Datos.IDValesXClientes == Convert.ToString(0))
                        {
                            Datos.Completado = false;
                            Datos.MensajeError = "El Cliente ya existes para ese vale";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EliminarValexClientes(Vales Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_EliminarValeXClientes", Datos.IDVale, Datos.IDCliente, Datos.IDUsuario);
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
        public void ObtenerLlegarGribClientes(Vales Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDVale };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ValesXClientes", Parametros);
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
        public void EnviarValeNotificaciones(Vales Datos)
        {
            try
            {
                int Resultado = 0;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_set_EnviarValeNotificacion",
                new SqlParameter("@IDVale", Datos.IDVale),
                new SqlParameter("@IDUsuario", Datos.IDUsuario));
                if (Ds != null)
                {
                    if (Ds.Tables.Count > 0)
                    {
                        int.TryParse(Ds.Tables[0].Rows[0][0].ToString(), out Resultado);
                        if (Resultado == 1)
                        {
                            if (Ds.Tables.Count == 2)
                            {
                                Datos.Completado = true;
                                Datos.tablaNotificaciones = Ds.Tables[1];
                            }
                            Datos.Opcion = Resultado;
                        }
                        else if (Resultado == -1)
                        {
                            Datos.Completado = false;
                        }
                        else if (Resultado == 0)
                        {
                            Datos.Completado = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Vales ObtenerValeDetalleCorreos(Vales Datos)
        {
            try
            {
                Vales Resultado = new Vales();
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ValesEnvioCorreos", Datos.IDVale);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Resultado.IDVale = !Dr.IsDBNull(Dr.GetOrdinal("id_vale")) ? Dr.GetString(Dr.GetOrdinal("id_vale")) : string.Empty;
                            Resultado.IDTipoVale = !Dr.IsDBNull(Dr.GetOrdinal("id_tipoVale")) ? Dr.GetInt32(Dr.GetOrdinal("id_tipoVale")) : 0;
                            Resultado.IDEstatusVale = !Dr.IsDBNull(Dr.GetOrdinal("id_estatusVale")) ? Dr.GetInt32(Dr.GetOrdinal("id_estatusVale")) : 0;
                            Resultado.Nombre = !Dr.IsDBNull(Dr.GetOrdinal("Titulo")) ? Dr.GetString(Dr.GetOrdinal("Titulo")) : string.Empty;
                            Resultado.Folio = !Dr.IsDBNull(Dr.GetOrdinal("folio")) ? Dr.GetString(Dr.GetOrdinal("folio")) : string.Empty;
                            Resultado.CantLimite = !Dr.IsDBNull(Dr.GetOrdinal("cantLimite")) ? Dr.GetInt32(Dr.GetOrdinal("cantLimite")) : 0;
                            Resultado.Abierto = !Dr.IsDBNull(Dr.GetOrdinal("abierto")) ? Dr.GetBoolean(Dr.GetOrdinal("abierto")) : false;
                            Resultado.RequierePeriodo = !Dr.IsDBNull(Dr.GetOrdinal("rangoFechas")) ? Dr.GetBoolean(Dr.GetOrdinal("rangoFechas")) : false;
                            switch (Resultado.IDTipoVale)
                            {
                                case 1:
                                case 2:
                                    Resultado.Monto = !Dr.IsDBNull(Dr.GetOrdinal("monto")) ? Dr.GetDecimal(Dr.GetOrdinal("monto")) : 0;
                                    Resultado.Porcentaje = !Dr.IsDBNull(Dr.GetOrdinal("porcentaje")) ? Dr.GetDecimal(Dr.GetOrdinal("porcentaje")) : 0;
                                    if (Resultado.RequierePeriodo)
                                    {
                                        Resultado.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("fechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaInicio")) : DateTime.Today;
                                        Resultado.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("fechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaFin")) : DateTime.Today;
                                    }
                                    else
                                    {
                                        Resultado.Lunes = !Dr.IsDBNull(Dr.GetOrdinal("lunes")) ? Dr.GetBoolean(Dr.GetOrdinal("lunes")) : false;
                                        Resultado.Martes = !Dr.IsDBNull(Dr.GetOrdinal("martes")) ? Dr.GetBoolean(Dr.GetOrdinal("martes")) : false;
                                        Resultado.Miercoles = !Dr.IsDBNull(Dr.GetOrdinal("miercoles")) ? Dr.GetBoolean(Dr.GetOrdinal("miercoles")) : false;
                                        Resultado.Jueves = !Dr.IsDBNull(Dr.GetOrdinal("jueves")) ? Dr.GetBoolean(Dr.GetOrdinal("jueves")) : false;
                                        Resultado.Viernes = !Dr.IsDBNull(Dr.GetOrdinal("viernes")) ? Dr.GetBoolean(Dr.GetOrdinal("viernes")) : false;
                                        Resultado.Sabado = !Dr.IsDBNull(Dr.GetOrdinal("sabado")) ? Dr.GetBoolean(Dr.GetOrdinal("sabado")) : false;
                                        Resultado.Domingo = !Dr.IsDBNull(Dr.GetOrdinal("domingo")) ? Dr.GetBoolean(Dr.GetOrdinal("domingo")) : false;
                                    }
                                    break;
                                case 3:
                                    string IDProductoNXN = !Dr.IsDBNull(Dr.GetOrdinal("id_productoRequerido")) ? Dr.GetString(Dr.GetOrdinal("id_productoRequerido")) : string.Empty;
                                    string ClaveNxN = !Dr.IsDBNull(Dr.GetOrdinal("ClaveN")) ? Dr.GetString(Dr.GetOrdinal("ClaveN")) : string.Empty;
                                    string NombreProductoNXN = !Dr.IsDBNull(Dr.GetOrdinal("ProductoN")) ? Dr.GetString(Dr.GetOrdinal("ProductoN")) : string.Empty;
                                    byte[] ImagenProductoNXN = (byte[])Dr.GetValue(Dr.GetOrdinal("ImagenProductoN"));
                                    string NombreImagen = !Dr.IsDBNull(Dr.GetOrdinal("url_imagen")) ? Dr.GetString(Dr.GetOrdinal("url_imagen")) : string.Empty;
                                    Resultado.ProductoRequerido = new Producto { IDProducto = IDProductoNXN, NombreProducto = NombreProductoNXN, Imagen = ImagenProductoNXN, UrlImagen = NombreImagen, Clave = ClaveNxN };
                                    Resultado.CantidadRequeridaNxN = !Dr.IsDBNull(Dr.GetOrdinal("cantRequerida")) ? Dr.GetInt32(Dr.GetOrdinal("cantRequerida")) : 0;
                                    Resultado.CantidadGratisNxN = !Dr.IsDBNull(Dr.GetOrdinal("cantGratis")) ? Dr.GetInt32(Dr.GetOrdinal("cantGratis")) : 0;

                                    if (Resultado.RequierePeriodo)
                                    {
                                        Resultado.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("fechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaInicio")) : DateTime.Today;
                                        Resultado.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("fechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaFin")) : DateTime.Today;
                                    }
                                    else
                                    {
                                        Resultado.Lunes = !Dr.IsDBNull(Dr.GetOrdinal("lunes")) ? Dr.GetBoolean(Dr.GetOrdinal("lunes")) : false;
                                        Resultado.Martes = !Dr.IsDBNull(Dr.GetOrdinal("martes")) ? Dr.GetBoolean(Dr.GetOrdinal("martes")) : false;
                                        Resultado.Miercoles = !Dr.IsDBNull(Dr.GetOrdinal("miercoles")) ? Dr.GetBoolean(Dr.GetOrdinal("miercoles")) : false;
                                        Resultado.Jueves = !Dr.IsDBNull(Dr.GetOrdinal("jueves")) ? Dr.GetBoolean(Dr.GetOrdinal("jueves")) : false;
                                        Resultado.Viernes = !Dr.IsDBNull(Dr.GetOrdinal("viernes")) ? Dr.GetBoolean(Dr.GetOrdinal("viernes")) : false;
                                        Resultado.Sabado = !Dr.IsDBNull(Dr.GetOrdinal("sabado")) ? Dr.GetBoolean(Dr.GetOrdinal("sabado")) : false;
                                        Resultado.Domingo = !Dr.IsDBNull(Dr.GetOrdinal("domingo")) ? Dr.GetBoolean(Dr.GetOrdinal("domingo")) : false;
                                    }
                                    break;
                                case 4:
                                    string IDProductoM = !Dr.IsDBNull(Dr.GetOrdinal("id_productoRequerido")) ? Dr.GetString(Dr.GetOrdinal("id_productoRequerido")) : string.Empty;
                                    string ClaveM = !Dr.IsDBNull(Dr.GetOrdinal("ClaveM")) ? Dr.GetString(Dr.GetOrdinal("ClaveM")) : string.Empty;
                                    string NombreProductoM = !Dr.IsDBNull(Dr.GetOrdinal("ProductoM")) ? Dr.GetString(Dr.GetOrdinal("ProductoM")) : string.Empty;
                                    byte[] ImagenProductoM = (byte[])Dr.GetValue(Dr.GetOrdinal("ImagenProductoM"));
                                    string NombreImagenM = !Dr.IsDBNull(Dr.GetOrdinal("UrlImagenProductoM")) ? Dr.GetString(Dr.GetOrdinal("UrlImagenProductoM")) : string.Empty;
                                    string IDProductoN = !Dr.IsDBNull(Dr.GetOrdinal("id_productoGratis")) ? Dr.GetString(Dr.GetOrdinal("id_productoGratis")) : string.Empty;
                                    string ClaveN = !Dr.IsDBNull(Dr.GetOrdinal("ClaveN")) ? Dr.GetString(Dr.GetOrdinal("ClaveN")) : string.Empty;
                                    string NombreProductoN = !Dr.IsDBNull(Dr.GetOrdinal("ProductoN")) ? Dr.GetString(Dr.GetOrdinal("ProductoN")) : string.Empty;
                                    byte[] ImagenProductoN = (byte[])Dr.GetValue(Dr.GetOrdinal("ImagenProductoN"));
                                    string NombreImagenN = !Dr.IsDBNull(Dr.GetOrdinal("UrlImagenProductoN")) ? Dr.GetString(Dr.GetOrdinal("UrlImagenProductoN")) : string.Empty;

                                    Resultado.ProductoRequerido = new Producto { IDProducto = IDProductoM, NombreProducto = NombreProductoM, Imagen = ImagenProductoM, UrlImagen = NombreImagenM, Clave = ClaveM };
                                    Resultado.CantRequeridad = !Dr.IsDBNull(Dr.GetOrdinal("cantRequerida")) ? Dr.GetInt32(Dr.GetOrdinal("cantRequerida")) : 0;
                                    Resultado.ProductoGratis = new Producto { IDProducto = IDProductoN, NombreProducto1 = NombreProductoN, ImagenProductoN = ImagenProductoN, UrlImagenN = NombreImagenN, ClaveN = ClaveN };
                                    Resultado.CantGratis = !Dr.IsDBNull(Dr.GetOrdinal("cantGratis")) ? Dr.GetInt32(Dr.GetOrdinal("cantGratis")) : 0;
                                    if (Resultado.RequierePeriodo)
                                    {
                                        Resultado.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("fechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaInicio")) : DateTime.Today;
                                        Resultado.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("fechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaFin")) : DateTime.Today;
                                    }
                                    else
                                    {
                                        Resultado.Lunes = !Dr.IsDBNull(Dr.GetOrdinal("lunes")) ? Dr.GetBoolean(Dr.GetOrdinal("lunes")) : false;
                                        Resultado.Martes = !Dr.IsDBNull(Dr.GetOrdinal("martes")) ? Dr.GetBoolean(Dr.GetOrdinal("martes")) : false;
                                        Resultado.Miercoles = !Dr.IsDBNull(Dr.GetOrdinal("miercoles")) ? Dr.GetBoolean(Dr.GetOrdinal("miercoles")) : false;
                                        Resultado.Jueves = !Dr.IsDBNull(Dr.GetOrdinal("jueves")) ? Dr.GetBoolean(Dr.GetOrdinal("jueves")) : false;
                                        Resultado.Viernes = !Dr.IsDBNull(Dr.GetOrdinal("viernes")) ? Dr.GetBoolean(Dr.GetOrdinal("viernes")) : false;
                                        Resultado.Sabado = !Dr.IsDBNull(Dr.GetOrdinal("sabado")) ? Dr.GetBoolean(Dr.GetOrdinal("sabado")) : false;
                                        Resultado.Domingo = !Dr.IsDBNull(Dr.GetOrdinal("domingo")) ? Dr.GetBoolean(Dr.GetOrdinal("domingo")) : false;
                                    }
                                    break;
                            }
                        }
                        Dr.Close();
                        DataTable TablaAUx = Ds.Tables[1];
                        DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        List<Producto> Lista = new List<Producto>();
                        Producto Item;
                        while (Dr2.Read())
                        {
                            Item = new Producto();
                            Item.IDProducto = Dr2.GetString(Dr2.GetOrdinal("IDProducto"));
                            Item.Clave = Dr2.GetString(Dr2.GetOrdinal("Clave"));
                            Item.NombreProducto = Dr2.GetString(Dr2.GetOrdinal("NombreProducto"));
                            if (Convert.IsDBNull(Dr2.GetValue(Dr2.GetOrdinal("ImagenProducto"))))
                                Item.Imagen = new byte[0];
                            else
                                Item.Imagen = (byte[])Dr2["ImagenProducto"];
                            Item.UrlImagen = Dr2.GetString(Dr2.GetOrdinal("url_imagen"));
                            Lista.Add(Item);
                        }
                        Resultado.ListaProductos = Lista;
                        Dr2.Close();
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
