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
    public partial class frmReportesProductosVendidos : Form
    {
        #region PROPIEDADES/VARIABLES
        DateTime Fecha = DateTime.MinValue;
        #endregion
        #region Constructores

        public frmReportesProductosVendidos()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "Form2 ~ Form2()");
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
                Reporte_Negocio Neg = new Reporte_Negocio();
                List<ReporteProductosVendidos> Lista = Neg.ObtenerReportesProductosVendidos(Comun.Conexion, Fecha);
                this.dgvReportesProductosVendidos.AutoGenerateColumns = false;
                this.dgvReportesProductosVendidos.DataSource = Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ReporteProductosVendidos ObtenerDatosReporte()
        {
            try
            {
                ReporteProductosVendidos DatosAux = new ReporteProductosVendidos();
                Int32 RowData = this.dgvReportesProductosVendidos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowData > -1)
                {
                    int ID = 0;
                    DataGridViewRow FilaDatos = this.dgvReportesProductosVendidos.Rows[RowData];
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoReporteProductosVendidos GenerarReporte = new frmNuevoReporteProductosVendidos();
                GenerarReporte.ShowDialog();
                if (GenerarReporte.DialogResult == DialogResult.OK)
                {
                    LlenarGrid();
                }
                GenerarReporte.Dispose();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReportesProductosVendidos ~ btnNuevo_Click");
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
                LogError.AddExcFileTxt(ex, "frmReportesProductosVendidos ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImpresion_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvReportesProductosVendidos.SelectedRows.Count == 1)
                {
                    ReporteProductosVendidos Datos = this.ObtenerDatosReporte();
                    frmVerReporteProductosVendidos VerReporte = new frmVerReporteProductosVendidos(Datos.IDReporte);
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
                LogError.AddExcFileTxt(ex, "frmReportesProductosVendidos ~ btnImpresion_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmReportesProductosVendidos_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReportesProductosVendidos ~ frmReportesProductosVendidos_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //BtnBuscar
                this.Fecha = dtpFechaBuscar.Value;
                LlenarGrid();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReportesProductosVendidos ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancelarBusq_Click(object sender, EventArgs e)
        {
            try
            {
                ////BOTON QUITAR BUSQUEDA
                this.Fecha = DateTime.MinValue;
                this.LlenarGrid();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReportesProductosVendidos ~ btnCancelarBusq_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       
        private void dtpFechaBuscar_ValueChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
