using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class TipoChechkList
    {
        private bool _BuscarTodos;
        private bool _Completado;
        private string _Conexion;
        private string _Descripcion;
        private int _IDTipoCheckList;
        private string _IDUsuario;
        private bool _IncluirSelect;
        private int _Opcion;
        private bool _OpcionMultiple;
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
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public int IDTipoCheckList
        {
            get { return _IDTipoCheckList; }
            set { _IDTipoCheckList = value; }
        }
        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }
        public bool IncluirSelect
        {
            get { return _IncluirSelect; }
            set { _IncluirSelect = value; }
        }
        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
        public bool OpcionMultiple
        {
            get { return _OpcionMultiple; }
            set { _OpcionMultiple = value; }
        }
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

    }
}
