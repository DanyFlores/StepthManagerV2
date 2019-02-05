using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using CreativaSL.Dll.Validaciones;
using StephManager.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephManager
{
    public partial class frmGastosXSucursal : Form
    {
        #region Constructor

        public frmGastosXSucursal()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmGastosXSucursal ~ frmGastosXSucursal()");
            }
        }

        #endregion

        #region Métodos

        private void CargarGridCatalogo()
        {
            try
            {
                if (this.cmbSucursales.SelectedIndex != -1)
                {
                    Sucursal DatosSuc = this.ObtenerSucursalCombo();
                    Gastos Aux = new Gastos { Conexion = Comun.Conexion, IDSucursal = DatosSuc.IDSucursal, FechaGasto = this.dtpFechaGasto.Value };
                    Gastos_Negocio GN = new Gastos_Negocio();
                    GN.ObtenerCatGastos(Aux);
                    this.dgvCatGastos.AutoGenerateColumns = false;
                    this.dgvCatGastos.DataSource = Aux.TablaDatos;
                }
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
                this.CargarComboSucursales();
                this.CargarGridCatalogo();
                this.ActiveControl = this.dtpFechaGasto;
                this.dtpFechaGasto.Focus();
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

        private void CargarComboSucursales()
        {
            try
            {
                Sucursal DatosSuc = new Sucursal { Conexion = Comun.Conexion, Opcion = 2 };
                Sucursal_Negocio SucNeg = new Sucursal_Negocio();
                this.cmbSucursales.DataSource = SucNeg.LlenarComboCatSucursales(DatosSuc);
                this.cmbSucursales.ValueMember = "IDSucursal";
                this.cmbSucursales.DisplayMember = "NombreSucursal";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Sucursal ObtenerSucursalCombo()
        {
            try
            {
                Sucursal DatosAux = new Sucursal();
                if (this.cmbSucursales.Items.Count > 0)
                {
                    if (this.cmbSucursales.SelectedIndex != -1)
                    {
                        DatosAux = (Sucursal)this.cmbSucursales.SelectedItem;
                    }
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ModificarDatos(int Row, Gastos Datos)
        {
            try
            {
                DataGridViewRow Fila = this.dgvCatGastos.Rows[Row];
                Fila.Cells["FechaGasto"].Value = Datos.FechaGasto;
                Fila.Cells["Monto"].Value = Datos.Monto;
                Fila.Cells["IDRubro"].Value = Datos.IDRubro;
                Fila.Cells["RubroDesc"].Value = Datos.RubroDesc;
                Fila.Cells["IDSubrubro"].Value = Datos.IDSubrubro;
                Fila.Cells["SubrubroDesc"].Value = Datos.SubrubroDesc;
                Fila.Cells["Observaciones"].Value = Datos.Observaciones;
                Fila.Cells["IDSucursal"].Value = Datos.IDSucursal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Gastos ObtenerDatosGrid(int RowIndex)
        {
            try
            {
                Gastos DatosAux = new Gastos();
                int IDRubro = 0;
                DateTime FechaGasto = DateTime.Today;
                decimal Monto = 0;
                DataGridViewRow Fila = this.dgvCatGastos.Rows[RowIndex];
                DateTime.TryParse(Fila.Cells["FechaGasto"].Value.ToString(), out FechaGasto);
                int.TryParse(Fila.Cells["IDRubro"].Value.ToString(), out IDRubro);
                decimal.TryParse(Fila.Cells["Monto"].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out Monto);
                DatosAux.IDGasto = Fila.Cells["IDGasto"].Value.ToString();
                DatosAux.IDSubrubro = Fila.Cells["IDSubrubro"].Value.ToString();
                DatosAux.Observaciones = Fila.Cells["Observaciones"].Value.ToString();
                DatosAux.IDSucursal = Fila.Cells["IDSucursal"].Value.ToString();
                DatosAux.Monto = Monto;
                DatosAux.IDRubro = IDRubro;
                DatosAux.FechaGasto = FechaGasto;
                return DatosAux;
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
                this.CargarGridCatalogo();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmGastosXSucursal ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCatGastos.SelectedRows.Count == 1)
                {
                    int RowIndex = this.dgvCatGastos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Gastos Datos = this.ObtenerDatosGrid(RowIndex);
                    if (MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Datos.Conexion = Comun.Conexion;
                        Datos.IDUsuario = Comun.IDUsuario;
                        Gastos_Negocio GN = new Gastos_Negocio();
                        GN.EliminarGasto(Datos);
                        if (Datos.Completado)
                        {
                            CargarGridCatalogo();
                        }
                        else
                            MessageBox.Show("Ocurrió un error al eliminar el registro. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmGastosXSucursal ~ btnEliminar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCatGastos.SelectedRows.Count == 1)
                {
                    int RowIndex = this.dgvCatGastos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Gastos Datos = this.ObtenerDatosGrid(RowIndex);
                    frmNuevoGasto NGasto = new frmNuevoGasto(Datos);
                    NGasto.ShowDialog();
                    NGasto.Dispose();
                    if (NGasto.DialogResult == DialogResult.OK)
                    {
                        this.ModificarDatos(RowIndex, NGasto.DatosGasto);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmGastosXSucursal ~ btnModificar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoGasto NGasto = new frmNuevoGasto();
                NGasto.ShowDialog();
                NGasto.Dispose();
                if (NGasto.DialogResult == DialogResult.OK)
                {
                    this.CargarGridCatalogo();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmGastosXSucursal ~ btnNuevo_Click");
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
                LogError.AddExcFileTxt(ex, "frmGastosXSucursal ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmGastosXSucursal_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmGastosXSucursal ~ frmGastosXSucursal_Load");
            }
        }

        #endregion

    }
}