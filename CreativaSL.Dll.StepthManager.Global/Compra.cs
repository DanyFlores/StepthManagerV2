using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Compra
    {
        private decimal _Subtotal;

        public decimal Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }

        private decimal _Iva;

        public decimal Iva
        {
            get { return _Iva; }
            set { _Iva = value; }
        }

        private decimal _Descuento;

        public decimal Descuento
        {
            get { return _Descuento; }
            set { _Descuento = value; }
        }

        private decimal _Total;

        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private string _IDCompra;

        public string IDCompra
        {
            get { return _IDCompra; }
            set { _IDCompra = value; }
        }

        private int _IDEstatusCompra;

        public int IDEstatusCompra
        {
            get { return _IDEstatusCompra; }
            set { _IDEstatusCompra = value; }
        }

        private string _IDProveedor;

        public string IDProveedor
        {
            get { return _IDProveedor; }
            set { _IDProveedor = value; }
        }

        private string _IDSucursal;

        public string IDSucursal
        {
            get { return _IDSucursal; }
            set { _IDSucursal = value; }
        }

        private string _RazonSocial;

        public string RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; }
        }

        private string _RFC;

        public string RFC
        {
            get { return _RFC; }
            set { _RFC = value; }
        }

        private string _DomicilioFiscal;

        public string DomicilioFiscal
        {
            get { return _DomicilioFiscal; }
            set { _DomicilioFiscal = value; }
        }

        private string _NumFactura;

        public string NumFactura
        {
            get { return _NumFactura; }
            set { _NumFactura = value; }
        }

        private string _RegimenFiscal;

        public string RegimenFiscal
        {
            get { return _RegimenFiscal; }
            set { _RegimenFiscal = value; }
        }

        private string _FolioFiscal;

        public string FolioFiscal
        {
            get { return _FolioFiscal; }
            set { _FolioFiscal = value; }
        }


        private string _NoSerieCertSAT;

        public string NoSerieCertSAT
        {
            get { return _NoSerieCertSAT; }
            set { _NoSerieCertSAT = value; }
        }

        private DateTime _FechaHoraCertificacion;

        public DateTime FechaHoraCertificacion
        {
            get { return _FechaHoraCertificacion; }
            set { _FechaHoraCertificacion = value; }
        }

        private string _NoSerieCertEmisor;

        public string NoSerieCertEmisor
        {
            get { return _NoSerieCertEmisor; }
            set { _NoSerieCertEmisor = value; }
        }

        private DateTime _FechaEmision;

        public DateTime FechaEmision
        {
            get { return _FechaEmision; }
            set { _FechaEmision = value; }
        }

        private string _LugarExpedicion;

        public string LugarExpedicion
        {
            get { return _LugarExpedicion; }
            set { _LugarExpedicion = value; }
        }

        private string _TotalLetras;

        public string TotalLetras
        {
            get { return _TotalLetras; }
            set { _TotalLetras = value; }
        }

        private DataTable _TablaProductos;

        public DataTable TablaProductos
        {
            get { return _TablaProductos; }
            set { _TablaProductos = value; }
        }
        

        private bool _Completado;

        public bool Completado
        {
            get { return _Completado; }
            set { _Completado = value; }
        }

        private string _Conexion;

        public string Conexion
        {
            get { return _Conexion; }
            set { _Conexion = value; }
        }

        private string _IDUsuario;

        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }

        private int _Resultado;

        public int Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }

        private bool _NuevoRegistro;

        public bool NuevoRegistro
        {
            get { return _NuevoRegistro; }
            set { _NuevoRegistro = value; }
        }

        private string _MensajeError;

        public string MensajeError
        {
            get { return _MensajeError; }
            set { _MensajeError = value; }
        }

        private DataTable _TablaDatos;

        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }


        private bool _Todos;

        public bool Todos
        {
            get { return _Todos; }
            set { _Todos = value; }
        }


        private bool _BusqFecha;

        public bool BusqFecha
        {
            get { return _BusqFecha; }
            set { _BusqFecha = value; }
        }

        private bool _BusqNumFactura;

        public bool BusqNumFactura
        {
            get { return _BusqNumFactura; }
            set { _BusqNumFactura = value; }
        }

        private bool _BusqProveedor;

        public bool BusqProveedor
        {
            get { return _BusqProveedor; }
            set { _BusqProveedor = value; }
        }

        private List<Producto> _ListaProductos;

        public List<Producto> ListaProductos
        {
            get { return _ListaProductos; }
            set { _ListaProductos = value; }
        }

        private List<Mobiliario> _ListaMobiliario;

        public List<Mobiliario> ListaMobiliario
        {
            get { return _ListaMobiliario; }
            set { _ListaMobiliario = value; }
        }

        private decimal _MontoPendiente;

        public decimal MontoPendiente
        {
            get { return _MontoPendiente; }
            set { _MontoPendiente = value; }
        }
        

    }
}
