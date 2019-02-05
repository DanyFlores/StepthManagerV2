using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class MobiliarioResguardo
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

        private DataTable _TablaMobiliarioResguardo;

        public DataTable TablaMobiliarioResguardo
        {
            get { return _TablaMobiliarioResguardo; }
            set { _TablaMobiliarioResguardo = value; }
        }
        
        private string _IDMobiliarioResguardo;

        public string IDMobiliarioResguardo
        {
            get { return _IDMobiliarioResguardo; }
            set { _IDMobiliarioResguardo = value; }
        }

        private string _IDMobiliario;

        public string IDMobiliario
        {
            get { return _IDMobiliario; }
            set { _IDMobiliario = value; }
        }

        private DateTime _FechaResguardo;

        public DateTime FechaResguardo
        {
            get { return _FechaResguardo; }
            set { _FechaResguardo = value; }
        }
        private string _Codigo;

        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        

        private string _FolioResguardo;

        public string FolioResguardo
        {
            get { return _FolioResguardo; }
            set { _FolioResguardo = value; }
        }

        private int _IDStatusMobiliario;

        public int IDStatusMobiliario
        {
            get { return _IDStatusMobiliario; }
            set { _IDStatusMobiliario = value; }
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

        private string _IDSucursalEquipo;

        public string IDSucursalEquipo
        {
            get { return _IDSucursalEquipo; }
            set { _IDSucursalEquipo = value; }
        }


        private string _IDMobiliarioDetalle;

        public string IDMobiliarioDetalle
        {
            get { return _IDMobiliarioDetalle; }
            set { _IDMobiliarioDetalle = value; }
        }

        private List<MobiliarioResguardo> _ListaMobiliarioDetalle;

        public List<MobiliarioResguardo> ListaMobiliarioDetalle
        {
            get { return _ListaMobiliarioDetalle; }
            set { _ListaMobiliarioDetalle = value; }
        }

        public string IDSucursal { get; set; }


        public object NombreSucursal { get; set; }

        public object NombreEstatus { get; set; }
    }
}
