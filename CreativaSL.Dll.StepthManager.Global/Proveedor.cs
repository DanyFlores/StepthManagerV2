using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CreativaSL.Dll.StephManager.Global
{
    public class Proveedor
    {
        private bool _IncluirSelect;

        public bool IncluirSelect
        {
            get { return _IncluirSelect; }
            set { _IncluirSelect = value; }
        }
        
        private bool _Completado;
        private string _Conexion;
        private string _Correo;
        private decimal _CostoUltimo;
        private string _CodigoPostal;
        private string _Direccion;
        private string _DirCalle;
        private string _DirColonia;
        private string _DirNumero;
        private string _IDProductoXProveedor;
        private string _IDProveedor;
        private int _IDPais;
        private int _IDEstado;
        private int _IDMunicipio;
        private string _IDUsuario;
        private string _MensajeError;
        private string _NombreComercial;
        private int _Opcion;
        private string _RazonSocial;
        private string _Representante;
        private string _RegimenFiscal;
        private int _Resultado;
        private string _RFC;
        private bool _Seleccionado;
        private DataTable _TablaDatos;
        private string _Telefono;

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
        public decimal CostoUltimo
        {
            get { return _CostoUltimo; }
            set { _CostoUltimo = value; }
        }
        public string CodigoPostal
        {
            get { return _CodigoPostal; }
            set { _CodigoPostal = value; }
        }
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
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
        
        public string IDProductoXProveedor
        {
            get { return _IDProductoXProveedor; }
            set { _IDProductoXProveedor = value; }
        }
        public string IDProveedor
        {
            get { return _IDProveedor; }
            set { _IDProveedor = value; }
        }
        public int IDPais
        {
            get { return _IDPais; }
            set { _IDPais = value; }
        }
        public int IDEstado
        {
            get { return _IDEstado; }
            set { _IDEstado = value; }
        }
        public int IDMunicipio
        {
            get { return _IDMunicipio; }
            set { _IDMunicipio = value; }
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
        public string NombreComercial
        {
            get { return _NombreComercial; }
            set { _NombreComercial = value; }
        }
        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
        public string RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; }
        }
        public string Representante
        {
            get { return _Representante; }
            set { _Representante = value; }
        }
        public string RegimenFiscal
        {
            get { return _RegimenFiscal; }
            set { _RegimenFiscal = value; }
        }
        public int Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }
        public string RFC
        {
            get { return _RFC; }
            set { _RFC = value; }
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
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private bool _Mobiliario;

        public bool Mobiliario
        {
            get { return _Mobiliario; }
            set { _Mobiliario = value; }
        }
        
    }
}
