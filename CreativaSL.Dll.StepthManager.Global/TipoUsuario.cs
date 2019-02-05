using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class TipoUsuario
    {
        private bool _Completado;
        private string _Conexion;
        private string _Descripcion;
        private int _IDTipoUsuario;
        private string _IDUsuario;
        private int _Opcion;
        private DataTable _TablaDatos;
        public int Resultado;

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
        public int IDTipoUsuario
        {
            get { return _IDTipoUsuario; }
            set { _IDTipoUsuario = value; }
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
    }
}
