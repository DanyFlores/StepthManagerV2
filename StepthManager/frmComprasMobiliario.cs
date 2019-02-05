using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
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
    public partial class frmComprasMobiliario : Form
    {
        #region Variables

        private bool ComprasPendientes = false;
        private bool ComprasProcesadas = false;
        private bool Busqueda = false;
        private Compra DatosBusq = new Compra();

        #endregion

        #region Constructor

        public frmComprasMobiliario()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmComprasMobiliario ~ frmComprasMobiliario()");
            }
        }

        #endregion

        #region Métodos

        private void BusquedaCompras()
        {
            try
            {
                Compra DatosAux = new Compra();
                DatosAux.BusqFecha = this.rbFecha.Checked;
                DatosAux.BusqNumFactura = this.rbNumFactura.Checked;
                DatosAux.BusqProveedor = this.rbProveedor.Checked;
                if (DatosAux.BusqFecha)
                    DatosAux.FechaEmision = this.dtpFecha.Value;
                if (DatosAux.BusqNumFactura)
                {
                    if (!string.IsNullOrEmpty(this.txtNumFactura.Text.Trim()))
                        DatosAux.NumFactura = this.txtNumFactura.Text.Trim();
                    else
                    {
                        MessageBox.Show("Ingrese un texto a buscar en Núm. de Factura.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (DatosAux.BusqProveedor)
                {
                    Proveedor ProvAux = this.ObtenerProveedorSeleccionado();
                    if (!string.IsNullOrEmpty(ProvAux.IDProveedor))
                        DatosAux.IDProveedor = ProvAux.IDProveedor;
                    else
                    {
                        MessageBox.Show("Seleccione un proveedor de la lista.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                this.DatosBusq = DatosAux;
                switch (this.tcCompras.SelectedIndex)
                {
                    case 0: this.CargarComprasPendientesBusq(DatosAux);
                        break;
                    case 1: this.CargarComprasProcesadasBusq(DatosAux);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarComprasPendientes()
        {
            try
            {
                if (!ComprasPendientes)
                {
                    Compra DatosAux = new Compra { Conexion = Comun.Conexion, Todos = false, IDEstatusCompra = 1, IDSucursal = Comun.IDSucursalCaja };
                    Compra_Negocio CN = new Compra_Negocio();
                    CN.ObtenerComprasMobiliarioPendientes(DatosAux);
                    this.dgvComprasPendientes.AutoGenerateColumns = false;
                    this.dgvComprasPendientes.DataSource = DatosAux.TablaDatos;
                    this.ComprasPendientes = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarComprasProcesadas()
        {
            try
            {
                if (!ComprasProcesadas)
                {
                    Compra DatosAux = new Compra { Conexion = Comun.Conexion, Todos = false, IDEstatusCompra = 2, IDSucursal = Comun.IDSucursalCaja };
                    Compra_Negocio CN = new Compra_Negocio();
                    CN.ObtenerComprasMobiliarioPendientes(DatosAux);
                    this.dgvComprasProcesadas.AutoGenerateColumns = false;
                    this.dgvComprasProcesadas.DataSource = DatosAux.TablaDatos;
                    this.ComprasProcesadas = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarComprasPendientesBusq(Compra DatosBusq)
        {
            try
            {
                if (!ComprasPendientes)
                {
                    DatosBusq.Conexion = Comun.Conexion;
                    DatosBusq.IDEstatusCompra = 1;
                    DatosBusq.IDSucursal = Comun.IDSucursalCaja;
                    Compra_Negocio CN = new Compra_Negocio();
                    CN.ObtenerComprasMobiliarioPendientesBusq(DatosBusq);
                    this.dgvComprasPendientes.AutoGenerateColumns = false;
                    this.dgvComprasPendientes.DataSource = DatosBusq.TablaDatos;
                    this.Busqueda = true;
                    this.ComprasPendientes = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarComprasProcesadasBusq(Compra DatosBusq)
        {
            try
            {
                if (!ComprasProcesadas)
                {
                    DatosBusq.Conexion = Comun.Conexion;
                    DatosBusq.IDEstatusCompra = 2;
                    DatosBusq.IDSucursal = Comun.IDSucursalCaja;
                    Compra_Negocio CN = new Compra_Negocio();
                    CN.ObtenerComprasMobiliarioPendientesBusq(DatosBusq);
                    this.dgvComprasProcesadas.AutoGenerateColumns = false;
                    this.dgvComprasProcesadas.DataSource = DatosBusq.TablaDatos;
                    this.Busqueda = true;
                    this.ComprasProcesadas = true;
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
                this.cmbProveedor.Enter -= new System.EventHandler(this.cmbProveedor_Enter);
                this.LlenarComboProveedores();
                this.CargarComprasPendientes();
                this.rbProveedor.Checked = false;
                this.ActiveControl = this.btnBuscar;
                this.btnBuscar.Focus();
                this.cmbProveedor.Enter += new System.EventHandler(this.cmbProveedor_Enter);
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

        private void LlenarComboProveedores()
        {
            try
            {
                Proveedor DatosAux = new Proveedor { Conexion = Comun.Conexion, IncluirSelect = true };
                Proveedor_Negocio PN = new Proveedor_Negocio();
                this.cmbProveedor.DataSource = PN.LlenarComboProveedoresMobiliario(DatosAux);
                this.cmbProveedor.DisplayMember = "NombreComercial";
                this.cmbProveedor.ValueMember = "IDProveedor";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Proveedor ObtenerProveedorSeleccionado()
        {
            try
            {
                Proveedor DatosAux = new Proveedor();
                if (this.cmbProveedor.SelectedIndex != -1)
                {
                    DatosAux = (Proveedor)this.cmbProveedor.SelectedItem;
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Compra ObtenerDatosGrid()
        {
            try
            {
                Compra DatosAux = new Compra();
                int TabIndex = this.tcCompras.SelectedIndex;
                switch (TabIndex)
                {
                    case 0: DatosAux = this.ObtenerDatos(this.dgvComprasPendientes, TabIndex);
                        break;
                    case 1: DatosAux = this.ObtenerDatos(this.dgvComprasProcesadas, TabIndex);
                        break;
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Compra ObtenerDatos(DataGridView DGV, int TabIndex)
        {
            try
            {
                Compra DatosAux = new Compra();
                if (DGV.SelectedRows.Count == 1)
                {
                    int RowSelected = DGV.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    DataGridViewRow Fila = DGV.Rows[RowSelected];
                    int IDEstatus = 0;
                    int.TryParse(Fila.Cells["IDEstatusCompra" + TabIndex].Value.ToString(), out IDEstatus);
                    DatosAux.IDCompra = Fila.Cells["IDCompra" + TabIndex].Value.ToString();
                    DatosAux.IDEstatusCompra = IDEstatus;
                    DatosAux.NumFactura = Fila.Cells["NumFactura" + TabIndex].Value.ToString();
                    decimal MontoPendiente = 0;
                    decimal.TryParse(Fila.Cells["MontoPendiente" + TabIndex].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out MontoPendiente);
                    DatosAux.MontoPendiente = MontoPendiente;
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
                frmNuevaCompraMobiliario NCompra = new frmNuevaCompraMobiliario();
                this.Visible = false;
                NCompra.ShowDialog();
                NCompra.Dispose();
                this.Visible = true;
                if (NCompra.DialogResult == DialogResult.OK)
                {
                    if (Busqueda)
                    {
                        this.ComprasPendientes = false;
                        this.CargarComprasPendientesBusq(this.DatosBusq);
                    }
                    else
                    {
                        this.ComprasPendientes = false;
                        this.CargarComprasPendientes();
                    }

                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmCompras ~ btnNuevo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarBusq_Click(object sender, EventArgs e)
        {
            try
            {
                if (Busqueda)
                {
                    this.ComprasPendientes = false;
                    this.ComprasProcesadas = false;
                    this.CargarComprasPendientes();
                    this.CargarComprasProcesadas();
                    if (this.cmbProveedor.Items.Count > 0)
                        this.cmbProveedor.SelectedIndex = 0;
                    this.txtNumFactura.Text = string.Empty;
                    this.dtpFecha.Value = DateTime.Today;
                    this.rbFecha.Checked = false;
                    this.rbNumFactura.Checked = false;
                    this.rbProveedor.Checked = false;
                    Busqueda = false;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCompras ~ btnComprasPendientes_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCompras ~ frmCompras_Load");
            }
        }

        private void tcCompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                switch (tcCompras.SelectedIndex)
                {
                    case 0:
                        if (Busqueda)
                            this.CargarComprasPendientesBusq(this.DatosBusq);
                        else
                            this.CargarComprasPendientes();
                        break;
                    case 1:
                        if (Busqueda)
                            this.CargarComprasProcesadasBusq(this.DatosBusq);
                        else
                            this.CargarComprasProcesadas();
                        break;
                    default: break;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCompras ~ tcCompras_SelectedIndexChanged");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ComprasPendientes = false;
                this.ComprasProcesadas = false;
                this.BusquedaCompras();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCompras ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProveedor_Enter(object sender, EventArgs e)
        {
            try
            {
                this.rbProveedor.Checked = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCompras ~ cmbProveedor_Enter");
            }
        }

        private void txtNumFactura_Enter(object sender, EventArgs e)
        {
            try
            {
                this.rbNumFactura.Checked = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCompras ~ txtNumFactura_Enter");
            }
        }

        private void dtpFecha_Enter(object sender, EventArgs e)
        {
            try
            {
                this.rbFecha.Checked = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCompras ~ dtpFecha_Enter");
            }
        }

        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCompras ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Compra DatosAux = this.ObtenerDatosGrid();
                if (!string.IsNullOrEmpty(DatosAux.IDCompra))
                {
                    if (MessageBox.Show("¿Está seguro de cancelar el pedido " + DatosAux.NumFactura + "?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (DatosAux.IDEstatusCompra == 1)
                        {
                            DatosAux.Conexion = Comun.Conexion;
                            DatosAux.IDUsuario = Comun.IDUsuario;
                            Compra_Negocio CN = new Compra_Negocio();
                            CN.CancelarCompraMobiliario(DatosAux);
                            if (DatosAux.Completado)
                            {
                                this.ComprasPendientes = false;
                                this.tcCompras_SelectedIndexChanged(this.tcCompras, new EventArgs());
                                MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se puede cancelar la compra. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("La compra debe estar en estatus Creada.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCompras ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Compra DatosAux = this.ObtenerDatosGrid();
                if (!string.IsNullOrEmpty(DatosAux.IDCompra))
                {
                    if (DatosAux.IDEstatusCompra == 1)
                    {
                        frmNuevaCompraMobiliario NCompra = new frmNuevaCompraMobiliario(DatosAux.IDCompra);
                        this.Visible = false;
                        NCompra.ShowDialog();
                        NCompra.Dispose();
                        this.Visible = true;
                        if (NCompra.DialogResult == DialogResult.OK)
                        {
                            if (Busqueda)
                            {
                                this.ComprasPendientes = false;
                                this.CargarComprasPendientesBusq(this.DatosBusq);
                            }
                            else
                            {
                                this.ComprasPendientes = false;
                                this.CargarComprasPendientes();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("La compra debe estar en estatus Creada.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmCompras ~ btnModificar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProcesarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                Compra DatosAux = this.ObtenerDatosGrid();
                if (!string.IsNullOrEmpty(DatosAux.IDCompra))
                {
                    if (DatosAux.IDEstatusCompra == 1)
                    {
                        if (MessageBox.Show("¿Está seguro de procesar el pedido " + DatosAux.NumFactura + "? Recuerde que este proceso No es reversible.", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DatosAux.Conexion = Comun.Conexion;
                            DatosAux.IDUsuario = Comun.IDUsuario;
                            Compra_Negocio CN = new Compra_Negocio();
                            CN.ProcesarCompraMobiliario(DatosAux);
                            if (DatosAux.Completado)
                            {
                                this.ComprasPendientes = false;
                                this.ComprasProcesadas = false;
                                this.tcCompras_SelectedIndexChanged(this.tcCompras, new EventArgs());
                                MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se puede procesar la compra. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("La compra debe estar en estatus Creada.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCompras ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetalleCompra_Click(object sender, EventArgs e)
        {
            try
            {
                Compra DatosAux = this.ObtenerDatosGrid();
                if (!string.IsNullOrEmpty(DatosAux.IDCompra))
                {
                    frmComprasMobiliarioDetalle DetalleCompra = new frmComprasMobiliarioDetalle(DatosAux.IDCompra);
                    this.Visible = false;
                    DetalleCompra.ShowDialog();
                    DetalleCompra.Dispose();
                    this.Visible = true;
                }
                else
                {
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmCompras ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvComprasProcesadas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    Compra Datos = this.ObtenerDatos(this.dgvComprasProcesadas, 1);
                    frmMobiliarioPagoCompras Pagos = new frmMobiliarioPagoCompras(Datos);
                    this.Visible = false;
                    Pagos.ShowDialog();
                    Pagos.Dispose();
                    this.Visible = true;
                    this.ComprasProcesadas = false;
                    if (Busqueda)
                    {
                        this.ComprasProcesadas = false;
                        this.CargarComprasProcesadasBusq(this.DatosBusq);
                    }
                    else
                    {
                        this.ComprasProcesadas = false;
                        this.CargarComprasProcesadas();
                    }
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmCompras ~ dgvComprasProcesadas_CellDoubleClick");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
