using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Usuario
    {
        private bool _AbrirCaja;
        private string _ApellidoPat;
        private string _ApellidoMat;
        private bool _Bloqueada;
        private byte[] _BufferHuella;
        private bool _BuscarTodos;
        private bool _Completado;
        private string _Conexion;
        private bool _CrearIDCaja;
        private string _CuentaUsuario;
        private string _DirCalle;
        private string _DirColonia;
        private string _DirNumero;
        private DateTime _FechaBloqueo;
        private string _IDEmpleado;
        private string _IDUsuario;
        private string _IDSucursalActual;
        private int _IDTipoUsuario;
        private int _Intentos;
        private int _Opcion;
        private string _Password;
        private int _Resultado;
        private string _MensajeError;
        private string _Nombre;
        private DataTable _TablaDatos;
        private DataTable _TablaUsuarioSucursal;

        public bool AbrirCaja
        {
            get { return _AbrirCaja; }
            set { _AbrirCaja = value; }
        }
        public string ApellidoPat
        {
            get { return _ApellidoPat; }
            set { _ApellidoPat = value; }
        }
        public string ApellidoMat
        {
            get { return _ApellidoMat; }
            set { _ApellidoMat = value; }
        }
        public bool Bloqueada
        {
            get { return _Bloqueada; }
            set { _Bloqueada = value; }
        }
        public byte[] BufferHuella
        {
            get { return _BufferHuella; }
            set { _BufferHuella = value; }
        }
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
        public bool CrearIDCaja
        {
            get { return _CrearIDCaja; }
            set { _CrearIDCaja = value; }
        }
        public string CuentaUsuario
        {
            get { return _CuentaUsuario; }
            set { _CuentaUsuario = value; }
        }
        public string DirCalle
        {
            get { return _DirCalle; }
            set { _DirCalle = value; }
        }
        public string DirColonia
        {
            get { return _DirColonia; }
            set { _DirColonia = value; }
        }
        public string DirNumero
        {
            get { return _DirNumero; }
            set { _DirNumero = value; }
        }
        public DateTime FechaBloqueo
        {
            get { return _FechaBloqueo; }
            set { _FechaBloqueo = value; }
        }
        public string IDEmpleado
        {
            get { return _IDEmpleado; }
            set { _IDEmpleado = value; }
        }
        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }
        public string IDSucursalActual
        {
            get { return _IDSucursalActual; }
            set { _IDSucursalActual = value; }
        }
        public int IDTipoUsuario
        {
            get { return _IDTipoUsuario; }
            set { _IDTipoUsuario = value; }
        }
        public int Intentos
        {
            get { return _Intentos; }
            set { _Intentos = value; }
        }
        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public int Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }
        public string MensajeError
        {
            get { return _MensajeError; }
            set { _MensajeError = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }
        public DataTable TablaUsuarioSucursal
        {
            get { return _TablaUsuarioSucursal; }
            set { _TablaUsuarioSucursal = value; }
        }

        private string _HuellaString;

        public string HuellaString
        {
            get { return _HuellaString; }
            set { _HuellaString = value; }
        }


        private int _IDPuesto;

        public int IDPuesto
        {
            get { return _IDPuesto; }
            set { _IDPuesto = value; }
        }

        private string _IDCategoriaPuesto;

        public string IDCategoriaPuesto
        {
            get { return _IDCategoriaPuesto; }
            set { _IDCategoriaPuesto = value; }
        }

        private bool _IncluirSelect;

        public bool IncluirSelect
        {
            get { return _IncluirSelect; }
            set { _IncluirSelect = value; }
        }

        private DateTime _FechaAltaN;

        public DateTime FechaAltaN
        {
            get { return _FechaAltaN; }
            set { _FechaAltaN = value; }
        }

        private DateTime _FechaBajaN;

        public DateTime FechaBajaN
        {
            get { return _FechaBajaN; }
            set { _FechaBajaN = value; }
        }

        private int _IDMotivoBaja;

        public int IDMotivoBaja
        {
            get { return _IDMotivoBaja; }
            set { _IDMotivoBaja = value; }
        }

        private string _MotivoBaja;

        public string MotivoBaja
        {
            get { return _MotivoBaja; }
            set { _MotivoBaja = value; }
        }

        private string _ComentariosBaja;

        public string ComentariosBaja
        {
            get { return _ComentariosBaja; }
            set { _ComentariosBaja = value; }
        }

        private bool _AltaNominal;

        public bool AltaNominal
        {
            get { return _AltaNominal; }
            set { _AltaNominal = value; }
        }

        private int _IDTipoNomina;

        public int IDTipoNomina
        {
            get { return _IDTipoNomina; }
            set { _IDTipoNomina = value; }
        }

        private decimal _SueldoBase;

        public decimal SueldoBase
        {
            get { return _SueldoBase; }
            set { _SueldoBase = value; }
        }
        private string _IDVacaciones;

        public string IDVacaciones
        {
            get { return _IDVacaciones; }
            set { _IDVacaciones = value; }
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
