using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Checador
    {
        private bool _Completado;
        private string _Conexion;
        private DateTime _FechaChecador;
        private string _IDSucursal;
        private string _IDUsuario;
        private bool _IncluirSelect;
        private int _Opcion;
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
        public DateTime FechaChecador
        {
            get { return _FechaChecador; }
            set { _FechaChecador = value; }
        }
        public string IDSucursal
        {
            get { return _IDSucursal; }
            set { _IDSucursal = value; }
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
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }


        private string _IDEmpleado;

        public string IDEmpleado
        {
            get { return _IDEmpleado; }
            set { _IDEmpleado = value; }
        }

        private int _IDTipoRegistro;

        public int IDTipoRegistro
        {
            get { return _IDTipoRegistro; }
            set { _IDTipoRegistro = value; }
        }

        private string _Motivo;

        public string Motivo
        {
            get { return _Motivo; }
            set { _Motivo = value; }
        }

        private bool _DispChecador;

        public bool DispChecador
        {
            get { return _DispChecador; }
            set { _DispChecador = value; }
        }

        private string _IDRegistro;

        public string IDRegistro
        {
            get { return _IDRegistro; }
            set { _IDRegistro = value; }
        }

        private int _IDStatusRegistro;

        public int IDStatusRegistro
        {
            get { return _IDStatusRegistro; }
            set { _IDStatusRegistro = value; }
        }

        private DateTime _FechaInicio;

        public DateTime FechaInicio
        {
            get { return _FechaInicio; }
            set { _FechaInicio = value; }
        }

        private DateTime _FechaFin;

        public DateTime FechaFin
        {
            get { return _FechaFin; }
            set { _FechaFin = value; }
        }
        
    }
}
