using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using CreativaSL.LibControls.WinForms;
using StephManager.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephManager
{
    public partial class frmNomina : Form
    {
        #region Variables globales

        private bool EsBusqueda = false;

        #endregion

        #region Constructor

        public frmNomina()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmGarantias ~ frmGarantias()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarDatos()
        {
            try
            {
                this.dtpFechaInicio.Value = DateTime.Today;
                this.dtpFechaFin.Value = DateTime.Today;
                this.txtBusq.Text = string.Empty;
                this.rbClaveNomina.Checked = true;
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
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
                this.IniciarDatos();
                this.CargarGridNomina();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridNomina()
        {
            try
            {
                Nomina Datos = this.ObtenerDatosBusqueda();
                Nomina_Negocio NN = new Nomina_Negocio();
                NN.ObtenerNominas(Datos);
                this.dgvNomina.AutoGenerateColumns = false;
                this.dgvNomina.DataSource = Datos.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Nomina ObtenerDatosGrid(int Row)
        {
            try
            {
                Nomina DatosAux = new Nomina();
                DataGridViewRow Fila = this.dgvNomina.Rows[Row];
                DatosAux.IDNomina = Fila.Cells["IDNomina"].Value.ToString();
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Nomina ObtenerDatosBusqueda()
        {
            try
            {
                Nomina DatosBusq = new Nomina();
                DatosBusq.EsBusqueda = this.EsBusqueda;
                if (this.rbClaveNomina.Checked)
                {
                    DatosBusq.BandBusqFechas = false;
                    DatosBusq.ClaveNomina = this.txtBusq.Text.Trim();
                    DatosBusq.FechaInicio = DateTime.Today;
                    DatosBusq.FechaFin = DateTime.Today;
                }
                else
                {
                    DatosBusq.BandBusqFechas = true;
                    DatosBusq.ClaveNomina = string.Empty;
                    DatosBusq.FechaInicio = this.dtpFechaInicio.Value;
                    DatosBusq.FechaFin = this.dtpFechaFin.Value;
                }
                DatosBusq.Conexion = Comun.Conexion;
                return DatosBusq;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidarBusquedaClave()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtBusq.Text.Trim()))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidarBusquedaFecha()
        {
            try
            {
                if(this.dtpFechaInicio.Value > this.dtpFechaFin.Value)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        #region Eventos Click
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rbClaveNomina.Checked || this.rbPeriodo.Checked)
                {
                    if (this.rbClaveNomina.Checked)
                    {
                        if (this.ValidarBusquedaClave())
                        {
                            this.EsBusqueda = true;
                            this.CargarGridNomina();
                        }
                        else
                            MessageBox.Show("Ingrese la clave de nómina a buscar.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (this.ValidarBusquedaFecha())
                        {
                            this.EsBusqueda = true;
                            this.CargarGridNomina();
                        }
                        else
                            MessageBox.Show("Ingrese el periodo correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    MessageBox.Show("Seleccione un tipo de Búsqueda.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNomina ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevaNomina_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Creativa btn = (Button_Creativa)sender;
                MenuStripNomina.Show(btn, btn.Width / 2, btn.Height);
                MenuStripNomina.Focus();
                //MenuStrip
                //frmNuevaNomina Nomina = new frmNuevaNomina(2); // Generar la nómina administrativa
                //this.Visible = false;
                //Nomina.ShowDialog();
                //Nomina.Dispose();
                //if (Nomina.DialogResult == DialogResult.OK)
                //{
                //    this.CargarGridNomina();
                //}
                //this.Visible = true;
            }
            catch (Exception ex)
            {
                //this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmNomina ~ btnNuevaNomina_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReporteDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvNomina.SelectedRows.Count == 1)
                {
                    int Row = this.dgvNomina.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Nomina DatosAux = this.ObtenerDatosGrid(Row);
                    if (!string.IsNullOrEmpty(DatosAux.IDNomina))
                    {
                        frmVerListados Reporte = new frmVerListados(4, DatosAux.IDNomina);
                        this.Visible = false;
                        Reporte.ShowDialog();
                        Reporte.Dispose();
                        this.Visible = true;
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmNomina ~ btnReporteDetalle_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReporteSaldos_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvNomina.SelectedRows.Count == 1)
                {
                    int Row = this.dgvNomina.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Nomina DatosAux = this.ObtenerDatosGrid(Row);
                    if (!string.IsNullOrEmpty(DatosAux.IDNomina))
                    {
                        frmVerListados Reporte = new frmVerListados(3, DatosAux.IDNomina);
                        this.Visible = false;
                        Reporte.ShowDialog();
                        Reporte.Dispose();
                        this.Visible = true;
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmNomina ~ btnReporteSaldos_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Abort;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNomina ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Otros eventos

        private void dtpFechaInicio_Enter(object sender, EventArgs e)
        {
            try
            {
                this.rbPeriodo.Checked = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNomina ~ dtpFechaInicio_Enter");
            }
        }

        private void frmNomina_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNomina ~ frmNomina_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbTicket_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rbClaveNomina.Checked)
                    this.txtBusq.Focus();
                else
                    this.dtpFechaInicio.Focus();
                this.txtBusq.Text = string.Empty;
                this.dtpFechaInicio.Value = DateTime.Today;
                this.dtpFechaFin.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNomina ~ rbTicket_CheckedChanged");
            }
        }

        private void toolsm_Click(object sender, EventArgs e)
        {
            try
            {
                int TipoNomina = 0;
                ToolStripMenuItem TSItem = (ToolStripMenuItem)sender;
                int.TryParse(TSItem.Tag.ToString(), out TipoNomina);
                if (TipoNomina > 0)
                {
                    frmNuevaNomina Nomina = new frmNuevaNomina(TipoNomina); // Generar la nómina administrativa
                    this.Visible = false;
                    Nomina.ShowDialog();
                    Nomina.Dispose();
                    if (Nomina.DialogResult == DialogResult.OK)
                    {
                        this.CargarGridNomina();
                    }
                    this.Visible = true;
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmNomina ~ toolsm_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                    this.btnBuscar_Click(this.btnBuscar, new EventArgs());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNomina ~ txtBusqueda_KeyPress");
            }
        }

        private void txtFolioBusq_Enter(object sender, EventArgs e)
        {
            try
            {
                this.rbClaveNomina.Checked = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNomina ~ txtFolioBusq_Enter");
            }
        }
        #endregion
        #endregion

    }
}

