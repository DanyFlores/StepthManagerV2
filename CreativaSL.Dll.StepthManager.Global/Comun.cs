using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Comun
    {
        private static string _Conexion;
        private static string _HostName;
        private static string _IDCaja;
        private static string _IDCajaCat;
        private static int _IDProyecto;
        private static string _IDSucursalCaja;
        private static string _IDUsuario;
        private static string _MACAddress;
        private static string _MensajeError;
        private static string _Sistema;
        private static DataTable _TablaPermisos;

        public static string Conexion
        {
            get { return _Conexion; }
            set { _Conexion = value; }
        }
        public static string HostName
        {
            get { return _HostName; }
            set { _HostName = value; }
        }
        public static string IDCaja
        {
            get { return _IDCaja; }
            set { _IDCaja = value; }
        }
        public static string IDCajaCat
        {
            get { return _IDCajaCat; }
            set { _IDCajaCat = value; }
        }
        public static int IDProyecto
        {
            get { return _IDProyecto; }
            set { _IDProyecto = value; }
        }
        public static string IDSucursalCaja
        {
            get { return _IDSucursalCaja; }
            set { _IDSucursalCaja = value; }
        }
        public static string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }
        public static string MACAddress
        {
            get { return _MACAddress; }
            set { _MACAddress = value; }
        }
        public static string MensajeError
        {
            get { return _MensajeError; }
            set { _MensajeError = value; }
        }
        public static string Sistema
        {
            get { return _Sistema; }
            set { _Sistema = value; }
        }
        public static DataTable TablaPermisos
        {
            get { return _TablaPermisos; }
            set { _TablaPermisos = value; }
        }


        private static bool _CajaAbierta;

        public static bool CajaAbierta
        {
            get { return _CajaAbierta; }
            set { _CajaAbierta = value; }
        }
        

        private static string _NombreUsuario;

        public static string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }

        private static string _ApellidoPatUsuario;

        public static string ApellidoPatUsuario
        {
            get { return _ApellidoPatUsuario; }
            set { _ApellidoPatUsuario = value; }
        }

        private static string _ApellidoMatUsuario;

        public static string ApellidoMatUsuario
        {
            get { return _ApellidoMatUsuario; }
            set { _ApellidoMatUsuario = value; }
        }

        private static int _IDTipoUsuario;

        public static int IDTipoUsuario
        {
            get { return _IDTipoUsuario; }
            set { _IDTipoUsuario = value; }
        }

        private static bool _CuentaBloqueada;

        public static bool CuentaBloqueada
        {
            get { return _CuentaBloqueada; }
            set { _CuentaBloqueada = value; }
        }

        private static string _Impresora;

        public static string Impresora
        {
            get { return _Impresora; }
            set { _Impresora = value; }
        }

        private static string _CuentaUsuario;

        public static string CuentaUsuario
        {
            get { return _CuentaUsuario; }
            set { _CuentaUsuario = value; }
        }

        private static string _RazonSocial;

        public static string RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; }
        }

        private static string _RFC;

        public static string RFC
        {
            get { return _RFC; }
            set { _RFC = value; }
        }

        private static string _Direccion;

        public static string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        private static string _UrlLogo;

        public static string UrlLogo
        {
            get { return _UrlLogo; }
            set { _UrlLogo = value; }
        }

        public static string RemoverSignosAcentos(string texto)
        {
            const string ConSignos = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜçÇ";
            const string SinSignos = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUcC";
            string textoSinAcentos = string.Empty;

            foreach (var caracter in texto)
            {
                var indexConAcento = ConSignos.IndexOf(caracter);
                if (indexConAcento > -1)
                    textoSinAcentos = textoSinAcentos + (SinSignos.Substring(indexConAcento, 1));
                else
                    textoSinAcentos = textoSinAcentos + (caracter);
            }
            textoSinAcentos = textoSinAcentos.Replace(" ", "-");
            textoSinAcentos = textoSinAcentos.ToLower();
            return textoSinAcentos;
        }

        public static string RemoverAcentos(string texto)
        {
            const string ConSignos = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜçÇ";
            const string SinSignos = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUcC";
            string textoSinAcentos = string.Empty;

            foreach (var caracter in texto)
            {
                var indexConAcento = ConSignos.IndexOf(caracter);
                if (indexConAcento > -1)
                    textoSinAcentos = textoSinAcentos + (SinSignos.Substring(indexConAcento, 1));
                else
                    textoSinAcentos = textoSinAcentos + (caracter);
            }
            textoSinAcentos = textoSinAcentos.Replace(" ", "-");
            textoSinAcentos = textoSinAcentos.ToLower();
            return textoSinAcentos;
        }




        private static string _NombreComercial;

        public static string NombreComercial
        {
            get { return _NombreComercial; }
            set { _NombreComercial = value; }
        }

        private static string _Empleado;

        public static string Empleado
        {
            get { return _Empleado; }
            set { _Empleado = value; }
        }

        private static string _Sucursal;

        public static string Sucursal
        {
            get { return _Sucursal; }
            set { _Sucursal = value; }
        }

        private static string _RegimenFiscal;

        public static string RegimenFiscal
        {
            get { return _RegimenFiscal; }
            set { _RegimenFiscal = value; }
        }

        private static string _Eslogan;

        public static string Eslogan
        {
            get { return _Eslogan; }
            set { _Eslogan = value; }
        }

        private static string _DomicilioFiscal;

        public static string DomicilioFiscal
        {
            get { return _DomicilioFiscal; }
            set { _DomicilioFiscal = value; }
        }


        private static bool _FaltaLogo;

        public static bool FaltaLogo
        {
            get { return _FaltaLogo; }
            set { _FaltaLogo = value; }
        }
        
        public static string UrlTxtLog { get; set; }

        private static DataTable _TablaNotificaciones;

        public static DataTable TablaNotificaciones
        {
            get { return _TablaNotificaciones; }
            set { _TablaNotificaciones = value; }
        }
    }
}
