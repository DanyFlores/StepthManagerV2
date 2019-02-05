using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Respuesta
    {
        private bool _BuscarTodos;
        private bool _Completado;
        private string _Conexion;
        private string _TextoRespuesta;
        private string _IDPregunta;
        private string _IDRespuesta;
        private string _IDUsuario;
        private int _Opcion;
        private DataTable _TablaDatos;
        public bool BuscarTodos
        {
            get { return _BuscarTodos; }
            set { _BuscarTodos = value; }
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
        public string Titulo
        {
            get { return _TextoRespuesta; }
            set { _TextoRespuesta = value; }
        }
        public string IDPregunta
        {
            get { return _IDPregunta; }
            set { _IDPregunta = value; }
        }
        public string IDRespuesta
        {
            get { return _IDRespuesta; }
            set { _IDRespuesta = value; }
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
