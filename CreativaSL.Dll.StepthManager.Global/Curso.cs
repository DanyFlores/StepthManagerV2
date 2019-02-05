using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Curso
    {
        private bool _BuscarTodos;
        private bool _Completado;
        private string _Conexion;
        private decimal _CalificacionMinAprobatoria;
        private string _Descripcion;
        private string _IDCurso;
        private string _IDUsuario;   
        private string _Nombre;
        private string _MensajeError;
        private int _Opcion;
        private string _ObjetivoGeneral;
        private int _Resultado;
        private int _Horas;
        private bool _Seleccionado;
        private DataTable _TablaDatos;
        private DataTable _TablaTema;
  
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
        public decimal CalificacionMinAprobatoria
        {
            get { return _CalificacionMinAprobatoria; }
            set { _CalificacionMinAprobatoria = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public string IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
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
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
        public string ObjetivoGeneral
        {
            get { return _ObjetivoGeneral; }
            set { _ObjetivoGeneral = value; }
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
        public DataTable TablaTema
        {
            get { return _TablaTema; }
            set { _TablaTema = value; }
        }

        private bool _IncluirSelect;

        public bool IncluirSelect
        {
            get { return _IncluirSelect; }
            set { _IncluirSelect = value; }
        }
        
    }
}
