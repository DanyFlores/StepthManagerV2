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
    public partial class frmReportesGarantias : Form
    {
        public frmReportesGarantias()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {

                LogError.AddExcFileTxt(ex, "frmReportesGarantias ~ frmReportesGarantias()");
            }
        }
        #region Eventos
       
        private void frmReportesGarantias_Load(object sender, EventArgs e)
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoReporteGarantias GenerarReporte = new frmNuevoReporteGarantias();
                GenerarReporte.ShowDialog();
                if (GenerarReporte.DialogResult == DialogResult.OK)
                {
                    LlenarGrid();
                }
                GenerarReporte.Dispose();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReportesGarantias ~ btnNuevo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnImpresion_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.GridViewGeneral.SelectedRows.Count == 1)
                {
                    ReporteGarantias Datos = this.ObtenerDatosReporte();
                    frmVerReporteGarantias VerReporte = new frmVerReporteGarantias(Datos.Id_reporte);
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
                LogError.AddExcFileTxt(ex, "frmReportesGarantias ~ btnImpresion_Click");
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
                LogError.AddExcFileTxt(ex, "frmReportesGarantias ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Metodos
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
                ReporteGarantiasNegocio Neg = new ReporteGarantiasNegocio();
                List<ReporteGarantias> Lista = Neg.ObtenerReportesGarantias(Comun.Conexion);//Neg.ObtenerReporteGarantias(Comun.Conexion);
                this.GridViewGeneral.AutoGenerateColumns = false;
                this.GridViewGeneral.DataSource = Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private ReporteGarantias ObtenerDatosReporte()
        {
            try
            {
                ReporteGarantias DatosAux = new ReporteGarantias();
                Int32 RowData = this.GridViewGeneral.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowData > -1)
                {
                    int ID = 0;
                    DataGridViewRow FilaDatos = this.GridViewGeneral.Rows[RowData];
                    int.TryParse(FilaDatos.Cells["Id_reporte"].Value.ToString(), out ID);
                    DatosAux.Id_reporte = ID;
                    
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime Fecha;
                Fecha = dtpFecha.Value;
                ReporteGarantiasNegocio Neg = new ReporteGarantiasNegocio();
                List<ReporteGarantias> Lista = Neg.BuscarReportesGarantias(Comun.Conexion, Fecha);//Neg.ObtenerReporteGarantias(Comun.Conexion);
                this.GridViewGeneral.AutoGenerateColumns = false;
                this.GridViewGeneral.DataSource = Lista;

            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReportesGarantias ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarBusq_Click(object sender, EventArgs e)
        {
            try
            {
                LlenarGrid();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReportesGarantias ~ btnCancelarBusq_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
