using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class TarjetaMonedero
    {
        private bool _Completado;
        private string _Conexion;
        private string _Descripcion;
        private string _Folio;
        private string _IDCliente;
        private string _IDTarjeta;
        private int _IDTipoMonedero;
        private string _IDUsuario;
        private string _NombreCliente;
        private int _NumVisitas;
        private int _Opcion;
        private decimal _Saldo;
        private DataTable _TablaDatos;
        private string _TipoMonederoDesc;
        private bool _Validada;


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
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public string Folio
        {
            get { return _Folio; }
            set { _Folio = value; }
        }
        public string IDCliente
        {
            get { return _IDCliente; }
            set { _IDCliente = value; }
        }
        public string IDTarjeta
        {
            get { return _IDTarjeta; }
            set { _IDTarjeta = value; }
        }
        public int IDTipoMonedero
        {
            get { return _IDTipoMonedero; }
            set { _IDTipoMonedero = value; }
        }
        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }
        public string NombreCliente
        {
            get { return _NombreCliente; }
            set { _NombreCliente = value; }
        }
        public int NumVisitas
        {
            get { return _NumVisitas; }
            set { _NumVisitas = value; }
        }
        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
        public decimal Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }
        public string TipoMonederoDesc
        {
            get { return _TipoMonederoDesc; }
            set { _TipoMonederoDesc = value; }
        }
        public bool Validada
        {
            get { return _Validada; }
            set { _Validada = value; }
        }
        
    }
}
