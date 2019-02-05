using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class PagoCompra
    {
        private bool _BuscarTodos;
        private bool _Completado;
        private string _Conexion;
        private string _IDSucursal;
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

        private string _IDCompra;

        public string IDCompra
        {
            get { return _IDCompra; }
            set { _IDCompra = value; }
        }

        private int _NumPago;

        public int NumPago
        {
            get { return _NumPago; }
            set { _NumPago = value; }
        }

        private DateTime _FechaPago;

        public DateTime FechaPago
        {
            get { return _FechaPago; }
            set { _FechaPago = value; }
        }

        private decimal _MontoPago;

        public decimal MontoPago
        {
            get { return _MontoPago; }
            set { _MontoPago = value; }
        }

        private string _IDEmpleado;

        public string IDEmpleado
        {
            get { return _IDEmpleado; }
            set { _IDEmpleado = value; }
        }

        private bool _NuevoRegistro;

        public bool NuevoRegistro
        {
            get { return _NuevoRegistro; }
            set { _NuevoRegistro = value; }
        }

        private string _IDPagoCompra;

        public string IDPagoCompra
        {
            get { return _IDPagoCompra; }
            set { _IDPagoCompra = value; }
        }

        private string _IDCajaXSucursal;

        public string IDCajaXSucursal
        {
            get { return _IDCajaXSucursal; }
            set { _IDCajaXSucursal = value; }
        }
        
    }
}
