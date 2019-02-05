using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Pedido
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

        private string _IDPedido;

        public string IDPedido
        {
            get { return _IDPedido; }
            set { _IDPedido = value; }
        }

        private string _FolioPedido;

        public string FolioPedido
        {
            get { return _FolioPedido; }
            set { _FolioPedido = value; }
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

        private int _IDEstatus;

        public int IDEstatus
        {
            get { return _IDEstatus; }
            set { _IDEstatus = value; }
        }

        private string _Estatus;

        public string Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }

        private bool _Completo;

        public bool Completo
        {
            get { return _Completo; }
            set { _Completo = value; }
        }

        private DateTime _FechaPedido;

        public DateTime FechaPedido
        {
            get { return _FechaPedido; }
            set { _FechaPedido = value; }
        }

        private List<PedidoDetalle> _DetallePedido;

        public List<PedidoDetalle> DetallePedido
        {
            get { return _DetallePedido; }
            set { _DetallePedido = value; }
        }

        private bool _NuevoRegistro;

        public bool NuevoRegistro
        {
            get { return _NuevoRegistro; }
            set { _NuevoRegistro = value; }
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

        private bool _BuscarTodos;

        public bool BuscarTodos
        {
            get { return _BuscarTodos; }
            set { _BuscarTodos = value; }
        }

        private string _TextoBusqueda;

        public string TextoBusqueda
        {
            get { return _TextoBusqueda; }
            set { _TextoBusqueda = value; }
        }
        
    }
}
