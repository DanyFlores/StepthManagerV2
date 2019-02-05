using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Horario
    {
        private bool _BuscarTodos;
        private bool _Completado;
        private string _Conexion;
        private string _IDSucursal;
        private string _IDUsuario;
        private bool _IncluirSelect;
        private int _Opcion;
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

        private int _IDTurno;

        public int IDTurno
        {
            get { return _IDTurno; }
            set { _IDTurno = value; }
        }

        private string _NombreTurno;

        public string NombreTurno
        {
            get { return _NombreTurno; }
            set { _NombreTurno = value; }
        }

        private TimeSpan _HoraEntrada;

        public TimeSpan HoraEntrada
        {
            get { return _HoraEntrada; }
            set { _HoraEntrada = value; }
        }

        private TimeSpan _HoraSalida;

        public TimeSpan HoraSalida
        {
            get { return _HoraSalida; }
            set { _HoraSalida = value; }
        }

        private TimeSpan _InicioValidezEntrada;

        public TimeSpan InicioValidezEntrada
        {
            get { return _InicioValidezEntrada; }
            set { _InicioValidezEntrada = value; }
        }

        private TimeSpan _FinValidezEntrada;

        public TimeSpan FinValidezEntrada
        {
            get { return _FinValidezEntrada; }
            set { _FinValidezEntrada = value; }
        }

        private TimeSpan _InicioValidezSalida;

        public TimeSpan InicioValidezSalida
        {
            get { return _InicioValidezSalida; }
            set { _InicioValidezSalida = value; }
        }

        private TimeSpan _FinValidezSalida;

        public TimeSpan FinValidezSalida
        {
            get { return _FinValidezSalida; }
            set { _FinValidezSalida = value; }
        }

        private string _IDCicloDetalle;

        public string IDCicloDetalle
        {
            get { return _IDCicloDetalle; }
            set { _IDCicloDetalle = value; }
        }

        private string _NombreDia;

        public string NombreDia
        {
            get { return _NombreDia; }
            set { _NombreDia = value; }
        }

        private int _Consecutivo;

        public int Consecutivo
        {
            get { return _Consecutivo; }
            set { _Consecutivo = value; }
        }

        private string _IDCiclo;

        public string IDCiclo
        {
            get { return _IDCiclo; }
            set { _IDCiclo = value; }
        }

        private int _ToleranciaLlegadaTarde;

        public int ToleraciaLlegadaTarde
        {
            get { return _ToleranciaLlegadaTarde; }
            set { _ToleranciaLlegadaTarde = value; }
        }

        private int _ToleranciaSalidaTemprano;

        public int ToleranciaSalidaTemprano
        {
            get { return _ToleranciaSalidaTemprano; }
            set { _ToleranciaSalidaTemprano = value; }
        }

        private float _DiasDeTrabajo;

        public float DiasDeTrabajo
        {
            get { return _DiasDeTrabajo; }
            set { _DiasDeTrabajo = value; }
        }
        
    }
}
