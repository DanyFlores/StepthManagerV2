using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Pregunta
    {
        private bool _BuscarTodos;
        private int _CantRespuestas;
        private bool _Completado;
        private string _Conexion;
        private bool _EsRequerida;
        private string _Titulo;
        private string _IDEncuesta;
        private string _IDPregunta;
        private int _IDTipoPregunta;
        private string _IDUsuario;
        private List<Respuesta> _ListaRespuestas;
        private int _Opcion;
        private bool _RequiereRespuestas;
        private DataTable _TablaDatos;
        private string _TipoPreguntaDesc;

        public bool BuscarTodos
        {
            get { return _BuscarTodos; }
            set { _BuscarTodos = value; }
        }
        public int CantRespuestas
        {
            get { return _CantRespuestas; }
            set { _CantRespuestas = value; }
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
        public bool EsRequerida
        {
            get { return _EsRequerida; }
            set { _EsRequerida = value; }
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
        public string IDPregunta
        {
            get { return _IDPregunta; }
            set { _IDPregunta = value; }
        }
        public int IDTipoPregunta
        {
            get { return _IDTipoPregunta; }
            set { _IDTipoPregunta = value; }
        }
        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }
        public List<Respuesta> ListaRespuestas
        {
            get { return _ListaRespuestas; }
            set { _ListaRespuestas = value; }
        }
        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
        public bool RequiereRespuestas
        {
            get { return _RequiereRespuestas; }
            set { _RequiereRespuestas = value; }
        }
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }
        public string TipoPreguntaDesc
        {
            get { return _TipoPreguntaDesc; }
            set { _TipoPreguntaDesc = value; }
        }


        private DataTable _TablaRespuestas;

        public DataTable TablaRespuestas
        {
            get { return _TablaRespuestas; }
            set { _TablaRespuestas = value; }
        }

        private bool _OpcionMultiple;

        public bool OpcionMultiple
        {
            get { return _OpcionMultiple; }
            set { _OpcionMultiple = value; }
        }
        
    }
}
