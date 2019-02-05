using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class DiasFestivos
    {
       
        private bool _BuscarTodos;
        private bool _Completado;
        private string _Conexion;
      
        private DateTime _Fecha;
       
        private string _IDUsuario;
        private string _MensajeError;
    
        private int _Opcion;
        private int _Resultado;
        private DataTable _TablaDatos;

        private string _IDDiasFestivos;

        public string IDDiasFestivos
        {
            get { return _IDDiasFestivos; }
            set { _IDDiasFestivos = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
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
        
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
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
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }
       
        private bool _IncluirSelect;

        public bool IncluirSelect
        {
            get { return _IncluirSelect; }
            set { _IncluirSelect = value; }
        }

        
    }
}
