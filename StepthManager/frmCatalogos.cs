using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StephManager.ClasesAux;
using CreativaSL.LibControls.WinForms;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using System.IO;
namespace StephManager
{
    public partial class frmCatalogos : Form
    {
        #region Propiedades / Variables

        private int TipoCatalogo;
        DataTable DatosActuales;

        #endregion

        #region Constructor (es)

        public frmCatalogos()
        {
            try
            {
                InitializeComponent();
                TipoCatalogo = 0;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogos ~ frmCatalogos()");
            }
        }

        #endregion

        #region Métodos

        private void Busqueda(string TextoBusqueda)
        {
            try
            {
                if (!string.IsNullOrEmpty(TextoBusqueda.Trim()))
                {
                    DataTable TablaDatos = this.DatosActuales;
                    DataRow[] ResultadosBusqueda;
                    DataTable TablaResultados = null;
                    switch (TipoCatalogo)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5: ResultadosBusqueda = TablaDatos.Select("Descripcion like '%" + TextoBusqueda + "%'");
                            if (ResultadosBusqueda.Count() > 0)
                                TablaResultados = ResultadosBusqueda.CopyToDataTable();
                            this.dataGridView1.DataSource = TablaResultados;
                            break;
                        case 6: ResultadosBusqueda = TablaDatos.Select("Folio like '%" + TextoBusqueda + "%'");
                            if (ResultadosBusqueda.Count() > 0)
                                TablaResultados = ResultadosBusqueda.CopyToDataTable();
                            this.dataGridView1.DataSource = TablaResultados;
                            break;
                        case 7: ResultadosBusqueda = TablaDatos.Select("RazonSocial like '%" + TextoBusqueda + "%'");
                            if (ResultadosBusqueda.Count() > 0)
                                TablaResultados = ResultadosBusqueda.CopyToDataTable();
                            this.dataGridView1.DataSource = TablaResultados;
                            break;
                        case 8: ResultadosBusqueda = TablaDatos.Select("NombreSucursal like '%" + TextoBusqueda + "%'");
                            if (ResultadosBusqueda.Count() > 0)
                                TablaResultados = ResultadosBusqueda.CopyToDataTable();
                            this.dataGridView1.DataSource = TablaResultados;
                            break;
                        case 9: ResultadosBusqueda = TablaDatos.Select("Nombre like '%" + TextoBusqueda + "%'");
                            if (ResultadosBusqueda.Count() > 0)
                                TablaResultados = ResultadosBusqueda.CopyToDataTable();
                            this.dataGridView1.DataSource = TablaResultados;
                            break;
                        case 10: ResultadosBusqueda = TablaDatos.Select("Descripcion like '%" + TextoBusqueda + "%'");
                            if (ResultadosBusqueda.Count() > 0)
                                TablaResultados = ResultadosBusqueda.CopyToDataTable();
                            this.dataGridView1.DataSource = TablaResultados;
                            break;
                        case 11: ResultadosBusqueda = TablaDatos.Select("Descripcion like '%" + TextoBusqueda + "%'");
                            if (ResultadosBusqueda.Count() > 0)
                                TablaResultados = ResultadosBusqueda.CopyToDataTable();
                            this.dataGridView1.DataSource = TablaResultados;
                            break;
                        case 12: ResultadosBusqueda = TablaDatos.Select("NombreTurno like '%" + TextoBusqueda + "%'");
                            if (ResultadosBusqueda.Count() > 0)
                                TablaResultados = ResultadosBusqueda.CopyToDataTable();
                            this.dataGridView1.DataSource = TablaResultados;
                            break;
                        case 13: ResultadosBusqueda = TablaDatos.Select("Descripcion like '%" + TextoBusqueda + "%'");
                            if (ResultadosBusqueda.Count() > 0)
                                TablaResultados = ResultadosBusqueda.CopyToDataTable();
                            this.dataGridView1.DataSource = TablaResultados;
                            break;
                        case 14: ResultadosBusqueda = TablaDatos.Select("Descripcion like '%" + TextoBusqueda + "%'");
                            if (ResultadosBusqueda.Count() > 0)
                                TablaResultados = ResultadosBusqueda.CopyToDataTable();
                            this.dataGridView1.DataSource = TablaResultados;
                            break;
                        case 15: ResultadosBusqueda = TablaDatos.Select("Descripcion like '%" + TextoBusqueda + "%'");
                            if (ResultadosBusqueda.Count() > 0)
                                TablaResultados = ResultadosBusqueda.CopyToDataTable();
                            this.dataGridView1.DataSource = TablaResultados;
                            break;
                        case 16: ResultadosBusqueda = TablaDatos.Select("Descripcion like '%" + TextoBusqueda + "%'");
                            if (ResultadosBusqueda.Count() > 0)
                                TablaResultados = ResultadosBusqueda.CopyToDataTable();
                            this.dataGridView1.DataSource = TablaResultados;
                            break;
                        case 17: ResultadosBusqueda = TablaDatos.Select("Descripcion like '%" + TextoBusqueda + "%'");
                            if (ResultadosBusqueda.Count() > 0)
                                TablaResultados = ResultadosBusqueda.CopyToDataTable();
                            this.dataGridView1.DataSource = TablaResultados;
                            break;
                        case 18: ResultadosBusqueda = TablaDatos.Select("NombreProducto like '%" + TextoBusqueda + "%'");
                            if (ResultadosBusqueda.Count() > 0)
                                TablaResultados = ResultadosBusqueda.CopyToDataTable();
                            this.dataGridView1.DataSource = TablaResultados;
                            break;
                        case 19: ResultadosBusqueda = TablaDatos.Select("Descripcion like '%" + TextoBusqueda + "%'");
                            if (ResultadosBusqueda.Count() > 0)
                                TablaResultados = ResultadosBusqueda.CopyToDataTable();
                            this.dataGridView1.DataSource = TablaResultados;
                            break;
                        case 20: ResultadosBusqueda = TablaDatos.Select("Descripcion like '%" + TextoBusqueda + "%'");
                            if (ResultadosBusqueda.Count() > 0)
                                TablaResultados = ResultadosBusqueda.CopyToDataTable();
                            this.dataGridView1.DataSource = TablaResultados;
                            break;
                        case 21: ResultadosBusqueda = TablaDatos.Select("Descripcion like '%" + TextoBusqueda + "%'");
                            if (ResultadosBusqueda.Count() > 0)
                                TablaResultados = ResultadosBusqueda.CopyToDataTable();
                            this.dataGridView1.DataSource = TablaResultados;
                            break;
                        case 22: ResultadosBusqueda = TablaDatos.Select("Descripcion like '%" + TextoBusqueda + "%'");
                            if (ResultadosBusqueda.Count() > 0)
                                TablaResultados = ResultadosBusqueda.CopyToDataTable();
                            this.dataGridView1.DataSource = TablaResultados;
                            break;
                        case 23: ResultadosBusqueda = TablaDatos.Select("Descripcion like '%" + TextoBusqueda + "%'");
                            if (ResultadosBusqueda.Count() > 0)
                                TablaResultados = ResultadosBusqueda.CopyToDataTable();
                            this.dataGridView1.DataSource = TablaResultados;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    this.dataGridView1.DataSource = this.DatosActuales;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridCatalogo()
        {
            try
            {
                switch (this.TipoCatalogo)
                {
                    case 1: this.IniciarGrid(this.dataGridView1, 2, this.ObtenerPropiedadesGridFamilias());
                        this.LlenarGridFamilias();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    case 2: this.IniciarGrid(this.dataGridView1, 2, this.ObtenerPropiedadesGridUnidadMedida());
                        this.LlenarGridUnidadMedida();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    case 3: this.IniciarGrid(this.dataGridView1, 3, this.ObtenerPropiedadesGridTipoMonedero());
                        this.LlenarGridTipoMonedero();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    case 4: this.IniciarGrid(this.dataGridView1, 3, this.ObtenerPropiedadesGridPadecimiento());
                        this.LlenarGridPadecimiento();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    case 5: this.IniciarGrid(this.dataGridView1, 2, this.ObtenerPropiedadesGridTagsInteres());
                        this.LlenarGridTagInteres();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    case 6: this.IniciarGrid(this.dataGridView1, 4, this.ObtenerPropiedadesGridTarjetaMonedero());
                        this.LlenarGridTarjetasMonedero();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    case 7: this.IniciarGrid(this.dataGridView1, 16, this.ObtenerPropiedadesGridProveedor());
                        this.LlenarGridProveedor();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    case 8: this.IniciarGrid(this.dataGridView1, 15, this.ObtenerPropiedadesGridSucursales());
                        this.LlenarGridSucursales();
                        this.btnAsignarGerente.Enabled = true;
                        break;
                    case 9: this.IniciarGrid(this.dataGridView1, 6, this.ObtenerPropiedadesGridCursos());
                        this.LlenarGridCursos();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    case 10: this.IniciarGrid(this.dataGridView1, 2, this.ObtenerPropiedadesGridTemas());
                        this.LlenarGridTemasCurso();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    case 11: this.IniciarGrid(this.dataGridView1, 3, this.ObtenerPropiedadesGridPuesto());
                        this.LlenarGridPuesto();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    case 12: this.IniciarGrid(this.dataGridView1, 11, this.ObtenerPropiedadesGridHorarios());
                        this.LlenarGridHorarios();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    case 13: this.IniciarGrid(this.dataGridView1, 2, this.ObtenerPropiedadesGridGastosRubros());
                        this.LlenarGridGastosRubros();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    case 14: this.IniciarGrid(this.dataGridView1, 4, this.ObtenerPropiedadesGridGastosSubRubros());
                        this.LlenarGridGastosSubRubros();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    case 15: this.IniciarGrid(this.dataGridView1, 8, this.ObtenerPropiedadesGridInstructor());
                        this.LlenarInstructor();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    case 16: this.IniciarGrid(this.dataGridView1, 2, this.ObtenerPropiedadesGridTipoMobiliario());
                        this.LlenarTipoMobiliario();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    case 17: this.IniciarGrid(this.dataGridView1, 5, this.ObtenerPropiedadesGridConceptoNomina());
                        this.LlenarGribConceptoNomina();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    case 18: this.IniciarGrid(this.dataGridView1, 3, this.ObtenerPropiedadesGridProductoExtra());
                        this.LlenarGridProductoExtra();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    case 19: this.IniciarGrid(this.dataGridView1, 3, this.ObtenerPropiedadesGridDiasFestivos());
                        this.LlenarGridDiasFestivos();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    case 20: this.IniciarGrid(this.dataGridView1, 2, this.ObtenerPropiedadesGridTipoUsuario());
                        this.LlenarGridTipoUsuario();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    case 21: this.IniciarGrid(this.dataGridView1, 2, this.ObtenerPropiedadesGridBanco());
                        this.LlenarGridBanco();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    case 22: this.IniciarGrid(this.dataGridView1, 2, this.ObtenerPropiedadesGridCategoriaActividad());
                        this.LlenarGridCategoriaActividad();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    case 23: this.IniciarGrid(this.dataGridView1, 5, this.ObtenerPropiedadesGridActividad());
                        this.LlenarGridActividad();
                        this.btnAsignarGerente.Enabled = false;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarFromSucurcarGenrente(Object DatosAux)
        {
            try
            {
                Int32 RowToUpdate = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                switch (TipoCatalogo)
                {
                    case 8:
                        frmNuevoGerenteXSucursal GerenteXSucursal = new frmNuevoGerenteXSucursal((Sucursal)DatosAux);
                        GerenteXSucursal.ShowDialog();
                        GerenteXSucursal.Dispose();
                        if (GerenteXSucursal.DialogResult == DialogResult.OK)
                        {
                            if (RowToUpdate > -1)
                            {
                                Sucursal DatosAuxProv = GerenteXSucursal.DatosSucursal;
                                this.dataGridView1.Rows[RowToUpdate].Cells["NombreSucursal"].Value = DatosAuxProv.NombreSucursal;
                            }
                            else
                            {
                                this.LlenarGridSucursales();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["NombreSucursal"], ListSortDirection.Ascending);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarFormNuevo()
        {
            try
            {
                DataTable TablaAux = new DataTable();
                switch (TipoCatalogo)
                {
                    case 1: 
                        frmNuevaFamiliaProducto FamiliaProducto = new frmNuevaFamiliaProducto();
                        FamiliaProducto.ShowDialog();
                        FamiliaProducto.Dispose();
                        if (FamiliaProducto.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            TablaAux.Rows.Add(new object[] { FamiliaProducto.DatosFamilia.IDFamiliaProducto, FamiliaProducto.DatosFamilia.Descripcion });
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 2:
                        frmNuevaUnidadMedida UnidadMedida = new frmNuevaUnidadMedida();
                        UnidadMedida.ShowDialog();
                        UnidadMedida.Dispose();
                        if (UnidadMedida.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            TablaAux.Rows.Add(new object[] { UnidadMedida.DatosUnidad.IDUnidadMedida, UnidadMedida.DatosUnidad.Descripcion });
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 3:
                        frmNuevoTipoMonedero TipoMonedero = new frmNuevoTipoMonedero();
                        TipoMonedero.ShowDialog();
                        TipoMonedero.Dispose();
                        if (TipoMonedero.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            TablaAux.Rows.Add(new object[] { TipoMonedero.DatosTipoMonedero.IDTipoMonedero, TipoMonedero.DatosTipoMonedero.Descripcion, TipoMonedero.DatosTipoMonedero.PuntosMinimos });
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 4:
                        frmNuevoPadecimiento Padecimiento = new frmNuevoPadecimiento();
                        Padecimiento.ShowDialog();
                        Padecimiento.Dispose();
                        if (Padecimiento.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            TablaAux.Rows.Add(new object[] { Padecimiento.DatosPadecimiento.IDPadecimiento, Padecimiento.DatosPadecimiento.Descripcion });
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 5:
                        frmNuevoTagInteres TagInteres = new frmNuevoTagInteres();
                        TagInteres.ShowDialog();
                        TagInteres.Dispose();
                        if (TagInteres.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            TablaAux.Rows.Add(new object[] { TagInteres.DatosTagInteres.IDTagInteres, TagInteres.DatosTagInteres.Descripcion });
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 6:
                        frmNuevaTarjeta Tarjeta = new frmNuevaTarjeta();
                        Tarjeta.ShowDialog();
                        Tarjeta.Dispose();
                        if (Tarjeta.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            TablaAux.Rows.Add(new object[] {    Tarjeta.DatosTarjetaMonedero.IDTarjeta, Tarjeta.DatosTarjetaMonedero.IDTipoMonedero,
                                                                Tarjeta.DatosTarjetaMonedero.Folio, Tarjeta.DatosTarjetaMonedero.TipoMonederoDesc});
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Folio"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 7:
                        frmNuevoProveedor Proveedor = new frmNuevoProveedor();
                        Proveedor.ShowDialog();
                        Proveedor.Dispose();
                        if (Proveedor.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            Proveedor DatosAux = Proveedor.DatosProveedor;
                            TablaAux.Rows.Add(new object[] { DatosAux.IDProveedor, DatosAux.RazonSocial, DatosAux.NombreComercial, DatosAux.Representante, 
                                                             DatosAux.RegimenFiscal ,DatosAux.Correo, DatosAux.Telefono, DatosAux.DirCalle, DatosAux.DirColonia,
                                                             DatosAux.DirNumero, DatosAux.CodigoPostal, DatosAux.IDPais, DatosAux.IDEstado,DatosAux.IDMunicipio, DatosAux.RFC, DatosAux.Mobiliario});
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["RazonSocial"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 8:
                        frmNuevaSucursal Sucursal = new frmNuevaSucursal();
                        Sucursal.ShowDialog();
                        Sucursal.Dispose();
                        if (Sucursal.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            Sucursal DatosAux = Sucursal.DatosSucursal;
                            TablaAux.Rows.Add(new object[] { DatosAux.IDSucursal, DatosAux.IDEmpresa, DatosAux.IDTipoSucursal, DatosAux.NombreSucursal, DatosAux.NombreTipoSucursal,
                                                             DatosAux.Direccion, DatosAux.Telefono, DatosAux.IDMunicipio, DatosAux.IDEstado, DatosAux.IDPais,
                                                             DatosAux.CodigoPostal, DatosAux.PorcentajeMonedero, DatosAux.rfc, DatosAux.Representante});
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["NombreSucursal"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 9:
                        frmNuevoCurso Curso = new frmNuevoCurso();
                        Curso.ShowDialog();
                        Curso.Dispose();
                        if (Curso.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            Curso DatosAux = Curso.DatosCursos;
                            TablaAux.Rows.Add(new object[] { DatosAux.IDCurso, DatosAux.Nombre,
                                                             DatosAux.Descripcion, DatosAux.ObjetivoGeneral, DatosAux.Horas, DatosAux.CalificacionMinAprobatoria});
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Nombre"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 10:
                        frmNuevoTema TemasCurso = new frmNuevoTema();
                        TemasCurso.ShowDialog();
                        TemasCurso.Dispose();
                        if (TemasCurso.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            TemasCurso DatosAux = TemasCurso.DatosTemasCurso;
                            TablaAux.Rows.Add(new object[] { DatosAux.IDTemaCurso, DatosAux.Descripcion });
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 11:
                        frmNuevoPuesto Puesto = new frmNuevoPuesto();
                        Puesto.ShowDialog();
                        Puesto.Dispose();
                        if (Puesto.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            Puestos DatosAux = Puesto.DatosPuesto;
                            TablaAux.Rows.Add(new object[] { DatosAux.IDPuesto, DatosAux.Descripcion });
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 12:
                        frmHorarioTurno Horario = new frmHorarioTurno();
                        Horario.ShowDialog();
                        Horario.Dispose();
                        if (Horario.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            Horario DatosAux = Horario.DatosHorario;
                            TablaAux.Rows.Add(new object[] { DatosAux.IDTurno, DatosAux.NombreTurno, DatosAux.HoraEntrada, DatosAux.HoraSalida,
                                                             DatosAux.InicioValidezEntrada, DatosAux.FinValidezEntrada, DatosAux.InicioValidezSalida,
                                                             DatosAux.FinValidezSalida, DatosAux.ToleraciaLlegadaTarde, DatosAux.ToleranciaSalidaTemprano,
                                                             DatosAux.DiasDeTrabajo});
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["NombreTurno"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 13:
                        frmGastosRubros GastosRubros = new frmGastosRubros();
                        GastosRubros.ShowDialog();
                        GastosRubros.Dispose();
                        if (GastosRubros.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            TablaAux.Rows.Add(new object[] { GastosRubros.DatosRubro.IDRubro, GastosRubros.DatosRubro.Descripcion });
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 14:
                        frmGastosSubRubros SubRubro = new frmGastosSubRubros();
                        SubRubro.ShowDialog();
                        SubRubro.Dispose();
                        if (SubRubro.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            TablaAux.Rows.Add(new object[] {    SubRubro.DatosSubRubro.IDSubrubro, SubRubro.DatosSubRubro.IDRubro,
                                                                SubRubro.DatosSubRubro.Descripcion, SubRubro.DatosSubRubro.Rubro});
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 15:
                        frmNuevoInstructor Instructor = new frmNuevoInstructor();
                        Instructor.ShowDialog();
                        Instructor.Dispose();
                        if (Instructor.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            Instructor DatosAux = Instructor.DatosInstructor;
                            TablaAux.Rows.Add(new object[] { DatosAux.IDInstructor, DatosAux.Nombre, DatosAux.ApellidoPat, DatosAux.ApellidoMat, DatosAux.IDGenero, DatosAux.FechaNac, 
                                                            DatosAux.Correo, DatosAux.Telefono });
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Nombre"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 16:
                        frmNuevoTipoMobiliario TipoMobiliario = new frmNuevoTipoMobiliario();
                        TipoMobiliario.ShowDialog();
                        TipoMobiliario.Dispose();
                        if (TipoMobiliario.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            TipoMobiliario DatosAux = TipoMobiliario.DatosMobiliario;
                            TablaAux.Rows.Add(new object[] { DatosAux.IDTipoMobiliario, DatosAux.Descripcion });
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 17:
                        frmNuevoConceptoNomina conceptoNomina = new frmNuevoConceptoNomina();
                        conceptoNomina.ShowDialog();
                        conceptoNomina.Dispose();
                        if (conceptoNomina.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            ConceptoNomina DatosAux = conceptoNomina.DatosConceptoNomina;
                            TablaAux.Rows.Add(new object[] { DatosAux.IDConceptoNomina, DatosAux.Descripcion, DatosAux.Calculado, DatosAux.SumaResta, DatosAux.SoloLectura });
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 18:
                        frmNuevoProductoExtra ProductoExtra = new frmNuevoProductoExtra();
                        ProductoExtra.ShowDialog();
                        ProductoExtra.Dispose();
                        if (ProductoExtra.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            Producto DatosAux = ProductoExtra.Datos;
                            TablaAux.Rows.Add(new object[] { DatosAux.IDProducto, DatosAux.Clave, DatosAux.NombreProducto });
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["NombreProducto"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 19:
                        frmNuevoNominaDiasFestivos DiasFestivos = new frmNuevoNominaDiasFestivos();
                        DiasFestivos.ShowDialog();
                        DiasFestivos.Dispose();
                        if (DiasFestivos.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            DiasFestivos DatosAux = DiasFestivos.DatosDiasFestivos;
                            TablaAux.Rows.Add(new object[] { DatosAux.IDDiasFestivos, DatosAux.Descripcion, DatosAux.Fecha });
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 20:
                        frmNuevoTipoUsuarioPermisos TipoUsuario = new frmNuevoTipoUsuarioPermisos();
                        TipoUsuario.ShowDialog();
                        TipoUsuario.Dispose();
                        if (TipoUsuario.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            TipoUsuario DatosAux = TipoUsuario.DatosUsuario;
                            TablaAux.Rows.Add(new object[] { DatosAux.IDTipoUsuario, DatosAux.Descripcion });
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 21:
                        frmNuevoBanco Bancos = new frmNuevoBanco();
                        Bancos.ShowDialog();
                        Bancos.Dispose();
                        if (Bancos.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            Banco DatosAux = Bancos.DatosBanco;
                            TablaAux.Rows.Add(new object[] { DatosAux.IDBanco, DatosAux.Descripcion });
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 22:
                        frmNuevoCategoriaCheklist CategoriaCheck = new frmNuevoCategoriaCheklist();
                        CategoriaCheck.ShowDialog();
                        CategoriaCheck.Dispose();
                        if (CategoriaCheck.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            CategoriaCheckList DatosAux = CategoriaCheck.DatosCategoria;
                            TablaAux.Rows.Add(new object[] { DatosAux.IDCategoriaChe, DatosAux.Descripcion });
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                    case 23:
                        frmNuevoActividadCheklist ActividadChk = new frmNuevoActividadCheklist();
                        ActividadChk.ShowDialog();
                        ActividadChk.Dispose();
                        if (ActividadChk.DialogResult == DialogResult.OK)
                        {
                            TablaAux = (DataTable)this.dataGridView1.DataSource;
                            ActividadesCheckList DatosAux = ActividadChk.DatosActividad;
                            TablaAux.Rows.Add(new object[] { DatosAux.IDActividades, DatosAux.IDCategoriaChe, DatosAux.NombreCategoria, DatosAux.Descripcion, DatosAux.Orden });
                            this.dataGridView1.DataSource = TablaAux;
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                            TablaAux.Dispose();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarFormModificar(Object DatosAux)
        {
            try
            {
                Int32 RowToUpdate = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                switch (TipoCatalogo)
                {
                    case 1: 
                        frmNuevaFamiliaProducto FamiliaProducto = new frmNuevaFamiliaProducto((FamiliaProducto) DatosAux);
                        FamiliaProducto.ShowDialog();
                        FamiliaProducto.Dispose();
                        if (FamiliaProducto.DialogResult == DialogResult.OK)
                        {   
                            if (RowToUpdate > -1)
                            {
                                this.dataGridView1.Rows[RowToUpdate].Cells["Descripcion"].Value = FamiliaProducto.DatosFamilia.Descripcion;
                            }
                            else
                            {
                                this.LlenarGridFamilias();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                        }
                        break;
                    case 2:
                        frmNuevaUnidadMedida UnidadMedida = new frmNuevaUnidadMedida((UnidadMedida)DatosAux);
                        UnidadMedida.ShowDialog();
                        UnidadMedida.Dispose();
                        if (UnidadMedida.DialogResult == DialogResult.OK)
                        {   
                            if (RowToUpdate > -1)
                            {
                                this.dataGridView1.Rows[RowToUpdate].Cells["Descripcion"].Value = UnidadMedida.DatosUnidad.Descripcion;
                            }
                            else
                            {
                                this.LlenarGridUnidadMedida();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                        }
                        break;
                    case 3:
                        frmNuevoTipoMonedero TipoMonedero = new frmNuevoTipoMonedero((TipoMonedero)DatosAux);
                        TipoMonedero.ShowDialog();
                        TipoMonedero.Dispose();
                        if (TipoMonedero.DialogResult == DialogResult.OK)
                        {   
                            if (RowToUpdate > -1)
                            {
                                this.dataGridView1.Rows[RowToUpdate].Cells["Descripcion"].Value = TipoMonedero.DatosTipoMonedero.Descripcion;
                                this.dataGridView1.Rows[RowToUpdate].Cells["PuntosMinimos"].Value = TipoMonedero.DatosTipoMonedero.PuntosMinimos;
                            }
                            else
                            {
                                this.LlenarGridTipoMonedero();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                        }
                        break;
                    case 4:
                        frmNuevoPadecimiento Padecimiento = new frmNuevoPadecimiento((Padecimiento)DatosAux);
                        Padecimiento.ShowDialog();
                        Padecimiento.Dispose();
                        if (Padecimiento.DialogResult == DialogResult.OK)
                        {   
                            if (RowToUpdate > -1)
                            {
                                this.dataGridView1.Rows[RowToUpdate].Cells["Descripcion"].Value = Padecimiento.DatosPadecimiento.Descripcion;
                            }
                            else
                            {
                                this.LlenarGridPadecimiento();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                        }
                        break;
                    case 5:
                        frmNuevoTagInteres TagInteres = new frmNuevoTagInteres((TagInteres)DatosAux);
                        TagInteres.ShowDialog();
                        TagInteres.Dispose();
                        if (TagInteres.DialogResult == DialogResult.OK)
                        {
                            if (RowToUpdate > -1)
                            {
                                this.dataGridView1.Rows[RowToUpdate].Cells["Descripcion"].Value = TagInteres.DatosTagInteres.Descripcion;
                            }
                            else
                            {
                                this.LlenarGridTagInteres();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                        }
                        break;
                    case 6:
                        frmNuevaTarjeta Tarjeta = new frmNuevaTarjeta((TarjetaMonedero)DatosAux);
                        Tarjeta.ShowDialog();
                        Tarjeta.Dispose();
                        if (Tarjeta.DialogResult == DialogResult.OK)
                        {
                            if (RowToUpdate > -1)
                            {
                                this.dataGridView1.Rows[RowToUpdate].Cells["IDTipoMonedero"].Value = Tarjeta.DatosTarjetaMonedero.IDTipoMonedero;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Folio"].Value = Tarjeta.DatosTarjetaMonedero.Folio;
                                this.dataGridView1.Rows[RowToUpdate].Cells["TipoMonedero"].Value = Tarjeta.DatosTarjetaMonedero.TipoMonederoDesc;
                            }
                            else
                            {
                                this.LlenarGridTarjetasMonedero();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Folio"], ListSortDirection.Ascending);
                        }
                        break;
                    case 7:
                        frmNuevoProveedor Proveedor = new frmNuevoProveedor((Proveedor)DatosAux);
                        Proveedor.ShowDialog();
                        Proveedor.Dispose();
                        if (Proveedor.DialogResult == DialogResult.OK)
                        {
                            if (RowToUpdate > -1)
                            {
                                Proveedor DatosAuxProv = Proveedor.DatosProveedor;
                                this.dataGridView1.Rows[RowToUpdate].Cells["RazonSocial"].Value = DatosAuxProv.RazonSocial;
                                this.dataGridView1.Rows[RowToUpdate].Cells["NombreComercial"].Value = DatosAuxProv.NombreComercial;
                                this.dataGridView1.Rows[RowToUpdate].Cells["RegimenFiscal"].Value = DatosAuxProv.RegimenFiscal;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Representante"].Value = DatosAuxProv.Representante;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Correo"].Value = DatosAuxProv.Correo;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Telefono"].Value = DatosAuxProv.Telefono;
                                this.dataGridView1.Rows[RowToUpdate].Cells["DiCalle"].Value = DatosAuxProv.DirCalle;
                                this.dataGridView1.Rows[RowToUpdate].Cells["DirColonia"].Value = DatosAuxProv.DirColonia;
                                this.dataGridView1.Rows[RowToUpdate].Cells["DirNumero"].Value = DatosAuxProv.DirNumero;
                                this.dataGridView1.Rows[RowToUpdate].Cells["CodigoPostal"].Value = DatosAuxProv.CodigoPostal;
                                this.dataGridView1.Rows[RowToUpdate].Cells["IDPais"].Value = DatosAuxProv.IDPais;
                                this.dataGridView1.Rows[RowToUpdate].Cells["IDEstado"].Value = DatosAuxProv.IDEstado;
                                this.dataGridView1.Rows[RowToUpdate].Cells["IDMunicipio"].Value = DatosAuxProv.IDMunicipio;
                                this.dataGridView1.Rows[RowToUpdate].Cells["RFC"].Value = DatosAuxProv.RFC;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Mobiliario"].Value = DatosAuxProv.Mobiliario;
                            }
                            else
                            {
                                this.LlenarGridProveedor();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["RazonSocial"], ListSortDirection.Ascending);
                        }
                        break;
                    case 8:
                        frmNuevaSucursal Sucursal = new frmNuevaSucursal((Sucursal)DatosAux);
                        Sucursal.ShowDialog();
                        Sucursal.Dispose();
                        if (Sucursal.DialogResult == DialogResult.OK)
                        {
                            if (RowToUpdate > -1)
                            {
                                Sucursal DatosAuxProv = Sucursal.DatosSucursal;
                                this.dataGridView1.Rows[RowToUpdate].Cells["IDTipoSucursal"].Value = DatosAuxProv.IDTipoSucursal;
                                this.dataGridView1.Rows[RowToUpdate].Cells["NombreSucursal"].Value = DatosAuxProv.NombreSucursal;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Direccion"].Value = DatosAuxProv.Direccion;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Telefono"].Value = DatosAuxProv.Telefono;
                                this.dataGridView1.Rows[RowToUpdate].Cells["IDMunicipio"].Value = DatosAuxProv.IDMunicipio;
                                this.dataGridView1.Rows[RowToUpdate].Cells["IDEstado"].Value = DatosAuxProv.IDEstado;
                                this.dataGridView1.Rows[RowToUpdate].Cells["IDPais"].Value = DatosAuxProv.IDPais;
                                this.dataGridView1.Rows[RowToUpdate].Cells["CodigoPostal"].Value = DatosAuxProv.CodigoPostal;
                                this.dataGridView1.Rows[RowToUpdate].Cells["PorcentajeMonedero"].Value = DatosAuxProv.PorcentajeMonedero;
                                this.dataGridView1.Rows[RowToUpdate].Cells["RFC"].Value = DatosAuxProv.rfc;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Representante"].Value = DatosAuxProv.Representante;
                            }
                            else
                            {
                                this.LlenarGridSucursales();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["NombreSucursal"], ListSortDirection.Ascending);
                        }
                        break;
                    case 9:
                        frmNuevoCurso Curso = new frmNuevoCurso((Curso)DatosAux);
                        Curso.ShowDialog();
                        Curso.Dispose();
                        if (Curso.DialogResult == DialogResult.OK)
                        {
                            if (RowToUpdate > -1)
                            {
                                Curso DatosAuxProv = Curso.DatosCursos;
                                this.dataGridView1.Rows[RowToUpdate].Cells["IDCurso"].Value = DatosAuxProv.IDCurso;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Nombre"].Value = DatosAuxProv.Nombre;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Descripcion"].Value = DatosAuxProv.Descripcion;
                                this.dataGridView1.Rows[RowToUpdate].Cells["ObjetivoGeneral"].Value = DatosAuxProv.ObjetivoGeneral;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Horas"].Value = DatosAuxProv.Horas;
                                this.dataGridView1.Rows[RowToUpdate].Cells["CalificacionMinAprobatoria"].Value = DatosAuxProv.CalificacionMinAprobatoria;
                            }
                            else
                            {
                                this.LlenarGridCursos();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Nombre"], ListSortDirection.Ascending);
                        }
                        break;
                    case 10:
                        frmNuevoTema TemaCurso = new frmNuevoTema((TemasCurso)DatosAux);
                        TemaCurso.ShowDialog();
                        TemaCurso.Dispose();
                        if (TemaCurso.DialogResult == DialogResult.OK)
                        {
                            if (RowToUpdate > -1)
                            {
                                TemasCurso DatosAuxProv = TemaCurso.DatosTemasCurso;
                                this.dataGridView1.Rows[RowToUpdate].Cells["IDTemaCurso"].Value = DatosAuxProv.IDTemaCurso;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Descripcion"].Value = DatosAuxProv.Descripcion;

                            }
                            else
                            {
                                this.LlenarGridTemasCurso();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                        }
                        break;
                    case 11:
                        frmNuevoPuesto NuevoPuesto = new frmNuevoPuesto((Puestos)DatosAux);
                        NuevoPuesto.ShowDialog();
                        NuevoPuesto.Dispose();
                        if (NuevoPuesto.DialogResult == DialogResult.OK)
                        {
                            if (RowToUpdate > -1)
                            {
                                Puestos DatosAuxProv = NuevoPuesto.DatosPuesto;
                                this.dataGridView1.Rows[RowToUpdate].Cells["IDPuesto"].Value = DatosAuxProv.IDPuesto;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Descripcion"].Value = DatosAuxProv.Descripcion;
                            }
                            else
                            {
                                this.LlenarGridPuesto();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                        }
                        break;
                    case 12:
                        frmHorarioTurno HorarioTurno = new frmHorarioTurno((Horario)DatosAux);
                        HorarioTurno.ShowDialog();
                        HorarioTurno.Dispose();
                        if (HorarioTurno.DialogResult == DialogResult.OK)
                        {
                            if (RowToUpdate > -1)
                            {
                                Horario DatosAuxProv = HorarioTurno.DatosHorario;
                                this.dataGridView1.Rows[RowToUpdate].Cells["IDTurno"].Value = DatosAuxProv.IDTurno;
                                this.dataGridView1.Rows[RowToUpdate].Cells["NombreTurno"].Value = DatosAuxProv.NombreTurno;
                                this.dataGridView1.Rows[RowToUpdate].Cells["HorarioEntrada"].Value = DatosAuxProv.HoraEntrada;
                                this.dataGridView1.Rows[RowToUpdate].Cells["HorarioSalida"].Value = DatosAuxProv.HoraSalida;
                                this.dataGridView1.Rows[RowToUpdate].Cells["InicioValidezEntrada"].Value = DatosAuxProv.InicioValidezEntrada;
                                this.dataGridView1.Rows[RowToUpdate].Cells["FinValidezEntrada"].Value = DatosAuxProv.FinValidezEntrada;
                                this.dataGridView1.Rows[RowToUpdate].Cells["InicioValidezSalida"].Value = DatosAuxProv.InicioValidezSalida;
                                this.dataGridView1.Rows[RowToUpdate].Cells["FinValidezSalida"].Value = DatosAuxProv.FinValidezSalida;
                                this.dataGridView1.Rows[RowToUpdate].Cells["ToleranciaLlegadaTarde"].Value = DatosAuxProv.ToleraciaLlegadaTarde;
                                this.dataGridView1.Rows[RowToUpdate].Cells["ToleranciaSalidaTemprano"].Value = DatosAuxProv.ToleranciaSalidaTemprano;
                                this.dataGridView1.Rows[RowToUpdate].Cells["DiasDeTrabajo"].Value = DatosAuxProv.DiasDeTrabajo;
                            }
                            else
                            {
                                this.LlenarGridHorarios();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["NombreTurno"], ListSortDirection.Ascending);
                        }
                        break;
                    case 13:
                        frmGastosRubros Gastos = new frmGastosRubros((Rubro)DatosAux);
                        Gastos.ShowDialog();
                        Gastos.Dispose();
                        if (Gastos.DialogResult == DialogResult.OK)
                        {
                            if (RowToUpdate > -1)
                            {
                                this.dataGridView1.Rows[RowToUpdate].Cells["Descripcion"].Value = Gastos.DatosRubro.Descripcion;
                            }
                            else
                            {
                                this.LlenarGridGastosRubros();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                        }
                        break;
                    case 14:
                        frmGastosSubRubros GastosSubRubro = new frmGastosSubRubros((Subrubro)DatosAux);
                        GastosSubRubro.ShowDialog();
                        GastosSubRubro.Dispose();
                        if (GastosSubRubro.DialogResult == DialogResult.OK)
                        {
                            if (RowToUpdate > -1)
                            {
                                this.dataGridView1.Rows[RowToUpdate].Cells["IDSubRubro"].Value = GastosSubRubro.DatosSubRubro.IDSubrubro;
                                this.dataGridView1.Rows[RowToUpdate].Cells["IDRubro"].Value = GastosSubRubro.DatosSubRubro.IDRubro;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Descripcion"].Value = GastosSubRubro.DatosSubRubro.Descripcion;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Rubro"].Value = GastosSubRubro.DatosSubRubro.Rubro;
                            }
                            else
                            {
                                this.LlenarGridGastosSubRubros();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                        }
                        break;
                    case 15:
                        frmNuevoInstructor Intructor = new frmNuevoInstructor((Instructor)DatosAux);
                        Intructor.ShowDialog();
                        Intructor.Dispose();
                        if (Intructor.DialogResult == DialogResult.OK)
                        {
                            if (RowToUpdate > -1)
                            {
                                Instructor DatosAuxProv = Intructor.DatosInstructor;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Nombre"].Value = DatosAuxProv.Nombre;
                                this.dataGridView1.Rows[RowToUpdate].Cells["ApellidoPat"].Value = DatosAuxProv.ApellidoPat;
                                this.dataGridView1.Rows[RowToUpdate].Cells["ApellidoMat"].Value = DatosAuxProv.ApellidoMat;
                                this.dataGridView1.Rows[RowToUpdate].Cells["IDGenero"].Value = DatosAuxProv.IDGenero;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Correo"].Value = DatosAuxProv.Correo;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Telefono"].Value = DatosAuxProv.Telefono;
                                this.dataGridView1.Rows[RowToUpdate].Cells["FechaNac"].Value = DatosAuxProv.FechaNac;
                            }
                            else
                            {
                                this.LlenarGridProveedor();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Nombre"], ListSortDirection.Ascending);
                        }
                        break;
                    case 16:
                        frmNuevoTipoMobiliario TipoMobiliario = new frmNuevoTipoMobiliario((TipoMobiliario)DatosAux);
                        TipoMobiliario.ShowDialog();
                        TipoMobiliario.Dispose();
                        if (TipoMobiliario.DialogResult == DialogResult.OK)
                        {
                            if (RowToUpdate > -1)
                            {
                                TipoMobiliario DatosAuxProv = TipoMobiliario.DatosMobiliario;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Descripcion"].Value = DatosAuxProv.Descripcion;
                            }
                            else
                            {
                                this.LlenarTipoMobiliario();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                        }
                        break;
                    case 17:
                        frmNuevoConceptoNomina ConceptoNoimina = new frmNuevoConceptoNomina((ConceptoNomina)DatosAux);
                        ConceptoNoimina.ShowDialog();
                        ConceptoNoimina.Dispose();
                        if (ConceptoNoimina.DialogResult == DialogResult.OK)
                        {
                            if (RowToUpdate > -1)
                            {
                                ConceptoNomina DatosAuxProv = ConceptoNoimina.DatosConceptoNomina;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Descripcion"].Value = DatosAuxProv.Descripcion;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Calculado"].Value = DatosAuxProv.Calculado;
                                this.dataGridView1.Rows[RowToUpdate].Cells["SumaResta"].Value = DatosAuxProv.SumaResta;
                                this.dataGridView1.Rows[RowToUpdate].Cells["SoloLectura"].Value = DatosAuxProv.SoloLectura;
                            }
                            else
                            {
                                this.LlenarGribConceptoNomina();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                        }
                        break;
                    case 18:
                        frmNuevoProductoExtra ProductoExtra = new frmNuevoProductoExtra((Producto)DatosAux);
                        ProductoExtra.ShowDialog();
                        ProductoExtra.Dispose();
                        if (ProductoExtra.DialogResult == DialogResult.OK)
                        {
                            if (RowToUpdate > -1)
                            {
                                Producto DatosAuxProv = ProductoExtra.Datos;
                                this.dataGridView1.Rows[RowToUpdate].Cells["IDProducto"].Value = DatosAuxProv.IDProducto;
                                this.dataGridView1.Rows[RowToUpdate].Cells["ClaveProducto"].Value = DatosAuxProv.Clave;
                                this.dataGridView1.Rows[RowToUpdate].Cells["NombreProducto"].Value = DatosAuxProv.NombreProducto;
                            }
                            else
                            {
                                this.LlenarGridProductoExtra();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["NombreProducto"], ListSortDirection.Ascending);
                        }
                        break;
                    case 19:
                        frmNuevoNominaDiasFestivos DiasFestivos = new frmNuevoNominaDiasFestivos((DiasFestivos)DatosAux);
                        DiasFestivos.ShowDialog();
                        DiasFestivos.Dispose();
                        if (DiasFestivos.DialogResult == DialogResult.OK)
                        {
                            if (RowToUpdate > -1)
                            {
                                DiasFestivos DatosAuxProv = DiasFestivos.DatosDiasFestivos;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Descripcion"].Value = DatosAuxProv.Descripcion;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Fecha"].Value = DatosAuxProv.Fecha;
                            }
                            else
                            {
                                this.LlenarGridDiasFestivos();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                        }
                        break;
                    case 20:
                        frmNuevoTipoUsuarioPermisos TipoUsario = new frmNuevoTipoUsuarioPermisos((TipoUsuario)DatosAux);
                        TipoUsario.ShowDialog();
                        TipoUsario.Dispose();
                        if (TipoUsario.DialogResult == DialogResult.OK)
                        {
                            if (RowToUpdate > -1)
                            {
                                TipoUsuario DatosAuxProv = TipoUsario.DatosUsuario;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Descripcion"].Value = DatosAuxProv.Descripcion;
                            }
                            else
                            {
                                this.LlenarGridTipoUsuario();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                        }
                        break;
                    case 21:
                        frmNuevoBanco Bancos = new frmNuevoBanco((Banco)DatosAux);
                        Bancos.ShowDialog();
                        Bancos.Dispose();
                        if (Bancos.DialogResult == DialogResult.OK)
                        {
                            if (RowToUpdate > -1)
                            {
                                Banco DatosAuxBanco = Bancos.DatosBanco;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Descripcion"].Value = DatosAuxBanco.Descripcion;
                            }
                            else
                            {
                                this.LlenarGridBanco();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                        }
                        break;
                    case 22:
                        frmNuevoCategoriaCheklist CategoriaChe = new frmNuevoCategoriaCheklist((CategoriaCheckList)DatosAux);
                        CategoriaChe.ShowDialog();
                        CategoriaChe.Dispose();
                        if (CategoriaChe.DialogResult == DialogResult.OK)
                        {
                            if (RowToUpdate > -1)
                            {
                                CategoriaCheckList DatosAuxBanco = CategoriaChe.DatosCategoria;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Descripcion"].Value = DatosAuxBanco.Descripcion;
                            }
                            else
                            {
                                this.LlenarGridCategoriaActividad();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                        }
                        break;
                    case 23:
                        frmNuevoActividadCheklist ActividadChec = new frmNuevoActividadCheklist((ActividadesCheckList)DatosAux);
                        ActividadChec.ShowDialog();
                        ActividadChec.Dispose();
                        if (ActividadChec.DialogResult == DialogResult.OK)
                        {
                            if (RowToUpdate > -1)
                            {
                                ActividadesCheckList DatosAuxActividad = ActividadChec.DatosActividad;
                                this.dataGridView1.Rows[RowToUpdate].Cells["NombreCategoria"].Value = DatosAuxActividad.NombreCategoria;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Descripcion"].Value = DatosAuxActividad.Descripcion;
                                this.dataGridView1.Rows[RowToUpdate].Cells["Orden"].Value = DatosAuxActividad.Orden;
                            }
                            else
                            {
                                this.LlenarGridActividad();
                            }
                            this.dataGridView1.Sort(this.dataGridView1.Columns["Descripcion"], ListSortDirection.Ascending);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EliminarRegistro(Object DatosAux)
        {
            try
            {
                Int32 RowToDelete = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                DataTable TablaAux = new DataTable();
                Catalogo_Negocio cn = new Catalogo_Negocio();
                if (RowToDelete > -1)
                {
                    switch (TipoCatalogo)
                    {
                        case 1: FamiliaProducto FPDatos = (FamiliaProducto)DatosAux;
                            FPDatos.Opcion = 3;
                            FPDatos.Conexion = Comun.Conexion;
                            FPDatos.IDUsuario = Comun.IDUsuario;
                            cn.ABCCatFamiliaProductos(FPDatos);
                            if (FPDatos.Completado)
                            {
                                if (RowToDelete > -1)
                                {
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                    //TablaAux = (DataTable)this.dataGridView1.DataSource;
                                    //TablaAux.Rows.RemoveAt(RowToDelete);
                                    //this.dataGridView1.DataSource = TablaAux;
                                    //TablaAux.Dispose();
                                }
                                else
                                {
                                    this.LlenarGridFamilias();
                                }
                            }
                            break;
                        case 2: UnidadMedida UMDatos = (UnidadMedida)DatosAux;
                            UMDatos.Opcion = 3;
                            UMDatos.Conexion = Comun.Conexion;
                            UMDatos.IDUsuario = Comun.IDUsuario;
                            cn.ABCCatUnidadMedida(UMDatos);
                            if (UMDatos.Completado)
                            {
                                if (RowToDelete > -1)
                                {
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                    //TablaAux = (DataTable)this.dataGridView1.DataSource;
                                    //TablaAux.Rows.RemoveAt(RowToDelete);
                                    //this.dataGridView1.DataSource = TablaAux;
                                    //TablaAux.Dispose();
                                }
                                else
                                {
                                    this.LlenarGridUnidadMedida();
                                }
                            }
                            break;
                        case 3: TipoMonedero TMDatos = (TipoMonedero)DatosAux;
                            TMDatos.Opcion = 3;
                            TMDatos.Conexion = Comun.Conexion;
                            TMDatos.IDUsuario = Comun.IDUsuario;
                            cn.ABCCatTipoMonedero(TMDatos);
                            if (TMDatos.Completado)
                            {
                                if (RowToDelete > -1)
                                {
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                    //TablaAux = (DataTable)this.dataGridView1.DataSource;
                                    //TablaAux.Rows.RemoveAt(RowToDelete);
                                    //this.dataGridView1.DataSource = TablaAux;
                                    //TablaAux.Dispose();
                                }
                                else
                                {
                                    this.LlenarGridTipoMonedero();
                                }
                            }
                            break;
                        case 4: Padecimiento PDDatos = (Padecimiento)DatosAux;
                            PDDatos.Opcion = 3;
                            PDDatos.Conexion = Comun.Conexion;
                            PDDatos.IDUsuario = Comun.IDUsuario;
                            cn.ABCCatPadecimientos(PDDatos);
                            if (PDDatos.Completado)
                            {
                                if (RowToDelete > -1)
                                {
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                    //TablaAux = (DataTable)this.dataGridView1.DataSource;
                                    //TablaAux.Rows.RemoveAt(RowToDelete);
                                    //this.dataGridView1.DataSource = TablaAux;
                                    //TablaAux.Dispose();
                                }
                                else
                                {
                                    this.LlenarGridPadecimiento();
                                }
                            }
                            break;
                        case 5: TagInteres TIDatos = (TagInteres)DatosAux;
                            TIDatos.Opcion = 3;
                            TIDatos.Conexion = Comun.Conexion;
                            TIDatos.IDUsuario = Comun.IDUsuario;
                            cn.ABCCatTagInteres(TIDatos);
                            if (TIDatos.Completado)
                            {
                                if (RowToDelete > -1)
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                else
                                    this.LlenarGridTagInteres();
                            }
                            break;
                        case 6: TarjetaMonedero TarjMDatos = (TarjetaMonedero)DatosAux;
                            TarjMDatos.Opcion = 3;
                            TarjMDatos.Conexion = Comun.Conexion;
                            TarjMDatos.IDUsuario = Comun.IDUsuario;
                            cn.ABCCatTarjetaMonedero(TarjMDatos);
                            if (TarjMDatos.Completado)
                            {
                                if (RowToDelete > -1)
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                else
                                    this.LlenarGridTarjetasMonedero();
                            }
                            break;
                        case 7: Proveedor ProvDatos = (Proveedor)DatosAux;
                            ProvDatos.Opcion = 3;
                            ProvDatos.Conexion = Comun.Conexion;
                            ProvDatos.IDUsuario = Comun.IDUsuario;
                            cn.ABCCatProveedores(ProvDatos);
                            if (ProvDatos.Completado)
                            {
                                if (RowToDelete > -1)
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                else
                                    this.LlenarGridProveedor();
                            }
                            break;
                        case 8: Sucursal SucursalDatos = (Sucursal)DatosAux;
                            SucursalDatos.Opcion = 3;
                            SucursalDatos.Conexion = Comun.Conexion;
                            SucursalDatos.IDUsuario = Comun.IDUsuario;
                            DataTable TablaDiasSemanas = new DataTable();
                            TablaDiasSemanas.Columns.Add("Dia", typeof(int));
                            TablaDiasSemanas.Columns.Add("HoraEntrada", typeof(TimeSpan));
                            TablaDiasSemanas.Columns.Add("HoraSalida", typeof(TimeSpan));
                            SucursalDatos.TablaSucursalesHorario = TablaDiasSemanas;
                            cn.ABCCatSucursales(SucursalDatos);
                            if (SucursalDatos.Completado)
                            {
                                if (RowToDelete > -1)
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                else
                                    this.LlenarGridSucursales();
                            }
                            break;
                        case 9: Curso CDatos = (Curso)DatosAux;
                            CDatos.Opcion = 3;
                            CDatos.Conexion = Comun.Conexion;
                            CDatos.IDUsuario = Comun.IDUsuario;
                            DataTable TablaTema = new DataTable();
                            TablaTema.Columns.Add("IDTema", typeof(string));
                            CDatos.TablaTema = TablaTema;
                            cn.ABCCatCursos(CDatos);
                            if (CDatos.Completado)
                            {
                                if (RowToDelete > -1)
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                else
                                    this.LlenarGridCursos();
                            }
                            break;
                        case 10: TemasCurso TCDatos = (TemasCurso)DatosAux;
                            TCDatos.Opcion = 3;
                            TCDatos.Conexion = Comun.Conexion;
                            TCDatos.IDUsuario = Comun.IDUsuario;
                            DataTable TablaSubTema = new DataTable();
                            TablaSubTema.Columns.Add("IDSubTema", typeof(string));
                            TablaSubTema.Columns.Add("IDServicio", typeof(string));
                            TablaSubTema.Columns.Add("Descripcion", typeof(string));
                            TablaSubTema.Columns.Add("PracticasSugerida", typeof(int));
                            TCDatos.TablaSubTemas = TablaSubTema;
                            cn.ABCCatTemasCursos(TCDatos);
                            if (TCDatos.Completado)
                            {
                                if (RowToDelete > -1)
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                else
                                    this.LlenarGridTemasCurso();
                            }
                            break;
                        case 11: Puestos PDatos = (Puestos)DatosAux;
                            PDatos.Opcion = 3;
                            PDatos.Conexion = Comun.Conexion;
                            PDatos.IDUsuario = Comun.IDUsuario;
                            DataTable TablaCategoria = new DataTable();
                            TablaCategoria.Columns.Add("IDCategoria", typeof(string));
                            TablaCategoria.Columns.Add("IDPuesto", typeof(int));
                            TablaCategoria.Columns.Add("Descripcion", typeof(string));
                            TablaCategoria.Columns.Add("SueldoBase", typeof(decimal));
                            PDatos.TablaCategoriaPuesto = TablaCategoria;
                            cn.ABCCatPuesto(PDatos);
                            if (PDatos.Completado)
                            {
                                if (RowToDelete > -1)
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                else
                                    this.LlenarGridPuesto();
                            }
                            else
                            {
                                if (PDatos.IDPuesto == -1)
                                    MessageBox.Show("No se puede eliminar el puesto. Está asignado a un empleado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                if (PDatos.IDPuesto == 0)
                                    MessageBox.Show("No se puede eliminar el puesto gerente", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                        case 12: Horario HorarioDatos = (Horario)DatosAux;
                            HorarioDatos.Opcion = 3;
                            HorarioDatos.Conexion = Comun.Conexion;
                            HorarioDatos.IDUsuario = Comun.IDUsuario;
                            cn.ABCHorariosTurnos(HorarioDatos);
                            if (HorarioDatos.Completado)
                            {
                                if (RowToDelete > -1)
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                else
                                    this.LlenarGridHorarios();
                            }
                            break;
                        case 13: Rubro RDatos = (Rubro)DatosAux;
                            RDatos.Opcion = 3;
                            RDatos.Conexion = Comun.Conexion;
                            RDatos.IDUsuario = Comun.IDUsuario;
                            cn.ABCGastosRubros(RDatos);
                            if (RDatos.Completado)
                            {
                                if (RowToDelete > -1)
                                {
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                }
                                else
                                {
                                    this.LlenarGridGastosRubros();
                                }
                            }
                            break;
                        case 14: Subrubro SubRubroDatos = (Subrubro)DatosAux;
                            SubRubroDatos.Opcion = 3;
                            SubRubroDatos.Conexion = Comun.Conexion;
                            SubRubroDatos.IDUsuario = Comun.IDUsuario;
                            cn.ABCGastosSubRubros(SubRubroDatos);
                            if (SubRubroDatos.Completado)
                            {
                                if (RowToDelete > -1)
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                else
                                    this.LlenarGridGastosSubRubros();
                            }
                            break;
                        case 15: Instructor InsDatos = (Instructor)DatosAux;
                            InsDatos.Opcion = 3;
                            InsDatos.Conexion = Comun.Conexion;
                            InsDatos.IDUsuario = Comun.IDUsuario;
                            cn.ABCInstructoress(InsDatos);
                            if (InsDatos.Completado)
                            {
                                if (RowToDelete > -1)
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                else
                                    this.LlenarInstructor();
                            }
                            break;
                        case 16: TipoMobiliario TipoDatos = (TipoMobiliario)DatosAux;
                            TipoDatos.Opcion = 3;
                            TipoDatos.Conexion = Comun.Conexion;
                            TipoDatos.IDUsuario = Comun.IDUsuario;
                            cn.ABCTipoMobiliario(TipoDatos);
                            if (TipoDatos.Completado)
                            {
                                if (RowToDelete > -1)
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                else
                                    this.LlenarTipoMobiliario();
                            }
                            break;
                        case 17: ConceptoNomina Nomina = (ConceptoNomina)DatosAux;
                            Nomina.Opcion = 3;
                            Nomina.Conexion = Comun.Conexion;
                            Nomina.IDUsuario = Comun.IDUsuario;
                            cn.ABCConceptoNomina(Nomina);
                            if (Nomina.Completado)
                            {
                                if (RowToDelete > -1)
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                else
                                    this.LlenarGribConceptoNomina();
                            }
                            else
                            {
                                if (Nomina.IDConceptoNomina == 0)
                                    MessageBox.Show("Este conceptos de nómina no es eliminable", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                        case 18: Producto Producto = (Producto)DatosAux;
                            Producto.Opcion = 3;
                            Producto.Conexion = Comun.Conexion;
                            Producto.IDUsuario = Comun.IDUsuario;
                            Producto.Imagen = new byte[0];
                            cn.ABCProductoExtra(Producto);
                            if (Producto.Completado)
                            {
                                if (RowToDelete > -1)
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                else
                                    this.LlenarGridProductoExtra();
                            }
                            break;
                        case 19: DiasFestivos DiasFestivosDatos = (DiasFestivos)DatosAux;
                            DiasFestivosDatos.Opcion = 3;
                            DiasFestivosDatos.Conexion = Comun.Conexion;
                            DiasFestivosDatos.IDUsuario = Comun.IDUsuario;
                            cn.ABCDiasFestivos(DiasFestivosDatos);
                            if (DiasFestivosDatos.Completado)
                            {
                                if (RowToDelete > -1)
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                else
                                    this.LlenarGridDiasFestivos();
                            }
                            break;
                        case 20: TipoUsuario TipoUsuarioDatos = (TipoUsuario)DatosAux;
                            TipoUsuarioDatos.Opcion = 3;
                            TipoUsuarioDatos.Conexion = Comun.Conexion;
                            TipoUsuarioDatos.IDUsuario = Comun.IDUsuario;
                            DataTable TablaPermisos = new DataTable();
                            TablaPermisos.Columns.Add("IDPermiso", typeof(string));
                            TablaPermisos.Columns.Add("IDProyecto", typeof(int));
                            TablaPermisos.Columns.Add("IDModulo", typeof(int));
                            TablaPermisos.Columns.Add("Lectura", typeof(bool));
                            TablaPermisos.Columns.Add("Escritura", typeof(bool));
                            TipoUsuarioDatos.TablaDatos = TablaPermisos;
                            TipoUsuario_Negocio TUN = new TipoUsuario_Negocio();
                            TUN.ActualizarPermisosXIDUsuario(TipoUsuarioDatos);
                            if (TipoUsuarioDatos.Completado)
                            {
                                if (RowToDelete > -1)
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                else
                                    this.LlenarGridTipoUsuario();
                            }
                            break;
                        case 21: Banco Bancos = (Banco)DatosAux;
                            Bancos.Opcion = 3;
                            Bancos.Conexion = Comun.Conexion;
                            Bancos.IDUsuario = Comun.IDUsuario;
                            cn.ABCBanco(Bancos);
                            if (Bancos.Completado)
                            {
                                if (RowToDelete > -1)
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                else
                                    this.LlenarGridBanco();
                            }
                            break;
                        case 22: CategoriaCheckList CategoriaChe = (CategoriaCheckList)DatosAux;
                            CategoriaChe.Opcion = 3;
                            CategoriaChe.Conexion = Comun.Conexion;
                            CategoriaChe.IDUsuario = Comun.IDUsuario;
                            cn.ABCCategoriaActividades(CategoriaChe);
                            if (CategoriaChe.Completado)
                            {
                                if (RowToDelete > -1)
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                else
                                    this.LlenarGridCategoriaActividad();
                            }
                            break;
                        case 23: ActividadesCheckList ActividadChk = (ActividadesCheckList)DatosAux;
                            ActividadChk.Opcion = 3;
                            ActividadChk.Conexion = Comun.Conexion;
                            ActividadChk.IDUsuario = Comun.IDUsuario;
                            cn.ABCActividadesCheck(ActividadChk);
                            if (ActividadChk.Completado)
                            {
                                if (RowToDelete > -1)
                                    this.dataGridView1.Rows.RemoveAt(RowToDelete);
                                else
                                    this.LlenarGridActividad();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void IniciarGrid(DataGridView actual, int numColumns, object[,] propiedades)
        {
            try
            {
                ConfiguracionDataGridView dgvConf = new ConfiguracionDataGridView();
                foreach (DataGridViewColumn columna in actual.Columns)
                {
                    columna.Dispose();
                }
                actual.Columns.Clear();
                actual.DataSource = null;
                dgvConf.AddColumnsDataGridViewReadOnly(actual, numColumns, propiedades);
                //actual.AutoSize = true;
                //actual.AutoGenerateColumns = false;
                //actual.AllowUserToAddRows = false;
                //actual.AllowUserToDeleteRows = false;
                //actual.AllowUserToOrderColumns = false;
                ////actual.AllowUserToResizeColumns = false;
                actual.MultiSelect = false;
                actual.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                actual.ReadOnly = true;//Zincri descomento esta linea
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LiberarMemoria(Control aux)
        {
            try
            {
                for (int i = 0; i < aux.Controls.Count; i++)
                {
                    if (aux.Controls[i].Controls.Count > 0)
                    {
                        this.LiberarMemoria(aux.Controls[i]);
                    }
                    else
                    {
                        aux.Controls[i].Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Object ObtenerDatos()
        {
            try
            {
                Object Datos = new Object();
                switch (TipoCatalogo)
                {
                    case 1: Datos = this.ObtenerDatosFamiliaProducto();
                        break;
                    case 2: Datos = this.ObtenerDatosUnidadMedida();
                        break;
                    case 3: Datos = this.ObtenerDatosTipoMonedero();
                        break;
                    case 4: Datos = this.ObtenerDatosPadecimiento();
                        break;
                    case 5: Datos = this.ObtenerDatosTagsInteres();
                        break;
                    case 6: Datos = this.ObtenerDatosTarjetaMonedero();
                        break;
                    case 7: Datos = this.ObtenerDatosProveedor();
                        break;
                    case 8: Datos = this.ObtenerDatosSucursales();
                        break;
                    case 9: Datos = this.ObtenerDatosCurso();
                        break;
                    case 10: Datos = this.ObtenerDatosTemasCursos();
                        break;
                    case 11: Datos = this.ObtenerDatosPuestos();
                        break;
                    case 12: Datos = this.ObtenerDatosHorarios();
                        break;
                    case 13: Datos = this.ObtenerDatosGastosRubros();
                        break;
                    case 14: Datos = this.ObtenerDatosGastosSubRubro();
                        break;
                    case 15: Datos = this.ObtenerDatosInstructores();
                        break;
                    case 16: Datos = this.ObtenerDatosTipoMobiliario();
                        break;
                    case 17: Datos = this.ObtenerDatosConceptoNomina();
                        break;
                    case 18: Datos = this.ObtenerDatosProductoExtra();
                        break;
                    case 19: Datos = this.ObtenerDatosDiasFestivos();
                        break;
                    case 20: Datos = this.ObtenerDatosTipoUsuario();
                        break;
                    case 21: Datos = this.ObtenerDatosBancos();
                        break;
                    case 22: Datos = this.ObtenerDatosCategoriaActividad();
                        break;
                    case 23: Datos = this.ObtenerDatosActividad();
                        break;
                    default:
                        break;
                }
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Métodos Obtener Datos

        private FamiliaProducto ObtenerDatosFamiliaProducto()
        {
            try
            {
                FamiliaProducto DatosAux = new FamiliaProducto();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected); 
                if (rowSelected > -1) 
                {
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    int IDFamiliaProducto = 0;
                    int.TryParse(fila.Cells["IDFamilia"].Value.ToString(), out IDFamiliaProducto);
                    DatosAux.IDFamiliaProducto = IDFamiliaProducto;
                    DatosAux.Descripcion = fila.Cells["Descripcion"].Value.ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private UnidadMedida ObtenerDatosUnidadMedida()
        {
            try
            {
                UnidadMedida DatosAux = new UnidadMedida();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (rowSelected > -1)
                {
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    int IDUnidadMedida = 0;
                    int.TryParse(fila.Cells["IDUnidadMedida"].Value.ToString(), out IDUnidadMedida);
                    DatosAux.IDUnidadMedida = IDUnidadMedida;
                    DatosAux.Descripcion = fila.Cells["Descripcion"].Value.ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private TarjetaMonedero ObtenerDatosTarjetaMonedero()
        {
            try
            {
                TarjetaMonedero DatosAux = new TarjetaMonedero();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (rowSelected > -1)
                {
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    int IDTipoMonedero = 0;
                    int.TryParse(fila.Cells["IDTipoMonedero"].Value.ToString(), out IDTipoMonedero);
                    DatosAux.IDTarjeta = fila.Cells["IDTarjeta"].Value.ToString();
                    DatosAux.IDTipoMonedero = IDTipoMonedero;
                    DatosAux.Folio = fila.Cells["Folio"].Value.ToString();
                    DatosAux.TipoMonederoDesc = fila.Cells["TipoMonedero"].Value.ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private TipoMonedero ObtenerDatosTipoMonedero()
        {
            try
            {
                TipoMonedero DatosAux = new TipoMonedero();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (rowSelected > -1)
                {
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    int IDTipoMonedero = 0, PuntosMinimos = 0;
                    int.TryParse(fila.Cells["IDTipoMonedero"].Value.ToString(), out IDTipoMonedero);
                    int.TryParse(fila.Cells["PuntosMinimos"].Value.ToString(), out PuntosMinimos);
                    DatosAux.IDTipoMonedero = IDTipoMonedero;
                    DatosAux.PuntosMinimos = PuntosMinimos;
                    DatosAux.Descripcion = fila.Cells["Descripcion"].Value.ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Padecimiento ObtenerDatosPadecimiento()
        {
            try
            {
                Padecimiento DatosAux = new Padecimiento();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (rowSelected > -1)
                {
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    DatosAux.IDPadecimiento = fila.Cells["IDPadecimiento"].Value.ToString();
                    DatosAux.Descripcion = fila.Cells["Descripcion"].Value.ToString();
                    DatosAux.Validar = (bool)fila.Cells["Verificar"].Value ? 1:0;
                   
                      
                    
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private TagInteres ObtenerDatosTagsInteres()
        {
            try
            {
                TagInteres DatosAux = new TagInteres();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (rowSelected > -1)
                {
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    DatosAux.IDTagInteres = fila.Cells["IDTagInteres"].Value.ToString();
                    DatosAux.Descripcion = fila.Cells["Descripcion"].Value.ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Proveedor ObtenerDatosProveedor()
        {
            try
            {
                Proveedor DatosAux = new Proveedor();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (rowSelected > -1)
                {
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    DatosAux.IDProveedor = fila.Cells["IDProveedor"].Value.ToString();
                    DatosAux.NombreComercial = fila.Cells["NombreComercial"].Value.ToString();
                    DatosAux.RegimenFiscal = fila.Cells["RegimenFiscal"].Value.ToString();
                    DatosAux.RazonSocial = fila.Cells["RazonSocial"].Value.ToString();
                    DatosAux.Representante = fila.Cells["Representante"].Value.ToString();
                    DatosAux.Correo = fila.Cells["Correo"].Value.ToString();
                    DatosAux.Telefono = fila.Cells["Telefono"].Value.ToString();
                    DatosAux.DirCalle = fila.Cells["DiCalle"].Value.ToString();
                    DatosAux.DirColonia = fila.Cells["DirColonia"].Value.ToString();
                    DatosAux.DirNumero = fila.Cells["DirNumero"].Value.ToString();
                    DatosAux.CodigoPostal = fila.Cells["CodigoPostal"].Value.ToString();
                    DatosAux.IDPais = Convert.ToInt32(fila.Cells["IDPais"].Value.ToString());
                    DatosAux.IDEstado = Convert.ToInt32(fila.Cells["IDEstado"].Value.ToString());
                    DatosAux.IDMunicipio = Convert.ToInt32(fila.Cells["IDMunicipio"].Value.ToString());
                    DatosAux.Mobiliario = bool.Parse(fila.Cells["Mobiliario"].Value.ToString());
                    DatosAux.RFC = fila.Cells["Rfc"].Value.ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Sucursal ObtenerDatosSucursales()
        {
            try
            {
                Sucursal DatosAux = new Sucursal();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (rowSelected > -1)
                {
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    DatosAux.IDSucursal = fila.Cells["IDSucursal"].Value.ToString();
                    DatosAux.IDEmpresa = Convert.ToInt32(fila.Cells["IDEmpresa"].Value.ToString());
                    DatosAux.IDTipoSucursal = Convert.ToInt32(fila.Cells["IDTipoSucursal"].Value.ToString());
                    DatosAux.IDMunicipio = Convert.ToInt32(fila.Cells["IDMunicipio"].Value.ToString());
                    DatosAux.IDEstado = Convert.ToInt32(fila.Cells["IDEstado"].Value.ToString());
                    DatosAux.IDPais = Convert.ToInt32(fila.Cells["IDPais"].Value.ToString());
                    DatosAux.NombreSucursal = fila.Cells["NombreSucursal"].Value.ToString();
                    DatosAux.Direccion = fila.Cells["Direccion"].Value.ToString();
                    DatosAux.Telefono = fila.Cells["Telefono"].Value.ToString();
                    DatosAux.CodigoPostal = fila.Cells["CodigoPostal"].Value.ToString();
                    DatosAux.PorcentajeMonedero = Convert.ToSingle(fila.Cells["PorcentajeMonedero"].Value.ToString());
                    DatosAux.rfc = fila.Cells["RFC"].Value.ToString();
                    DatosAux.Representante = fila.Cells["Representante"].Value.ToString();
                    DatosAux.RegimenFiscal = fila.Cells["RegimenFiscal"].Value.ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Curso ObtenerDatosCurso()
        {
            try
            {
                Curso DatosAux = new Curso();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (rowSelected > -1)
                {
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    DatosAux.IDCurso = fila.Cells["IDCurso"].Value.ToString();
                    DatosAux.Nombre = fila.Cells["Nombre"].Value.ToString();
                    DatosAux.Descripcion = fila.Cells["Descripcion"].Value.ToString();
                    DatosAux.ObjetivoGeneral = fila.Cells["ObjetivoGeneral"].Value.ToString();
                    DatosAux.Horas = Convert.ToInt32(fila.Cells["Horas"].Value.ToString());
                    DatosAux.CalificacionMinAprobatoria = Convert.ToDecimal(fila.Cells["CalificacionMinAprobatoria"].Value.ToString());
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private TemasCurso ObtenerDatosTemasCursos()
        {
            try
            {
                TemasCurso DatosAux = new TemasCurso();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (rowSelected > -1)
                {
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    DatosAux.IDTemaCurso = fila.Cells["IDTemaCurso"].Value.ToString();
                    DatosAux.Descripcion = fila.Cells["Descripcion"].Value.ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Puestos ObtenerDatosPuestos()
        {
            try
            {
                Puestos DatosAux = new Puestos();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (rowSelected > -1)
                {
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    DatosAux.IDPuesto = Convert.ToInt32(fila.Cells["IDPuesto"].Value.ToString());
                    DatosAux.Descripcion = fila.Cells["Descripcion"].Value.ToString();
                    bool EsGerente = false;
                    bool.TryParse(fila.Cells["EsGerente"].Value.ToString(), out EsGerente);
                    DatosAux.EsGerente = EsGerente;
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Horario ObtenerDatosHorarios()
        {
            try
            {
                Horario DatosAux = new Horario();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (rowSelected > -1)
                {
                    TimeSpan HoraEntrada = new TimeSpan();
                    TimeSpan HoraSalida = new TimeSpan();
                    TimeSpan InicioValidarEntrada = new TimeSpan();
                    TimeSpan FinValidarEntrada = new TimeSpan();
                    TimeSpan InicioValidarSalida = new TimeSpan();
                    TimeSpan FinValidarSalida = new TimeSpan();
                    int ToleranciaLlegadaTarde = 0, ToleranciaSalidaTemprano = 0;
                    
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    DatosAux.IDTurno = Convert.ToInt32(fila.Cells["IDTurno"].Value.ToString());
                    DatosAux.NombreTurno = fila.Cells["NombreTurno"].Value.ToString();
                    
                    DatosAux.ToleraciaLlegadaTarde = Convert.ToInt32(fila.Cells["ToleranciaLlegadaTarde"].Value.ToString());
                    DatosAux.ToleranciaSalidaTemprano = Convert.ToInt32(fila.Cells["ToleranciaSalidaTemprano"].Value.ToString());
                    TimeSpan.TryParse(fila.Cells["HorarioEntrada"].Value.ToString(), out HoraEntrada);
                    DatosAux.HoraEntrada = HoraEntrada;
                    TimeSpan.TryParse(fila.Cells["HorarioSalida"].Value.ToString(), out HoraSalida);
                    DatosAux.HoraSalida = HoraSalida;
                    TimeSpan.TryParse(fila.Cells["InicioValidezEntrada"].Value.ToString(), out InicioValidarEntrada);
                    DatosAux.InicioValidezEntrada = InicioValidarEntrada;
                    TimeSpan.TryParse(fila.Cells["FinValidezEntrada"].Value.ToString(), out FinValidarEntrada);
                    DatosAux.FinValidezEntrada = FinValidarEntrada;
                    TimeSpan.TryParse(fila.Cells["InicioValidezSalida"].Value.ToString(), out InicioValidarSalida);
                    DatosAux.InicioValidezSalida = InicioValidarSalida;
                    TimeSpan.TryParse(fila.Cells["FinValidezSalida"].Value.ToString(), out FinValidarSalida);
                    DatosAux.FinValidezSalida = FinValidarSalida;
                    int.TryParse(fila.Cells["ToleranciaLlegadaTarde"].Value.ToString(), out ToleranciaLlegadaTarde);
                    DatosAux.ToleraciaLlegadaTarde = ToleranciaLlegadaTarde;
                    int.TryParse(fila.Cells["ToleranciaSalidaTemprano"].Value.ToString(), out ToleranciaSalidaTemprano);
                    DatosAux.ToleranciaSalidaTemprano = ToleranciaSalidaTemprano;
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Rubro ObtenerDatosGastosRubros()
        {
            try
            {
                Rubro DatosAux = new Rubro();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (rowSelected > -1)
                {
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    int IDRubro = 0;
                    int.TryParse(fila.Cells["IDRubro"].Value.ToString(), out IDRubro);
                    DatosAux.IDRubro = IDRubro;
                    DatosAux.Descripcion = fila.Cells["Descripcion"].Value.ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Subrubro ObtenerDatosGastosSubRubro()
        {
            try
            {
                Subrubro DatosAux = new Subrubro();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (rowSelected > -1)
                {
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    int IDRubro = 0;
                    int.TryParse(fila.Cells["IDRubro"].Value.ToString(), out IDRubro);
                    DatosAux.IDSubrubro = fila.Cells["IDSubRubro"].Value.ToString();
                    DatosAux.IDRubro = IDRubro;
                    DatosAux.Descripcion = fila.Cells["Descripcion"].Value.ToString();
                    DatosAux.Rubro = fila.Cells["Rubro"].Value.ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Instructor ObtenerDatosInstructores()
        {
            try
            {
                Instructor DatosAux = new Instructor();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (rowSelected > -1)
                {
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    DatosAux.IDInstructor = fila.Cells["IDInstructor"].Value.ToString();
                    DatosAux.Nombre = fila.Cells["Nombre"].Value.ToString();
                    DatosAux.ApellidoPat = fila.Cells["ApellidoPat"].Value.ToString();
                    DatosAux.ApellidoMat = fila.Cells["ApellidoMat"].Value.ToString();
                    DatosAux.IDGenero = Convert.ToInt32(fila.Cells["IDGenero"].Value.ToString());
                    DatosAux.Correo = fila.Cells["Correo"].Value.ToString();
                    DatosAux.Telefono = fila.Cells["Telefono"].Value.ToString();
                    DatosAux.FechaNac = Convert.ToDateTime(fila.Cells["FechaNac"].Value.ToString());
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private TipoMobiliario ObtenerDatosTipoMobiliario()
        {
            try
            {
                TipoMobiliario DatosAux = new TipoMobiliario();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (rowSelected > -1)
                {
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    DatosAux.IDTipoMobiliario = fila.Cells["IDTipoMobiliario"].Value.ToString();
                    DatosAux.Descripcion = fila.Cells["Descripcion"].Value.ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ConceptoNomina ObtenerDatosConceptoNomina()
        {
            try
            {
                ConceptoNomina DatosAux = new ConceptoNomina();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (rowSelected > -1)
                {
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    int ID = 0;
                    int.TryParse(fila.Cells["IDConceptoNomina"].Value.ToString(), out ID);
                    DatosAux.IDConceptoNomina = ID;
                    DatosAux.Descripcion = fila.Cells["Descripcion"].Value.ToString();
                    bool Cal;
                    bool.TryParse(fila.Cells["Calculado"].Value.ToString(), out Cal);
                    DatosAux.Calculado = Cal;
                    bool sumaresta;
                    bool.TryParse(fila.Cells["SumaResta"].Value.ToString(), out sumaresta);
                    DatosAux.SumaResta = sumaresta;
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private Producto ObtenerDatosProductoExtra()
        {
            try
            {
                Producto DatosAux = new Producto();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (rowSelected > -1)
                {
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    DatosAux.IDProducto = fila.Cells["IDProducto"].Value.ToString();
                    DatosAux.Clave = fila.Cells["ClaveProducto"].Value.ToString();
                    DatosAux.NombreProducto = fila.Cells["NombreProducto"].Value.ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private DiasFestivos ObtenerDatosDiasFestivos()
        {
            try
            {
                DiasFestivos DatosAux = new DiasFestivos();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (rowSelected > -1)
                {
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    DatosAux.IDDiasFestivos = fila.Cells["IDDiasFestivos"].Value.ToString();
                    DatosAux.Descripcion = fila.Cells["Descripcion"].Value.ToString();
                    DatosAux.Fecha = Convert.ToDateTime(fila.Cells["Fecha"].Value.ToString());
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private TipoUsuario ObtenerDatosTipoUsuario()
        {
            try
            {
                TipoUsuario DatosAux = new TipoUsuario();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (rowSelected > -1)
                {
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    int ID;
                    int.TryParse(fila.Cells["IDTipoUsuario"].Value.ToString(), out ID);
                    DatosAux.IDTipoUsuario = ID;
                    DatosAux.Descripcion = fila.Cells["Descripcion"].Value.ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private Banco ObtenerDatosBancos()
        {
            try
            {
                Banco DatosAux = new Banco();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (rowSelected > -1)
                {
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    int ID;
                    int.TryParse(fila.Cells["IDBanco"].Value.ToString(), out ID);
                    DatosAux.IDBanco = ID;
                    DatosAux.Descripcion = fila.Cells["Descripcion"].Value.ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private CategoriaCheckList ObtenerDatosCategoriaActividad()
        {
            try
            {
                CategoriaCheckList DatosAux = new CategoriaCheckList();
                Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (rowSelected > -1)
                {
                    DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                    int ID = 0;
                    int.TryParse(fila.Cells["IDCategoria"].Value.ToString(), out ID);
                    DatosAux.IDCategoriaChe = ID;
                    DatosAux.Descripcion = fila.Cells["Descripcion"].Value.ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ActividadesCheckList ObtenerDatosActividad()
        {
            ActividadesCheckList DatosAux = new ActividadesCheckList();
            Int32 rowSelected = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowSelected > -1)
            {
                DataGridViewRow fila = this.dataGridView1.Rows[rowSelected];
                int ID = 0, ID2 = 0, ID3;
                int.TryParse(fila.Cells["IDActividad"].Value.ToString(), out ID);
                DatosAux.IDActividades = ID;
                int.TryParse(fila.Cells["IDCategoria"].Value.ToString(), out ID2);
                DatosAux.IDCategoriaChe = ID2;
                DatosAux.Descripcion = fila.Cells["Descripcion"].Value.ToString();
                int.TryParse(fila.Cells["Orden"].Value.ToString(), out ID3);
                DatosAux.Orden = ID3;
            }
            return DatosAux;
        }
        #endregion

        #region Métodos Llenar Datos

        private void LlenarGridFamilias()
        {
            try
            {
                FamiliaProducto DatosAux = new FamiliaProducto();
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.Opcion = 1;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerCatFamiliaProductos(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridPadecimiento()
        {
            try
            {
                Padecimiento DatosAux = new Padecimiento();
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.Opcion = 1;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerCatPadecimiento(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridProveedor()
        {
            try
            {
                Proveedor DatosAux = new Proveedor();
                DatosAux.Conexion = Comun.Conexion;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerCatProveedores(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridSucursales()
        {
            try
            {
                Sucursal DatosAux = new Sucursal();
                DatosAux.Conexion = Comun.Conexion;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerCatSucursales(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridCursos()
        {
            try
            {
                Curso DatosAux = new Curso();
                DatosAux.Conexion = Comun.Conexion;
                bool BandTodos = false;
                DatosAux.BuscarTodos = BandTodos;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerCatCursos(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridTemasCurso()
        {
            try
            {
                TemasCurso DatosAux = new TemasCurso();
                DatosAux.Conexion = Comun.Conexion;
                bool BandTodos = false;
                DatosAux.BuscarTodos = BandTodos;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerCatTemasCurso(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridPuesto()
        {
            try
            {
                Puestos DatosAux = new Puestos();
                DatosAux.Conexion = Comun.Conexion;
                bool BandTodos = false;
                DatosAux.BuscarTodos = BandTodos;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerCatPuestos(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LlenarGridHorarios()
        {
            try
            {
                Horario DatosAux = new Horario();
                DatosAux.Conexion = Comun.Conexion;
                bool BandTodos = false;
                DatosAux.BuscarTodos = BandTodos;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerCatHorarios(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridGastosRubros()
        {
            try
            {
                Rubro DatosAux = new Rubro();
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.Opcion = 1;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerCatGastosRubros(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LlenarGridGastosSubRubros()
        {
            try
            {
                Subrubro DatosAux = new Subrubro();
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.Opcion = 1;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerCatGastosSubRubros(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarInstructor()
        {
            try
            {
                Instructor DatosAux = new Instructor();
                DatosAux.Conexion = Comun.Conexion;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerInstructore(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LlenarTipoMobiliario()
        {
            try
            {
                TipoMobiliario DatosAux = new TipoMobiliario();
                DatosAux.Conexion = Comun.Conexion;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerTipoMobiliario(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LlenarGribConceptoNomina()
        {
            try
            {
                ConceptoNomina DatosAux = new ConceptoNomina();
                DatosAux.Conexion = Comun.Conexion;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerConceptoNomina(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LlenarGridProductoExtra()
        {
            try
            {
                Producto DatosAux = new Producto();
                DatosAux.Conexion = Comun.Conexion;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerProductosExtras(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LlenarGridDiasFestivos()
        {
            try
            {
                DiasFestivos DatosAux = new DiasFestivos();
                DatosAux.Conexion = Comun.Conexion;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerDiasFestivos(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LlenarGridTipoUsuario()
        {
            try
            {
                TipoUsuario DatosAux = new TipoUsuario();
                DatosAux.Conexion = Comun.Conexion;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerTipoUsuario(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LlenarGridTagInteres()
        {
            try
            {
                TagInteres DatosAux = new TagInteres();
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.Opcion = 1;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerCatTagInteres(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LlenarGridBanco()
        {
            try
            {
                Banco DatosAux = new Banco();
                DatosAux.Conexion = Comun.Conexion;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerBanco(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LlenarGridCategoriaActividad()
        {
            try
            {
                CategoriaCheckList DatosAux = new CategoriaCheckList();
                DatosAux.Conexion = Comun.Conexion;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerCategoriaActividad(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LlenarGridActividad()
        {
            try
            {
                ActividadesCheckList DatosAux = new ActividadesCheckList();
                DatosAux.Conexion = Comun.Conexion;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerActividad(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LlenarGridTarjetasMonedero()
        {
            try
            {
                TarjetaMonedero DatosAux = new TarjetaMonedero();
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.Opcion = 1;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerCatTarjetaMonedero(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridTipoMonedero()
        {
            try
            {
                TipoMonedero DatosAux = new TipoMonedero();
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.Opcion = 1;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerCatTipoMonedero(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridUnidadMedida()
        {
            try
            {
                UnidadMedida DatosAux = new UnidadMedida();
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.Opcion = 1;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerCatUnidadMedida(DatosAux);
                this.dataGridView1.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion        

        #region Métodos Propiedades Grid

        private object[,] ObtenerPropiedadesGridFamilias()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDFamilia",           "IDFamilia",            "IDFamilia",            1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Familia de Producto", "Descripcion",          "Descripcion",  1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private object[,] ObtenerPropiedadesGridPadecimiento()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDPadecimiento",      "IDPadecimiento",       "IDPadecimiento",       1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Padecimiento",        "Descripcion",          "Descripcion",          1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Verificado",          "Verificar",              "Verificar",          3,          true,           125,        DataGridViewContentAlignment.MiddleLeft,        "",         true},//agregue, zincri
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private object[,] ObtenerPropiedadesGridProveedor()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDProveedor",         "IDProveedor",          "IDProveedor",          1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Razón Social",        "RazonSocial",          "RazonSocial",          1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Nombre Comercial",    "NombreComercial",      "NombreComercial",      1,          true,           200,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Regimen Fiscal",      "RegimenFiscal",        "RegimenFiscal",        1,          true,           200,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"RFC",                 "Rfc",                  "Rfc",                  1,          true,           125,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Agente de Ventas",    "Representante",        "Representante",        1,          true,           200,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Correo Electrónico",  "Correo",               "Correo",               1,          true,           200,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Número Telefónico",   "Telefono",             "Telefono",             1,          true,           100,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Calle",               "DiCalle",              "DiCalle",              1,          true,           100,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Colonia",             "DirColonia",           "DirColonia",           1,          true,           100,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Numero",              "DirNumero",            "DirNumero",            1,          true,           100,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"C.P",                 "CodigoPostal",         "CodigoPostal",         1,          true,           100,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"IDPais",              "IDPais",               "IDPais",               1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,        "",         true},
                    {"IDEstado",            "IDEstado",             "IDEstado",             1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,        "",         true},
                    {"IDMunicipio",         "IDMunicipio",          "IDMunicipio",          1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,        "",         true},
                    {"Mobiliario",          "Mobiliario",           "Mobiliario",           3,          true,          125,        DataGridViewContentAlignment.MiddleCenter,        "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private object[,] ObtenerPropiedadesGridSucursales()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDSucursal",          "IDSucursal",           "IDSucursal",           1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"IDEmpresa",           "IDEmpresa",            "IDEmpresa",            1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"IDTipoSucursal",      "IDTipoSucursal",       "IDTipoSucursal",       1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"IDMunicipio",         "IDMunicipio",          "IDMunicipio",          1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"IDEstado",            "IDEstado",             "IDEstado",             1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"IDPais",              "IDPais",               "IDPais",               1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Nombre Sucursal",     "NombreSucursal",       "NombreSucursal",       1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Tipo Usuario",        "TipoUsuario",          "TipoUsuario",          1,          true,           200,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"RFC",                 "RFC",                  "RFC",                  1,          true,           200,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Direccion",           "Direccion",            "Direccion",            1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Telefono",            "Telefono",             "Telefono",             1,          true,           125,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Codigo Postal",      "CodigoPostal",          "CodigoPostal",         1,          true,           125,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Nombre Representante","Representante",        "Representante",        1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Régimen Fiscal",      "RegimenFiscal",        "RegimenFiscal",        1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Porcentaje Monedero","PorcentajeMonedero",    "PorcentajeMonedero",   1,          false,          125,        DataGridViewContentAlignment.MiddleLeft,        "C2",       true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private object[,] ObtenerPropiedadesGridCursos()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDCurso",             "IDCurso",              "IDCurso",              1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Nombre",              "Nombre",               "Nombre",               1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Descripcion",         "Descripcion",          "Descripcion",          1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Objetivo General",    "ObjetivoGeneral",      "ObjetivoGeneral",      1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Horas",               "Horas",                "Horas",                1,          true,           125,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Calificacion Aprobatoria",      "CalificacionMinAprobatoria",          "CalificacionMinAprobatoria",         1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private object[,] ObtenerPropiedadesGridTemas()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDTemaCurso",       "IDTemaCurso",        "IDTemaCurso",        1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Descripcion",         "Descripcion",          "Descripcion",          1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private object[,] ObtenerPropiedadesGridPuesto()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDPuesto",            "IDPuesto",             "IDPuesto",             1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Descripcion",         "Descripcion",          "Descripcion",          1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"EsGerente",         "EsGerente",          "EsGerente",          1,          false,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private object[,] ObtenerPropiedadesGridHorarios()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDTurno",             "IDTurno",             "IDTurno",                  1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"NombreTurno",         "NombreTurno",          "NombreTurno",             1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"H. Entrada",          "HorarioEntrada",       "HorarioEntrada",          1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"H. Salida",           "HorarioSalida",        "HorarioSalida",           1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Inicio Validar Entrada",     "InicioValidezEntrada",        "InicioValidezEntrada",           1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Fin Validar Salida",         "FinValidezEntrada",        "FinValidezEntrada",                 1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Inicio Validar Salida",      "InicioValidezSalida",        "InicioValidezSalida",             1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Fin Validar Salida",         "FinValidezSalida",        "FinValidezSalida",                   1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"T. llegada Tarde",           "ToleranciaLlegadaTarde",        "ToleranciaLlegadaTarde",       1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"T. Salida Temprano",         "ToleranciaSalidaTemprano",        "ToleranciaSalidaTemprano",   1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Dias de Trabajo",            "DiasDeTrabajo",        "DiasDeTrabajo",                         1,          false,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private object[,] ObtenerPropiedadesGridGastosRubros()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDRubro",             "IDRubro",            "IDRubro",            1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Gastos Rubros",        "Descripcion",        "Descripcion",       1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private object[,] ObtenerPropiedadesGridGastosSubRubros()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDSubRubro",           "IDSubRubro",            "IDSubRubro",            1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"IDRubro",             "IDRubro",                "IDRubro",       1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Rubro",               "Rubro",         "Rubro",         1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"SubRubro",          "Descripcion",           "Descripcion",                1,          true,           180,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private object[,] ObtenerPropiedadesGridInstructor()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDInstructor",        "IDInstructor",         "IDInstructor",         1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Nombre",              "Nombre",               "Nombre",               1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Apellido Paterno",    "ApellidoPat",          "ApellidoPat",          1,          true,           200,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Apellido Materno",    "ApellidoMat",          "ApellidoMat",          1,          true,           200,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"IDGenero",            "IDGenero",             "IDGenero",             1,          false,          125,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Fecha Nacimiento",    "FechaNac",              "FechaNac",      1,          true,           200,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Correo Electrónico",  "Correo",               "Correo",               1,          true,           200,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Número Telefónico",   "Telefono",             "Telefono",             1,          true,           200,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private object[,] ObtenerPropiedadesGridTipoMobiliario()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDTipoMobiliario",        "IDTipoMobiliario",         "IDTipoMobiliario",         1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Descripcion",              "Descripcion",               "Descripcion",               1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private object[,] ObtenerPropiedadesGridConceptoNomina()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDConceptoNomina",    "IDConceptoNomina",     "IDConceptoNomina",       1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Concepto Nomina",     "Descripcion",          "Descripcion",          1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Calculado",           "Calculado",               "Calculado",        3,          true,           180,        DataGridViewContentAlignment.MiddleRight,       "",         true},
                    {"¿Suma?",           "SumaResta",               "SumaResta",        3,          true,           180,        DataGridViewContentAlignment.MiddleRight,       "",         true},
                    {"Solo Lectura",           "SoloLectura",               "SoloLectura",        3,          false,           180,        DataGridViewContentAlignment.MiddleRight,       "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private object[,] ObtenerPropiedadesGridProductoExtra()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDProducto",          "IDProducto",           "IDProducto",       1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Clave Producto",      "ClaveProducto",        "ClaveProducto",          1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Nombre Producto",     "NombreProducto",           "NombreProducto",        1,          true,           300,        DataGridViewContentAlignment.MiddleLeft,       "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private object[,] ObtenerPropiedadesGridDiasFestivos()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDDiasFestivos",      "IDDiasFestivos",       "IDDiasFestivos",       1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Nombre",              "Descripcion",         "Descripcion",          1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Fecha",     "Fecha",           "Fecha",        1,          true,           300,        DataGridViewContentAlignment.MiddleLeft,       "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private object[,] ObtenerPropiedadesGridTipoUsuario()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDTipoUsuario",      "IDTipoUsuario",       "IDTipoUsuario",       1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Descripcion",              "Descripcion",         "Descripcion",          1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private object[,] ObtenerPropiedadesGridBanco()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDBanco",      "IDBanco",       "IDBanco",       1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Descripcion",              "Descripcion",         "Descripcion",          1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private object[,] ObtenerPropiedadesGridCategoriaActividad()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDCategoria",      "IDCategoria",       "IDCategoria",       1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Descripcion",              "Descripcion",         "Descripcion",          1,          true,           700,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private object[,] ObtenerPropiedadesGridActividad()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDActividad",      "IDActividad",       "IDActividad",       1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"IDCategoria",      "IDCategoria",       "IDCategoria",       1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Nombre Categoria",    "NombreCategoria",   "NombreCategoria",          1,          true,           350,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Actividad",              "Descripcion",         "Descripcion",          1,          true,           350,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Orden",              "Orden",         "Orden",          1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private object[,] ObtenerPropiedadesGridTagsInteres()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDTagInteres",        "IDTagInteres",         "IDTagInteres",         1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Tag de interés",        "Descripcion",          "Descripcion",        1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private object[,] ObtenerPropiedadesGridTarjetaMonedero()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDTarjeta",           "IDTarjeta",            "IDTarjeta",            1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"IDTipoMonedero",      "IDTipoMonedero",       "IDTipoMonedero",       1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Folio",               "Folio",                "Folio",                1,          true,           180,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Tipo de monedero",    "TipoMonedero",         "TipoMonedero",         1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private object[,] ObtenerPropiedadesGridTipoMonedero()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDTipoMonedero",      "IDTipoMonedero",       "IDTipoMonedero",       1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Tipo de monedero",    "Descripcion",          "Descripcion",          1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Puntos Mínimos",      "PuntosMinimos",        "PuntosMinimos",        1,          true,           180,        DataGridViewContentAlignment.MiddleRight,       "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private object[,] ObtenerPropiedadesGridUnidadMedida()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDUnidadMedida",      "IDUnidadMedida",       "IDUnidadMedida",       1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Unidad de Medida",    "Descripcion",          "Descripcion",          1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #endregion

        #region Eventos

        #region Eventos Click

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TipoCatalogo > 0)
                {
                    this.Busqueda(this.txtBusqueda.Text);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogos ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarBusqueda_Click(object sender, EventArgs e)
        {
            try
            {
                if (TipoCatalogo > 0)
                {
                    this.dataGridView1.DataSource = DatosActuales;
                }
                this.txtBusqueda.Text = string.Empty;
                this.txtBusqueda.Focus();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogos ~ btnCancelarBusqueda_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Creativa BtnClick = (Button_Creativa) sender;
                int AuxTipoCatalogo = 0;
                int.TryParse(BtnClick.Tag.ToString(), out AuxTipoCatalogo);
                this.TipoCatalogo = AuxTipoCatalogo;
                this.CargarGridCatalogo();
                this.txtBusqueda.Focus();

            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogos ~ btnFamiliaProducto_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecargarGridPadecimiento()
        {
            try
            {
                //Button_Creativa BtnClick = (Button_Creativa)sender;
                //int AuxTipoCatalogo = 0;
                //int.TryParse(BtnClick.Tag.ToString(), out AuxTipoCatalogo);
                this.TipoCatalogo = 4;
                this.CargarGridCatalogo();
                this.txtBusqueda.Focus();

            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogos ~ btnFamiliaProducto_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count == 1)
                {
                    if (DialogResult.Yes == MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        this.EliminarRegistro(this.ObtenerDatos());
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogos ~ btnEliminar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count == 1)
                {
                    this.CargarFormModificar(this.ObtenerDatos());
                    this.CargarGridCatalogo();
                    //this.RecargarGridPadecimiento();
                }
                else
                {
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogos ~ btnNuevo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                //Buton nuevo de catalogos
                this.CargarFormNuevo();
                this.CargarGridCatalogo();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogos ~ btnNuevo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAsignarGerente_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count == 1)
                    this.CargarFromSucurcarGenrente(this.ObtenerDatos());
                else
                {
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogos ~ btnNuevo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogos ~ btnSalir_Click");
            }
        }

        #endregion

        #region Eventos del Formulario

        private void frmCatalogos_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (DatosActuales != null)
                    DatosActuales.Dispose();
                this.LiberarMemoria(this);
               
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogos ~ frmCatalogos_FormClosing");
            }
        }

        #endregion

        #region Eventos en TextBox

        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Busqueda(this.txtBusqueda.Text);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogos ~ txtBusqueda_KeyUp");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void frmCatalogos_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion        

    }
}
