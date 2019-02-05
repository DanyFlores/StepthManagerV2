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
    public partial class frmSeleccionarMobiliario : Form
    {
        #region Propiedades / Variables

        private Mobiliario _Datos;
        public Mobiliario Datos
        {
            get { return _Datos; }
            set { _Datos = value; }
        }

        #endregion

        #region Constructor

        public frmSeleccionarMobiliario()
        {
            try
            {
                InitializeComponent();
                this._Datos = new Mobiliario();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmSeleccionarMobiliario ~ frmSeleccionarMobiliario()");
            }
        }

        #endregion

        #region Métodos

        private void BuscarRegistros(string Busqueda)
        {
            try
            {
                Mobiliario DatosAux = new Mobiliario { Conexion = Comun.Conexion, Descripcion = Busqueda, IDProveedor = this._Datos.IDProveedor };
                Mobiliario_Negocio MN = new Mobiliario_Negocio();
                MN.ObtenerBusquedaMobiliario(DatosAux);
                this.dgvMobiliario.AutoGenerateColumns = false;
                this.dgvMobiliario.DataSource = DatosAux.TablaDatos;
                this.dgvMobiliario.Focus();
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

        private Mobiliario ObtenerDatos(int Fila)
        {
            try
            {
                Mobiliario Aux = new Mobiliario();
                if (Fila < this.dgvMobiliario.Rows.Count)
                {
                    Aux.IDMobiliario = this.dgvMobiliario.Rows[Fila].Cells["IDMobiliario"].Value.ToString();
                    Aux.Codigo = this.dgvMobiliario.Rows[Fila].Cells["Codigo"].Value.ToString();
                    Aux.Descripcion = this.dgvMobiliario.Rows[Fila].Cells["Descripcion"].Value.ToString();
                    Aux.Marca = this.dgvMobiliario.Rows[Fila].Cells["Marca"].Value.ToString();
                    Aux.Modelo = this.dgvMobiliario.Rows[Fila].Cells["Modelo"].Value.ToString();
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
                frmNuevoMobiliario NMobiliario = new frmNuevoMobiliario();
                NMobiliario.ShowDialog();
                NMobiliario.Dispose();
                if (NMobiliario.DialogResult == DialogResult.OK)
                {
                    this.txtBusqueda.Focus();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmSeleccionarMobiliario ~ btnAgregar_Click");
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
                LogError.AddExcFileTxt(ex, "frmSeleccionarMobiliario ~ btnBuscar_Click");
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
                LogError.AddExcFileTxt(ex, "frmSeleccionarMobiliario ~ btnCerrarForm_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMobiliario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                LogError.AddExcFileTxt(ex, "frmSeleccionarMobiliario ~ dgvMobiliario_CellDoubleClick");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMobiliario_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)Keys.Enter)
                {
                    if (this.dgvMobiliario.SelectedRows.Count == 1)
                    {
                        int Fila = this.dgvMobiliario.SelectedRows[0].Index;
                        this._Datos = this.ObtenerDatos(Fila);
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmSeleccionarMobiliario ~ dgvMobiliario_KeyPress");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSeleccionarMobiliario_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmSeleccionarMobiliario ~ frmSeleccionarMobiliario_Load");
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
                LogError.AddExcFileTxt(ex, "frmSeleccionarMobiliario ~ txtBusqueda_KeyPress");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void frmSeleccionarMobiliario_KeyUp(object sender, KeyEventArgs e)
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
                LogError.AddExcFileTxt(ex, "frmSeleccionarMobiliario ~ frmSeleccionarMobiliario_KeyUp");
            }
        }

    }
}
