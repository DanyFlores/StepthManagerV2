using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Cliente
    {
        /// <summary>
        /// 
        /// </summary>
        private string _ApellidoMat;
        private string _ApellidoPat;
        private bool _BuscarTodos;
        private bool _Completado;
        private string _Conexion;
        private string _Correo;
        private string _Descripcion;
        private DateTime _FechaNac;
        private string _FolioTarjeta;
        private string _GeneroDesc;
        private string _IDCliente;
        private int _IDGenero;
        private string _IDTarjeta;
        private string _IDUsuario;
        private string _MensajeError;
        private string _Nombre;
        private int _Opcion;
        private int _Resultado;
        private decimal _SaldoMonedero;
        private bool _Seleccionado;
        private DataTable _TablaDatos;
        private DataTable _TablaPadecimientos;
        private DataTable _TablaTagsInteres;
        private string _Telefono;

        public string ApellidoMat
        {
            get { return _ApellidoMat; }
            set { _ApellidoMat = value; }
        }
        public string ApellidoPat
        {
            get { return _ApellidoPat; }
            set { _ApellidoPat = value; }
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
        public string Correo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public DateTime FechaNac
        {
            get { return _FechaNac; }
            set { _FechaNac = value; }
        }
        public string FolioTarjeta
        {
            get { return _FolioTarjeta; }
            set { _FolioTarjeta = value; }
        }
        public string GenereoDesc
        {
            get { return _GeneroDesc; }
            set { _GeneroDesc = value; }
        }
        public string IDCliente
        {
            get { return _IDCliente; }
            set { _IDCliente = value; }
        }
        public int IDGenero
        {
            get { return _IDGenero; }
            set { _IDGenero = value; }
        }
        public string IDTarjeta
        {
            get { return _IDTarjeta; }
            set { _IDTarjeta = value; }
        }
        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
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
        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
        public int Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }
        public decimal SaldoMonedero
        {
            get { return _SaldoMonedero; }
            set { _SaldoMonedero = value; }
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
        public DataTable TablaPadecimientos
        {
            get { return _TablaPadecimientos; }
            set { _TablaPadecimientos = value; }
        }
        public DataTable TablaTagsInteres
        {
            get { return _TablaTagsInteres; }
            set { _TablaTagsInteres = value; }
        }
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private bool _IncluirSelect;

        public bool IncluirSelect
        {
            get { return _IncluirSelect; }
            set { _IncluirSelect = value; }
        }

        private string _Observaciones;

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }


        private string _Recomendaciones;

        public string Recomendaciones
        {
            get { return _Recomendaciones; }
            set { _Recomendaciones = value; }
        }
        private List<Cliente> _ListaHistClientes;

        public List<Cliente> ListaHistClientes
        {
            get { return _ListaHistClientes; }
            set { _ListaHistClientes = value; }
        }

        private string _IDCita;

        public string IDCita
        {
            get { return _IDCita; }
            set { _IDCita = value; }
        }

        private string _IDServicio;

        public string IDServicio
        {
            get { return _IDServicio; }
            set { _IDServicio = value; }
        }
        private string _IDSucursal;

        public string IDSucursal
        {
            get { return _IDSucursal; }
            set { _IDSucursal = value; }
        }
        private string _NombreSucursal;

        public string NombreSucursal
        {
            get { return _NombreSucursal; }
            set { _NombreSucursal = value; }
        }
        private string _NombreServicio;

        public string NombreServicio
        {
            get { return _NombreServicio; }
            set { _NombreServicio = value; }
        }

        private string _IDEmpleado;

        public string IDEmpleado
        {
            get { return _IDEmpleado; }
            set { _IDEmpleado = value; }
        }
        private string _NombreEmpleado;

        public string NombreEmpleado
        {
            get { return _NombreEmpleado; }
            set { _NombreEmpleado = value; }
        }

        private string _IDVenta;

        public string IDVenta
        {
            get { return _IDVenta; }
            set { _IDVenta = value; }
        }

        private string _FolioVenta;

        public string FolioVenta
        {
            get { return _FolioVenta; }
            set { _FolioVenta = value; }
        }
        private decimal _Total;

        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private int _IDTipoVenta;

        public int IDTipoVenta
        {
            get { return _IDTipoVenta; }
            set { _IDTipoVenta = value; }
        }

        private string _TipoVenta;

        public string TipoVenta
        {
            get { return _TipoVenta; }
            set { _TipoVenta = value; }
        }
        private int _VisitasVentas;

        public int VisitasVentas
        {
            get { return _VisitasVentas; }
            set { _VisitasVentas = value; }
        }

        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        
        
    }
}
