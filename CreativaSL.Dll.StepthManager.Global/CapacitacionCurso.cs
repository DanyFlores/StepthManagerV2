using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class CapacitacionCurso
    {
        private bool _Todos;

        public bool Todos
        {
            get { return _Todos; }
            set { _Todos = value; }
        }

        private bool _BuscarTodos;
        private bool _Completado;
        private string _Conexion;
        private string _IDCurso;
        private string _IDUsuario;   
        private string _NombreCapacitacion;
        private string _MensajeError;
        private int _Opcion;
        private int _Resultado;
        private bool _Seleccionado;
        private DataTable _TablaDatos;

        private DataTable _TablaCalificaciones;

        public DataTable TablaCalificaciones
        {
            get { return _TablaCalificaciones; }
            set { _TablaCalificaciones = value; }
        }
        

        private string _IDCapacitacion;

        public string IDCapacitacion
        {
            get { return _IDCapacitacion; }
            set { _IDCapacitacion = value; }
        }

        private string _IDInstructor;

        public string IDInstructor
        {
            get { return _IDInstructor; }
            set { _IDInstructor = value; }
        }

        private int _IDStatusCursos;

        public int IDStatusCursos
        {
            get { return _IDStatusCursos; }
            set { _IDStatusCursos = value; }
        }

        private string _Lugar;

        public string Lugar
        {
            get { return _Lugar; }
            set { _Lugar = value; }
        }

        private DateTime _FechaInicioCurso;

        public DateTime FechaInicioCurso
        {
            get { return _FechaInicioCurso; }
            set { _FechaInicioCurso = value; }
        }

        private DateTime _FechaFinCurso;

        public DateTime FechaFinCurso
        {
            get { return _FechaFinCurso; }
            set { _FechaFinCurso = value; }
        }
        
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
        public string NombreCapacitacion
        {
            get { return _NombreCapacitacion; }
            set { _NombreCapacitacion = value; }
        }

        private string _NombreEmpleado;

        public string NombreEmpleado
        {
            get { return _NombreEmpleado; }
            set { _NombreEmpleado = value; }
        }

        private float _Calificacion;

        public float Calificacion
        {
            get { return _Calificacion; }
            set { _Calificacion = value; }
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

        private bool _BusqFecha;

        public bool BusqFecha
        {
            get { return _BusqFecha; }
            set { _BusqFecha = value; }
        }

        private bool _BusqProveedor;

        public bool BusqProveedor
        {
            get { return _BusqProveedor; }
            set { _BusqProveedor = value; }
        }

        private DateTime _FechaBus;

        public DateTime FechaBus
        {
            get { return _FechaBus; }
            set { _FechaBus = value; }
        }

        private string _IDInscripcion;

        public string IDInscripcion
        {
            get { return _IDInscripcion; }
            set { _IDInscripcion = value; }
        }

        private string _IDCalificacion;

        public string IDCalificacion
        {
            get { return _IDCalificacion; }
            set { _IDCalificacion = value; }
        }

        private string _IDVenta;

        public string IDVenta
        {
            get { return _IDVenta; }
            set { _IDVenta = value; }
        }
        

        private string _IDEmpleado;

        public string IDEmpleado
        {
            get { return _IDEmpleado; }
            set { _IDEmpleado = value; }
        }

        private bool _Vigente;

        public bool Vigente
        {
            get { return _Vigente; }
            set { _Vigente = value; }
        }
        
    }
}
