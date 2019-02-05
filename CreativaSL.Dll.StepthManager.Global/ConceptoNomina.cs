using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class ConceptoNomina
    {
        private bool _Completado;
        private string _Conexion;
        private string _Descripcion;
        private string _IDUsuario;
        private int _Opcion;
        private bool _Seleccionado;
        private DataTable _TablaDatos;

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

        private int _IDConceptoNomina;

        public int IDConceptoNomina
        {
            get { return _IDConceptoNomina; }
            set { _IDConceptoNomina = value; }
        }

        private bool _Calculado;

        public bool Calculado
        {
            get { return _Calculado; }
            set { _Calculado = value; }
        }

        private bool _SumaResta;

        public bool SumaResta
        {
            get { return _SumaResta; }
            set { _SumaResta = value; }
        }

        private bool _SoloLectura;

        public bool SoloLectura
        {
            get { return _SoloLectura; }
            set { _SoloLectura = value; }
        }
    }
}
