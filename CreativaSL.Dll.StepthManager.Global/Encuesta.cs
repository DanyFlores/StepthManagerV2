using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Encuesta
    {
        private bool _BuscarTodos;
        private bool _Completado;
        private string _Conexion;
        private DateTime _FechaFin;
        private DateTime _FechaInicio;
        private string _Titulo;
        private string _IDEncuesta;
        private int _IDTipoEncuesta;
        private string _IDUsuario;
        private decimal _Incentivo;
        private List<Pregunta> _ListaPreguntas;
        private string _MensajeError;
        private bool _NuevoRegistro;
        private int _Opcion;        
        private bool _RequierePeriodo;
        private bool _SoloVigentes;
        private DataTable _TablaDatos;
        private DataTable _TablaPreguntas;
        private DataTable _TablaRespuestas;
        private string _TipoEncuestaDesc;

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
        public DateTime FechaFin
        {
            get { return _FechaFin; }
            set { _FechaFin = value; }
        }
        public DateTime FechaInicio
        {
            get { return _FechaInicio; }
            set { _FechaInicio = value; }
        }
        public string Titulo
        {
            get { return _Titulo; }
            set { _Titulo = value; }
        }
        public string IDEncuesta
        {
            get { return _IDEncuesta; }
            set { _IDEncuesta = value; }
        }
        public int IDTipoEncuesta
        {
            get { return _IDTipoEncuesta; }
            set { _IDTipoEncuesta = value; }
        }
        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }
        public decimal Incentivo
        {
            get { return _Incentivo; }
            set { _Incentivo = value; }
        }
        public List<Pregunta> ListaPreguntas
        {
            get { return _ListaPreguntas; }
            set { _ListaPreguntas = value; }
        }
        public string MensajeError
        {
            get { return _MensajeError; }
            set { _MensajeError = value; }
        }
        public bool NuevoRegistro
        {
            get { return _NuevoRegistro; }
            set { _NuevoRegistro = value; }
        }
        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
        public bool RequierePeriodo
        {
            get { return _RequierePeriodo; }
            set { _RequierePeriodo = value; }
        }
        public bool SoloVigentes
        {
            get { return _SoloVigentes; }
            set { _SoloVigentes = value; }
        }
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }
        public DataTable TablaPreguntas
        {
            get { return _TablaPreguntas; }
            set { _TablaPreguntas = value; }
        }
        public DataTable TablaRespuestas
        {
            get { return _TablaRespuestas; }
            set { _TablaRespuestas = value; }
        }
        public string TipoEncuestaDesc
        {
            get { return _TipoEncuestaDesc; }
            set { _TipoEncuestaDesc = value; }
        }

        private int _IDEstatusEncuesta;

        public int IDEstatusEncuesta
        {
            get { return _IDEstatusEncuesta; }
            set { _IDEstatusEncuesta = value; }
        }

        private string _EstatusEncuesta;
    
        public string EstatusEncuesta
        {
            get { return _EstatusEncuesta; }
            set { _EstatusEncuesta = value; }
        }

        private DataTable _tablaNotificaciones;

        public DataTable tablaNotificaciones
        {
            get { return _tablaNotificaciones; }
            set { _tablaNotificaciones = value; }
        }
        private int _Resultado;

        public int Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }
        
    }
}
