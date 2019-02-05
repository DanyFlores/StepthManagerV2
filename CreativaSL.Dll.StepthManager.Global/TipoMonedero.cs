using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class TipoMonedero
    {
        private bool _Completado;
        private string _Conexion;
        private string _Descripcion;
        private string _IDProducto;
        private string _IDProductoXTipoMonedero;
        private int _IDTipoMonedero;
        private string _IDUsuario;
        private int _Opcion;
        private decimal _Porcentaje;
        private bool _Seleccionado;
        private DataTable _TablaDatos;

        public bool Completado
        {
            get { return _Completado; }
            set { _Completado = value; }
        }
        public string Conexion
        {
            get { return _Conexion; }
            set { _Conexion = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public string IDProducto
        {
            get { return _IDProducto; }
            set { _IDProducto = value; }
        }
        public string IDProductoXTipoMonedero
        {
            get { return _IDProductoXTipoMonedero; }
            set { _IDProductoXTipoMonedero = value; }
        }
        public int IDTipoMonedero
        {
            get { return _IDTipoMonedero; }
            set { _IDTipoMonedero = value; }
        }
        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }
        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
        public decimal Porcentaje
        {
            get { return _Porcentaje; }
            set { _Porcentaje = value; }
        }
        public bool Seleccionado
        {
            get { return _Seleccionado; }
            set { _Seleccionado = value; }
        }
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

        private int _PuntosMinimos;

        public int PuntosMinimos
        {
            get { return _PuntosMinimos; }
            set { _PuntosMinimos = value; }
        }
        
    }
}
