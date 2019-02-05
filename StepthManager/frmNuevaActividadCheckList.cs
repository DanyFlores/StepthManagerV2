using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using CreativaSL.Dll.Validaciones;
using StephManager.ClasesAux;
using System.IO;

namespace StephManager
{
    public partial class frmNuevaActividadCheckList : Form
    {

        #region Propiedades / Variables 
        private int TipoForm = 0;
        private ChechkList _DatosChechkList;
        public ChechkList DatosChechkList
        {
            get { return _DatosChechkList; }
            set { _DatosChechkList = value; }
        }
        #endregion

        #region Constructores

        public frmNuevaActividadCheckList()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;
            }
            catch(Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaActividadCheckList ~ frmNuevaActividadCheckList()");
            }
        }

        public frmNuevaActividadCheckList(ChechkList DatosAux)
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 2;
                this._DatosChechkList = DatosAux;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaActividadCheckList ~ frmNuevaActividadCheckList(ChechkList DatosAux)");
            }
        }
        #endregion

        #region Métodos

        private void CargarDatosAModificar(ChechkList DatosAux)
        {
            try
            {
                this.lbltitulo.Text = DatosAux.Titulo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void IniciarForm()
        {
            try
            {
                this.LlenarGridChecListActividad(false, this._DatosChechkList.IDCheckList);
                if (this.TipoForm ==1)
                    this.IniciarDatos();
                else
                    this.CargarDatosAModificar(this._DatosChechkList);
                    this.ActiveControl = this.btnAgregarActividad;
                this.btnAgregarActividad.Focus();
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

        private void IniciarDatos()
        {
            try
            {
                this.lbltitulo.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridChecListActividad(bool Band, string IDCheckList)
        {
            try
            {
                ActividadesCheckList DatosAux = new ActividadesCheckList { Conexion = Comun.Conexion, BuscarTodos = Band, IDCheckList = IDCheckList };
                ActividadCheckList_Negocio CN = new ActividadCheckList_Negocio();
                CN.ObtenerCatActividadCheck(DatosAux);
                this.dgvActividadesCheckList.AutoGenerateColumns = false;
                this.dgvActividadesCheckList.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ActividadesCheckList ObtenerDatosAvtividadCheckList()
        {
            try
            {
                ActividadesCheckList DatosAux = new ActividadesCheckList();
                Int32 RowData = this.dgvActividadesCheckList.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowData > -1)
                {
                    DataGridViewRow FilaDatos = this.dgvActividadesCheckList.Rows[RowData];
                    DatosAux.IDActividades = Convert.ToInt32(FilaDatos.Cells["IDActividadCheckList"].Value.ToString());
                    DatosAux.IDCategoriaChe = Convert.ToInt32(FilaDatos.Cells["IDCategorioCheckList"].Value.ToString());
                    DatosAux.NombreCategoria = FilaDatos.Cells["NombreCategoria"].Value.ToString();
                    DatosAux.Descripcion = FilaDatos.Cells["NombreActividad"].Value.ToString();
                    DatosAux.Orden = Convert.ToInt32(FilaDatos.Cells["Orden"].Value.ToString());
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ModificarDatos(ActividadesCheckList Datos)
        {
            try
            {
                Int32 RowToUpdate = this.dgvActividadesCheckList.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowToUpdate > -1)
                {
                    this.dgvActividadesCheckList.Rows[RowToUpdate].Cells["IDActividadCheckList"].Value = Datos.IDActividades;
                    this.dgvActividadesCheckList.Rows[RowToUpdate].Cells["IDCategorioCheckList"].Value = Datos.IDCategoriaChe;
                    this.dgvActividadesCheckList.Rows[RowToUpdate].Cells["NombreCategoria"].Value = Datos.NombreCategoria;
                    this.dgvActividadesCheckList.Rows[RowToUpdate].Cells["NombreActividad"].Value = Datos.Descripcion;
                    this.dgvActividadesCheckList.Rows[RowToUpdate].Cells["Orden"].Value = Datos.Orden;
                }
                else
                    this.LlenarGridChecListActividad(false, _DatosChechkList.IDCheckList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void BusquedaCheckActividad(string TextoCheck, string ID)
        {
            try
            {
                ActividadesCheckList DatosAux = new ActividadesCheckList { Conexion = Comun.Conexion, Descripcion = TextoCheck, BuscarTodos = false, IDCheckList = ID };
                ActividadCheckList_Negocio CN = new ActividadCheckList_Negocio();
                CN.ObtenercheckBusquedaAct(DatosAux);
                this.dgvActividadesCheckList.AutoGenerateColumns = false;
                this.dgvActividadesCheckList.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    #endregion

    #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaActividadCheckList ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmNuevaActividadCheckList_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    #endregion

        private void btnAgregarActividad_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevActividadCheck Check = new frmNuevActividadCheck(this._DatosChechkList);
                Check.ShowDialog();
                Check.Dispose();
                this.Visible = true;
                if (Check.DialogResult == DialogResult.OK)
                {
                    this.LlenarGridChecListActividad(true, Check.DatosCheckList.IDCheckList);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaActividadCheckList ~ btnAgregarActividad_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnQuitarActividad_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvActividadesCheckList.SelectedRows.Count == 1)
                {
                    ActividadesCheckList DatosAux = this.ObtenerDatosAvtividadCheckList();
                    if (DatosAux.IDActividades != 0)
                    {
                        DatosAux.Conexion = Comun.Conexion;
                        DatosAux.IDUsuario = Comun.IDUsuario;
                        DatosAux.Opcion = 3;
                        ActividadCheckList_Negocio ACLN = new ActividadCheckList_Negocio();
                        ACLN.ABCActividadChecKList(DatosAux);
                        if (DatosAux.Completado)
                        {
                            MessageBox.Show("Registro Eliminado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Int32 RowToDelete = this.dgvActividadesCheckList.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                            if (RowToDelete > -1)
                                this.dgvActividadesCheckList.Rows.RemoveAt(RowToDelete);
                            else
                                this.LlenarGridChecListActividad(false, DatosChechkList.IDCheckList);
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar los datos. Contacte a Soporte Técnico.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaActividadCheckList ~ btnQuitarActividad_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnModificarActividad_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvActividadesCheckList.SelectedRows.Count == 1)
                {
                    ActividadesCheckList DatosAux = this.ObtenerDatosAvtividadCheckList();
                    if (DatosAux.IDActividades != 0)
                    {
                        this.Visible = true;
                        frmNuevActividadCheck CheckLsis = new frmNuevActividadCheck(DatosAux, this._DatosChechkList);
                        CheckLsis.ShowDialog();
                        CheckLsis.Dispose();
                        if (CheckLsis.DialogResult == DialogResult.OK)
                        {
                            if (CheckLsis.DatosActividadCheckList.Completado)
                            {
                                this.ModificarDatos(CheckLsis.DatosActividadCheckList);
                            }
                        }
                        this.Visible = true;
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaActividadCheckList ~ btnModificarActividad_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void chkTodosLosRegistros_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.LlenarGridChecListActividad(this.chkTodosLosRegistros.Checked, _DatosChechkList.IDCheckList);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaActividadCheckList ~ chkTodosLosRegistros_CheckedChanged");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtBusqueda.Text.Trim()))
                {
                    this.BusquedaCheckActividad(this.txtBusqueda.Text.Trim(), this._DatosChechkList.IDCheckList);
                }
                else
                {
                    this.LlenarGridChecListActividad(false, this._DatosChechkList.IDCheckList);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaActividadCheckList ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}