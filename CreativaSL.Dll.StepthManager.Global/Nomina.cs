using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Nomina
    {
        private bool _Completado;
        private string _Conexion;
        private string _IDSucursal;
        private string _IDUsuario;
        private bool _IncluirSelect;
        private int _Opcion;
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
        public string IDSucursal
        {
            get { return _IDSucursal; }
            set { _IDSucursal = value; }
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
        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }
        private DataTable _TablaConceptosFijos;

        public DataTable TablaConceptosFijos
        {
            get { return _TablaConceptosFijos; }
            set { _TablaConceptosFijos = value; }
        }

        private DataTable _TablaConceptosVariables;

        public DataTable TablaConceptosVariables
        {
            get { return _TablaConceptosVariables; }
            set { _TablaConceptosVariables = value; }
        }
        
        private string _IDNomina;

        public string IDNomina
        {
            get { return _IDNomina; }
            set { _IDNomina = value; }
        }

        private DateTime _FechaInicio;

        public DateTime FechaInicio
        {
            get { return _FechaInicio; }
            set { _FechaInicio = value; }
        }

        private DateTime _FechaFin;

        public DateTime FechaFin
        {
            get { return _FechaFin; }
            set { _FechaFin = value; }
        }

        private bool _BandBusqFechas;

        public bool BandBusqFechas
        {
            get { return _BandBusqFechas; }
            set { _BandBusqFechas = value; }
        }

        private string _ClaveNomina;

        public string ClaveNomina
        {
            get { return _ClaveNomina; }
            set { _ClaveNomina = value; }
        }

        private bool _EsBusqueda;

        public bool EsBusqueda
        {
            get { return _EsBusqueda; }
            set { _EsBusqueda = value; }
        }
        

        private int _IDTipoNomina;

        public int IDTipoNomina
        {
            get { return _IDTipoNomina; }
            set { _IDTipoNomina = value; }
        }

        private string _IDEmpleado;

        public string IDEmpleado
        {
            get { return _IDEmpleado; }
            set { _IDEmpleado = value; }
        }

        private int _IDConcepto;

        public int IDConcepto
        {
            get { return _IDConcepto; }
            set { _IDConcepto = value; }
        }

        private string _ConceptoNomina;

        public string ConceptoNomina
        {
            get { return _ConceptoNomina; }
            set { _ConceptoNomina = value; }
        }

        private bool _EsFijo;

        public bool EsFijo
        {
            get { return _EsFijo; }
            set { _EsFijo = value; }
        }

        private decimal _Monto;

        public decimal Monto
        {
            get { return _Monto; }
            set { _Monto = value; }
        }

        private int _Resultado;

        public int Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }

        private string _IDConceptoNomina;

        public string IDConceptoNomina
        {
            get { return _IDConceptoNomina; }
            set { _IDConceptoNomina = value; }
        }

        private bool _BusqFolio;

        public bool BusqFolio
        {
            get { return _BusqFolio; }
            set { _BusqFolio = value; }
        }





        private int _DiasPeriodo;

        public int DiasPeriodo
        {
            get { return _DiasPeriodo; }
            set { _DiasPeriodo = value; }
        }

        private int _DiasLaborados;

        public int DiasLaborados
        {
            get { return _DiasLaborados; }
            set { _DiasLaborados = value; }
        }

        private int _DiasDescanso;

        public int DiasDescanso
        {
            get { return _DiasDescanso; }
            set { _DiasDescanso = value; }
        }

        private int _Faltas;

        public int Faltas
        {
            get { return _Faltas; }
            set { _Faltas = value; }
        }

        private int _DiasDescuentoFaltas;

        public int DiasDescuentoFaltas
        {
            get { return _DiasDescuentoFaltas; }
            set { _DiasDescuentoFaltas = value; }
        }

        private int _Retardos;

        public int Retardos
        {
            get { return _Retardos; }
            set { _Retardos = value; }
        }

        private int _FaltasRetardo;

        public int FaltasRetardo
        {
            get { return _FaltasRetardo; }
            set { _FaltasRetardo = value; }
        }

        private int _DiasDescuentoRetardos;

        public int DiasDescuentoRetardos
        {
            get { return _DiasDescuentoRetardos; }
            set { _DiasDescuentoRetardos = value; }
        }

        private int _DiasDescuentoTotales;

        public int DiasDescuentoTotales
        {
            get { return _DiasDescuentoTotales; }
            set { _DiasDescuentoTotales = value; }
        }

        private int _DiasFestivos;

        public int DiasFestivos
        {
            get { return _DiasFestivos; }
            set { _DiasFestivos = value; }
        }

        private int _DiasVacaciones;

        public int DiasVacaciones
        {
            get { return _DiasVacaciones; }
            set { _DiasVacaciones = value; }
        }

        private int _DiasDomingo;

        public int DiasDomingo
        {
            get { return _DiasDomingo; }
            set { _DiasDomingo = value; }
        }




        private decimal _Percepciones;

        public decimal Percepciones
        {
            get { return _Percepciones; }
            set { _Percepciones = value; }
        }

        private decimal _Deducciones;

        public decimal Deducciones
        {
            get { return _Deducciones; }
            set { _Deducciones = value; }
        }

        private decimal _Total;

        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private string _NombreEmpleado;

        public string NombreEmpleado
        {
            get { return _NombreEmpleado; }
            set { _NombreEmpleado = value; }
        }

        private string _PeriodoFechas;

        public string PeriodoFechas
        {
            get { return _PeriodoFechas; }
            set { _PeriodoFechas = value; }
        }


        private List<Nomina> _ListaNomina;

        public List<Nomina> ListaNomina
        {
            get { return _ListaNomina; }
            set { _ListaNomina = value; }
        }

        private List<Nomina> _ListaConceptos;

        public List<Nomina> ListaConceptos
        {
            get { return _ListaConceptos; }
            set { _ListaConceptos = value; }
        }

        private string _TipoNomina;

        public string TipoNomina
        {
            get { return _TipoNomina; }
            set { _TipoNomina = value; }    
        }

        private string _Simbolo;

        public string Simbolo
        {
            get { return _Simbolo; }
            set { _Simbolo = value; }
        }
        
    }
}
