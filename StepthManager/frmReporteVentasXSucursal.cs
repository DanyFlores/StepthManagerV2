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
    public partial class frmReporteVentasXSucursal : Form
    {
        #region Propiedades / Variables
        DateTime Fecha = DateTime.MinValue;
        #endregion

        #region Constructores

        public frmReporteVentasXSucursal()
        {
            try
            {
                InitializeComponent();
                IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReporteVentasXSucursal ~ frmReporteVentasXSucursal()");
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
                ReporteVentasXSucursal_Negocio Neg = new ReporteVentasXSucursal_Negocio();
                List<ReportesVentaXSucursal> Lista = Neg.ObtenerReporteVentasXSucursal(Comun.Conexion, this.Fecha);
                this.dgvReporteVentasXSucursal.AutoGenerateColumns = false;
                this.dgvReporteVentasXSucursal.DataSource = Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ReportesVentaXSucursal ObtenerDatosReporte()
        {
            try
            {
                ReportesVentaXSucursal DatosAux = new ReportesVentaXSucursal();
                Int32 RowData = this.dgvReporteVentasXSucursal.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowData > -1)
                {
                    int ID = 0;
                    DataGridViewRow FilaDatos = this.dgvReporteVentasXSucursal.Rows[RowData];
                    int.TryParse(FilaDatos.Cells["IDReporte"].Value.ToString(), out ID);
                    DatosAux.IDReporte = ID;
                    DateTime FechaInicio = DateTime.MinValue;
                    DateTime FechaFin = DateTime.MinValue;
                    string IDSucursal = (FilaDatos.Cells["IDSucursal"].Value.ToString());
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoReporteVentasXSucursal GenerarReporte = new frmNuevoReporteVentasXSucursal();
                GenerarReporte.ShowDialog();
                if (GenerarReporte.DialogResult == DialogResult.OK)
                {
                    LlenarGrid();
                }
                GenerarReporte.Dispose();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReporteVentasXSucursal ~ btnNuevo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
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
                LogError.AddExcFileTxt(ex, "frmReporteVentasXSucursal ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImpresion_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvReporteVentasXSucursal.SelectedRows.Count == 1)
                {
                    ReportesVentaXSucursal Datos = this.ObtenerDatosReporte();
                    frmVerReporteVentasXSucursal VerReporte = new frmVerReporteVentasXSucursal(Datos.IDReporte);
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
                LogError.AddExcFileTxt(ex, "frmReporteVentasXSucursal ~ btnImpresion_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmReporteVentasXSucursal_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReporteVentasXSucursal ~ frmReporteVentasXSucursal_Load");
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
                LogError.AddExcFileTxt(ex, "frmReporteVentasXSucursal ~ button_Creativa1_Click");
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
                LogError.AddExcFileTxt(ex, "frmReporteVentasXSucursal ~ btnCancelarBusq_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
