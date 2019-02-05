using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Padecimiento
    {
        private bool _Completado;
        private int _Validar;
        private string _Conexion;
        private string _Descripcion;
        private string _IDCliente;
        private string _IDPadecimiento;
        private string _IDPadecimientoXCliente;
        private string _IDUsuario;
        private int _Opcion;
        private bool _Seleccionado;
        private DataTable _TablaDatos;

        public int Validar//agregue, zincri
        {
            get { return _Validar; }
            set { _Validar = value; }
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
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public string IDCliente
        {
            get { return _IDCliente; }
            set { _IDCliente = value; }
        }
        public string IDPadecimiento
        {
            get { return _IDPadecimiento; }
            set { _IDPadecimiento = value; }
        }
        public string IDPadecimientoXCliente
        {
            get { return _IDPadecimientoXCliente; }
            set { _IDPadecimientoXCliente = value; }
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

    }
}
