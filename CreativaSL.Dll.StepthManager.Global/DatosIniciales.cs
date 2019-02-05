using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class DatosIniciales
    {
        private bool _Completado;
        private string _CuentaUsuario;
        private string _Conexion;
        private int _IDProyecto;
        private string _NombreSucursal;
        private int _Opcion;
        private string _Password;
        private string _RazonSocial;

        public bool Completado
        {
            get { return _Completado; }
            set { _Completado = value; }
        }
        public string CuentaUsuario
        {
            get { return _CuentaUsuario; }
            set { _CuentaUsuario = value; }
        }
        public string Conexion
        {
            get { return _Conexion; }
            set { _Conexion = value; }
        }
        public int IDProyecto
        {
            get { return _IDProyecto; }
            set { _IDProyecto = value; }
        }
        public string NombreSucursal
        {
            get { return _NombreSucursal; }
            set { _NombreSucursal = value; }
        }
        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public string RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; }
        }
    }
}
