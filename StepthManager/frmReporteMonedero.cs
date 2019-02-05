using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
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
    public partial class frmReporteMonedero : Form
    {
        #region Propiedades / Variables
        DateTime Fecha = DateTime.MinValue;
        #endregion

        #region Constructores

        public frmReporteMonedero()
        {
            try
            {
                InitializeComponent();
                IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReporteMonedero ~ frmReporteMonedero()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                this.LlenarGrid();
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

        private void LlenarGrid()
        {
            try
            {
                Reporte_NegocioMonedero Neg = new Reporte_NegocioMonedero();
                List<ReporteMonedero> Lista = Neg.ObtenerReportesMonedero(Comun.Conexion, this.Fecha);
                this.dgvReportesTrabajosRealizados.AutoGenerateColumns = false;
                this.dgvReportesTrabajosRealizados.DataSource = Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ReporteMonedero ObtenerDatosReporte()
        {
            try
            {
                ReporteMonedero DatosAux = new ReporteMonedero();
                Int32 RowData = this.dgvReportesTrabajosRealizados.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowData > -1)
                {
                    int ID = 0;
                    DataGridViewRow FilaDatos = this.dgvReportesTrabajosRealizados.Rows[RowData];
                    int.TryParse(FilaDatos.Cells["IDReporte"].Value.ToString(), out ID);
                    DatosAux.IDReporte = ID;

                    DateTime FechaInicio = DateTime.MinValue;
                    DateTime FechaFin = DateTime.MinValue;
                    DateTime.TryParse(FilaDatos.Cells["FechaInicio"].Value.ToString(), out FechaInicio);
                    DateTime.TryParse(FilaDatos.Cells["FechaFin"].Value.ToString(), out FechaFin);
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            try
            {
                frmNuevoReporteMonedero GenerarReporte = new frmNuevoReporteMonedero();
                GenerarReporte.ShowDialog();
                if (GenerarReporte.DialogResult == DialogResult.OK)
                {
                    LlenarGrid();
                }
                GenerarReporte.Dispose();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReporteMonedero ~ btnNuevo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Abort;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReporteMonedero ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImpresion_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvReportesTrabajosRealizados.SelectedRows.Count == 1)
                {
                    ReporteMonedero Datos = this.ObtenerDatosReporte();
                    frmVerReporteMonedero VerReporte = new frmVerReporteMonedero(Datos.IDReporte);
                    VerReporte.ShowDialog();
                    VerReporte.Dispose();
                }
                else
                {
                    MessageBox.Show("Seleccione una fila.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReporteMonedero ~ btnImpresion_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmReporteMonedero_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReporteMonedero ~ frmReporteMonedero_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Creativa1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Fecha = dtpFechaBusqueda.Value;
                LlenarGrid();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReporteMonedero ~ button_Creativa1_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarBusq_Click(object sender, EventArgs e)
        {
            try
            {
                this.Fecha = DateTime.MinValue;
                LlenarGrid();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReporteMonedero ~ btnCancelarBusq_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
