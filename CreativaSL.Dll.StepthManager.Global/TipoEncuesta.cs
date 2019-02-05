using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class TipoEncuesta
    {
        private bool _BuscarTodos;
        private bool _Completado;
        private string _Conexion;
        private string _Descripcion;
        private int _IDTipoEncuesta;
        private string _IDUsuario;
        private bool _IncluirSelect;
        private int _Opcion;
        private bool _RequierePeriodo;
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
        public int IDTipoEncuesta
        {
            get { return _IDTipoEncuesta; }
            set { _IDTipoEncuesta = value; }
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
        public bool RequierePeriodo
        {
            get { return _RequierePeriodo; }
            set { _RequierePeriodo = value; }
        }
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

    }
}
