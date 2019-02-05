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
    public partial class frmCitas : Form
    {
        #region Variables

        private bool Busqueda = false;

        #endregion

        #region Constructor

        public frmCitas()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCitas ~ frmCitas()");
            }
        }

        #endregion

        #region Métodos

        private void CargarGridCitasBusqueda()
        {
            try
            {
                if (!this.chkBuscarXSucursal.Checked && !this.chkBuscarXFecha.Checked && !this.chkBuscarXCliente.Checked)
                {
                    MessageBox.Show("Debe seleccionar al menos un criterio de Búsqueda.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Cita DatosAux = new Cita
                    {
                        Conexion = Comun.Conexion,
                        BusqCliente = chkBuscarXCliente.Checked,
                        BusqFechaCita = chkBuscarXFecha.Checked,
                        BusqSucursal = chkBuscarXSucursal.Checked,
                        IDSucursal = string.Empty,
                        NombreCliente = string.Empty
                    };
                    string IDSucursal = string.Empty;
                    if (this.chkBuscarXSucursal.Checked)
                    {
                        if (this.cmbSucursal.SelectedIndex != -1)
                        {
                            Sucursal SucAux = (Sucursal)this.cmbSucursal.SelectedItem;
                            IDSucursal = SucAux.IDSucursal;
                        }
                        if(string.IsNullOrEmpty(IDSucursal.Trim()))
                        {
                            MessageBox.Show("Seleccione una sucursal. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        DatosAux.IDSucursal = IDSucursal;
                    }
                    if (this.chkBuscarXCliente.Checked)
                    {
                        if (string.IsNullOrEmpty(this.txtBusqueda.Text.Trim()))
                        {
                            MessageBox.Show("Ingrese el nombre del cliente. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        DatosAux.NombreCliente = this.txtBusqueda.Text.Trim();
                    }
                    DatosAux.FechaCita = this.dtpFecha.Value;
                    Cita_Negocio CN = new Cita_Negocio();
                    CN.ObtenerCitasBusqueda(DatosAux);
                    this.dgvCitas.AutoGenerateColumns = false;
                    this.dgvCitas.DataSource = DatosAux.TablaDatos;
                    Busqueda = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridCitasPendientes()
        {
            try
            {
                Cita DatosAux = new Cita { Conexion = Comun.Conexion };
                Cita_Negocio CN = new Cita_Negocio();
                CN.ObtenerCitasPendientesDiaActual(DatosAux);
                this.dgvCitas.AutoGenerateColumns = false;
                this.dgvCitas.DataSource = DatosAux.TablaDatos;
                Busqueda = false;
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
                this.LlenarComboSucursales();
                this.CargarGridCitasPendientes();
                this.ActiveControl = this.chkBuscarXSucursal;
                this.chkBuscarXSucursal.Focus();
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

        private void LimpiarBusqueda()
        {
            try
            {
                this.chkBuscarXCliente.Checked = false;
                this.chkBuscarXFecha.Checked = false;
                this.chkBuscarXSucursal.Checked = false;
                if (this.cmbSucursal.Items.Count > 0)
                    this.cmbSucursal.SelectedIndex = 0;
                this.txtBusqueda.Text = string.Empty;
                this.dtpFecha.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboSucursales()
        {
            try
            {
                Sucursal DatosAux = new Sucursal { Conexion = Comun.Conexion, Opcion = 1 };
                Sucursal_Negocio SN = new Sucursal_Negocio();
                this.cmbSucursal.DataSource = SN.LlenarComboCatSucursales(DatosAux);
                this.cmbSucursal.ValueMember = "IDSucursal";
                this.cmbSucursal.DisplayMember = "NombreSucursal";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Cita ObtenerDatosCita(int RowSelected)
        {
            try
            {
                Cita DatosAux = new Cita();
                DataGridViewRow Fila = this.dgvCitas.Rows[RowSelected];
                DatosAux.IDCita = Fila.Cells["IDCita"].Value.ToString();
                DatosAux.NombreCliente = Fila.Cells["Cliente"].Value.ToString();
                DatosAux.IDSucursal = Fila.Cells["IDSucursal"].Value.ToString();
                int IDStatus = 0;
                int.TryParse(Fila.Cells["IDStatusCita"].Value.ToString(), out IDStatus);
                DatosAux.IDStatusCita = IDStatus;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnAtenderCita_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCitas.SelectedRows.Count == 1)
                {
                    Int32 RowToDelete = this.dgvCitas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Cita DatosAux = this.ObtenerDatosCita(RowToDelete);
                    if (!string.IsNullOrEmpty(DatosAux.IDCita))
                    {
                        if (DatosAux.IDStatusCita == 1)
                        {
                            frmAtenderCita Atender = new frmAtenderCita(DatosAux);
                            Atender.ShowDialog();
                            Atender.Dispose();
                            if (Atender.DialogResult == DialogResult.OK)
                            {
                                this.CargarGridCitasPendientes();
                                this.LimpiarBusqueda();
                            }
                        }
                        else
                            MessageBox.Show("El estatus de la cita no permite marcarla como concluida.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCitas ~ btnAsignarTarjeta_Click");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarGridCitasBusqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCitas ~ btnBuscar_Click");
            }
        }

        private void btnCancelarBusq_Click(object sender, EventArgs e)
        {
            try
            {
                if (Busqueda)
                {
                    this.CargarGridCitasPendientes();
                    this.LimpiarBusqueda();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCitas ~ btnCancelarBusq_Click");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCitas.SelectedRows.Count == 1)
                {
                    Int32 RowToDelete = this.dgvCitas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Cita DatosAux = this.ObtenerDatosCita(RowToDelete);
                    if (!string.IsNullOrEmpty(DatosAux.IDCita))
                    {
                        if (DatosAux.IDStatusCita == 1)
                        {
                            frmCancelarCita Cancelar = new frmCancelarCita(DatosAux.IDCita);
                            Cancelar.ShowDialog();
                            Cancelar.Dispose();
                            if (Cancelar.DialogResult == DialogResult.OK)
                            {
                                this.CargarGridCitasPendientes();
                                this.LimpiarBusqueda();
                            }
                        }
                        else
                            MessageBox.Show("El estatus de la cita no permite su cancelación.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCitas ~ btnEliminar_Click");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmNuevaCita Cita = new frmNuevaCita();
                Cita.ShowDialog();
                Cita.Dispose();
                this.Visible = true;
                if (Cita.DialogResult == DialogResult.OK)
                {
                    this.CargarGridCitasPendientes();
                    this.LimpiarBusqueda();
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCitas ~ btnNuevo_Click");
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
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCitas ~ btnSalir_Click");
            }
        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCitas.SelectedRows.Count == 1)
                {
                    Int32 RowToDelete = this.dgvCitas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Cita DatosAux = this.ObtenerDatosCita(RowToDelete);
                    if (!string.IsNullOrEmpty(DatosAux.IDCita))
                    {
                        frmDetalleCita Cancelar = new frmDetalleCita(DatosAux.IDCita);
                        Cancelar.ShowDialog();
                        Cancelar.Dispose();
                        if (Cancelar.DialogResult == DialogResult.OK)
                        {
                            this.CargarGridCitasPendientes();
                            this.LimpiarBusqueda();
                        }

                    }
                    else
                        MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCitas ~ btnVerDetalles_Click");
            }
        }

        private void frmCitas_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCitas ~ frmCitas_Load");
            }
        }

        #endregion

    }
}
