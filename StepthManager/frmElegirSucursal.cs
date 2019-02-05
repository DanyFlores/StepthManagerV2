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
using CreativaSL.LibControls.WinForms;
using StephManager.ClasesAux;
using System.IO;

namespace StephManager
{
    public partial class frmElegirSucursal : Form
    {
        #region Propiedades / Variables        
        private Sucursal _Seleccionado;
        public Sucursal Seleccionado
        {
            get { return _Seleccionado; }
            set { _Seleccionado = value; }
        }
        private List<Sucursal> _DatosActuales;
        public List<Sucursal> DatosActuales
        {
            get { return _DatosActuales; }
            set { _DatosActuales = value; }
        }
        
        #endregion

        #region Constructor

        public frmElegirSucursal()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirSucursal ~ frmElegirSucursal()");

            }
        }

        #endregion

        #region Métodos

        private void Busqueda(string TextoBusqueda)
        {
            try
            {
                if (!string.IsNullOrEmpty(TextoBusqueda.Trim()))
                {
                    List<Sucursal> Resultados = this.DatosActuales.FindAll(x => x.NombreSucursal.ToUpper().Contains(TextoBusqueda.ToUpper()));
                    this.dgvSucursal.DataSource = Resultados;
                }
                else
                {
                    this.dgvSucursal.DataSource = this.DatosActuales;
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
                this.LlenarGridSucursales();
                this.txtBusqueda.Text = string.Empty;
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

        private void LlenarGridSucursales()
        {
            try
            {
                this.dgvSucursal.AutoGenerateColumns = false;
                this.dgvSucursal.DataSource = this.DatosActuales;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Sucursal ObtenerDatos(int Index)
        {
            try
            {
                DataGridViewRow Fila = this.dgvSucursal.Rows[Index];
                Sucursal Datos = new Sucursal();
                Datos.IDSucursal = Fila.Cells["IDSucursal"].Value.ToString();
                Datos.NombreSucursal = Fila.Cells["NombreSucursal"].Value.ToString();
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
                this.Busqueda(this.txtBusqueda.Text);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirTarjetaMonedero ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarBusqueda_Click(object sender, EventArgs e)
        {
            try
            {
                this.dgvSucursal.DataSource = DatosActuales;
                this.txtBusqueda.Text = string.Empty;
                this.txtBusqueda.Focus();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirTarjetaMonedero ~ btnCancelarBusqueda_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSucursal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    this._Seleccionado = this.ObtenerDatos(e.RowIndex);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirTarjetaMonedero ~ dgv_Tarjetas_CellDoubleClick");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSucursal_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (this.dgvSucursal.SelectedRows.Count == 1)
                    {
                        Int32 RowSelected = this.dgvSucursal.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                        this._Seleccionado = this.ObtenerDatos(RowSelected);
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirTarjetaMonedero ~ txtBusqueda_KeyUp");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmElegirProveedor_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirTarjetaMonedero ~ frmElegirTarjetaMonedero_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Busqueda(this.txtBusqueda.Text);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirTarjetaMonedero ~ txtBusqueda_KeyUp");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
