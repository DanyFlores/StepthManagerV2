using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CreativaSL.Dll.StephManager.Global
{
    public class NotificacionesSistemas
    {
        private string _IDNotificacion;

        public string IDNotificacion
        {
            get { return _IDNotificacion; }
            set { _IDNotificacion = value; }
        }

        private string _IDSucursal;

        public string IDSucursal
        {
            get { return _IDSucursal; }
            set { _IDSucursal = value; }
        }

        private int _IDTipoNotificacion;

        public int IDTipoNotificacion
        {
            get { return _IDTipoNotificacion; }
            set { _IDTipoNotificacion = value; }
        }
        private DataTable _TablaNotificaciones;

        public DataTable TablaNotificaciones
        {
            get { return _TablaNotificaciones; }
            set { _TablaNotificaciones = value; }
        }

        private bool _Visto;

        public bool Visto
        {
            get { return _Visto; }
            set { _Visto = value; }
        }
        
        private bool _Completado;

        public bool Completado
        {
            get { return _Completado; }
            set { _Completado = value; }
        }
        private string _IDUsuario;

        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }
        private string _Conexion;

        public string Conexion
        {
            get { return _Conexion; }
            set { _Conexion = value; }
        }
        
    }
}
