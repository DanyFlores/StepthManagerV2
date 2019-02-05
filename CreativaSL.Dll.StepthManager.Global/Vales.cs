using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Vales
    {
        private bool _Abierto;
        private bool _BuscarTodos;
        private bool _Completado; 
        private string _Conexion;
        private int _CantLimite;
        private int _CantValesAplicados;
        private int _CantRequeridad;
        private int _CantGratis;
        private int _CantidadRequeridaNxN;
        private int _CantidadGratisNxN;
        private string _Folio;
        private DateTime _FechaInicio;
        private DateTime _FechaFin;
        private string _IDVale;
        private int _IDTipoVale;
        private string _IDProductoNxN;
        private string _IDProductoRequerido;
        private string _IDProductoGratis;
        private string _IDUsuario;
        private decimal _Monto;
        private string _MensajeError;
        private string _Nombre;
        private string _NombreTipoVale;

        public string NombreTipoVale
        {
            get { return _NombreTipoVale; }
            set { _NombreTipoVale = value; }
        }
        
        private bool _Lunes;
        private bool _Martes;
        private bool _Miercoles;
        private bool _Jueves;
        private bool _Viernes;
        private bool _Sabado;
        private bool _Domingo;
        private bool _NuevoRegistro;
        private int _Opcion;
        private decimal _Porcentaje;
        private int _Resultado;
        private bool _RangoFechas;
        private bool _RequierePeriodo;
        private bool _SoloVigentes;
        private DataTable _TablaDatos;

        
        public bool Abierto
        {
            get { return _Abierto; }
            set { _Abierto = value; }
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
        public int CantLimite
        {
            get { return _CantLimite; }
            set { _CantLimite = value; }
        }
        public int CantValesAplicados
        {
            get { return _CantValesAplicados; }
            set { _CantValesAplicados = value; }
        }
        public int CantRequeridad
        {
            get { return _CantRequeridad; }
            set { _CantRequeridad = value; }
        }
        public int CantGratis
        {
            get { return _CantGratis; }
            set { _CantGratis = value; }
        }
        public int CantidadRequeridaNxN
        {
            get { return _CantidadRequeridaNxN; }
            set { _CantidadRequeridaNxN = value; }
        }
        public int CantidadGratisNxN
        {
            get { return _CantidadGratisNxN; }
            set { _CantidadGratisNxN = value; }
        }
        public string Folio
        {
            get { return _Folio; }
            set { _Folio = value; }
        }
        public DateTime FechaInicio
        {
            get { return _FechaInicio; }
            set { _FechaInicio = value; }
        }
        public DateTime FechaFin
        {
            get { return _FechaFin; }
            set { _FechaFin = value; }
        }
        public string IDVale
        {
            get { return _IDVale; }
            set { _IDVale = value; }
        }
        public int IDTipoVale
        {
            get { return _IDTipoVale; }
            set { _IDTipoVale = value; }
        }
        public string IDProductoNxN
        {
            get { return _IDProductoNxN; }
            set { _IDProductoNxN = value; }
        }
        public string IDProductoRequerido
        {
            get { return _IDProductoRequerido; }
            set { _IDProductoRequerido = value; }
        }
        public string IDProductoGratis
        {
            get { return _IDProductoGratis; }
            set { _IDProductoGratis = value; }
        }
        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }
        public decimal Monto
        {
            get { return _Monto; }
            set { _Monto = value; }
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
        public bool Lunes
        {
            get { return _Lunes; }
            set { _Lunes = value; }
        }
        public bool Martes
        {
            get { return _Martes; }
            set { _Martes = value; }
        }
        public bool Miercoles
        {
            get { return _Miercoles; }
            set { _Miercoles = value; }
        }
        public bool Jueves
        {
            get { return _Jueves; }
            set { _Jueves = value; }
        }
        public bool Viernes
        {
            get { return _Viernes; }
            set { _Viernes = value; }
        }
        public bool Sabado
        {
            get { return _Sabado; }
            set { _Sabado = value; }
        }
        public bool Domingo
        {
            get { return _Domingo; }
            set { _Domingo = value; }
        }
        public bool NuevoRegistro
        {
            get { return _NuevoRegistro; }
            set { _NuevoRegistro = value; }
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
        public int Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }
        public bool RangoFechas
        {
            get { return _RangoFechas; }
            set { _RangoFechas = value; }
        }
        public bool RequierePeriodo
        {
            get { return _RequierePeriodo; }
            set { _RequierePeriodo = value; }
        }
        public bool SoloVigentes
        {
            get { return _SoloVigentes; }
            set { _SoloVigentes = value; }
        }
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

        private int _IDEstatusVale;

        public int IDEstatusVale
        {
            get { return _IDEstatusVale; }
            set { _IDEstatusVale = value; }
        }

        private string _EstatusValeDesc;

        public string EstatusValeDesc
        {
            get { return _EstatusValeDesc; }
            set { _EstatusValeDesc = value; }
        }


        private int _TabVales;

        public int TabVales
        {
            get { return _TabVales; }
            set { _TabVales = value; }
        }

        private Producto _ProductoRequerido;

        public Producto ProductoRequerido
        {
            get { return _ProductoRequerido; }
            set { _ProductoRequerido = value; }
        }

        private Producto _ProductoGratis;

        public Producto ProductoGratis
        {
            get { return _ProductoGratis; }
            set { _ProductoGratis = value; }
        }

        private List<Producto> _ListaProductos;

        public List<Producto> ListaProductos
        {
            get { return _ListaProductos; }
            set { _ListaProductos = value; }
        }

        private string _IDValesXClientes;

        public string IDValesXClientes
        {
            get { return _IDValesXClientes; }
            set { _IDValesXClientes = value; }
        }

        private string _IDCliente;

        public string IDCliente
        {
            get { return _IDCliente; }
            set { _IDCliente = value; }
        }

        private string _NombreCliente;

        public string NombreCliente
        {
            get { return _NombreCliente; }
            set { _NombreCliente = value; }
        }

        private string _Correo;

        public string Correo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }

        private string _AsusntoVales;
        
        public string AsusntoVales
        {
            get { return _AsusntoVales; }
            set { _AsusntoVales = value; }
        }
        private DataTable _tablaNotificaciones;

        public DataTable tablaNotificaciones
        {
            get { return _tablaNotificaciones; }
            set { _tablaNotificaciones = value; }
        }
        
    }
}
