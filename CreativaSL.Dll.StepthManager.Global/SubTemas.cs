using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class SubTemas
    {
        private bool _BuscarTodos;
        private bool _Completado;
        private string _Conexion;
        private string _Descripcion;
        private string _IDSubTemas;
        private string _IDServicio;
        private string _IDTemaCurso;
        private string _IDUsuario;
        private string _NombreServicio;

        public string NombreServicio
        {
            get { return _NombreServicio; }
            set { _NombreServicio = value; }
        }
        
        private string _MensajeError;
        private List<SubTemas> _ListSubTema;
        private int _Opcion;
        private int _Resultado;
        private int _Horas;
        private bool _Seleccionado;
        private int _PraticasSugeridas;
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
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public string IDSubTemas
        {
            get { return _IDSubTemas; }
            set { _IDSubTemas = value; }
        }
        public string IDServicio
        {
            get { return _IDServicio; }
            set { _IDServicio = value; }
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
        public List<SubTemas> ListaSubTema
        {
            get { return _ListSubTema; }
            set { _ListSubTema = value; }
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
        public int PracticasSugeridas
        {
            get { return _PraticasSugeridas; }
            set { _PraticasSugeridas = value; }
        }
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }
       
       
    }
}
