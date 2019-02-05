using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class CatalogoWeb
    {
        private string _IDImagen;

        public string IDImagen
        {
            get { return _IDImagen; }
            set { _IDImagen = value; }
        }

        private string _IDSucursal;

        public string IDSucursal
        {
            get { return _IDSucursal; }
            set { _IDSucursal = value; }
        }

        private string _Tag;

        public string Tag
        {
            get { return _Tag; }
            set { _Tag = value; }
        }

        private Image _Imagen;

        public Image Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }

        private Image _ImagenMin;

        public Image ImagenMin
        {
            get { return _ImagenMin; }
            set { _ImagenMin = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private byte[] _BufferImagen;

        public byte[] BufferImagen
        {
            get { return _BufferImagen; }
            set { _BufferImagen = value; }
        }

        private byte[] _BufferImagenMin;

        public byte[] BufferImagenMin
        {
            get { return _BufferImagenMin; }
            set { _BufferImagenMin = value; }
        }
        
        
        private string _Conexion;

        public string Conexion
        {
            get { return _Conexion; }
            set { _Conexion = value; }
        }

        private string _IDUsuario;

        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }

        private bool _Completado;

        public bool Completado
        {
            get { return _Completado; }
            set { _Completado = value; }
        }

        private DataTable _TablaDatos;

        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

        private Image _ImagenDGV;

        public Image ImagenDGV
        {
            get { return _ImagenDGV; }
            set { _ImagenDGV = value; }
        }

        private bool _NuevoRegistro;

        public bool NuevoRegistro
        {
            get { return _NuevoRegistro; }
            set { _NuevoRegistro = value; }
        }

        private bool _ModificarImagen;

        public bool ModificarImagen
        {
            get { return _ModificarImagen; }
            set { _ModificarImagen = value; }
        }

        private bool _PublicarImagen;

        public bool PublicarImagen
        {
            get { return _PublicarImagen; }
            set { _PublicarImagen = value; }
        }

        private string _Alt;

        public string Alt
        {
            get { return _Alt; }
            set { _Alt = value; }
        }

        private string _Title;

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _NombreArchivo;

        public string NombreArchivo
        {
            get { return _NombreArchivo; }
            set { _NombreArchivo = value; }
        }

        private string _TipoArchivo;

        public string TipoArchivo
        {
            get { return _TipoArchivo; }
            set { _TipoArchivo = value; }
        }

        private string _NombrePagina;

        public string NombrePagina
        {
            get { return _NombrePagina; }
            set { _NombrePagina = value; }
        }
        private string _IDProducto;

        public string IDProducto
        {
            get { return _IDProducto; }
            set { _IDProducto = value; }
        }

        private string _NombreServicio;
        public string UrlImagen;

        public string NombreServicio
        {
            get { return _NombreServicio; }
            set { _NombreServicio = value; }
        }
    }
}
