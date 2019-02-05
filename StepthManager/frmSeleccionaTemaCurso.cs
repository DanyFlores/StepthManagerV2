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
    public partial class frmSeleccionaTemaCurso : Form
    {
        #region Propiedades / Variables        
        private List<TemasCurso> _Seleccionado;
        public List<TemasCurso> Seleccionado
        {
            get { return _Seleccionado; }
            set { _Seleccionado = value; }
        }
        private List<TemasCurso> _DatosActuales;
        public List<TemasCurso> DatosActuales
        {
            get { return _DatosActuales; }
            set { _DatosActuales = value; }
        }
        
        #endregion

        #region Constructor

        public frmSeleccionaTemaCurso()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmSeleccionaTemaCurso ~ frmSeleccionaTemaCurso()");

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
                    List<TemasCurso> Resultados = this.DatosActuales.FindAll(x => x.Descripcion.ToUpper().Contains(TextoBusqueda.ToUpper()));
                    this.dgvTemaCurso.DataSource = Resultados;
                }
                else
                {
                    this.dgvTemaCurso.DataSource = this.DatosActuales;
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
                this.dgvTemaCurso.AutoGenerateColumns = false;
                this.dgvTemaCurso.DataSource = this.DatosActuales;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<TemasCurso> ObtenerDatos()
        {
            try
            {
                return this._DatosActuales;
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
                LogError.AddExcFileTxt(ex, "frmSeleccionaTemaCurso ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarBusqueda_Click(object sender, EventArgs e)
        {
            try
            {
                this.dgvTemaCurso.DataSource = DatosActuales;
                this.txtBusqueda.Text = string.Empty;
                this.txtBusqueda.Focus();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmSeleccionaTemaCurso ~ btnCancelarBusqueda_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
 
        private void frmSeleccionaTemaCurso_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmSeleccionaTemaCurso ~ frmSeleccionaTemaCurso_Load");
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
                LogError.AddExcFileTxt(ex, "frmSeleccionaTemaCurso ~ txtBusqueda_KeyUp");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<TemasCurso> Aux = new List<TemasCurso>();
                foreach (TemasCurso Item in this._DatosActuales)
                {
                    if (Item.Seleccionado)
                    {
                        Aux.Add(Item);
                    }
                }
                this._Seleccionado = Aux;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmSeleccionaTemaCurso ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmSeleccionaTemaCurso ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
