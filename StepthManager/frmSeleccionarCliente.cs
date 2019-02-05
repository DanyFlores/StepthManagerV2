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
    public partial class frmSeleccionarCliente : Form
    {
        #region Propiedades / Variables

        private Cliente _Datos;
        public Cliente Datos
        {
            get { return _Datos; }
            set { _Datos = value; }
        }

        #endregion

        #region Constructor

        public frmSeleccionarCliente()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmSeleccionarCliente ~ frmSeleccionarCliente()");
            }
        }

        #endregion

        #region Métodos

        private void BuscarRegistros(string Busqueda)
        {
            try
            {
                Cliente DatosAux = new Cliente { Conexion = Comun.Conexion, Nombre = Busqueda };
                Cliente_Negocio CN = new Cliente_Negocio();
                CN.ObtenerBusquedaClientes(DatosAux);
                this.dgvClientes.AutoGenerateColumns = false;
                this.dgvClientes.DataSource = DatosAux.TablaDatos;
                this.dgvClientes.Focus();
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
                this.ActiveControl = this.txtBusqueda;
                this.txtBusqueda.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Cliente ObtenerDatos(int Fila)
        {
            try
            {
                Cliente Aux = new Cliente();
                if (Fila < this.dgvClientes.Rows.Count)
                {
                    Aux.IDCliente= this.dgvClientes.Rows[Fila].Cells["IDCliente"].Value.ToString();
                    Aux.Nombre = this.dgvClientes.Rows[Fila].Cells["NombreCompleto"].Value.ToString();
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
                frmNuevoCliente NCliente = new frmNuevoCliente();
                NCliente.ShowDialog();
                NCliente.Dispose();
                if (NCliente.DialogResult == DialogResult.OK)
                {
                    this.txtBusqueda.Focus();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmSeleccionarCliente ~ btnAgregar_Click");
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
                LogError.AddExcFileTxt(ex, "frmSeleccionarCliente ~ btnBuscar_Click");
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
                LogError.AddExcFileTxt(ex, "frmSeleccionarCliente ~ btnCerrarForm_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                LogError.AddExcFileTxt(ex, "frmSeleccionarCliente ~ dgvClientes_CellDoubleClick");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvClientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)Keys.Enter)
                {
                    if (this.dgvClientes.SelectedRows.Count == 1)
                    {
                        
                        //int Fila = this.dgvClientes.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                        int Fila = this.dgvClientes.SelectedRows[0].Index;
                        this._Datos = this.ObtenerDatos(Fila);
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmSeleccionarProducto ~ dgvClientes_KeyPress");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSeleccionarCliente_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmSeleccionarCliente ~ frmSeleccionarCliente_Load");
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
                LogError.AddExcFileTxt(ex, "frmSeleccionarCliente ~ txtBusqueda_KeyPress");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void frmSeleccionarCliente_KeyUp(object sender, KeyEventArgs e)
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
                LogError.AddExcFileTxt(ex, "frmSeleccionarCliente ~ frmSeleccionarCliente_KeyUp");
            }
        }

    }
}
