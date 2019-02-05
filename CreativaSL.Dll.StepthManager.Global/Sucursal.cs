using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Sucursal
    {
        private bool _Completado;
        private string _Conexion;
        private string _CodigoPostal;
        private string _Direccion;
        private int _Dia;
        private TimeSpan _HoraEntrada;
        private TimeSpan _HoraSalida;
        private int _IDEmpresa;
        private string _IDSucursal;
        private int _IDTipoSucursal;
        private string _IDUsuario;
        private int _IDMunicipio;
        private int _IDEstado;
        private int _IDPais;
        private int _Opcion;
        private float _PorcentajeMonedero;
        private string _Telefono;
        private string _NombreSucursal;
        private string _NombreTipoSucursal;
        private DataTable _TablaDatos;
        private DataTable _TablaSucursalesHorario;


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
        public string CodigoPostal
        {
            get { return _CodigoPostal; }
            set { _CodigoPostal = value; }
        }
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        public int Dia
        {
            get { return _Dia; }
            set { _Dia = value; }
        }
        public TimeSpan HoraEntrada
        {
            get { return _HoraEntrada; }
            set { _HoraEntrada = value; }
        }
        public TimeSpan HoraSalida
        {
            get { return _HoraSalida; }
            set { _HoraSalida = value; }
        }
        public int IDEmpresa
        {
            get { return _IDEmpresa; }
            set { _IDEmpresa = value; }
        }
        public int IDTipoSucursal
        {
            get { return _IDTipoSucursal; }
            set { _IDTipoSucursal = value; }
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
        public int IDMunicipio
        {
            get { return _IDMunicipio; }
            set { _IDMunicipio = value; }
        }
        public int IDEstado
        {
            get { return _IDEstado; }
            set { _IDEstado = value; }
        }
        public int IDPais
        {
            get { return _IDPais; }
            set { _IDPais = value; }
        }

        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
        public float PorcentajeMonedero
        {
            get { return _PorcentajeMonedero; }
            set { _PorcentajeMonedero = value; }
        }
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        public string NombreSucursal
        {
            get { return _NombreSucursal; }
            set { _NombreSucursal = value; }
        }
        public string NombreTipoSucursal
        {
            get { return _NombreTipoSucursal; }
            set { _NombreTipoSucursal = value; }
        }
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }
        public DataTable TablaSucursalesHorario
        {
            get { return _TablaSucursalesHorario; }
            set { _TablaSucursalesHorario = value; }
        }

        private bool _IncluirSelect;
        public int Resultado;

        public bool IncluirSelect
        {
            get { return _IncluirSelect; }
            set { _IncluirSelect = value; }
        }
        private string _IDEmpleado;

        public string IDEmpleado
        {
            get { return _IDEmpleado; }
            set { _IDEmpleado = value; }
        }
        private string _rfc;

        public string rfc
        {
            get { return _rfc; }
            set { _rfc = value; }
        }
        private string _Representante;

        public string Representante
        {
            get { return _Representante; }
            set { _Representante = value; }
        }

        private string _RegimenFiscal;

        public string RegimenFiscal
        {
            get { return _RegimenFiscal; }
            set { _RegimenFiscal = value; }
        }

        private bool _Seleccionado;

        public bool Seleccionado
        {
            get { return _Seleccionado; }
            set { _Seleccionado = value; }
        }

    }
}
