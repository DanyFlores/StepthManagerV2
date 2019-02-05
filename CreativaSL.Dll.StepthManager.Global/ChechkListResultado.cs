using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class ChechkListResultado
    {
        private bool _BuscarTodos;
        private bool _Completado;
        private string _Conexion;
        private string _IDUsuario;
        private bool _IncluirSelect;
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
        private string _Titulo;

        public string Titulo
        {
            get { return _Titulo; }
            set { _Titulo = value; }
        }
        private string _IDCheckList;

        public string IDCheckList
        {
            get { return _IDCheckList; }
            set { _IDCheckList = value; }
        }
        private string _IDResultado;

        public string IDResultado
        {
            get { return _IDResultado; }
            set { _IDResultado = value; }
        }
        private string _IDSucursal;

        public string IDSucursal
        {
            get { return _IDSucursal; }
            set { _IDSucursal = value; }
        }
        private string _IDEmpleado;

        public string IDEmpleado
        {
            get { return _IDEmpleado; }
            set { _IDEmpleado = value; }
        }
        private DateTime _FechaAplicacion;

        public DateTime FechaAplicacion
        {
            get { return _FechaAplicacion; }
            set { _FechaAplicacion = value; }
        }
        private string _NombreEmpleado;

        public string NombreEmpleado
        {
            get { return _NombreEmpleado; }
            set { _NombreEmpleado = value; }
        }
        private string _NombreSucursal;

        public string NombreSucursal
        {
            get { return _NombreSucursal; }
            set { _NombreSucursal = value; }
        }
        private string _HoraAplicacion;

        public string HoraAplicacion
        {
            get { return _HoraAplicacion; }
            set { _HoraAplicacion = value; }
        }
        private string _Responsable;

        public string Responsable
        {
            get { return _Responsable; }
            set { _Responsable = value; }
        }
        private string _TipoCategoria;

        public string TipoCategoria
        {
            get { return _TipoCategoria; }
            set { _TipoCategoria = value; }
        }
        private string _NombreActividad;

        public string NombreActividad
        {
            get { return _NombreActividad; }
            set { _NombreActividad = value; }
        }
        private string _Observaciones;

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }
        private string _Seguimiento;

        public string Seguimiento
        {
            get { return _Seguimiento; }
            set { _Seguimiento = value; }
        }
        
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }
        private int _IDActiviadCheck;

        public int IDActvidadCheck
        {
            get { return _IDActiviadCheck; }
            set { _IDActiviadCheck = value; }
        }
        private int _IDCategoriaCheck;

        public int IDCategoriaCheck
        {
            get { return _IDCategoriaCheck; }
            set { _IDCategoriaCheck = value; }
        }
        private int _IDActividadOpciones;

        public int IDActividadOpciones
        {
            get { return _IDActividadOpciones; }
            set { _IDActividadOpciones = value; }
        }
        private int _IDOpcionSeleccionado;

        public int IDOpcionSeleccionado
        {
            get { return _IDOpcionSeleccionado; }
            set { _IDOpcionSeleccionado = value; }
        }
        private int _OrdenActividad;

        public int OrdenActividad
        {
            get { return _OrdenActividad; }
            set { _OrdenActividad = value; }
        }
        private string _NombreCategoria;

        public string NombreCategoria
        {
            get { return _NombreCategoria; }
            set { _NombreCategoria = value; }
        }
        private int _OrdenCategoria;

        public int OrdenCategoria
        {
            get { return _OrdenCategoria; }
            set { _OrdenCategoria = value; }
        }
        private string _TituloCheckList;

        public string TituloCheckList
        {
            get { return _TituloCheckList; }
            set { _TituloCheckList = value; }
        }
        
    }
}
