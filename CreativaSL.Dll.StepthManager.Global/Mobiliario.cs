using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Mobiliario
    {
        private bool _Completado;
        private string _Conexion;
        private string _IDUsuario;
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
        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
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

        private string _IDMobiliario;

        public string IDMobiliario
        {
            get { return _IDMobiliario; }
            set { _IDMobiliario = value; }
        }

        private string _Codigo;

        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _Marca;

        public string Marca
        {
            get { return _Marca; }
            set { _Marca = value; }
        }

        private string _Modelo;

        public string Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }

        private int _Existencia;

        public int Existencia
        {
            get { return _Existencia; }
            set { _Existencia = value; }
        }

        private string _IDProveedor;

        public string IDProveedor
        {
            get { return _IDProveedor; }
            set { _IDProveedor = value; }
        }

        private bool _NuevoRegistro;

        public bool NuevoRegistro
        {
            get { return _NuevoRegistro; }
            set { _NuevoRegistro = value; }
        }

        private bool _BuscarTodos;

        public bool BuscarTodos
        {
            get { return _BuscarTodos; }
            set { _BuscarTodos = value; }
        }

        private int _Resultado;

        public int Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }

        private string _MensajeError;

        public string MensajeError
        {
            get { return _MensajeError; }
            set { _MensajeError = value; }
        }

        private decimal _Precio;

        public decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        private decimal _PrecioUSD;

        public decimal PrecioUSD
        {
            get { return _PrecioUSD; }
            set { _PrecioUSD = value; }
        }

        private decimal _Descuento;

        public decimal Descuento
        {
            get { return _Descuento; }
            set { _Descuento = value; }
        }

        private decimal _Iva;

        public decimal Iva
        {
            get { return _Iva; }
            set { _Iva = value; }
        }

        private decimal _IvaUnitario;

        public decimal IvaUnitario
        {
            get { return _IvaUnitario; }
            set { _IvaUnitario = value; }
        }

        private decimal _DescuentoUnitario;

        public decimal DescuentoUnitario
        {
            get { return _DescuentoUnitario; }
            set { _DescuentoUnitario = value; }
        }

        private decimal _Subtotal;

        public decimal Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }

        private decimal _Total;

        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private int _Cantidad;

        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        private string _IDTipoMobiliario;

        public string IDTipoMobiliario
        {
            get { return _IDTipoMobiliario; }
            set { _IDTipoMobiliario = value; }
        }

        private string _TipoMobiliarioDescripcion;

        public string TipoMobiliarioDescripcion
        {
            get { return _TipoMobiliarioDescripcion; }
            set { _TipoMobiliarioDescripcion = value; }
        }

        private string _IDSucursal;

        public string IDSucursal
        {
            get { return _IDSucursal; }
            set { _IDSucursal = value; }
        }

        private string _IDMobiliarioXSucursal;

        public string IDMobiliarioXSucursal
        {
            get { return _IDMobiliarioXSucursal; }
            set { _IDMobiliarioXSucursal = value; }
        }

        private string _NombreSucursal;

        public string NombreSucursal
        {
            get { return _NombreSucursal; }
            set { _NombreSucursal = value; }
        }

        private string _IDSucursalDest;

        public string IDSucursalDestino
        {
            get { return _IDSucursalDest; }
            set { _IDSucursalDest = value; }
        }
        
        
    }
}
