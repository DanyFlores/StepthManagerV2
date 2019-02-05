using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class Comision
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

        private string _IDComisionXCategoria;

        public string IDComisionXCategoria
        {
            get { return _IDComisionXCategoria; }
            set { _IDComisionXCategoria = value; }
        }

        private bool _EsPorcentaje;

        public bool EsPorcentaje
        {
            get { return _EsPorcentaje; }
            set { _EsPorcentaje = value; }
        }

        private string _IDCategoria;

        public string IDCategoria
        {
            get { return _IDCategoria; }
            set { _IDCategoria = value; }
        }

        private string _CategoriaDesc;

        public string CategoriaDesc
        {
            get { return _CategoriaDesc; }
            set { _CategoriaDesc = value; }
        }
        

        private string _IDProducto;

        public string IDProducto
        {
            get { return _IDProducto; }
            set { _IDProducto = value; }
        }

        private string _ProductoDesc;

        public string ProductoDesc
        {
            get { return _ProductoDesc; }
            set { _ProductoDesc = value; }
        }

        private int _IDTipoComision;

        public int IDTipoComision
        {
            get { return _IDTipoComision; }
            set { _IDTipoComision = value; }
        }

        private string _TipoComisionDesc;

        public string TipoComisionDesc
        {
            get { return _TipoComisionDesc; }
            set { _TipoComisionDesc = value; }
        }

        private decimal _Monto;

        public decimal Monto
        {
            get { return _Monto; }
            set { _Monto = value; }
        }

        private decimal _Porcentaje;

        public decimal Porcentaje
        {
            get { return _Porcentaje; }
            set { _Porcentaje = value; }
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

        private int _IDPuesto;

        public int IDPuesto
        {
            get { return _IDPuesto; }
            set { _IDPuesto = value; }
        }

        private bool _NuevoRegistro;

        public bool NuevoRegistro
        {
            get { return _NuevoRegistro; }
            set { _NuevoRegistro = value; }
        }

        private int _Resultado;

        public int Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }


        private string _IDResumenComision;

        public string IDResumenComision
        {
            get { return _IDResumenComision; }
            set { _IDResumenComision = value; }
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

        private decimal _Total;

        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private string _Folio;

        public string Folio
        {
            get { return _Folio; }
            set { _Folio = value; }
        }

        private List<Comision> _ListaComisiones;

        public List<Comision> ListaComisiones
        {
            get { return _ListaComisiones; }
            set { _ListaComisiones = value; }
        }

        private List<Comision> _ListaTiposComision;

        public List<Comision> ListaTiposComision
        {
            get { return _ListaTiposComision; }
            set { _ListaTiposComision = value; }
        }

    }
}
