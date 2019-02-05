using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Cita
    {
        private bool _Completado;
        private string _Conexion;
        private string _IDUsuario;
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
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }


        private string _IDCita;

        public string IDCita
        {
            get { return _IDCita; }
            set { _IDCita = value; }
        }

        private bool _BusqSucursal;

        public bool BusqSucursal
        {
            get { return _BusqSucursal; }
            set { _BusqSucursal = value; }
        }

        private bool _BusqFechaCita;

        public bool BusqFechaCita
        {
            get { return _BusqFechaCita; }
            set { _BusqFechaCita = value; }
        }

        private bool _BusqCliente;

        public bool BusqCliente
        {
            get { return _BusqCliente; }
            set { _BusqCliente = value; }
        }

        private string _IDSucursal;

        public string IDSucursal
        {
            get { return _IDSucursal; }
            set { _IDSucursal = value; }
        }

        private DateTime _FechaCita;

        public DateTime FechaCita
        {
            get { return _FechaCita; }
            set { _FechaCita = value; }
        }

        private string _NombreCliente;

        public string NombreCliente
        {
            get { return _NombreCliente; }
            set { _NombreCliente = value; }
        }

        private string _IDCliente;

        public string IDCliente
        {
            get { return _IDCliente; }
            set { _IDCliente = value; }
        }

        private string _NombreSucursal;

        public string NombreSucursal
        {
            get { return _NombreSucursal; }
            set { _NombreSucursal = value; }
        }

        private string _IDEmpleado;

        public string IDEmpleado
        {
            get { return _IDEmpleado; }
            set { _IDEmpleado = value; }
        }

        private string _NombreEmpleado;

        public string NombreEmpleado
        {
            get { return _NombreEmpleado; }
            set { _NombreEmpleado = value; }
        }

        private string _HoraCita;

        public string HoraCita
        {
            get { return _HoraCita; }
            set { _HoraCita = value; }
        }

        private int _IDStatusCita;

        public int IDStatusCita
        {
            get { return _IDStatusCita; }
            set { _IDStatusCita = value; }
        }

        private string _EstatusCita;

        public string EstatusCita
        {
            get { return _EstatusCita; }
            set { _EstatusCita = value; }
        }

        private string _Observaciones;

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        private string _IDEmpleadoAtendio;

        public string IDEmpleadoAtendio
        {
            get { return _IDEmpleadoAtendio; }
            set { _IDEmpleadoAtendio = value; }
        }

        private string _EmpleadoAtendio;

        public string EmpleadoAtendio
        {
            get { return _EmpleadoAtendio; }
            set { _EmpleadoAtendio = value; }
        }

        private string _FechaHoraAtencion;

        public string FechaHoraAtencion
        {
            get { return _FechaHoraAtencion; }
            set { _FechaHoraAtencion = value; }
        }

        private string _IDEmpleadoCancela;

        public string IDEmpleadoCancela
        {
            get { return _IDEmpleadoCancela; }
            set { _IDEmpleadoCancela = value; }
        }

        private string _EmpleadoCancela;

        public string EmpleadoCancela
        {
            get { return _EmpleadoCancela; }
            set { _EmpleadoCancela = value; }
        }

        private string _FechaHoraCancelacion;

        public string FechaHoraCancelacion
        {
            get { return _FechaHoraCancelacion; }
            set { _FechaHoraCancelacion = value; }
        }

        private string _MotivoCancelacion;

        public string MotivoCancelacion
        {
            get { return _MotivoCancelacion; }
            set { _MotivoCancelacion = value; }
        }

        private int _IDHorario;

        public int IDHorario
        {
            get { return _IDHorario; }
            set { _IDHorario = value; }
        }

        private TimeSpan _HoraInicio;

        public TimeSpan HoraInicio
        {
            get { return _HoraInicio; }
            set { _HoraInicio = value; }
        }

        private TimeSpan _HoraFin;

        public TimeSpan HoraFin
        {
            get { return _HoraFin; }
            set { _HoraFin = value; }
        }

        private bool _HorarioLibre;

        public bool HorarioLibre
        {
            get { return _HorarioLibre; }
            set { _HorarioLibre = value; }
        }

        private string _IDServicio;

        public string IDServicio
        {
            get { return _IDServicio; }
            set { _IDServicio = value; }
        }

        private int _Periodos;

        public int Periodos
        {
            get { return _Periodos; }
            set { _Periodos = value; }
        }

        private string _Comentarios;
       
        public string Comentarios
        {
            get { return _Comentarios; }
            set { _Comentarios = value; }
        }

        private DataTable _tablaNotificaciones;

        public DataTable tablaNotificaciones
        {
            get { return _tablaNotificaciones; }
            set { _tablaNotificaciones = value; }
        }
    }
}
