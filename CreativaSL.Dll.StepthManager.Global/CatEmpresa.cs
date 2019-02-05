using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class CatEmpresa
    {
        private bool _Completado;
        private string _Conexion;
        private string _CorreoElectronico;
        private string _IDEmpresa;
        private string _IDUsuario;
        private string _Instagram;
        private string _Facebook;
        private int _Opcion;
        private float _PorcentajeIVA;
        private string _Rfc;
        private string _RepresentanteLegal;
        private string _Mensaje1;
        private string _Mensaje2;
        private string _Mensaje3;
        private string _NombreComercial;
        private string _RazonSocial;
        private string _Slogan;
        private string _SitioWeb;
        private string _Twitter;
        private string _UrlLogo;
        private DataTable _TablaDatos;
        private string _Youtube;

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
        public string CorreoElectronico
        {
            get { return _CorreoElectronico; }
            set { _CorreoElectronico = value; }
        }
        public string IDEmpresa
        {
            get { return _IDEmpresa; }
            set { _IDEmpresa = value; }
        }
        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }
        public string Instagram
        {
            get { return _Instagram; }
            set { _Instagram = value; }
        }
        public string Facebook
        {
            get { return _Facebook; }
            set { _Facebook = value; }
        }
        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
        public float PorcentajeIVA
        {
            get { return _PorcentajeIVA; }
            set { _PorcentajeIVA = value; }
        }
        public string Rfc
        {
            get { return _Rfc; }
            set { _Rfc = value; }
        }
        public string RepresentanteLegal
        {
            get { return _RepresentanteLegal; }
            set { _RepresentanteLegal = value; }
        }
        public string Mensaje1
        {
            get { return _Mensaje1; }
            set { _Mensaje1 = value; }
        }
        public string Mensaje2
        {
            get { return _Mensaje2; }
            set { _Mensaje2 = value; }
        }
        public string Mensaje3
        {
            get { return _Mensaje3; }
            set { _Mensaje3 = value; }
        }
        public string NombreComercial
        {
            get { return _NombreComercial; }
            set { _NombreComercial = value; }
        }
        public string RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; }
        }
        public string Slogan
        {
            get { return _Slogan; }
            set { _Slogan = value; }
        }
        public string SitioWeb
        {
            get { return _SitioWeb; }
            set { _SitioWeb = value; }
        }
        public string Twitter
        {
            get { return _Twitter; }
            set { _Twitter = value; }
        }
        public string UrlLogo
        {
            get { return _UrlLogo; }
            set { _UrlLogo = value; }
        }
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }
        public string Youtube
        {
            get { return _Youtube; }
            set { _Youtube = value; }
        }
    }
}
