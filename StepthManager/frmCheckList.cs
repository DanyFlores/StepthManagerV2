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
using System.Globalization;
using System.IO;

namespace StephManager
{
    public partial class frmCheckList : Form
    {

        #region Constructores

        public frmCheckList()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCheckList ~ frmCheckList()");
            }
        }

        #endregion

        #region Métodos
        private void IniciarForm()
        {
            try
            {
                this.LlenarGridChecList(false);
                this.txtBusqueda.Focus();
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

        private void LlenarGridChecList(bool Band)
        {
            try
            {
                ChechkList DatosAux = new ChechkList { Conexion = Comun.Conexion, BuscarTodos = Band };
                CheckList_Negocio CN = new CheckList_Negocio();
                CN.ObtenerCatCheck(DatosAux);
                this.dgvCheckList.AutoGenerateColumns = false;
                this.dgvCheckList.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BusquedaCheck(string TextoCheck)
        {
            try
            {
                ChechkList DatosAux = new ChechkList { Conexion = Comun.Conexion, Titulo = TextoCheck, BuscarTodos = false };
                CheckList_Negocio CN = new CheckList_Negocio();
                CN.ObtenercheckBusqueda(DatosAux);
                this.dgvCheckList.AutoGenerateColumns = false;
                this.dgvCheckList.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ChechkList ObtenerDatosCheckList()
        {
            try
            {
                ChechkList DatosAux = new ChechkList();
                Int32 RowData = this.dgvCheckList.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowData > -1)
                {
                    DataGridViewRow FilaDatos = this.dgvCheckList.Rows[RowData];
                    DatosAux.IDCheckList = FilaDatos.Cells["IDCheckList"].Value.ToString();
                    DatosAux.IDTipoCheckList = Convert.ToInt32(FilaDatos.Cells["IDTipoCheckList"].Value.ToString());
                    DatosAux.TipoCheck = FilaDatos.Cells["TipoCheck"].Value.ToString();
                    DatosAux.Titulo = FilaDatos.Cells["Titulo"].Value.ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ModificarDatos(ChechkList Datos)
        {
            try
            {
                Int32 RowToUpdate = this.dgvCheckList.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowToUpdate > -1)
                {
                    this.dgvCheckList.Rows[RowToUpdate].Cells["IDCheckList"].Value = Datos.IDCheckList;
                    this.dgvCheckList.Rows[RowToUpdate].Cells["IDTipoCheckList"].Value = Datos.IDTipoCheckList;
                    this.dgvCheckList.Rows[RowToUpdate].Cells["TipoCheck"].Value = Datos.TipoCheck;
                    this.dgvCheckList.Rows[RowToUpdate].Cells["Titulo"].Value = Datos.Titulo;
                }
                else
                    this.LlenarGridChecList(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Eventos

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCheckList ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCheckList_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCheckList ~ frmEncuestas_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoCheckList Check = new frmNuevoCheckList();
                Check.ShowDialog();
                Check.Dispose();
                this.Visible = true;
                if (Check.DialogResult == DialogResult.OK)
                {
                    this.BusquedaCheck(Check.DatosCheckList.Titulo);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCheckList ~ btnNuevo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }
        private void btnActividades_Click(object sender, EventArgs e)
        {
            try
            {
                 if (this.dgvCheckList.SelectedRows.Count == 1)
                {
                    ChechkList DatosAux = this.ObtenerDatosCheckList();
                    if (!string.IsNullOrEmpty(DatosAux.IDCheckList))
                    {
                        this.Visible = false;
                        frmNuevaActividadCheckList Check = new frmNuevaActividadCheckList(DatosAux);
                        Check.ShowDialog();
                        Check.Dispose();
                        this.Visible = true;
                    }
                }
                 else
                     MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCheckList ~ btnActividades_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }
        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtBusqueda.Text.Trim()))
                {
                    this.BusquedaCheck(this.txtBusqueda.Text.Trim());
                }
                else
                {
                    this.LlenarGridChecList(false);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCheckList ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkTodosLosRegistros_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.LlenarGridChecList(this.chkTodosLosRegistros.Checked);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCheckList ~ chkTodosLosRegistros_CheckedChanged");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCheckList.SelectedRows.Count == 1)
                {
                    ChechkList DatosAux = this.ObtenerDatosCheckList();
                    if (!string.IsNullOrEmpty(DatosAux.IDCheckList))
                    {
                        this.Visible = true;
                        frmNuevoCheckList CheckLsis = new frmNuevoCheckList(DatosAux);
                        CheckLsis.ShowDialog();
                        CheckLsis.Dispose();
                        if (CheckLsis.DialogResult == DialogResult.OK)
                        {
                            if (CheckLsis.DatosCheckList.Completado)
                            {
                                this.ModificarDatos(CheckLsis.DatosCheckList);
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
                LogError.AddExcFileTxt(ex, "frmCheckList ~ btnModificar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCheckList.SelectedRows.Count == 1)
                {
                    ChechkList DatosAux = this.ObtenerDatosCheckList();
                    if (!string.IsNullOrEmpty(DatosAux.IDCheckList))
                    {
                        CheckList_Negocio CN = new CheckList_Negocio();
                        DatosAux.Conexion = Comun.Conexion;
                        DatosAux.IDUsuario = Comun.IDUsuario;
                        DatosAux.Opcion = 3;
                        CN.ABCChecKList(DatosAux);
                        if (DatosAux.Completado)
                        {
                            MessageBox.Show("Registro Eliminado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Int32 RowToDelete = this.dgvCheckList.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                            if (RowToDelete > -1)
                                this.dgvCheckList.Rows.RemoveAt(RowToDelete);
                            else
                                this.LlenarGridChecList(false);
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
                LogError.AddExcFileTxt(ex, "frmCheckList ~ btnEliminar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnOpcion_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCheckList.SelectedRows.Count == 1)
                { 
                    ChechkList DatosAux = this.ObtenerDatosCheckList();
                    if(!string.IsNullOrEmpty(DatosAux.IDCheckList))
                    {
                        this.Visible = true;
                        frmNuevaActividadOpcionesCheckList Opiniones = new frmNuevaActividadOpcionesCheckList(DatosAux);
                        Opiniones.ShowDialog();
                        Opiniones.Dispose();
                        this.Visible = true;
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                 LogError.AddExcFileTxt(ex, "frmCheckList ~ btnOpcion_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCheckList.SelectedRows.Count == 1)
                {
                    ChechkList DatosAux = this.ObtenerDatosCheckList();
                    if (!string.IsNullOrEmpty(DatosAux.IDCheckList))
                    {
                        this.Visible = false;
                        frmCheckListRespuesta CheckRespuesta = new frmCheckListRespuesta(DatosAux);
                        CheckRespuesta.ShowDialog();
                        CheckRespuesta.Dispose();
                        this.Visible = true;
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCheckList ~ btnOpcion_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnVerReporte_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCheckList.SelectedRows.Count == 1)
                {
                    ChechkList DatosAux = this.ObtenerDatosCheckList();
                    if (!string.IsNullOrEmpty(DatosAux.IDCheckList))
                    {
                        ChechkListResultado Datos = new ChechkListResultado();
                        this.Visible = true;
                        frmVerRespuestaCheckList Opiniones = new frmVerRespuestaCheckList(2, DatosAux, Datos);
                        Opiniones.ShowDialog();
                        Opiniones.Dispose();
                        this.Visible = true;
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCheckListRespuesta ~ btnResultado_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

    }
}
