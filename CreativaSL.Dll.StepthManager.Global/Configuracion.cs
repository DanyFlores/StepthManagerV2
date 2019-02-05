using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Configuracion
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


        private int _IDConfiguracion;

        public int IDConfiguracion
        {
            get { return _IDConfiguracion; }
            set { _IDConfiguracion = value; }
        }

        private int _IDEmpresa;

        public int IDEmpresa
        {
            get { return _IDEmpresa; }
            set { _IDEmpresa = value; }
        }

        private string _RazonSocial;

        public string RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; }
        }

        private string _NombreComercial;

        public string NombreComercial
        {
            get { return _NombreComercial; }
            set { _NombreComercial = value; }
        }

        private string _RFC;

        public string RFC
        {
            get { return _RFC; }
            set { _RFC = value; }
        }

        private string _Eslogan;

        public string Eslogan
        {
            get { return _Eslogan; }
            set { _Eslogan = value; }
        }

        private string _Representante;

        public string Representante
        {
            get { return _Representante; }
            set { _Representante = value; }
        }

        private string _NombreImagen;

        public string NombreImagen
        {
            get { return _NombreImagen; }
            set { _NombreImagen = value; }
        }

        private string _UrlLogo;

        public string UrlLogo
        {
            get { return _UrlLogo; }
            set { _UrlLogo = value; }
        }


        private byte[] _BufferImagen;

        public byte[] BufferImagen
        {
            get { return _BufferImagen; }
            set { _BufferImagen = value; }
        }

        private decimal _PorcentajeIva;

        public decimal PorcentajeIva
        {
            get { return _PorcentajeIva; }
            set { _PorcentajeIva = value; }
        }

        private DateTime _Fecha01;

        public DateTime Fecha01
        {
            get { return _Fecha01; }
            set { _Fecha01 = value; }
        }

        private DateTime _Fecha02;

        public DateTime Fecha02
        {
            get { return _Fecha02; }
            set { _Fecha02 = value; }
        }

        private DateTime _Fecha03;

        public DateTime Fecha03
        {
            get { return _Fecha03; }
            set { _Fecha03 = value; }
        }

        private bool _BandFecha01;

        public bool BandFecha01
        {
            get { return _BandFecha01; }
            set { _BandFecha01 = value; }
        }

        private bool _BandFecha02;

        public bool BandFecha02
        {
            get { return _BandFecha02; }
            set { _BandFecha02 = value; }
        }

        private bool _BandFecha03;

        public bool BandFecha03
        {
            get { return _BandFecha03; }
            set { _BandFecha03 = value; }
        }
        private bool _BandLogo;

        public bool BandLogo
        {
            get { return _BandLogo; }
            set { _BandLogo = value; }
        }

        private System.Drawing.Image _ImagenArchivo;

        public System.Drawing.Image ImagenArchivo
        {
            get { return _ImagenArchivo; }
            set { _ImagenArchivo = value; }
        }

        private string _DomicilioFiscal;

        public string DomicilioFiscal
        {
            get { return _DomicilioFiscal; }
            set { _DomicilioFiscal = value; }
        }

        private string _RegimenFiscal;

        public string RegimenFiscal
        {
            get { return _RegimenFiscal; }
            set { _RegimenFiscal = value; }
        }

        private string _TextoGarantia;

        public string TextoGarantia
        {
            get { return _TextoGarantia; }
            set { _TextoGarantia = value; }
        }
        private decimal _PagoDiasFestivos;

        public decimal PagoDiasFestivos
        {
            get { return _PagoDiasFestivos; }
            set { _PagoDiasFestivos = value; }
        }

        private decimal _PagoDiasVacaciones;

        public decimal PagoDiasVacaciones
        {
            get { return _PagoDiasVacaciones; }
            set { _PagoDiasVacaciones = value; }
        }
        private decimal _PagoDiasDomingo;

        public decimal PagoDiasDomingo
        {
            get { return _PagoDiasDomingo; }
            set { _PagoDiasDomingo = value; }
        }
        private int _FaltasRetardos;

        public int FaltasRetardos
        {
            get { return _FaltasRetardos; }
            set { _FaltasRetardos = value; }
        }
        private string _TextoTicket;

        public string TextoTicket
        {
            get { return _TextoTicket; }
            set { _TextoTicket = value; }
        }

        private bool _EsFechaCorte;

        public bool EsFechaCorte
        {
            get { return _EsFechaCorte; }
            set { _EsFechaCorte = value; }
        }

        private int _Resultado;

        public int Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }

        private decimal _DescCumpleaños;

        public decimal DescCumpleaños
        {
            get { return _DescCumpleaños; }
            set { _DescCumpleaños = value; }
        }

    }
}
