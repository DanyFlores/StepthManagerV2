using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class CatPais
    {
        private string _A2;
        private string _A3;
        private bool _Completado;
        private string _Conexion;
        private string _Descripcion;
        private int _IDPais;
        private string _IDUsuario;
        private int _Opcion;
        private DataTable _TablaDatos;

        public string A2
        {
            get { return _A2; }
            set { _A2 = value; }
        }
        public string A3
        {
            get { return _A3; }
            set { _A3 = value; }
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
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public int IDPais
        {
            get { return _IDPais; }
            set { _IDPais = value; }
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
    }
}
