using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using StephManager.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephManager
{
    public partial class frmSeleccionarProducto : Form
    {
        #region Propiedades / Variables

        private int TipoForm = 0; // 1. Productos, 2. Servicios, 3. Productos y Servicios
        private Producto _Datos;
        public Producto Datos
        {
            get { return _Datos; }
            set { _Datos = value; }
        }

        #endregion

        #region Constructor

        public frmSeleccionarProducto(int Tipo)
        {
            try
            {
                InitializeComponent();
                this._Datos = new Producto();
                this.TipoForm = Tipo;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmSeleccionarProducto ~ frmSeleccionarProducto()");
            }
        }

        #endregion

        #region Métodos

        private void BuscarRegistros(string Busqueda)
        {
            try
            {
                Producto DatosAux = new Producto { Opcion = TipoForm, Conexion = Comun.Conexion, NombreProducto = Busqueda, IDProveedor = string.IsNullOrEmpty(this._Datos.IDProveedor) ? string.Empty:this._Datos.IDProveedor,
                                                   IDSucursal = string.IsNullOrEmpty(this._Datos.IDSucursal) ? string.Empty : this._Datos.IDSucursal
                };
                Producto_Negocio ProdNeg = new Producto_Negocio();
                ProdNeg.ObtenerBusquedaProductosServicios(DatosAux);
                this.dgvProductos.AutoGenerateColumns = false;
                this.dgvProductos.DataSource = DatosAux.TablaDatos;
                this.dgvProductos.Focus();
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
                if (TipoForm != 1 && TipoForm != 2 && TipoForm != 4 && TipoForm != 5)
                    this.btnAgregar.Enabled = false;
                switch (TipoForm)
                {
                    case 1: this.dgvProductos.Columns["NombreProducto"].HeaderText = "Producto";
                        break;
                    case 2: this.dgvProductos.Columns["NombreProducto"].HeaderText = "Servicio";
                        break;
                    case 3: this.dgvProductos.Columns["NombreProducto"].HeaderText = "Producto / Servicio";
                        break;
                    case 4: 
                    case 5: this.dgvProductos.Columns["NombreProducto"].HeaderText = "Producto";
                        break;
                    case 16: this.dgvProductos.Columns["NombreProducto"].HeaderText = "Producto / Servicio";
                        break;
                    default:
                        break;
                }
                this.ActiveControl = this.txtBusqueda;
                this.txtBusqueda.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Producto ObtenerDatos(int Fila)
        {
            try
            {
                Producto Aux = new Producto();
                if (Fila < this.dgvProductos.Rows.Count)
                {
                    Aux.IDProducto = this.dgvProductos.Rows[Fila].Cells["IDProducto"].Value.ToString();
                    Aux.NombreProducto = this.dgvProductos.Rows[Fila].Cells["NombreProducto"].Value.ToString();
                    Aux.Clave = this.dgvProductos.Rows[Fila].Cells["Clave"].Value.ToString();
                    if (TipoForm == 2)
                    {
                        int AuxTM = 0;
                        int.TryParse(this.dgvProductos.Rows[Fila].Cells["TiempoMinutos"].Value.ToString(), out AuxTM);
                        Aux.TiempoMinutos = AuxTM;
                    }
                    if (TipoForm == 4)
                    {
                        int IDUM = 0;
                        int.TryParse(this.dgvProductos.Rows[Fila].Cells["IDUnidadMedida"].Value.ToString(), out IDUM);
                        decimal UltimoCosto = 0;
                        decimal.TryParse(this.dgvProductos.Rows[Fila].Cells["UltimoCosto"].Value.ToString(), out UltimoCosto);
                        Aux.IDUnidadMedida = IDUM;
                        Aux.UnidadMedidaDesc = this.dgvProductos.Rows[Fila].Cells["UnidadMedidaDesc"].Value.ToString();
                        Aux.UltimoCosto = UltimoCosto;
                    }
                    if (TipoForm == 5 || TipoForm == 14)
                    {
                        decimal Existencia = 0;
                        decimal.TryParse(this.dgvProductos.Rows[Fila].Cells["Existencia"].Value.ToString(), out Existencia);
                        Aux.Existencia = Existencia;
                    }
                }
                return Aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TipoForm == 1 || TipoForm == 4 || TipoForm == 5)
                {
                    frmNuevoProducto NProducto = new frmNuevoProducto();
                    NProducto.ShowDialog();
                    NProducto.Dispose();
                    if (NProducto.DialogResult == DialogResult.OK)
                    {
                        this.txtBusqueda.Focus();
                    }
                }
                else if (TipoForm == 2)
                {
                    frmNuevoServicio NServicio = new frmNuevoServicio();
                    NServicio.ShowDialog();
                    NServicio.Dispose();
                    if (NServicio.DialogResult == DialogResult.OK)
                    {
                        this.txtBusqueda.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmSeleccionarProducto ~ btnAgregar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(this.txtBusqueda.Text.Trim()))
                    this.BuscarRegistros(this.txtBusqueda.Text.Trim());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmSeleccionarProducto ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrarForm_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmSeleccionarProducto ~ btnCerrarForm_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    this._Datos = this.ObtenerDatos(e.RowIndex);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmSeleccionarProducto ~ dgvProductos_CellDoubleClick");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (this.dgvProductos.SelectedRows.Count == 1)
                {
                    int Fila = this.dgvProductos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    this._Datos = this.ObtenerDatos(Fila);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void frmSeleccionarProducto_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmSeleccionarProducto ~ frmSeleccionarProducto_Load");
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)Keys.Enter)
                {
                    if(!string.IsNullOrEmpty(this.txtBusqueda.Text.Trim()))
                        this.BuscarRegistros(this.txtBusqueda.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmSeleccionarProducto ~ txtBusqueda_KeyPress");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void frmSeleccionarProducto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.btnCerrarForm_Click(this.btnCerrarForm, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmSeleccionarProducto ~ frmSeleccionarProducto_KeyUp");
            }
        }

    }
}
