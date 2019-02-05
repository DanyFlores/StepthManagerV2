using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class TemasCurso
    {
        private bool _BuscarTodos;
        private bool _Completado;
        private string _Conexion;
        private string _Descripcion;
        private string _IDTemaXCurso;

        public string IDTemaXCurso
        {
            get { return _IDTemaXCurso; }
            set { _IDTemaXCurso = value; }
        }
        private string _IDCurso;

        public string IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }
        private string _IDTema;

        public string IDTema
        {
            get { return _IDTema; }
            set { _IDTema = value; }
        }
        
        
        private string _IDTemaCurso;
        private string _IDUsuario;
        private string _MensajeError;
        private int _Opcion;
        private int _Resultado;
        private int _Horas;
        private bool _Seleccionado;
        private DataTable _TablaDatos;
        private DataTable _TablaSubTemas;
  
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
       
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public string IDTemaCurso
        {
            get { return _IDTemaCurso; }
            set { _IDTemaCurso = value; }
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
        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
       
        public int Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }
        public int Horas
        {
            get { return _Horas; }
            set { _Horas = value; }
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
        public DataTable TablaSubTemas
        {
            get { return _TablaSubTemas; }
            set { _TablaSubTemas = value; }
        }

        
        
    }
}
