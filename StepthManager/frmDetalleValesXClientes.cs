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
using CreativaSL.Dll.Validaciones;
using System.IO;

namespace StephManager
{
    public partial class frmDetalleValesXClientes : Form
    {

        #region Propiedades / Variables
        private Vales _DatosVales;
        public Vales DatosVales
        {
            get { return _DatosVales; }
            set { _DatosVales = value; }
        }

        #endregion

        public frmDetalleValesXClientes(Vales Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosVales = Datos;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmValesXClientes ~ frmValesXClientes()");
            }
        }

        private void IniciarForm()
        {
            try
            {
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
                this.CargarDatosAModificar(_DatosVales);
                this.CargarLlenarGridClientesXVales();
                this.ActiveControl = this.btnCancelar;
                this.btnCancelar.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDatosAModificar(Vales Datos)
        {
            try
            {
                this.txtNombreVale.Text = this._DatosVales.Nombre;
                this.txtFolioVale.Text = this._DatosVales.Folio;
                this.txtCantidadLimite.Text = this._DatosVales.CantLimite.ToString();
                this.txtTipoVale.Text = this._DatosVales.NombreTipoVale.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarLlenarGridClientesXVales()
        {
            try
            {
                Vales DatosAux = new Vales();
                Vales_Negocio CN = new Vales_Negocio();
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDVale = this._DatosVales.IDVale;
                CN.ObternerValesXClientes(DatosAux);
                this.dgvClientes.DataSource = null;
                this.dgvClientes.AutoGenerateColumns = false;
                this.dgvClientes.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmValesXClientes_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmValesXClientes ~ frmValesXClientes_Load");
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
                LogError.AddExcFileTxt(ex, "frmValesXClientes ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
