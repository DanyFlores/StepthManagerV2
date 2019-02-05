using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Gastos
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

        private string _IDGasto;

        public string IDGasto
        {
            get { return _IDGasto; }
            set { _IDGasto = value; }
        }

        private string _IDSucursal;

        public string IDSucursal
        {
            get { return _IDSucursal; }
            set { _IDSucursal = value; }
        }

        private string _nombreSucursal;

        public string nombreSucursal
        {
            get { return _nombreSucursal; }
            set { _nombreSucursal = value; }
        }
        

        private DateTime _FechaGasto = DateTime.Now;

        public DateTime FechaGasto
        {
            get { return _FechaGasto; }
            set { _FechaGasto = value; }
        }

        private decimal _Monto;

        public decimal Monto
        {
            get { return _Monto; }
            set { _Monto = value; }
        }

        private int _IDRubro;

        public int IDRubro
        {
            get { return _IDRubro; }
            set { _IDRubro = value; }
        }

        private string _RubroDesc;

        public string RubroDesc
        {
            get { return _RubroDesc; }
            set { _RubroDesc = value; }
        }

        private string _IDSubrubro;

        public string IDSubrubro
        {
            get { return _IDSubrubro; }
            set { _IDSubrubro = value; }
        }

        private string _SubrubroDesc;

        public string SubrubroDesc
        {
            get { return _SubrubroDesc; }
            set { _SubrubroDesc = value; }
        }

        private string _Observaciones;

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        private bool _NuevoRegistro;

        public bool NuevoRegistro
        {
            get { return _NuevoRegistro; }
            set { _NuevoRegistro = value; }
        }
        
    }
}
