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
    public partial class frmComisiones : Form
    {
        #region Constructor

        public frmComisiones()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmComisiones ~ frmComisiones()");
            }            
        }

        #endregion

        #region Métodos

        private void CargarGridResumenComisiones()
        {
            try
            {
                Comision Datos = new Comision { BuscarTodos = false, Conexion = Comun.Conexion };
                Comision_Negocio CN = new Comision_Negocio();
                CN.ObtenerResumenComisiones(Datos);
                this.dgvComisiones.AutoGenerateColumns = false;
                this.dgvComisiones.DataSource = Datos.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridResumenComisionesBusq()
        {
            try
            {
                Comision Datos = new Comision { BuscarTodos = false, Conexion = Comun.Conexion, Folio = this.txtBusqueda.Text.Trim() };
                Comision_Negocio CN = new Comision_Negocio();
                CN.ObtenerResumenComisionesBusq(Datos);
                this.dgvComisiones.AutoGenerateColumns = false;
                this.dgvComisiones.DataSource = Datos.TablaDatos;
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
                this.CargarGridResumenComisiones();
                this.ActiveControl = this.txtBusqueda;
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

        private Comision ObtenerDatosGrid(int Fila)
        {
            try
            {
                Comision Datos = new Comision();
                DataGridViewRow FilaGrid = this.dgvComisiones.Rows[Fila];
                Datos.IDResumenComision = FilaGrid.Cells["IDComisionResumen"].Value.ToString();
                Datos.Conexion = Comun.Conexion;
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtBusqueda.Text.Trim()))
                {
                    this.CargarGridResumenComisionesBusq();
                }
                else
                    MessageBox.Show("Ingrese el folio a buscar", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmComisiones ~ btnBuscar_Click");
            }
        }

        private void btnCancBusq_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarGridResumenComisiones();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmComisiones ~ btnBuscar_Click");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvComisiones.SelectedRows.Count == 1)
                {
                    int Row = this.dgvComisiones.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Comision Datos = this.ObtenerDatosGrid(Row);
                    frmVerListados Reporte = new frmVerListados(2, Datos.IDResumenComision);
                    Reporte.ShowDialog();
                    Reporte.Dispose();
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmComisiones ~ btnImprimir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoResumenComision Comisiones = new frmNuevoResumenComision();
                Comisiones.ShowDialog();
                Comisiones.Dispose();
                if (Comisiones.DialogResult == DialogResult.OK)
                {
                    this.CargarGridResumenComisiones();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmComisiones ~ btnNuevo_Click");
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
                LogError.AddExcFileTxt(ex, "frmComisiones ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmComisiones_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmComisiones ~ frmComisiones_Load");
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmComisiones ~ txtBusqueda_KeyPress");
            }
        }

        #endregion

        private void btnReglas_Click(object sender, EventArgs e)
        {
            try
            {
                frmReglasComisiones Reglas = new frmReglasComisiones();
                this.Visible = false;
                Reglas.ShowDialog();
                Reglas.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmComisiones ~ btnReglas_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
