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
    public class CatalogoWeb_Datos
    {
        public List<CatalogoWeb> ObtenerCatalogoWeb(CatalogoWeb Datos)
        {
            try
            {
                List<CatalogoWeb> Lista = new List<CatalogoWeb>();
                CatalogoWeb Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_CatalogoWebXIDSucPublicarImagen");
                while (Dr.Read())
                {
                    Item = new CatalogoWeb();
                    Item.IDImagen = Dr.GetString(Dr.GetOrdinal("IDImagen"));
                    Item.IDSucursal = Dr.GetString(Dr.GetOrdinal("IDSucursal"));
                    Item.Tag = Dr.GetString(Dr.GetOrdinal("Tag"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.Alt = Dr.GetString(Dr.GetOrdinal("Alt"));
                    Item.Title = Dr.GetString(Dr.GetOrdinal("Title"));
                    Item.NombreArchivo = Dr.GetString(Dr.GetOrdinal("NombreArchivo"));
                    Item.TipoArchivo = Dr.GetString(Dr.GetOrdinal("TipoArchivo"));
                    Item.NombrePagina = Dr.GetString(Dr.GetOrdinal("NombrePagina"));
                    Item.PublicarImagen = Dr.GetBoolean(Dr.GetOrdinal("PublicarImagen"));
                    Item.IDProducto = Dr.GetString(Dr.GetOrdinal("IDProducto"));
                    Item.NombreServicio = Dr.GetString(Dr.GetOrdinal("NombreServicio"));
                    if (Convert.IsDBNull(Dr.GetValue(Dr.GetOrdinal("ImagenMin"))))
                        Item.BufferImagen = new byte[0];
                    else
                        Item.BufferImagen = (byte[])Dr["ImagenMin"];
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

        public List<CatalogoWeb> ObtenerCatalogoWebBusq(CatalogoWeb Datos)
        {
            try
            {
                List<CatalogoWeb> Lista = new List<CatalogoWeb>();
                CatalogoWeb Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_CatalogoWebXIDSucBusqPublicarImagen", Datos.Tag);
                while (Dr.Read())
                {
                    Item = new CatalogoWeb();
                    Item.IDImagen = Dr.GetString(Dr.GetOrdinal("IDImagen"));
                    Item.IDSucursal = Dr.GetString(Dr.GetOrdinal("IDSucursal"));
                    Item.Tag = Dr.GetString(Dr.GetOrdinal("Tag"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.Alt = Dr.GetString(Dr.GetOrdinal("Alt"));
                    Item.Title = Dr.GetString(Dr.GetOrdinal("Title"));
                    Item.NombreArchivo = Dr.GetString(Dr.GetOrdinal("NombreArchivo"));
                    Item.TipoArchivo = Dr.GetString(Dr.GetOrdinal("TipoArchivo"));
                    Item.NombrePagina = Dr.GetString(Dr.GetOrdinal("NombrePagina"));
                    Item.PublicarImagen = Dr.GetBoolean(Dr.GetOrdinal("PublicarImagen"));
                    Item.IDProducto = Dr.GetString(Dr.GetOrdinal("IDProducto"));
                    Item.NombreServicio = Dr.GetString(Dr.GetOrdinal("NombreServicio"));
                    if (Convert.IsDBNull(Dr.GetValue(Dr.GetOrdinal("ImagenMin"))))
                        Item.BufferImagen = new byte[0];
                    else
                        Item.BufferImagen = (byte[])Dr["ImagenMin"];
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

        public void EliminarCatalogoWeb(CatalogoWeb Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_del_EliminarImagenCatWeb", Datos.IDImagen, Datos.IDUsuario);
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

        public void AprobarImagenWeb(CatalogoWeb Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_del_AprobarImagenCatWeb", Datos.IDImagen, Datos.UrlImagen, Datos.IDUsuario);
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

        public void ACCatalogoWeb(CatalogoWeb Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDImagen, Datos.IDSucursal, Datos.Tag, Datos.ModificarImagen, Datos.BufferImagen, Datos.BufferImagenMin, Datos.Descripcion,
                                        Datos.Alt, Datos.Title, Datos.NombreArchivo, Datos.TipoArchivo, Datos.NombrePagina, Datos.IDProducto, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_ac_CatalogoWebPublicarImagen", Parametros);
                if (Result != null)
                {
                    string ID = Result.ToString();
                    if (Datos.NuevoRegistro)
                        Datos.IDImagen = ID;
                    Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GuardarImagen(CatalogoWeb Datos)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(Datos.Conexion, "spCSLDB_set_Prueba", Datos.BufferImagen);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
