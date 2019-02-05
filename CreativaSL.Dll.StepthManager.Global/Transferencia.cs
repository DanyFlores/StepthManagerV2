using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Transferencia
    {
        private bool _BuscarTodos;
        private bool _Completado;
        private string _Conexion;
        private string _IDUsuario;
        private int _Opcion;
        private DataTable _TablaDatos;
        
        public bool BuscarTodos
        {
            get { return _BuscarTodos; }
            set { _BuscarTodos = value; }
        }
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
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }


        private string _IDProducto;

        public string IDProducto
        {
            get { return _IDProducto; }
            set { _IDProducto = value; }
        }

        private string _IDSucursalOrigen;

        public string IDSucursalOrigen
        {
            get { return _IDSucursalOrigen; }
            set { _IDSucursalOrigen = value; }
        }

        private string _IDSucursalDestino;

        public string IDSucursalDestino
        {
            get { return _IDSucursalDestino; }
            set { _IDSucursalDestino = value; }
        }

        private decimal _Cantidad;

        public decimal Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        private int _Resultado;

        public int Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }
        
        
    }
}