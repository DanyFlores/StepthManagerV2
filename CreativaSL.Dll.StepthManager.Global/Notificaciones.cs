using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Notificaciones
    {

        private bool _Completado;
        private string _Conexion;
        private string _Descripcion;
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
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
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

        private string _IDNotificaciones;

        public string IDNotificaciones
        {
            get { return _IDNotificaciones; }
            set { _IDNotificaciones = value; }
        }

        private int _IDTipoNotificaciones;

        public int IDTipoNotificaciones
        {
            get { return _IDTipoNotificaciones; }
            set { _IDTipoNotificaciones = value; }
        }

        private string _NombreNotificaciones;

        public string NombreNotificaciones
        {
            get { return _NombreNotificaciones; }
            set { _NombreNotificaciones = value; }
        }

        private string _DescripcionNotificacion;

        public string DescripcionNotificacion
        {
            get { return _DescripcionNotificacion; }
            set { _DescripcionNotificacion = value; }
        }

        private bool _EnviarNotificacion;

        public bool EnviarNotificacion
        {
            get { return _EnviarNotificacion; }
            set { _EnviarNotificacion = value; }
        }
        private bool _IndividualGrupo;

        public bool IndividualGrupo
        {
            get { return _IndividualGrupo; }
            set { _IndividualGrupo = value; }
        }
        private string _IDCliente;

        public string IDCliente
        {
            get { return _IDCliente; }
            set { _IDCliente = value; }
        }
        private string _IDNivelEntrega;

        public string IDNivelEntrega
        {
            get { return _IDNivelEntrega; }
            set { _IDNivelEntrega = value; }
        }

        private bool _Todos;

        public bool Todos
        {
            get { return _Todos; }
            set { _Todos = value; }
        }

        private DataTable _tablaNotificaciones;

        public DataTable tablaNotificaciones
        {
            get { return _tablaNotificaciones; }
            set { _tablaNotificaciones = value; }
        }

        private DateTime _FechaBusq = DateTime.Now;

        public DateTime FechaBusq
        {
            get { return _FechaBusq; }
            set { _FechaBusq = value; }
        }

        private DateTime _FechaBusq2 = DateTime.Now;

        public DateTime FechaBusq2
        {
            get { return _FechaBusq2; }
            set { _FechaBusq2 = value; }
        }
        
        private bool _BusqNotificaciones;

        public bool BusqNotificaciones
        {
            get { return _BusqNotificaciones; }
            set { _BusqNotificaciones = value; }
        }

        private bool _BusqFechas;
        public int Resultado;

        public bool BusqFechas
        {
            get { return _BusqFechas; }
            set { _BusqFechas = value; }
        }
        
       
    }
}
