using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class CategoriasPuesto
    {
        
        private bool _Completado;
        private string _Conexion;
        private string _Descripcion;
        private string _DescripcionPuesto;
        private string _IDCategoria;
        private int _IDPuesto;
        private string _IDUsuario;
        private bool _IncluirSelect;
        private int _Opcion;
        private decimal _SueldoBase;
        private DataTable _TablaDatos;
        private DataTable _TablaCategoria;

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
        public string DescripcionPuesto
        {
            get { return _DescripcionPuesto; }
            set { _DescripcionPuesto = value; }
        }
        public string IDCategoria
        {
            get { return _IDCategoria; }
            set { _IDCategoria = value; }
        }
        public int IDPuesto
        {
            get { return _IDPuesto; }
            set { _IDPuesto = value; }
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
        public decimal SueldoBase
        {
            get { return _SueldoBase; }
            set { _SueldoBase = value; }
        }
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }
        public DataTable TablaCategoria
        {
            get { return _TablaCategoria; }
            set { _TablaCategoria = value; }
        }
    }
}

