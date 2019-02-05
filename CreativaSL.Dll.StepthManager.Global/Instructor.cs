using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Instructor
    {
        private string _ApellidoMat;
        private string _ApellidoPat;
        private bool _BuscarTodos;
        private bool _Completado;
        private string _Conexion;
        private string _Correo;
        private DateTime _FechaNac;
        private int _IDGenero;
        private string _IDUsuario;
        private string _MensajeError;
        private string _Nombre;
        private int _Opcion;
        private int _Resultado;
        private DataTable _TablaDatos;
        private string _Telefono;

        private string _IDInstructor;

        public string IDInstructor
        {
            get { return _IDInstructor; }
            set { _IDInstructor = value; }
        }
        

        public string ApellidoMat
        {
            get { return _ApellidoMat; }
            set { _ApellidoMat = value; }
        }
        public string ApellidoPat
        {
            get { return _ApellidoPat; }
            set { _ApellidoPat = value; }
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
        public string Correo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }
        public DateTime FechaNac
        {
            get { return _FechaNac; }
            set { _FechaNac = value; }
        }
        public int IDGenero
        {
            get { return _IDGenero; }
            set { _IDGenero = value; }
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
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private bool _IncluirSelect;

        public bool IncluirSelect
        {
            get { return _IncluirSelect; }
            set { _IncluirSelect = value; }
        }

        
    }
}
