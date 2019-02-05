using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class TipoVales
    {
        private bool _BuscarTodos;
        private bool _Completado;
        private string _Conexion;
        private string _Descripcion;
        private int _IDTipoVale;
        private string _IDUsuario;
        private bool _IncluirSelect;
        private bool _Monto;
        private bool _NxN;
        private bool _NxM;
        private string _MensajeError;
        private bool _NuevoRegistro;
        private int _Opcion;
        private bool _Porcentaje;
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
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public int IDTipoVale
        {
            get { return _IDTipoVale; }
            set { _IDTipoVale = value; }
        }
        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }
        public bool IncluirSelect
        {
            get { return _IncluirSelect; }
            set { _IncluirSelect = value; }
        }
        public bool Monto
        {
            get { return _Monto; }
            set { _Monto = value; }
        }
        public bool NxN
        {
            get { return _NxN; }
            set { _NxN = value; }
        }
        public bool NxM
        {
            get { return _NxM; }
            set { _NxM = value; }
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
        public bool Porcentaje
        {
            get { return _Porcentaje; }
            set { _Porcentaje = value; }
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

    }
}
